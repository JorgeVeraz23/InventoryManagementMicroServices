namespace Transacciones.API.Dto
{
    public class TransactionResponseDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoTransaccion { get; set; } = "";
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal { get; set; }
        public string? Detalle { get; set; }
    }

}
