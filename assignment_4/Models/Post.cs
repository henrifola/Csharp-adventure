using System;
using System.ComponentModel.DataAnnotations;

namespace assignment_4.Models
{
    public class Post
    {
        public Post() {}

        public Post(string title, string summary, string content, Account account, DateTime timestamp)
        {
            Title = title;
            Summary = summary;
            Content = content;
            Account = account;
            Time = timestamp;
        }

        public int PostId { get; set; }
        
        [Required, Display(Name="Title")]
        public string Title { get; set; }

        [Required, Display(Name="Summary")]
        public string Summary { get; set; }

        [Required, Display(Name = "Content")]
        public string Content { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public string AccountId { get; set; }
        public Account Account { get; set; }
    }
}