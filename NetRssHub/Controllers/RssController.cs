using Microsoft.AspNetCore.Mvc;
using NetRssHub.Entity;

namespace NetRssHub.Controllers
{
    [ApiController]
    [Route("api")]
    public class RssController : ControllerBase
    {
        private readonly ILogger<RssController> _logger;

        public RssController(ILogger<RssController> logger)
        {
            _logger = logger;
        }

        [HttpGet("~/{typeOrName}/{tag1?}/{tag2?}/{tag3?}/{tag4?}")]
        public string Rss(string typeOrName, string? tag1, string? tag2, string? tag3, string? tag4)
        {
            return typeOrName;
        }

        [HttpGet("routes/{routeName}")]
        public List<RouteInfo> RouteInfo(string routeName)
        {
            return new List<RouteInfo>();
        }
    }
}