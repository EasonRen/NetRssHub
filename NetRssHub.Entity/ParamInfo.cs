using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetRssHub.Entity
{
    public class ParamInfo
    {
        public string? TypeOrName { get; set; }
        public string? Tag1 { get; set; }
        public string? Tag2 { get; set; }
        public string? Tag3 { get; set; }
        public string? Tag4 { get; set; }
        public QueryInfo? QueryInfo { get; set; }
    }
}
