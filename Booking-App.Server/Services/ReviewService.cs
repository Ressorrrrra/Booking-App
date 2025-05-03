using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Booking_App.Server.Services.Interfaces;

namespace Booking_App.Server.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task CreateReview(CreateReviewRequest review)
        {

            await _reviewRepository.CreateReview(new Review
            {
                PostDate = DateTimeOffset.UtcNow,
                OrderId = review.OrderId,
                Text = review.Text,
                Rating = review.Rating,
            });
        }

        public async Task<bool> DeleteReview(int id)
        {
            return await _reviewRepository.DeleteReview(id);
        }

        public async Task<ReviewDto?> GetReview(int id)
        {
            var review = await _reviewRepository.GetReview(id);
            if (review != null)
            {
                return new ReviewDto
                {
                    Id = review.Id,
                    Username = review.Order.User.UserName,
                    PostDate = review.PostDate,
                    Rating = review.Rating,
                    Text = review.Text,
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ReviewDto>> GetReviewsByHotelId(int hotelId)
        {
            return (await _reviewRepository.GetReviewsByHotelId(hotelId)).Select(r => new ReviewDto
            {
                Id = r.Id,
                Username = r.Order?.User.UserName ?? "Неизвестный пользователь",
                PostDate = r.PostDate,
                Rating = r.Rating,
                Text = r.Text,
            }).ToList();
        }

        public async Task<bool> UpdateReview(CreateReviewRequest reviewDto, int id)
        {
            var review = new Review
            {
                Text = reviewDto.Text,
                Rating = reviewDto.Rating,
            };

            return await _reviewRepository.UpdateReview(review, id);
        }
    }
}
