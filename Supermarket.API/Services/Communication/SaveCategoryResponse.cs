using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Services.Communication
{
    public class SaveCategoryResponse:BaseResponse
    {
        public Category category { get; private set; }

        private SaveCategoryResponse(bool success , string messages , Category category):base(success, messages)
        {
            this.category = category;
        }
        
        public SaveCategoryResponse(Category category):this (true, string.Empty, category)
        {

        }

        public SaveCategoryResponse(string message):this(false,message, null)
        {

        }
    }
}
