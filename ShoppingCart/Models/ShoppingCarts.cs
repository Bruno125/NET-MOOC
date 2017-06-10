using System;
using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public partial class ShoppingCarts
    {
        public ShoppingCarts()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            ProductShoppingCarts = new HashSet<ProductShoppingCarts>();
        }

        public int ShoppingCartId { get; set; }
        public string ClientGuid { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<ProductShoppingCarts> ProductShoppingCarts { get; set; }
    }
}
