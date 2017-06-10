using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using Microsoft.AspNetCore.Cors;

namespace ShoppingCart.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/Producto2")]
    public class ProductController : Controller
    {
        public IProductRepository Products { get; set; }

        public ProductController(IProductRepository products)
        {
            Products = products;
        }

        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return Products.GetAll();
        }

        //private readonly IProductRepository productRepository;

        //public ProductController()
        //{
        //    this.productRepository = new ProductRepository(new ShoppingCartContext());
        //}

        //public ProductController(IProductRepository productRepository)
        //{
        //    this.productRepository = productRepository;
        //}

        // GET: api/Product
    }
}
