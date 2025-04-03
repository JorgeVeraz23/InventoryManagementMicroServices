using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.UtilitiesShared
{
    public class TransactionFilterParams
    {
        public TransactionType? TipoTransaccion { get; set; }
        public int? ProductoId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
