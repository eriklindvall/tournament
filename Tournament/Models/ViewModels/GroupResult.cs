using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tournament.Models.ViewModels
{
    public class GroupResult
    {
        public string GroupName { get; set; }
        public List<TableRow> Table { get; set; }
        public List<Match> Matches { get; set; }
    }
}