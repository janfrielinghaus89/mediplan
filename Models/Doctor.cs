using System.ComponentModel.DataAnnotations;

namespace MEDIplan.Models
{
    public class Doctor
    {
        // Properties for Doctor

        [Key]
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        public bool AllowsMail { get; set; }

        [Required]
        [MaxLength (50)]
        public string FaxNumber { get; set; }

        [Required]
        [MaxLength (50)]
        public string PhoneNumber { get; set; }
    }
}
