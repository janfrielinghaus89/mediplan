using System.ComponentModel.DataAnnotations;

namespace MEDIplan.Models
{
    public class User
    {
        // Properties for User

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        // Foreign Keys

        public int WardId { get; set; } // From Ward.cs
    }
}
