using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HobbyTracker.Models
{
    public class Community
    {
        [Key]
        public int CommunityID { get; set; }
        [Required]
        public string CommunityName { get; set; }
        //In community, you can have more than one CommunityComment added to it

        public string CommunityLocation { get; set; }
        public string CommunityLoc { get; set; }

        public string CommunityOwner { get; set; }

        public string DescriptionField { get; set; }

        public string Email { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}