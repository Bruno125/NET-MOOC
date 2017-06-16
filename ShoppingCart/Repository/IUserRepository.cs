using System;
using System.Collections.Generic;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public interface IUserRepository
    {
        void Login(String email, String password);
        void Create(User user);
        void SocialAuth(String accessToken);
        IEnumerable<User> GetAll();

	}
}
