using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireLocator.Models
{
    public class Main_Info
    {
        public List<User_Info> userInfo { get; set; }
        public int total_user { get; set; }
        public int total_fire_victim { get; set; }
        public int heavy { get; set; }
        public int light { get; set; }
        public int paranaque { get; set; }
        public int taguig { get; set; }
        public int makati { get; set; }
        public int muntinlupa { get; set; }
        public int pasay { get; set; }

        public Main_Info()
        {
            total_user = 0;
            total_fire_victim = 0;
            heavy = 0;
            light = 0;
            paranaque = 0;
            taguig = 0;
            makati = 0;
            muntinlupa = 0;
            pasay = 0;
        }

    }
}