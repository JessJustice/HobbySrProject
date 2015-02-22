using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HobbyTracker.Models
{
    public class Collection
    {
        public int CollectionID { get; set; }
        public string CollectionName { get; set; }
        public int UserID { get; set; }
        public int GenreID { get; set; }
        public int ItemID { get; set; }

        public virtual User User { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual IEnumerable<Item> Items { get; set; }
    }
}