using System.ComponentModel.DataAnnotations;
using Shared.Models.UtilitiesShared;

namespace Productos.API.Entity
{
    public class Category : BaseEntity<int>
    {
        
        [Required]
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public virtual ICollection<Products>? ProductList {  get; set; }
    }
}
