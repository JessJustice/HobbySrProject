﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HobbyTracker.Models
{
    public class Item
    {
 
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }
        
      //  public virtual IEnumerable<Collection> Collections { get; set; }
        public virtual Collection Collection { get; set; }
    }
}