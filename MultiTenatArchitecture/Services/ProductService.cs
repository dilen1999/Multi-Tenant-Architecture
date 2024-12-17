using Microsoft.EntityFrameworkCore;
using MultiTenatArchitecture.Models;
using MultiTenatArchitecture.Services.DTO;

namespace MultiTenatArchitecture.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IEnumerable<Product> GetAllProducts(string tenantId)
        //{
        //    var result = _context.Products
        //        .Where(p=> p.TenantId == tenantId)
        //        .ToList();
        //    return result;
        //}

        public async Task<IEnumerable<Product>> GetAllProducts(string tenantId)
        {
            var result = await _context.Products
                .Where(p => p.TenantId == tenantId)
                .ToListAsync();
            return result;
        }

        public Product CreateProduct(CreateProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                TenantId = request.TenantId // Set the TenantId from the request
            };

            _context.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return true;
        }
    }
}
