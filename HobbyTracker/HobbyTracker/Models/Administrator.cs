using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HobbyTracker.Models
{
    public class Administrator
    {
        [Key]
        public int AdminID { get; set; }
    }
}