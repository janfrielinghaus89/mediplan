using System.ComponentModel.DataAnnotations;

namespace MEDIplan.Models
{
    public class Medication
    {
        // Properties for Patient

        [Key]
        public int MedicationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public double SubstanceAmount { get; set; }
    }
}
