using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyTracker.Models

{
    public class Collection
    {
        public int CollectionID { get; set; }
        [Display(Name = "Collection")]
        public string CollectionName { get; set; }
       // [Display(Name = "Name")]
        public int UserID { get; set; }
       // [Display(Name = "Genre")]
        public int GenreID { get; set; }
       // [Display(Name = "Item")]
        public int ItemID { get; set; }

        public virtual User User { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual IEnumerable<Item> Items { get; set; }
    }
}