using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Raccoon.Objects
{
    public class Result <T> where T: Common
    {
        [JsonProperty("_index", NullValueHandling = NullValueHandling.Ignore)]
        public string Index { get; set; }

        [JsonProperty("_score", NullValueHandling = NullValueHandling.Ignore)]
        public double? Score { get; set; }

        [JsonProperty("_type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("_source", NullValueHandling = NullValueHandling.Ignore)]
        public T Source { get; set; }
    }
}
