using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSPress.Models
{
    public class DashboardModel
    {
        public int ID { get; set; }
        public HighLight Errata { get; set; }
        public HighLight FlaggedItems { get; set; }
        public HighLight Users { get; set; }

    }

    public class HighLight
    {   public string Glyph { get; set; }
        public string Colour { get; set; }
        public string Title{ get; set; }
        public int Count { get; set; }
        public string Details { get; set; }
    }
}