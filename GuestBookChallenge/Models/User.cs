using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBook.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required, MinLength(6)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Profile Pic")]
        public string? ProfilePic { get; set; }
    }
}
