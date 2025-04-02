using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Models.UtilitiesShared;

namespace Productos.API.Entity
{
    public class Product : BaseEntity<int>
    {
        
        [Required]
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        [Required]
        public int Stock {  get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int IdCategoria { get; set; }
        public virtual Category Category { get; set; } = default!;
        [ForeignKey("StoredFiles")]
        public Guid ImageFileId { get; set; }
        public virtual StoredFile StoredFiles { get; set; } = default!;

    }
}
