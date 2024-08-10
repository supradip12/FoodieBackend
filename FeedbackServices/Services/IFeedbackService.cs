using FeedbackServices.Model;

namespace FeedbackServices.Services
{
    public interface IFeedbackService
    {
        bool AddFeedBack(Feedback feedback);
        List<Feedback> GetAllFeedBacks();
        List<Feedback> GetByRating(string rating);
        Feedback GetByUserEmail(string UserEmail);
    }
}