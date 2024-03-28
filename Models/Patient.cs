using System.ComponentModel.DataAnnotations;

namespace MEDIplan.Models
{
    public class Patient
    {
        // Properties for Patient
        
        [Key]
        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set;}

        [Required]
        public bool KvCardQuarter { get; set; }

        // Foreign Keys

        [Required]
        public int DoctorId { get; set; } // From Doctor.cs

        // Navigation Property
        public virtual Doctor Doctor { get; set; }
    }
}
