using Microsoft.EntityFrameworkCore;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartWebApi.Repository
{
    public class AddressRepo : IAddress
    {
        private readonly ShoppingCartDbContext _ShoppingCartDb;

        public AddressRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            return await _ShoppingCartDb.Address.ToListAsync();
        }

        public async Task<Address> GetAddress(int AddressId)
        {
            return await _ShoppingCartDb.Address
                .FirstOrDefaultAsync(e => e.AddressId == AddressId);
        }

        public async Task<Address> SaveAddress(Address address)
        {
            var result = await _ShoppingCartDb.Address.AddAsync(address);
            await _ShoppingCartDb.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Address> UpdateAddress(Address Address)
        {
            var result = await _ShoppingCartDb.Address
                .FirstOrDefaultAsync(e => e.AddressId == Address.AddressId);

            if (result != null)
            {

                await _ShoppingCartDb.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async void DeleteAddress(int AddressId)
        {
            var result = await _ShoppingCartDb.Address
                .FirstOrDefaultAsync(e => e.AddressId == AddressId);
            if (result != null)
            {
                _ShoppingCartDb.Address.Remove(result);
                await _ShoppingCartDb.SaveChangesAsync();
            }
        }

        Task<IEnumerable<Address>> IAddress.GetAllAddress()
        {
            throw new System.NotImplementedException();
        }

        Task<Address> IAddress.GetAddress(int UserId)
        {
            throw new System.NotImplementedException();
        }

        Task<Address> IAddress.SaveAddress(Address address)
        {
            throw new System.NotImplementedException();
        }

        Task<Address> IAddress.UpdateAddress(Address address)
        {
            throw new System.NotImplementedException();
        }
    }
}