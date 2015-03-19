using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hobo.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}