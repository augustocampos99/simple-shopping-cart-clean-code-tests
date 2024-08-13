using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllLimit(int limit, int skip);
        Task<Product?> GetByGuid(Guid guid);
        Task<Product> Create(Product post);
        Task<Product> Update(Product post);
        Task<int> Delete(Product post);
    }
}
