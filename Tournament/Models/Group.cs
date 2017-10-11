using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tournament.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}