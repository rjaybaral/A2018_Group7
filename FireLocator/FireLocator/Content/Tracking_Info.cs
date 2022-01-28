using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireLocator.Models
{
    public class Tracking_Info
    {
        public string Item { get; set; }
        public string Latitude { get; set; }
        public string Longhitude { get; set; }
        public Tracking_Info()
        {
            Item = "1";
        }
    }
}