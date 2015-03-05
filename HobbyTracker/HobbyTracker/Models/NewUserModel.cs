using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HobbyTracker.Models
{
    public class NewUserModel
    {
        [Key]
        public int NewUserModelID { get; set; }

        //This is just a placeholder model so that a welcome page can be made for a new user to help
        //acquaint them with our software. No matter what I did, I was unable to add a new page to the 
        //Views folder for any of the models. I added it and ran it, but it would never show up. There was always
        //a server error. The work-around is having a basic model (therefore adding a new table to the database)
        //that will allow me to scaffold it. This adds a view model for it with an Index action that I can use
        //as the introduction page. If anyone figures out a better way, by all means go for it. This has taken hours already.
    }
}