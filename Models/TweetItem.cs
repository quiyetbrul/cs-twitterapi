using System;
using System.ComponentModel.DataAnnotations;

namespace twitterapi.Models
{
    [MetadataType(typeof(TweetItem))]
    public class TweetItem
    {
        public long id { get; set; }
        public string userPostDate { get; set; }
        public string userName { get; set; }

        [StringLength(240, MinimumLength = 1, ErrorMessage = "Cannot be empty or exceed 240 characters.")]
        public string userMessage { get; set; }

        public bool userPosted { get; set; }
    }
}