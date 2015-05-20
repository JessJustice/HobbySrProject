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
        [Required]
        public string CollectionName { get; set; }
        // [Display(Name = "Genre")]
        public int GenreID { get; set; }
        public bool Private { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<CollectionItem> CollectionItems { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}