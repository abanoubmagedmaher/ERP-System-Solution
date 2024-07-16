using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 5;
        public int PageSize 
        {
            
            get=> _pageSize; 
            set =>_pageSize =(value > MaxPageSize) ? MaxPageSize : value;
        }
        public int? brandId { get; set; }
        public int? typeId { get; set; }
        public string ? Sort { get; set; }

        private string _Search;
        public string Search
        {
            get => _Search;
            set => _Search = value.ToLower().Trim();
        }
    }
}
