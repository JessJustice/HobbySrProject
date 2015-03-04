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

        public string CommunityName { get; set; }
        //In community, you can have more thabn one CommunityComment added to it
        public virtual ICollection<CommunityComment> CommunityComments { get; set; }


    }
}