using System.ComponentModel.DataAnnotations;

namespace FeedbackServices.Model
{
    public class Feedback
    {
        [Key]
        public string UserEmail { get; set; }
        public string RestaurantName { get; set; }
        public string UserName { get; set; }
        public string UserFeedBack { get; set; }
        public string Rating { get; set; }

    }
}
