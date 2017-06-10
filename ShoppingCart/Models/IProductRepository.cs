using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();
        void Add(Products info);
    }
}
