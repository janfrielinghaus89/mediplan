using System.ComponentModel.DataAnnotations;

namespace MEDIplan.Models
{
    public class Delivery
    {
        // Properties for Delivery

        [Key]
        public int DeliveryId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Foreign Keys

        [Required]
        public int PatientId { get; set; } // From Patient.cs

        [Required]
        public int MedicationId { get; set; }

        [Required]
        public int InventoryId { get; set; } // From Inventory.cs

        // Navigation Property
        public virtual Patient Patient { get; set; }
        public virtual Medication Medication { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
