using Shared.Models.UtilitiesShared;
using Transacciones.API.Dto;

namespace Transacciones.API.Entity
{
    public class Transaction : BaseEntity<long>
    {
        public DateTime Date { get; set; }

        public TransactionType Type { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total { get; set; }  

        public string Detail { get; set; }
    }
}
