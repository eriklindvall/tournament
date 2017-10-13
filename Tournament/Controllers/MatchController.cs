using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using Tournament.Models;
using Tournament.Models.ViewModels;

namespace Tournament.Controllers
{
    public class MatchController : ApiController
    {
        private TournamentDbContext _dbContext = new TournamentDbContext();
        
        public IEnumerable<Match> Get()
        {
            return _dbContext
                .Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam);
        }

        public Match Get(int id)
        {
            return _dbContext
                .Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .SingleOrDefault(m => m.Id == id);
        }

        public Match Post([FromBody]Match match)
        {
            _dbContext.Matches.Add(match);
            _dbContext.SaveChanges();
            return match;
        }

        [HttpPut]
        [Route("api/match/result/{id}")]
        public Match Result(int id, [FromBody]MatchResult matchResult)
        {
            var match = _dbContext.Matches.Find(id);
            match.HomeScore = matchResult.HomeScore;
            match.AwayScore = matchResult.AwayScore;
            if (matchResult.HomeOvertimeScore != null && matchResult.AwayOvertimeScore != null)
            {
                match.HomeOvertimeScore = matchResult.HomeOvertimeScore;
                match.AwayOvertimeScore = matchResult.AwayOvertimeScore;
            }
            if (matchResult.HomePenaltyScore != null && matchResult.AwayPenaltyScore != null)
            {
                match.HomePenaltyScore = matchResult.HomePenaltyScore;
                match.AwayPenaltyScore = matchResult.AwayPenaltyScore;
            }
            match.IsPlayed = true;
            _dbContext.SaveChanges();
            return match;
        }
    }
}