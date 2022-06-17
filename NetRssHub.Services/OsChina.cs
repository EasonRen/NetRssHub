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
            string? type = ParamInfo.TypeOrName;
            throw new NotImplementedException();
        }

        public async Task<SyndicationFeed> GetRss()
        {
            SyndicationFeed feed = new SyndicationFeed("开源中国",
               "综合资讯。",
               new Uri("http://cnblogs.com/tuyile006"),
               "FeedID,如：uuid:0913a2a5-6900-42a0-a3ab-2ba6a1706b03;id=10373",
               DateTime.Now);

            List<SyndicationItem> items = new List<SyndicationItem>();

            SyndicationItem item1 = new SyndicationItem();
            item1.BaseUri = new Uri("https://www.cnblogs.com/tuyile006/p/3710305.html");
            item1.Title = new TextSyndicationContent("博客标题，如：解析和生成RSS或Atom");
            item1.Content = SyndicationContent.CreatePlaintextContent("正文：本文讲述如何在.Net中实现Rss和Atom的生成和解析……");
            item1.Summary = SyndicationContent.CreatePlaintextContent("摘要：本文讲述如何在.Net中实现Rss和Atom的生成和解析");
            item1.PublishDate = DateTime.Now;
            items.Add(item1);

            SyndicationItem item2 = new SyndicationItem();
            item2.BaseUri = new Uri("https://www.cnblogs.com/tuyile006/p/3710305.html");
            item2.Title = new TextSyndicationContent("博客标题2，如：.Net笔记介绍");
            item2.Content = SyndicationContent.CreatePlaintextContent("正文：兴趣是最好的老师……");
            item2.Summary = SyndicationContent.CreatePlaintextContent("摘要：小y的博客.Net笔记介绍");
            item2.PublishDate = DateTime.Now;
            items.Add(item2);

            feed.Items = items;

            return feed;
        }
    }
}
