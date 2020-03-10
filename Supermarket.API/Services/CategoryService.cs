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
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Category>> ListAsync()
        {
            var categories = await _categoryRepository.ListAsync();
            return categories;
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(category);
                      
            }
            catch (Exception ex)
            {

                return new SaveCategoryResponse($"Ocurrio un erro al guardar la Categoria: {ex.Message}");

            }
        } 

        public async Task<SaveCategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);
            if(existingCategory == null)
            {
                return new SaveCategoryResponse($"Not found the category {id}");
            }

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new SaveCategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {

                return new SaveCategoryResponse($"No se pudo acutalizar la categoria numero {existingCategory.Id} : {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponse> DeleteAsync(int id)
        {
            var existinCateogry = await _categoryRepository.FindByIdAsync(id);
            if(existinCateogry == null)
            {
                return new SaveCategoryResponse($"No se encontro la cateogira {id}");
            }
            try
            {
                _categoryRepository.Delete(existinCateogry);
                await _unitOfWork.CompleteAsync();
                return new SaveCategoryResponse(existinCateogry);
            }
            catch (Exception ex)
            {

                return new SaveCategoryResponse($"No se pudo borrar la cateogria {existinCateogry.Name} : {ex.Message}");
            }
        }
    }
}
