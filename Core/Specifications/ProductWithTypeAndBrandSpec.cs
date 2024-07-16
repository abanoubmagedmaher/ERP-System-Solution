using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithTypeAndBrandSpec: BaseSpecifications<Product>
    {
        public ProductWithTypeAndBrandSpec( ProductSpecParams ProductParams)
            : base(x =>
                 (string.IsNullOrEmpty(ProductParams.Search) || x.Name.ToLower().Trim().Contains(ProductParams.Search) )&&
                 (!ProductParams.brandId.HasValue || x.ProductBrandId == ProductParams.brandId)
               &&
                (!ProductParams.typeId.HasValue || x.ProductTypeId == ProductParams.typeId)
                 )
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(ProductParams.PageSize * (ProductParams.PageIndex - 1), ProductParams.PageSize);

            if (!string.IsNullOrEmpty(ProductParams.Sort))
            {
                switch (ProductParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        AddorderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
        }
        public ProductWithTypeAndBrandSpec(int id):base(x=>x.Id==id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}
