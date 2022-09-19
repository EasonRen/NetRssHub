using NetRssHub.Common.Entity;
using NetRssHub.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRssHub.Services
{
    public interface IRssFactory
    {
        IRss CreateRssService(ParamInfo paramInfo, HttpClient httpClient);
    }
}
