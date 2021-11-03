using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareHomework
{
    public class ExtraHeaderAttribute: Attribute
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
