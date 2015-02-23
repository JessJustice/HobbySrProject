﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyTracker.Models
{
    public class CollectionItem
    {
        public int CollectionItemID { get; set; }
        
        [ForeignKey("Collection")]
        [Column(Order = 1)]
        public int CollectionID { get; set; }
        
        [ForeignKey("Item")]
        [Column(Order = 2)]
        public int ItemID { get; set; }

        public virtual Collection Collection { get; set; }
        public virtual Item Item { get; set; }
    }
}