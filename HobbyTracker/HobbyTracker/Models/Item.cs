using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyTracker.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        [Display(Name = "Item")]
        public string ItemName { get; set; }
        [Display(Name = "Description")]
        public string ItemDesc { get; set; }
        public int? GenreID { get; set; }


        public virtual Genre Genre { get; set; }
        public virtual Collection Collection { get; set; }
    }
}