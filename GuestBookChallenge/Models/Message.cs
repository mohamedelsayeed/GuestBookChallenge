using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBookChallenge.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(250)]
        public string Title { get; set; }
        
        [Required, MaxLength(2500)]
        public string Body { get; set; }
        public string? Pic { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Reply>? Replies { get; set; }

    }
}
