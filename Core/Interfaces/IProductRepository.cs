using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        #region Products
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsAsync();
        #endregion

        #region Brands
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        #endregion

        #region ProductTypes
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        #endregion
    }
}
