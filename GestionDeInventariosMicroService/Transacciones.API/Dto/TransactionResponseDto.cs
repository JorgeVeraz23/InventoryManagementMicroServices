namespace Transacciones.API.Dto
{
    public class TransactionResponseDto
    {
        public int ProductId { get; set; }
        public string Type { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public decimal Iva => Total * 0.12m;
    }
}
