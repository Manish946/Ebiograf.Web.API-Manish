using Ebiograf.Web.API.Models.Snacks;
using Ebiograf.Web.API.ModelsDto.SnackDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.SnackService
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> getProducts();
        public Task<Product> GetProductByID(int ProductID);
        public Task<Product> CreateProduct(ProductDto createProduct);
        public Task<Product> UpdateProduct(ProductDto updateProduct, int ProductID);
        public Task<Product> DeleteProduct(int ProductID);
    }
}
