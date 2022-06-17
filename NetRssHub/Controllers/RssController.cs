using Microsoft.AspNetCore.Mvc;
using NetRssHub.Entity;
using NetRssHub.Services;
using System.Net;
using System.Net.Http;
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
        private readonly IRssFactory _rssFactory;

        public RssController(ILogger<RssController> logger, IHttpClientFactory httpClientFactory, IRssFactory rssFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _rssFactory = rssFactory;
        }

        [HttpGet("{typeOrName}/{tag1?}/{tag2?}/{tag3?}/{tag4?}")]
        public async Task<IActionResult> Rss(string typeOrName, string? tag1, string? tag2, string? tag3, string? tag4, [FromQuery] QueryInfo queryInfo)
        {
            ParamInfo paramInfo = new ParamInfo { QueryInfo = queryInfo, TypeOrName = typeOrName, Tag1 = tag1, Tag2 = tag2, Tag3 = tag3, Tag4 = tag4 };
            var rssService = _rssFactory.CreateRssService(paramInfo, _httpClientFactory.CreateClient());

            if (rssService != null)
            {
                var feed = await rssService.GetRss();

                var sb = new StringBuilder();
                XmlWriter xmlWriter = XmlWriter.Create(sb);
                feed.SaveAsRss20(xmlWriter);
                xmlWriter.Flush();
                xmlWriter.Close();

                return new ContentResult
                {
                    Content = sb.ToString(),
                    ContentType = "text/xml",
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("routes/{routeName}")]
        public List<RouteInfo> RouteInfo(string routeName)
        {
            return new List<RouteInfo>();
        }
    }
}