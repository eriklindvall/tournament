using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tournament.Models
{
    public enum MatchState
    {
        NotPlayed,
        Regulation,
        Overtime,
        Penalties
    }
    public class MatchResult
    {
        [Key]
        [ForeignKey("Match")]
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int HomeOvertimeScore { get; set; }
        public int AwayOvertimeScore { get; set; }
        public int HomePenaltyScore { get; set; }
        public int AwayPenaltyScore { get; set; }
        public MatchState MatchState { get; set; }
    }
}