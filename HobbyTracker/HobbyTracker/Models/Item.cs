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
        //[Display(Name = "Name")]
       // public int UserID { get; set; }

      //  public virtual User User { get; set; }
        
      //  public virtual IEnumerable<CollectionItem> CollectionItems { get; set; }
        public virtual Collection Collection { get; set; }
    }
}