using FeedbackServices.Model;

namespace FeedbackServices.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly FeedbackContext _context;
        public FeedbackService(FeedbackContext context)
        {
            _context = context;
        }


        public bool AddFeedBack(Feedback feedback)
        {
            try
            {
                _context.FeedBacks.Add(feedback);
                _context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Error occurred during adding feedbacks.");
                return false;
            }
            return true;
        }



        public List<Feedback> GetAllFeedBacks()
        {
            try
            {
                return _context.FeedBacks.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Feedback> GetByRating(string rating)
        {
            try
            {
                var feedbacks = _context.FeedBacks.Where(f => f.Rating == rating).ToList();
                if (feedbacks != null)
                {
                    return feedbacks;  // Assuming you want to return the string representation of the feedback object
                }
                else
                {
                    return null;
                    // Return a message indicating that the user was not found
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public Feedback GetByUserEmail(string UserEmail)
        {
            //return context.Feedbacks.Where(us => us.UserName == username).FirstOrDefault().ToString();
            try
            {
                var feedbacks = _context.FeedBacks.FirstOrDefault(us => us.UserEmail == UserEmail);

                if (feedbacks != null)
                {
                    return feedbacks;  // Assuming you want to return the string representation of the feedback object
                }
                else
                {

                    return null;                    // Return a message indicating that the user was not found
                }
            }
            catch (Exception ex)
            {
                return null;

            }
        }


    }
}
