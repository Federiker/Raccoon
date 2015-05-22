using System;
using Newtonsoft.Json;

namespace Raccoon.Objects
{
    public struct UserReview
    {
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }

        [JsonProperty("review_text", NullValueHandling = NullValueHandling.Ignore)]
        public string ReviewText { get; set; }

        [JsonProperty("review_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ReviewTime { get; set; }

        [JsonProperty("user_vote", NullValueHandling = NullValueHandling.Ignore)]
        public short? UserVote {
            get
            {
                return this._UserVote;
            }
            set
            {
                if (value.HasValue && value.Value > 0 && value.Value < 11)
                {
                    this._UserVote = value;
                }
                else if (value == null)
                {
                    this._UserVote = null;
                }
            }
        }

        [JsonIgnore]    //Just in case
        private short? _UserVote;
    }
}
