using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournament.Models;
using Tournament.Models.ViewModels;

namespace Tournament.Business.Result
{
    public class TablerowComparison
    {
        private List<Match> _matches;
        public TablerowComparison(List<Match> matches)
        {
            _matches = matches;
        }

        public int CompareTableRows(TableRow row1, TableRow row2)
        {
            //points
            if (row1.Points != row2.Points)
            {
                return row2.Points - row1.Points;
            }

            //goal difference
            var row1Diff = row1.GoalsScored - row1.GoalsConceded;
            var row2Diff = row2.GoalsScored - row2.GoalsConceded;
            if (row1Diff != row2Diff)
            {
                return row2Diff - row1Diff;
            }

            //scored goals
            if (row1.GoalsScored != row2.GoalsScored)
            {
                return row2.GoalsScored - row1.GoalsScored;
            }

            //meeting
            var match = _matches.SingleOrDefault(m => m.IsPlayed && 
                                             (m.HomeTeamId == row1.Team.Id || m.AwayTeamId == row1.Team.Id) &&
                                             (m.HomeTeamId == row2.Team.Id || m.AwayTeamId == row2.Team.Id));
            if (match == null)
            {
                return 0;
            }
            return match.HomeTeamId == row1.Team.Id ? match.AwayScore - match.HomeScore : match.HomeScore - match.AwayScore;
        }
    }
}