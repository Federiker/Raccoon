using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raccoon.Objects
{
    public struct BasedOn
    {
        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public string Media { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}
