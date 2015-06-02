using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HobbyTracker.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string TextInput { get; set; }
        public int CommunityID { get; set;}
        public string CommentUser { get; set; }

        public virtual Community Community { get; set; }
    }
}