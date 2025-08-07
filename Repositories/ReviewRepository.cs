using hotal_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotal_DB.Data;

namespace hotal_DB.Repositories
{
     public class ReviewRepository
    {
        private readonly HotelContext _context;

        public ReviewRepository(HotelContext context)
        {
            _context = context;
        }
        public void AddReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
        public void UpdateReview(Review review)
        {
            _context.Reviews.Update(review);
            _context.SaveChanges();
        }
        public void DeleteReview(int reviewId)
        {
            var review = _context.Reviews.Find(reviewId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }
        public Review GetReviewById(int reviewId)
        {
            return _context.Reviews.Find(reviewId);
        }
        public List<Review> GetAllReviews()
        {
            return _context.Reviews.ToList();
        }
        public List<Review> GetReviewsByGuestId(int guestId)
        {
            return _context.Reviews.Where(r => r.GuestId == guestId).ToList();
        }
        public List<Review> GetReviewsByRoomId(int roomId)
        {
            return _context.Reviews.Where(r => r.RoomId == roomId).ToList();
        }
    }
}
