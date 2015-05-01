using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HobbyTracker.Models;

namespace HobbyTracker.ViewModels
{
    public class CommunityIndexData
    {
        public String NameSortParm { get; set; }
        public String DescSortParm { get; set; }

        public IEnumerable<Community> Communities { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}