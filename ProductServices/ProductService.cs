using Infrastructure.Repositories;
using ProductsDomain.Products;
using System.Threading.Tasks;
using ProductServices.DTOs.Products;
using ProductServices.Products.Extensions;
using ProductServices.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ProductServices
{
    public class ProductService
    {
        private readonly IProductRepository productsRepository;

        private readonly ICategoryRepository categoryRepository;

        public ProductService(IProductRepository pRepository, ICategoryRepository cRepository)
        {
            productsRepository = pRepository;
            categoryRepository = cRepository;
        }

        public IQueryable<ProductResponseDto> AsQueriable(bool includeCategories = false)
        {
            IQueryable<Product> queryable = null;
            if (includeCategories) queryable = productsRepository.AsQueryableWithCategories();
            else queryable = productsRepository.AsQueryable();
            return queryable.AsEnumerable().Select(x => x.ToProductDto()).AsQueryable();
        }

        public async Task<IEnumerable<ProductResponseDto>> FindProducts(int index, int total)
        {
            var products = await productsRepository.QueryAsync(index, total);
            return products.Select(x => x.ToProductDto()).ToList();
        }

        public async Task<ProductResponseDto> FindProduct(int id)
        {
            var product = await productsRepository.FindASync(id);
            return product.ToProductDto();
        }

        public async Task AddAsync(AddProductDto product)
        {
            var category = await categoryRepository.FindASync(product.CategoryId);
            if (category == null) throw new CategoryNotFoundException("Category not found");
            
            var p = new Product(product.Name, product.Description, product.Price, category);
            await productsRepository.AddAsync(p);
        }

    }
}
