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
        public string? TypeOrName { get; private set; }
        public string? Tag1 { get; private set; }
        public string? Tag2 { get; private set; }
        public string? Tag3 { get; private set; }
        public string? Tag4 { get; private set; }
        public QueryInfo QueryInfo { get; private set; }

        public RssBase(string? typeOrName, string? tag1, string? tag2, string? tag3, string? tag4, QueryInfo queryInfo)
        {
            TypeOrName = typeOrName;
            Tag1 = tag1;
            Tag2 = tag2;
            Tag3 = tag3;
            Tag4 = tag4;
            QueryInfo = queryInfo;
        }
    }
}
