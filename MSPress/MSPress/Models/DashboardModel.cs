using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSPress.Models
{
    public class DashboardModel
    {
        public int ID { get; set; }
        public int ErrataCount { get; set; }
        public HighLight Errata { get; set; }
    }

    public class HighLight
    {
        public string Colour { get; set; }
        public string Title{ get; set; }
        public int Count { get; set; }
    }
}