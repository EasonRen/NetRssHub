using HtmlAgilityPack;
using Microsoft.Net.Http.Headers;
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
        public Cnblogs(ParamInfo paramInfo, HttpClient httpClient)
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
            SyndicationFeed feed = new SyndicationFeed("博客园", "代码改变世界", new Uri("https://www.cnblogs.com/"), "https://www.cnblogs.com/", DateTime.Now);
            List<SyndicationItem> items = new List<SyndicationItem>();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://www.cnblogs.com/")
            {
                Headers =
                {
                    { HeaderNames.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9" },
                    { HeaderNames.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.124 Safari/537.36 Edg/102.0.1245.41" }
                }
            };

            var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentString = await httpResponseMessage.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(contentString))
                {
                    SyndicationItem syndicationItem;
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(contentString);
                    var articleNodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='post_list']/article");

                    foreach (var article in articleNodes)
                    {
                        syndicationItem = new SyndicationItem();
                        var title = article.SelectSingleNode("./section/div/a");
                        var content = article.SelectSingleNode("./section/div/p");
                        var dateTime = article.SelectSingleNode("./section/footer/span[1]/span");

                        syndicationItem.BaseUri = new Uri(title?.Attributes["href"]?.Value ?? string.Empty);
                        syndicationItem.Title = new TextSyndicationContent(title?.InnerText ?? string.Empty);
                        syndicationItem.Content = SyndicationContent.CreatePlaintextContent(content?.InnerText?? string.Empty);
                        syndicationItem.Summary = SyndicationContent.CreatePlaintextContent(content?.InnerText ?? string.Empty);
                        syndicationItem.PublishDate = DateTime.Parse(dateTime.InnerText);

                        items.Add(syndicationItem);
                    }
                }
            }

            feed.Items = items;
            return feed;
        }
    }
}
