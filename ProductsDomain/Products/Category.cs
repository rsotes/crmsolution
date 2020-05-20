using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsDomain.Products.Extensions;

namespace ProductsDomain.Products
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public ICollection<Product> Products { get; protected set; }

        protected internal Category()
        {
        }

        public Category(string name)
        {
            Name = name;
            this.ValidateName();
        }
    }
}
