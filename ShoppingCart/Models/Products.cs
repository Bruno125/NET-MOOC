using System;
using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public partial class Products
    {
        public Products()
        {
            ProductShoppingCarts = new HashSet<ProductShoppingCarts>();
        }
        public int ProductId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<ProductShoppingCarts> ProductShoppingCarts { get; set; }
    }
}
