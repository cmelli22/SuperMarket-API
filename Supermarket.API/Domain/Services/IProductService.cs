using Supermarket.API.Domain.Models;
using Supermarket.API.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services
{
    public interface IProductService
    {
        Task<List<Product>> ListAsync();
        Task<SaveProductResponse> PostAsync(Product producto);
    }
}
