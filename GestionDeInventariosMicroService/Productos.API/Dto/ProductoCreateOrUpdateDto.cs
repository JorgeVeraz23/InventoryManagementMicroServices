namespace Productos.API.Dto
{

    public class ProductUpdateDto : ProductCreateDto
    {
        public int Id { get; set; }
    }

    public class ProductCreateDto
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }

        public IFormFile? Image { get; set; } 
    }




}
