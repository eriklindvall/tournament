using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tournament.Models.ViewModels
{
    public class TableRow
    {
        public Team Team { get; set; }
        public int Played { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int Points { get; set; }
    }
}