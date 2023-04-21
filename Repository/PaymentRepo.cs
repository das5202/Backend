
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Repository;

namespace ShoppingCartWebApi.Models
{
    public class PaymentRepo : IPayment
    {
        private readonly ShoppingCartDbContext _ShoppingCartDb;

        public PaymentRepo(ShoppingCartDbContext shoppingCartDbContext)
        {
            _ShoppingCartDb = shoppingCartDbContext;
        }

        public async Task<IEnumerable<Payment>> GetAllTransaction()
        {
            return await _ShoppingCartDb.Payment.ToListAsync();
        }

        public async Task<Payment> GetTransaction(int TransactionId)
        {
            return await _ShoppingCartDb.Payment
                .FirstOrDefaultAsync(e => e.TransactionId == TransactionId);
        }

        public async Task<Payment> SaveTransaction(Payment payment)
        {
            var result = await _ShoppingCartDb.Payment.AddAsync(payment);
            await _ShoppingCartDb.SaveChangesAsync();
            return result.Entity;

        }
    }
}



            

            