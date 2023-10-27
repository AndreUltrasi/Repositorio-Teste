using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;

namespace WebApplication2.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;

        public ProductsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProductsAsync(Products product)
        {
            if (_context.Products == null)
            {
                throw new Exception("A tabela de produtos não está configurada corretamente no contexto.");
            }

            if (product.Quantity <= 0)
            {
                throw new Exception("A quantidade do produto deve ser maior que zero.");
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductsAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new Exception($"Produto com ID {id} não encontrado.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Products> GetProductsByIdAsync(int id)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);

            if (product == null)
            {
                throw new Exception($"Produto com ID {id} não encontrado.");
            }

            return product;
        }

        public async Task<bool> UpdateProductsAsync(Products updatedProduct, int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new Exception($"Produto com ID {id} não encontrado.");
            }

            product.Id = updatedProduct.Id;
            product.Price = updatedProduct.Price;


            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}