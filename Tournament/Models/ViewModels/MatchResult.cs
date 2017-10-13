using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tournament.Models.ViewModels
{
    public class MatchResult
    {
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int? HomeOvertimeScore { get; set; }
        public int? AwayOvertimeScore { get; set; }
        public int? HomePenaltyScore { get; set; }
        public int? AwayPenaltyScore { get; set; }
    }
}