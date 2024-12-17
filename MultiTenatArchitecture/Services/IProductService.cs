using MultiTenatArchitecture.Models;
using MultiTenatArchitecture.Services.DTO;

namespace MultiTenatArchitecture.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts(string tenantId);
        Product CreateProduct(CreateProductRequest request);

        bool DeleteProduct(int id);
    }
}
