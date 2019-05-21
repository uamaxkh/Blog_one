using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Profile
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string email { get; set; }
        public string wayToFindBlog { get; set; }
        public string Hobbies { get; set; }
        public string favoriteDrink { get; set; }

        public Profile(string Name, string BirthDate, string email,
            string wayToFindBlog, string Hobbies, string favoriteDrink)
        {
            this.Name = Name;
            this.BirthDate = BirthDate.Substring(0, 4) + BirthDate.Substring(7, 3) + BirthDate.Substring(4, 3);
            this.email = email;
            this.wayToFindBlog = wayToFindBlog;
            this.Hobbies = Hobbies;
            this.favoriteDrink = favoriteDrink;
        }

        public Profile()
        {

        }
    }
}