using Booking_App.Server.DTO;
using Booking_App.Server.Models;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IReviewService
    {
        public Task<ReviewDto?> GetReview(int id);

        public Task<List<ReviewDto>> GetReviewsByHotelId(int hotelId);
        public Task<bool> DeleteReview(int id);
        public Task<bool> UpdateReview(CreateReviewRequest review, int id);
        public Task CreateReview(CreateReviewRequest review);
    }
}
