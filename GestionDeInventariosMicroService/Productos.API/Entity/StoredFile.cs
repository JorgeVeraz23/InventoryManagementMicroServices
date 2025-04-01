using System.ComponentModel.DataAnnotations.Schema;
using Shared.Models.UtilitiesShared;

namespace Productos.API.Entity
{
    public class StoredFile : BaseEntity<Guid>
    {
        public string FileName { get; set; } = "";

        public string ContentType { get; set; } = "";
        public string Url { get; set; } = "";
        public long SizeInBytes { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Product")]
        public int IdProduct {  get; set; }
        public virtual Product? Product { get; set; }

    }
}
