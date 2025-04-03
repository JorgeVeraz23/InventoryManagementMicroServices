using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Dto
{
    public class ProductDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }
        public Guid? ImageFileId { get; set; } // opcional, si manejás archivos
    }

}
