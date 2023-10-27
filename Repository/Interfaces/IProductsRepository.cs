using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> GetProductsAsync();
        Task<Products> GetProductsByIdAsync(int id);
        Task<bool> CreateProductsAsync(Products product);
        Task<bool> UpdateProductsAsync(Products updatedProduct, int id);
        Task<bool> DeleteProductsAsync(int id);
    }
}