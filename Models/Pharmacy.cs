using System.ComponentModel.DataAnnotations;

namespace MEDIplan.Models
{
    public class Pharmacy
    {
        // Properties for Pharmacy

        [Key]
        public int PharmacyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(120)]
        public string Address { get; set; }

        [MaxLength(30)]
        public string FaxNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Mail {  get; set; }

        [Required]
        public bool AllowsMail { get; set; }
    }
}
