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
            SyndicationFeed feed = new SyndicationFeed("����԰_DotNet�ʼ�",
                "��Ȥ����õ���ʦ��",
                new Uri("http://cnblogs.com/tuyile006"),
                "FeedID,�磺uuid:0913a2a5-6900-42a0-a3ab-2ba6a1706b03;id=10373",
                DateTime.Now);

            List<SyndicationItem> items = new List<SyndicationItem>();

            SyndicationItem item1 = new SyndicationItem();
            item1.BaseUri = new Uri("https://www.cnblogs.com/tuyile006/p/3710305.html");
            item1.Title = new TextSyndicationContent("���ͱ��⣬�磺����������RSS��Atom");
            item1.Content = SyndicationContent.CreatePlaintextContent("���ģ����Ľ��������.Net��ʵ��Rss��Atom�����ɺͽ�������");
            item1.Summary = SyndicationContent.CreatePlaintextContent("ժҪ�����Ľ��������.Net��ʵ��Rss��Atom�����ɺͽ���");
            item1.PublishDate = DateTime.Now;
            items.Add(item1);

            SyndicationItem item2 = new SyndicationItem();
            item2.BaseUri = new Uri("https://www.cnblogs.com/tuyile006/p/3710305.html");
            item2.Title = new TextSyndicationContent("���ͱ���2���磺.Net�ʼǽ���");
            item2.Content = SyndicationContent.CreatePlaintextContent("���ģ���Ȥ����õ���ʦ����");
            item2.Summary = SyndicationContent.CreatePlaintextContent("ժҪ��Сy�Ĳ���.Net�ʼǽ���");
            item2.PublishDate = DateTime.Now;
            items.Add(item2);
            //ѭ����ӡ���

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