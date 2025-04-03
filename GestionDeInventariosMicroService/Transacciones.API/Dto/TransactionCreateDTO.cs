using Shared.Models.UtilitiesShared;

namespace Transacciones.API.Dto
{

    public class TransactionUpdateDTO : TransactionCreateDTO
    {
        public long Id { get; set; }
    }



    public class TransactionCreateDTO
    {
        public TransactionType TipoTransaccion { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string? Detalle { get; set; }
    }
}
