namespace Productos.API.Dto
{
    public class ProductDto
    {
        public int Id { get; set; } // Solo se usa para actualizaciones
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Guid? ImageFileId { get; set; } // opcional, si manejás archivos
    }
}
