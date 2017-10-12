using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tournament.Models;

namespace Tournament.Controllers
{
    public class TeamController : ApiController
    {
        private TournamentDbContext _dbContext = new TournamentDbContext();
        
        public IEnumerable<Team> Get()
        {
            return _dbContext.Teams;
        }

        public Team Get(int id)
        {
            return _dbContext.Teams.Find(id);
        }

        public Team Post([FromBody]Team team)
        {
            _dbContext.Teams.Add(team);
            _dbContext.SaveChanges();
            return team;
        }
    }
}