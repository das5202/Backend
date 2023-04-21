using ShoppingCartWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Repository;

namespace ShoppingCartWebApi.Models
{
    public class FeedbackRepo : IFeedback
    {
        private readonly ShoppingCartDbContext _ShoppingCartDb;

        public FeedbackRepo(ShoppingCartDbContext shoppingCartDbContext)
        {
            _ShoppingCartDb = shoppingCartDbContext;
        }

        public async Task<IEnumerable<feedback>> GetAllFeedbackDetails()
        {
            return await _ShoppingCartDb.feedback.ToListAsync();
        }

        public async Task<feedback> GetFeedbackDetails(string Username)
        {
            return await _ShoppingCartDb.feedback
                .FirstOrDefaultAsync(e => e.Username == Username);
        }

        public Task<feedback> GetFeedBackDetails(int UserId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<feedback> SaveFeedbackDetails(feedback feedback)
        {
            var result = await _ShoppingCartDb.feedback.AddAsync(feedback);
            await _ShoppingCartDb.SaveChangesAsync();
            return result.Entity;
        }
    }
}

 