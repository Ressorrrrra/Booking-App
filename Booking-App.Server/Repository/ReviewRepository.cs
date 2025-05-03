using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Booking_App.Server.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookingContext db;

        public ReviewRepository(BookingContext bookingContext)
        {
            db = bookingContext;
        }
        public async Task CreateReview(Review review)
        {
            await db.Reviews.AddAsync(review);
        }

        public async Task<bool> DeleteReview(int id)
        {
            var review = await this.GetReview(id);
            if (review != null) 
            {
                db.Reviews.Remove(review);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Review?> GetReview(int id)
        {
            return await db.Reviews.Include(review => review.Order).ThenInclude(order => order.User).FirstOrDefaultAsync(review => review.Id == id);
        }

        public async Task<List<Review>> GetReviewsByHotelId(int id)
        {
            var reviews = await db.Reviews.Where(review => review.Order.Room.HotelId == id).Include(review => review.Order).ThenInclude(order => order.User).ToListAsync();
            return reviews;
        }

        public async Task<bool> UpdateReview(Review review, int id)
        {
            var r = await db.Reviews.FirstOrDefaultAsync(review => review.Id == id);
            if (r == null) 
            {
                return false;
            }
            else
            {
                r.Text = review.Text;
                r.Rating = review.Rating;
                return true;
            }
        }
    }
}
