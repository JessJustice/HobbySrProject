using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyTracker.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Display(Name = "Genre")]
        public string GenreName { get; set; }

        public virtual IEnumerable<Collection> Collections { get; set; }
        public virtual IEnumerable<Item> Items { get; set; }
    }
}