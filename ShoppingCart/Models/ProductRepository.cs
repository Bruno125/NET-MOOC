using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ProductRepository: IProductRepository
    {
        private ShoppingCartContext context;

        public ProductRepository(ShoppingCartContext context)
        {
            this.context = context;
        }

        public IEnumerable<Products> GetAll()
        {
            return context.Products.ToList();
        }

        public void Add(Products product)
        {
            context.Products.Add(product);
        }
    }
}

