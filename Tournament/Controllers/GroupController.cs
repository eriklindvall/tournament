using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tournament.Models;
using System.Data.Entity;
using Tournament.Models.ViewModels;
using Tournament.Business.Result;

namespace Tournament.Controllers
{
    public class GroupController : ApiController
    {
        private TournamentDbContext _dbContext = new TournamentDbContext();
        
        public IEnumerable<Group> Get()
        {
            return _dbContext
                .Groups
                .Include(group => group.Matches)
                .Include(group => group.Teams);
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

        [HttpGet]
        [Route("api/group/result")]
        public IEnumerable<GroupResult> GetGroupTables()
        {
            var groups = _dbContext.Groups.Include(group => group.Matches).Include(group => group.Teams).ToList();
            var factory = new GroupResultFactory();
            return groups.Select(group => factory.GetResult(group.Name, group.Teams.ToList(), group.Matches.ToList()));
        }
    }
}