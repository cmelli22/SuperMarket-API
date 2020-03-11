using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productservice, IMapper mapper)
        {
            _productService = productservice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<List<Product>, List<ProductResoruce>>(products);
            return Ok(resources);
        }
    }
}