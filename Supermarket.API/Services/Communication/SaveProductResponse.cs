using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Services.Communication
{
    public class SaveProductResponse:BaseResponse
    {
        public Product producto { get; protected set; }


        public SaveProductResponse(Product producto) :base(true, string.Empty)
        {
            this.producto = producto;
        }

        public SaveProductResponse(string message) : base(false, message)
        {
          
        }
    }
}
