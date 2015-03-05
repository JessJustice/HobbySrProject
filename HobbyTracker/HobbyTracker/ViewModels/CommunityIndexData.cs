using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HobbyTracker.Models;

namespace HobbyTracker.ViewModels
{
    public class CommunityIndexData
    {
        public IEnumerable<Community> Communities { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}