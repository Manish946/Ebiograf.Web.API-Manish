using Ebiograf.Web.API.Models.Snacks;
using Ebiograf.Web.API.ModelsDto.SnackDto;
using Ebiograf.Web.API.Repository.SnackRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Services.SnackService
{
    public class ProductService:IProductService
    {
        public IProductRepository ProductRepo;
        public ProductService(IProductRepository _ProductRepo)
        {
            ProductRepo = _ProductRepo;
        }



        public async Task<IEnumerable<Product>> getProducts() => await ProductRepo.getProducts();
        public async Task<Product> GetProductByID(int ProductID) => await ProductRepo.GetProductByID(ProductID);
        public async Task<Product> CreateProduct(ProductDto createProduct) => await ProductRepo.CreateProduct(createProduct);
        public async Task<Product> UpdateProduct(ProductDto updateProduct, int ProductID) => await ProductRepo.UpdateProduct(updateProduct, ProductID);
        public async Task<Product> DeleteProduct(int ProductID) => await ProductRepo.DeleteProduct(ProductID);
    }
}
