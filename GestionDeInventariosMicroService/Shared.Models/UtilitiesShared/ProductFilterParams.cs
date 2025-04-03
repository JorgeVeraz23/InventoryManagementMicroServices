using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.UtilitiesShared
{
    public class ProductFilterParams
    {
        public string? Search {  get; set; }
        public string? SortBy { get; set; } = "Name";
        public bool Desc {  get; set; }= false;

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public DateTime? FromDate { get; set; } 
        public DateTime? ToDate { get; set; }   

    }
}
