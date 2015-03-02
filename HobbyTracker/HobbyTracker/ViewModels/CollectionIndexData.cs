using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HobbyTracker.Models;

namespace HobbyTracker.ViewModels
{
    public class CollectionIndexData
    {
        public IEnumerable<Collection> Collections { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public ApplicationUser User { get; set; }
    }
}