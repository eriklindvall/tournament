using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournament.Models;
using Tournament.Models.ViewModels;

namespace Tournament.Business.Result
{
    public class GroupTableFactory
    {
        public GroupTable GetTable(List<Team> teams, List<Match> matches)
        {
            var table = new GroupTable() { TableRows = new List<TableRow>() };
            table.TableRows.AddRange(teams.Select(team => CreateTableRow(team, matches)));
            table.TableRows.Sort(new TablerowComparison(matches).CompareTableRows);
            return table;
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