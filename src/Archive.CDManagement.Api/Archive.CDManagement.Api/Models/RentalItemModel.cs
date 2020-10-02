using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archive.CDManagement.Api.Models
{
    [Table("RentalItems")]
    public class RentalItemModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Rental")]
        public int RentalId { get; set; }

        public RentalModel Rental { get; set; }

        [Required]
        [ForeignKey("CD")]
        public int CDId { get; set; }

        public CDModel CD { get; set; }
    }
}