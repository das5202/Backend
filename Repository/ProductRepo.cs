using static ShoppingCartWebApi.Repository.ProductRepo;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShoppingCartWebApi.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly ShoppingCartDbContext _ShoppingCartDb;
        public ProductRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = await _ShoppingCartDb.Product.AddAsync(product);
            await _ShoppingCartDb.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _ShoppingCartDb.Product.ToListAsync();
        }

        public async Task<Product> GetProduct(int ProductId)
        {
            return await _ShoppingCartDb.Product.FirstOrDefaultAsync(p => p.ProductId == ProductId);
        }

        public async Task<IEnumerable<Product>> Search(string ProductName)
        {
            IQueryable<Product> query = _ShoppingCartDb.Product;
            if (!string.IsNullOrEmpty(ProductName))
            {
                query = query.Where(x => x.ProductName.Contains(ProductName));
            }
            return await query.ToListAsync();
        }
        public async void DeleteProduct(int ProductId)
        {
            var result = await _ShoppingCartDb.Product
                .FirstOrDefaultAsync(p => p.ProductId == ProductId);
            if (result != null)
            {
                _ShoppingCartDb.Product.Remove(result);
                await _ShoppingCartDb.SaveChangesAsync();
            }
        }
        //    public async Task<Product> UpdateProduct(Product product)
        //    {
        //        var result = await _ShoppingCartDb.Product.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

        //        if (result != null)
        //        {
        //            result.Category = product.Category;
        //            result.ProductName = product.ProductName;
        //            result.Price = product.Price;
        //            result.Description = product.Description;
        //            result.ProductImage = product.ProductImage;

        //            await _ShoppingCartDb.SaveChangesAsync();

        //            return result;
        //        }

        //        return null;
        //    }
        //}

        public async Task UpdateProduct(Product product, int id)
        {
            //var result = await _ShoppingCartDb.Product.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);
            var result = await _ShoppingCartDb.Product.FindAsync(id);
            if (result != null)
            {
                result.Category = product.Category;
                result.ProductName = product.ProductName;
                result.Price = product.Price;
                result.Description = product.Description;
                result.ProductImage = product.ProductImage;



                await _ShoppingCartDb.SaveChangesAsync();




            }
        }



        }
    }