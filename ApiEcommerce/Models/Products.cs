using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiEcommerce.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? nameProduct { get; set; }
        public decimal Price { get; set; }
        public string? resume { get; set; }
        public string? imgURL { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; } // Adicione essa propriedade
    }
}
