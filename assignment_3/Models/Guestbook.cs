using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment_3.Models
{
    public class Guestbook
    {
        [Required]
        public int Id { get; set; }
        
        [Required, DisplayName("Post_Name")]
        public string Post_Name { get; set; }
        
        [Required, DisplayName("Post_Title")]
        public string Post_Title { get; set; }
        
        [Required, DisplayName("Post_Message")]
        public string Post_Message { get; set; }
    }
}