using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBookChallenge.Models
{
    public class Reply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(2500)]
        public string Body { get; set; }
        public string? Pic { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        [ForeignKey("Message")]
        public int? MessageId { get; set; }
        public virtual User? User { get; set; }
        public virtual Message? Message { get; set; }
    }
}
