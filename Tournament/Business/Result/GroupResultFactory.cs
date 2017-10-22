using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournament.Models;
using Tournament.Models.ViewModels;

namespace Tournament.Business.Result
{
    public class GroupResultFactory
    {
        public GroupResult GetResult(string groupName, List<Team> teams, List<Match> matches)
        {
            var result = new GroupResult() { GroupName = groupName, Table = new List<TableRow>(), Matches = matches };
            result.Table.AddRange(teams.Select(team => CreateTableRow(team, matches.Where(match => match.IsPlayed).ToList())));
            result.Table.Sort(new TablerowComparison(matches).CompareTableRows);
            return result;
        }

        private TableRow CreateTableRow(Team team, List<Match> matches)
        {
            var wins = matches.Sum(match => (match.HomeTeamId == team.Id && match.HomeScore > match.AwayScore) ||
                                            (match.AwayTeamId == team.Id && match.AwayScore > match.HomeScore)
                                            ? 1 : 0);
            var draws = matches.Sum(match => (match.HomeTeamId == team.Id || match.AwayTeamId == team.Id) &&
                                            match.HomeScore == match.AwayScore
                                            ? 1 : 0);
            var losses = matches.Sum(match => (match.HomeTeamId == team.Id && match.HomeScore < match.AwayScore) ||
                                            (match.AwayTeamId == team.Id && match.AwayScore < match.HomeScore)
                                            ? 1 : 0);

            return new TableRow()
            {
                Team = team,
                Played = wins + draws + losses,
                Wins = wins,
                Draws = draws,
                Losses = losses,
                GoalsScored = matches.Sum(match => match.HomeTeamId == team.Id
                                            ? match.HomeScore
                                            : match.AwayTeamId == team.Id
                                                ? match.AwayScore
                                                : 0),
                GoalsConceded = matches.Sum(match => match.HomeTeamId == team.Id
                                            ? match.AwayScore
                                            : match.AwayTeamId == team.Id
                                                ? match.HomeScore
                                                : 0),
                Points = 3 * wins + draws
            };
        }
    }
}