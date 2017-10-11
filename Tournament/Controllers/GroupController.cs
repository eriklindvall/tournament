using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tournament.Models;

namespace Tournament.Controllers
{
    public class GroupController : ApiController
    {
        private TournamentDbContext _dbContext = new TournamentDbContext();
        
        public IEnumerable<Group> Get()
        {
            return _dbContext.Groups;
        }

        public Group Get(int id)
        {
            return _dbContext.Groups.Find(id);
        }

        public Group Post([FromBody]Group group)
        {
            _dbContext.Groups.Add(group);
            _dbContext.SaveChanges();
            return group;
        }
    }
}