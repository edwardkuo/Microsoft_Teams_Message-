using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessagetoMSTeams
{
    public class MsTeamsMessageModel
    {

        public string title { get; set; }
        public string text { get; set; }
        public Section[] sections { get; set; }
    }
    public class Section
    {
        public string activityTitle { get; set; }
        public string activitySubtitle { get; set; }
        public string title { get; set; }
        public Fact[] facts { get; set; }
    }
    public class Fact
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
