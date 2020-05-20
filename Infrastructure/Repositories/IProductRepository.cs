﻿using ProductsDomain;
using ProductsDomain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IProductRepository : IRepositoryRead<Product>, IRepositoryWrite<Product>
    {
        Task<List<Product>> FindAsync(params int[] id);

        IQueryable<Product> AsQueryableWithCategories();
    }
}
