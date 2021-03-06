﻿using ProductsDomain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface ICategoryRepository : IRepositoryRead<Category>, IRepositoryWrite<Category>
    {
    }
}
