using System;
using System.Collections.Generic;
using HobbyTracker.Models;
using System.Linq;
using System.Web;

namespace HobbyTracker.ViewModels
{
    public class UserIndexData
    {
        public IEnumerable<Collection> Collections { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}