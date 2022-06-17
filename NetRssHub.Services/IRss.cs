using NetRssHub.Entity;
using System.ServiceModel.Syndication;

namespace NetRssHub.Services
{
    public interface IRss
    {
        Task<SyndicationFeed> GetRss();
        List<RouteInfo> GetRouteInfos();
    }
}