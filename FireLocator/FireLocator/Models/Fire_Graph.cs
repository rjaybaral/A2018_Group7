using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FireLocator.Models
{
    public class Fire_Graph
    {

        [XmlElement("0")]
        public string Heat_Level { get; set; }
        [XmlElement("1")]
        public string Date_Time { get; set; }
    }
}