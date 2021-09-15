using AutoMapper;
using Ebiograf.Web.API.Models.Snacks;
using Ebiograf.Web.API.ModelsDto.SnackDto;
using EBiograf.Web.Api.Environment;
using EBiograf.Web.Api.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebiograf.Web.API.Repository.SnackRepo
{
    public class ProductRepository:IProductRepository
    {
        private readonly EBiografDbContext context;
        private IMapper mapper;
        public ProductRepository(EBiografDbContext _context, IMapper _mapper) // Dependency Injection
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<Product> CreateProduct(ProductDto createProduct)
        {
            var Product = mapper.Map<Product>(createProduct);
            await context.Products.AddAsync(Product);
            await context.SaveChangesAsync();
            return Product;
        }

        public async Task<Product> DeleteProduct(int ProductID)
        {
            var deleteProduct = await context.Products.FindAsync(ProductID);
            if (deleteProduct != null)
            {
                context.Products.Remove(deleteProduct);
                await context.SaveChangesAsync();
            }
            return deleteProduct;

        }

        public async Task<Product> GetProductByID(int ProductID)
        {
            return await context.Products.FindAsync(ProductID);

        }

        public async Task<IEnumerable<Product>> getProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(ProductDto UpdateProduct, int ProductID)
        {
            var updatedProduct = mapper.Map<Product>(UpdateProduct);
            var Product = await context.Products.FindAsync(ProductID);
            if (Product == null)
            {
                throw new AppException("Product not found");

            }
            if (!string.IsNullOrWhiteSpace(updatedProduct.Name.ToString()))
            {
                Product.Name = updatedProduct.Name;
            }
            if (!string.IsNullOrWhiteSpace(updatedProduct.Price.ToString()))
            {
                Product.Price = updatedProduct.Price;
            }
            if (!string.IsNullOrWhiteSpace(updatedProduct.Description.ToString()))
            {
                Product.Description = updatedProduct.Description;
            }

            context.Products.Update(Product);
            await context.SaveChangesAsync();

            return Product;

        }
    }
}
