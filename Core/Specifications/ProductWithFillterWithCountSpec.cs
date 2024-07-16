using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithFillterWithCountSpec :BaseSpecifications<Product>
    {
        public ProductWithFillterWithCountSpec(ProductSpecParams productParams)
            : base(x =>

            
                //(string.IsNullOrEmpty(productParams.Search) || x.ProductBrandId.ToString().Trim().Contains(productParams.Search)) ||
                //(string.IsNullOrEmpty(productParams.Search) || x.Price.ToString().Trim().Contains(productParams.Search)) ||
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Trim().Contains(productParams.Search)) &&
            (!productParams.brandId.HasValue || x.ProductBrandId== productParams.brandId)
            && 
            (!productParams.typeId.HasValue ||  x.ProductTypeId== productParams.typeId)
            )
        {
            
        }
    }
}
