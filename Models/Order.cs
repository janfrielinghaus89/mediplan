using System.ComponentModel.DataAnnotations;

namespace MEDIplan.Models
{
    public class Order
    {
        // Properties for Patient

        [Key]
        public int OrderId { get; set; }

        // Foreign Keys

        [Required]
        public int UserId { get; set; } // From User.cs

        [Required]
        public int MedicationId { get; set; } // From Medication.cs

        [Required]
        public int DoctorId { get; set; } // From Doctor.cs

        [Required]
        public int PatientId { get; set; } // From Patient.cs

        // Navigation Property
        public virtual User User { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Medication Medication { get; set; }
        public virtual Patient Patient { get; set; }

    }
}
