﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using Tournament.Models;

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
    }
}