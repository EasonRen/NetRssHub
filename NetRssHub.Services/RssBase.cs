using NetRssHub.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRssHub.Services
{
    public class RssBase
    {
        public ParamInfo ParamInfo { get; private set; }
        public HttpClient HttpClient { get; private set; }
        public RssBase(ParamInfo paramInfo, HttpClient httpClient)
        {
            ParamInfo = paramInfo;
            HttpClient = httpClient;
        }
    }
}
