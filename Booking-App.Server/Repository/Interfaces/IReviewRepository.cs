using Booking_App.Server.Models;

namespace Booking_App.Server.Repository.Interfaces
{
    public interface IReviewRepository
    {
        public Task<Review?> GetReview(int id);
        public Task<List<Review>> GetReviewsByHotelId(int id);
        public Task<bool> DeleteReview(int id);
        public Task<bool> UpdateReview(Review review, int id);
        public Task CreateReview(Review review);
    }
}
