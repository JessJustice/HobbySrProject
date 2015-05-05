using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HobbyTracker.Models;

namespace HobbyTracker.ViewModels
{
    public class CollectionIndexData
    {
        //public string NameSortParm { get; set; }
        //public string GenreSortParm { get; set; }
        //public string PrivateSortParm { get; set; }
        public IEnumerable<Collection> Collections { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<CollectionItem> CollectionItems { get; set; }
    }
}