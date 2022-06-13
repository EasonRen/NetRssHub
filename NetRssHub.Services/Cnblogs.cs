using NetRssHub.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace NetRssHub.Services
{
    public class Cnblogs : RssBase, IRss
    {
        public Cnblogs(string? typeOrName, string? tag1, string? tag2, string? tag3, string? tag4, QueryInfo queryInfo)
            : base(typeOrName, tag1, tag2, tag3, tag4, queryInfo)
        {
        }

        public List<RouteInfo> GetRouteInfos()
        {
            string? type = TypeOrName;
            throw new NotImplementedException();
        }

        public SyndicationFeed GetRss()
        {
            throw new NotImplementedException();
        }
    }
}
