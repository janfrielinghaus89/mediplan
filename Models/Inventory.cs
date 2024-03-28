using System.ComponentModel.DataAnnotations;

namespace MEDIplan.Models
{
    public class Inventory
    {
        // Properties for Inventory

        [Key]
        public int InventoryId { get; set; }

        [Required]
        public int OnStock {  get; set; }

        // Foreign Keys

        [Required]
        public int MedicationId { get; set; } // From Medication.cs

        [Required]
        public int PatientId { get; set; } // From Patient.cs

        [Required]
        public int DosageId { get; set; } // From Dosage.cs
    }
}
