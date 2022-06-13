using NetRssHub.Entity;
using System.ServiceModel.Syndication;

namespace NetRssHub.Services
{
    public interface IRss
    {
        SyndicationFeed GetRss();
        List<RouteInfo> GetRouteInfos();
    }
}