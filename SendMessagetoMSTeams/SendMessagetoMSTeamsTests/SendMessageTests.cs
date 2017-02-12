using Microsoft.VisualStudio.TestTools.UnitTesting;
using SendMessagetoMSTeams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMessagetoMSTeams.Tests
{
    [TestClass()]
    public class SendMessageTests
    {
        private string MSTeamsChannel = "Channel URL";

        [TestMethod()]
        public void InfoTest()
        {
            SendMessage MsTeamsmessage = new SendMessage(MSTeamsChannel, "Demo");
            MsTeamsmessage.Info("VS Everywhere Demo", "Info", "台中");
        }
    }
}