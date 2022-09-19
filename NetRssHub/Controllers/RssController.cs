using Microsoft.AspNetCore.Mvc;
using NetRssHub.Common.Entity;
using NetRssHub.Services;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.Unicode;
using System.Xml;

namespace NetRssHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

                using MemoryStream stream = new MemoryStream();
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.Encoding = new UTF8Encoding(false);

                XmlWriter xmlWriter = XmlWriter.Create(stream, settings);
                feed.SaveAsRss20(xmlWriter);
                xmlWriter.Flush();
                xmlWriter.Close();

                string xml = Encoding.UTF8.GetString(stream.ToArray());
                return new ContentResult
                {
                    Content = xml,
                    ContentType = "application/xml; charset=utf-8",
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("routes/{routeName}")]
        public IActionResult RouteInfo(string routeName)
        {
            var rssService = _rssFactory.CreateRssService(new ParamInfo { TypeOrName = routeName }, null);

            if (rssService != null)
            {
                return Ok(rssService.GetRouteInfos());
            }
            else
            {
                return NotFound();
            }
        }
    }
}