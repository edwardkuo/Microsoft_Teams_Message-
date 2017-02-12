using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SendMessagetoMSTeams
{
  public  class SendMessage
    {
        private readonly string _connectorsUrl;
        private readonly string _systemName;
        private MsTeamsMessageModel _message;

        public void Info(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFile = "", [CallerLineNumber] int sourceLine = 0)
        {
            SendtoMSTeams(Messageformat("Info", null, message, memberName, sourceFile, sourceLine));
        }

        private MsTeamsMessageModel Messageformat(string type, Exception exception, string message, string memberName = "", string sourceFile = "", int sourceLine = 0)
        {
            var section = new List<Section>();
            var facts = new List<Fact>();
            _message = new MsTeamsMessageModel
            {
                title = $"[DEMO]-{type}",
                text = _systemName
            };
            facts.Add(new Fact() { name = "message", value = message });
            facts.Add(new Fact() { name = "memberName", value = memberName });
            facts.Add(new Fact() { name = "sourceFile", value = sourceFile });
            facts.Add(new Fact() { name = "SourceLine", value = sourceLine.ToString() });
            if (exception != null)
            {
                facts.Add(new Fact() { name = "Exception", value = exception.Message });
            }
            section.Add(new Section() { activityTitle = DateTime.Now.ToLongDateString(), activitySubtitle = DateTime.Now.ToLongTimeString(), title = "---------", facts = facts.ToArray() });
            _message.sections = section.ToArray();
            return _message;
        }

        public bool SendtoMSTeams(dynamic message)
        {
            var client = new RestClient(_connectorsUrl);
            var request = new RestSharp.RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            if (message != null)
            {
                request.AddJsonBody(message);
            }
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SendMessage(string connectorUrl, string systemName)
        {
            // this._logger = logger;
            this._connectorsUrl = connectorUrl;
            this._systemName = systemName;
        }
    }
}
