using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Raccoon.Objects
{
    public class Videogames : Common
    {
        [JsonProperty("alternative_names", NullValueHandling = NullValueHandling.Ignore)]
        public HashSet<string> AlternativeTitles { get; set; }

        [JsonProperty("characters", NullValueHandling = NullValueHandling.Ignore)]
        public HashSet<string> Characters { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public HashSet<string> Genres { get; set; }

        [JsonProperty("coop", NullValueHandling = NullValueHandling.Ignore)]
        public string Coop { get; set; }

        [JsonProperty("developer", NullValueHandling = NullValueHandling.Ignore)]   
        //Was saved as a single string but I plan to change it to string[] (right now it's comma separated)
#if WRONG_DEVELOPER_FORMAT
        public string Developer { get; set; }
#else
        public HashSet<string> Developer { get; set; }
#endif

        [JsonProperty("esrb", NullValueHandling = NullValueHandling.Ignore)]
        public string ESRB { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("plot", NullValueHandling = NullValueHandling.Ignore)]
        public string Plot { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public HashSet<Image> Images { get; set; }

        [JsonProperty("platform_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? PlatformId { get; set; }

        [JsonProperty("publishers", NullValueHandling = NullValueHandling.Ignore)]
#if WRONG_DEVELOPER_FORMAT
        public string Publishers { get; set; }
#else
        public HashSet<string> Publishers { get; set; }
#endif

        [JsonProperty("rating_vote", NullValueHandling = NullValueHandling.Ignore)]
        public double? RatingVote { get; set; }

        [JsonProperty("trailers", NullValueHandling = NullValueHandling.Ignore)]
#if WRONG_DEVELOPER_FORMAT
        public string Trailers { get; set; }
#else
        public HashSet<string> Trailers { get; set; }
#endif

        [JsonProperty("publishers_nested", NullValueHandling = NullValueHandling.Ignore)]
        public HashSet<PublishersNested> PublishersNested { get; set; }

        [JsonProperty("cast_nested", NullValueHandling = NullValueHandling.Ignore)]
        public HashSet<CastNested> CastNested { get; set; }

        [JsonProperty("cast", NullValueHandling = NullValueHandling.Ignore)]
        public HashSet<string> Cast { get; set; }

        [JsonProperty("released", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Released { get; set; }

        [JsonIgnore]
        public override string MediaTypeName
        {
            get
            {
                return "videogames";
            }
        }
    }
}
