using NetRssHub.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetRssHub.Common
{
    public class RssBase
    {
        public ParamInfo ParamInfo { get; private set; }
        public HttpClient RssClient { get; private set; }
        public RssBase(ParamInfo paramInfo, HttpClient httpClient)
        {
            ParamInfo = paramInfo;
            RssClient = httpClient;
        }
    }
}
