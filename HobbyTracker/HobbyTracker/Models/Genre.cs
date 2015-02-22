using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HobbyTracker.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }

        public virtual IEnumerable<Collection> Collections { get; set; }
    }
}