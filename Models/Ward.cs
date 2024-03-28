using System.ComponentModel.DataAnnotations;

namespace MEDIplan.Models
{
    public class Ward
    {
        // Properties for Ward

        [Key]
        public int WardId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
