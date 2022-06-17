using NetRssHub.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetRssHub.Services
{
    public class RssFactory : IRssFactory
    {
        public IRss CreateRssService(ParamInfo paramInfo, HttpClient httpClient)
        {
            Assembly currentAssembly = Assembly.GetAssembly(GetType());
            var types = currentAssembly.GetTypes().Where(a => !a.IsInterface && a.IsClass && a.GetInterfaces().Contains(typeof(IRss)));
            var currentType = types.Where(a => a.Name.ToLower() == paramInfo?.TypeOrName?.ToLower()).FirstOrDefault();

            if (currentType != null)
            {
                return Activator.CreateInstance(currentType, paramInfo, httpClient) as IRss;
            }
            else
            {
                return null;
            }
        }
    }
}
