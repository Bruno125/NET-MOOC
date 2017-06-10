using System;
using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public partial class ProductShoppingCarts
    {
        public int ProductProductId { get; set; }
        public int ShoppingCartShoppingCartId { get; set; }

        public virtual Products ProductProduct { get; set; }
        public virtual ShoppingCarts ShoppingCartShoppingCart { get; set; }
    }
}
