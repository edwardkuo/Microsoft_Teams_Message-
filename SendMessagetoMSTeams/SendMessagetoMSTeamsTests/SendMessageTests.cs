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
        private string MSTeamsChannel = "https://outlook.office.com/webhook/2cd44f77-d9f6-4de1-8baf-6c761390d8fa@ae4d8d00-0b04-4be4-80e7-9a22cbf55fe7/IncomingWebhook/4c0729ef74fd42829d03e21fa1302ee3/ddf6cd19-24e2-4f4e-b073-d18ee0f82602";

        [TestMethod()]
        public void InfoTest()
        {
            SendMessage MsTeamsmessage = new SendMessage(MSTeamsChannel, "Demo");
            MsTeamsmessage.Info("VS Everywhere Demo", "Info", "Good");
        }
    }
}