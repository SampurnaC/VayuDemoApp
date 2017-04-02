using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Film
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Time { get; set; }
        public int Cast { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Origin { get; set; }
        public string Time_code { get; set; }
        public int Good { get; set; }
    }
}