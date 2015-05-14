using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HobbyTracker.Models
{
    public class Activity
    {
        [Key]

        public int ActivityID { get; set; }
        [DisplayName("Activity Name")]
        [Required(ErrorMessage = "Please enter your activity name")]
        public string ActName { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [DisplayName("Will you attend?")]
        [Required(ErrorMessage = "Please specify wheter you'll attend")]
        public bool? WillAttend { get; set; }
        [DisplayName("Community Name")]
        public int CommunityID { get; set; }
        [DisplayName("Username")]
        public string UserName { get; set; }

        public virtual Community Community { get; set; } //to keep track of which community this activity is a part of
    }
}