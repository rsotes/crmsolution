using Infrastructure;
using ProductServices;
using ProductServices.DTOs.Products;
using ProductServices.Exceptions;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductsApi.Controllers
{
    [RoutePrefix("categories")]
    public class CategoryController : ApiController
    {
        private readonly CategoryService categoryService;

        private readonly IUnitOfWork Uow;

        public CategoryController(CategoryService cService, IUnitOfWork uow)
        {
            categoryService = cService;
            Uow = uow;
        }

        [Route("{id:int}")]
        public async Task<CategoryResponseDto> GetCategory(int id)
        {
            return await categoryService.find(id);
        }

        [Route("")]
        [HttpPost]
        public void PostCategory(AddCategoryDto dto)
        {
            if (dto == null) throw new CategoryRequiredException("Category is required");
            categoryService.Add(dto);
            Uow.Commit();
        }
    }
}
