using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class ShoppingCart
    {

        public ShoppingCart()
        {
            User = new User();
            ProductShoppingCarts = new HashSet<ProductShoppingCart>();
        }

        [Key]
        public int ShoppingCartId { get; set; }
        public string ClientGuid { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ProductShoppingCart> ProductShoppingCarts { get; set; }
    }
}
