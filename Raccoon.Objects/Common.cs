using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Raccoon.Objects
{
    [DebuggerDisplay("_id::{Id}")]
    public abstract class Common
    {
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("_rev", NullValueHandling = NullValueHandling.Ignore)]
        public string Revision { get; set; }

        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }

        [JsonProperty("updated_by", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastUpdated { get; set; }

        [JsonProperty("based_on", NullValueHandling = NullValueHandling.Ignore)]
        public HashSet<BasedOn> BasedOn { get; set; }

        [JsonProperty("user_reviews", NullValueHandling = NullValueHandling.Ignore)]
        public HashSet<UserReview> UserReviews { get; set; }

        [JsonIgnore]
        public virtual string MediaTypeName {
            get
            {
                return string.Empty;
            }
        }
    }
}
