using System.ComponentModel.DataAnnotations;

namespace MEDIplan.Models
{
    public class Dosage
    {
        // Properties for Dosage

        [Key]
        public int DosageId { get; set; }

        [Required]
        public double DosageAmount { get; set; }

        [Required]
        [MaxLength(500)]
        public string DosageInstruction { get; set; }

        // Foreign Keys

        [Required]
        public int MedicationId { get; set; } // From Medication.cs

        [Required]
        public int PatientId { get; set; } // From Patient.cs

        // Navigation Property
        public virtual Medication Medication { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
