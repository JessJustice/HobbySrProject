using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HobbyTracker.Models
{
    public class CommunityComment
    {
        [Key]
        public int CommunityCommentID { get; set; }

        [ForeignKey("Community")]
        [Column(Order = 1)]
        public int CommunityID { get; set; }

        [ForeignKey("Comment")]
        [Column(Order = 2)]
        public int CommentID { get; set; }

        public virtual Community Community { get; set; }
        public virtual Comment Comment { get; set; }


    }
}