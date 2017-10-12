using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

    public class Match
    {
        public int Id { get; set; }
        public int? HomeTeamId { get; set; }
        public int? AwayTeamId { get; set; }
        [ForeignKey("HomeTeamId")]
        public Team HomeTeam { get; set; }
        [ForeignKey("AwayTeamId")]
        public Team AwayTeam { get; set; }
        public DateTime KickoffTime { get; set; }
        public int? GroupId { get; set; }
        [JsonIgnore]
        public Group Group { get; set; }
        public int Round { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int HomeOvertimeScore { get; set; }
        public int AwayOvertimeScore { get; set; }
        public int HomePenaltyScore { get; set; }
        public int AwayPenaltyScore { get; set; }
        public MatchState MatchState { get; set; }
    }
}