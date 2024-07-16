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
        public ProductWithTypeAndBrandSpec(string sort, int? brandId, int? typeId)
            : base(x =>
                 (!brandId.HasValue || x.ProductBrandId == brandId)
               &&
                (!typeId.HasValue || x.ProductTypeId ==typeId)
                 )
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
