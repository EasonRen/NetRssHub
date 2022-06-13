using Microsoft.AspNetCore.Mvc;
using NetRssHub.Entity;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace NetRssHub.Controllers
{
    [ApiController]
    [Route("rss")]
    public class RssController : ControllerBase
    {
        private readonly ILogger<RssController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public RssController(ILogger<RssController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{typeOrName}/{tag1?}/{tag2?}/{tag3?}/{tag4?}")]
        public IActionResult Rss(string typeOrName, string? tag1, string? tag2, string? tag3, string? tag4, [FromQuery] QueryInfo queryInfo)
        {
            SyndicationFeed feed = new SyndicationFeed("博客园_DotNet笔记",
                "兴趣是最好的老师。",
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
            //循环添加……

            feed.Items = items;
            string xml = string.Empty;
            XmlWriterSettings settings = new XmlWriterSettings();

            var sb = new StringBuilder();

            XmlWriter xmlWriter = XmlWriter.Create(sb);
            feed.SaveAsRss20(xmlWriter);
            xmlWriter.Flush();
            xmlWriter.Close();

            xml = sb.ToString();

            return new ContentResult
            {
                Content = xml,
                ContentType = "text/xml",
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        [HttpGet("routes/{routeName}")]
        public List<RouteInfo> RouteInfo(string routeName)
        {
            return new List<RouteInfo>();
        }
    }
}