using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Tournament.Models;

namespace Tournament.Demo
{
    public class DemoInitializer : DropCreateDatabaseAlways<TournamentDbContext>
    {
        protected override void Seed(TournamentDbContext context)
        {
            base.Seed(context);
            context.Groups.AddRange(_groups);
            context.Teams.AddRange(_teams);
            context.Matches.AddRange(_matches);
        }

        private IEnumerable<Group> _groups = new Group[]
        {
            new Group(){ Id = 1, Name = "Group A" }
        };

        private IEnumerable<Team> _teams = new Team[]
        {
            new Team() { Id = 1, Name = "Sweden", Abbreviation = "SWE", GroupId = 1 },
            new Team() { Id = 2, Name = "Denmark", Abbreviation = "DEN", GroupId = 1 },
            new Team() { Id = 3, Name = "Norway", Abbreviation = "NOR", GroupId = 1 },
            new Team() { Id = 4, Name = "Finland", Abbreviation = "FIN", GroupId = 1 }
        };

        private IEnumerable<Match> _matches = new Match[]
        {
            new Match() { Id = 1, HomeTeamId = 1, AwayTeamId = 2, KickoffTime = DateTime.Now, GroupId = 1 },
            new Match() { Id = 2, HomeTeamId = 3, AwayTeamId = 4, KickoffTime = DateTime.Now, GroupId = 1 },
            new Match() { Id = 3, HomeTeamId = 1, AwayTeamId = 3, KickoffTime = DateTime.Now.AddDays(1), GroupId = 1 },
            new Match() { Id = 4, HomeTeamId = 2, AwayTeamId = 4, KickoffTime = DateTime.Now.AddDays(1), GroupId = 1 },
            new Match() { Id = 5, HomeTeamId = 4, AwayTeamId = 1, KickoffTime = DateTime.Now.AddDays(2), GroupId = 1 },
            new Match() { Id = 6, HomeTeamId = 3, AwayTeamId = 2, KickoffTime = DateTime.Now.AddDays(2), GroupId = 1 }
        };
    }
}