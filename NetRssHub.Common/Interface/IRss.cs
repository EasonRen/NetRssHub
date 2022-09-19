using NetRssHub.Common.Entity;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;

namespace NetRssHub.Common.Interface
{
    public interface IRss
    {
        Task<SyndicationFeed> GetRss();
        List<RouteInfo> GetRouteInfos();
    }
}
