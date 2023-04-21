using ShoppingCartWebApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ShoppingCartWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCartWebApi.Repository
{
    public class UserRepo : IUser
    {
        private readonly ShoppingCartDbContext _shoppingCartDbContext;

        public UserRepo(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }

        public async Task<IEnumerable<UserDetails>> GetAllUsers()
        {
            return await _shoppingCartDbContext.UserDetails.ToListAsync();
        }

        public async Task<UserDetails> GetUser(int UserId)
        {
            return await _shoppingCartDbContext.UserDetails
                .FirstOrDefaultAsync(u => u.UserId == UserId);
        }

        public async Task<UserDetails> RegisterUser(UserDetails User)
        {
            var result = await _shoppingCartDbContext.UserDetails.AddAsync(User);
            await _shoppingCartDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserDetails> UpdateUserDetails(UserDetails User)
        {
            var result = await _shoppingCartDbContext.UserDetails
                .FirstOrDefaultAsync(u => u.UserId == User.UserId);

            if (result != null)
            {
                result.UserId = User.UserId;
                result.Role = User.Role;
                result.FirstName = User.FirstName;
                result.LastName = User.LastName;
                result.EmailId = User.EmailId;
                result.MobileNumber = User.MobileNumber;
                result.AddressInfo = User.AddressInfo;
                result.City = User.UserState;
                result.Pincode = User.Pincode;
                result.Password = User.Password;
                result.IsLogin = User.IsLogin;

                await _shoppingCartDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        //public async void DeleteUser(int UserId)
        //{
        //    var result = await _shoppingCartDbContext.UserDetails
        //        .FirstOrDefaultAsync(u => u.UserId == UserId);
        //    if (result != null)
        //    {
        //        _shoppingCartDbContext.UserDetails.Remove(result);
        //        await _shoppingCartDbContext.SaveChangesAsync();
        //    }
        //}

    }
}