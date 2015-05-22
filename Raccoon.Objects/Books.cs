using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Raccoon.Objects
{
    public class Books : Common
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonIgnore]
        public override string MediaTypeName
        {
            get
            {
                return "books";
            }
        }
    }
}
