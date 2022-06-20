using NetRssHub.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace NetRssHub.Services
{
    public class OsChina : RssBase, IRss
    {
        public OsChina(ParamInfo paramInfo, HttpClient httpClient)
            : base(paramInfo, httpClient)
        {
        }

        public List<RouteInfo> GetRouteInfos()
        {
            throw new NotImplementedException();
        }

        public async Task<SyndicationFeed> GetRss()
        {
            throw new NotImplementedException();
        }
    }
}
