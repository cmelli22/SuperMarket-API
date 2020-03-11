using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductReposiroty _productRepository;

        public ProductService(IProductReposiroty productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }
    }
}
