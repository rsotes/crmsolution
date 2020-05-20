using Infrastructure.Repositories;
using ProductServices.DTOs.Products;
using System.Threading.Tasks;
using ProductServices.DTOs.Products.Extensions;
using ProductsDomain.Utils.Exceptions;
using Infrastructure;

namespace ProductServices
{
    public class CategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository cRepository)
        {
            categoryRepository = cRepository;
        }

        public async Task<CategoryResponseDto> find(int id)
        {
            var category = await categoryRepository.FindASync(id);
            if (category == null) throw new DomainNotFoundException("Category not found");
            return category.ToCategoryDto();
        }

        public void Add(AddCategoryDto dto)
        {
            categoryRepository.Add(new ProductsDomain.Products.Category(dto.Name));
        }
    }
}
