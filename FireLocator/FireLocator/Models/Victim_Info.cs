using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FireLocator.Models
{
    public class Victim_Info
    {
        public String ID_victim { get; set; }
        public String Item { get; set; }
        public String Fullname { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Latitude { get; set; }
        public String Longhitude { get; set; }
        public String Status { get; set; }
        public String Reason { get; set; }

        public Victim_Info()
        {

        }
    }
}