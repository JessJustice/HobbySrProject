using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HobbyTracker.Models
{
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }
        [Required(ErrorMessage = "Please enter your activity name")]
        public string ActName { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please specify wheter you'll attend")]
        public bool? WillAttend { get; set; }

        public int CommunityID { get; set; }


        public virtual Community Community { get; set; } //to keep track of which community this activity is a part of
    }
}