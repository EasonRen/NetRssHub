﻿using NetRssHub.Common.Entity;
using NetRssHub.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace NetRssHub.Services
{
    public class RssFactory : IRssFactory
    {
        public IRss CreateRssService(ParamInfo paramInfo, HttpClient httpClient)
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;
            var allPluginsAssembly = Directory.GetFiles(Path.Combine(rootPath, "Plugins"), "NetRssHub.Plugins.*.dll").Select(Assembly.LoadFrom).ToList();

            //Assembly currentAssembly = Assembly.GetAssembly(GetType());
            //var types = currentAssembly.GetTypes().Where(a => !a.IsInterface && a.IsClass && a.GetInterfaces().Contains(typeof(IRss)));

            List<Type> types = new List<Type>();

            allPluginsAssembly?.ForEach(a =>
            {
                types.AddRange(a.GetTypes().Where(a => !a.IsInterface && a.IsClass && a.GetInterfaces().Contains(typeof(IRss))));
            });
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
