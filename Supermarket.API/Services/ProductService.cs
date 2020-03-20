using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductReposiroty _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductReposiroty productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<SaveProductResponse> PostAsync(Product producto)
        {
            try
            {
                await _productRepository.PostAsync(producto);
                await _unitOfWork.CompleteAsync();

                return new SaveProductResponse(producto);
            }
            catch (Exception ex)
            {

                return new SaveProductResponse($"No se pudo Agregar El producto : {ex.Message}");
            }
        }
    }
}
