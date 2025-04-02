namespace Productos.API.Dto
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; } = "";

        public string ImageUrl { get; set; } = "";
    }
}
