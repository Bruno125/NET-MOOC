using System;
using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public partial class ConectionUsers
    {
        public int ConectionUserId { get; set; }
        public string ConectionId { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
