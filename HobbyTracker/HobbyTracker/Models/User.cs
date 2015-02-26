using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyTracker.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Display(Name = "Name")]
        public string UserName { get; set; }
       
        //public virtual IEnumerable<Item> Items { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
    }
}