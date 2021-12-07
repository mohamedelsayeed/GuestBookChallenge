using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBook.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string Title { get; set; }
        
        [Required, MaxLength(2500)]
        public string Body { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
