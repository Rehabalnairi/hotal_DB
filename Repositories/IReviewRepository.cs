using hotal_DB.Models;

namespace hotal_DB.Repositories
{
    public interface IReviewRepository
    {
        void AddReview(Review review);
        void DeleteReview(int reviewId);
        List<Review> GetAllReviews();
        Review GetReviewById(int reviewId);
        List<Review> GetReviewsByGuestId(int guestId);
        List<Review> GetReviewsByRoomId(int roomId);
        void UpdateReview(Review review);
    }
}