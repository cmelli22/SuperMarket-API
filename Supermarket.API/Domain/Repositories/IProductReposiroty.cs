using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories
{
    public interface IProductReposiroty
    {
        Task<List<Product>> ListAsync();
        Task PostAsync(Product producto);
    }
}
