using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HobbyTracker.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
       
        public virtual IEnumerable<Item> Items { get; set; }
    }
}