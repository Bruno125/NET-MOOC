using System;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers.Models
{
    public class ProfileResponse
    {
        public User User { get; set; }
        public string Error { get; set; }
    }
}
