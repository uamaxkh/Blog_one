using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Models
{
    public class Profile : BaseEntity
    {
        //Клас профілю (анкети)
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string WayToFindBlog { get; set; }
        public virtual ICollection<Hobby> Hobbies { get; set; } //!!! Прибрати virtual, щоб був доступ без контексту?
        public string FavoriteDrink { get; set; }

        //Визначаємо список хобі для можливості їх додавання
        //через Entity Framework (у відношення багато-багато)
        public Profile()
        {
            Hobbies = new List<Hobby>();
        }

        public Profile(string name, string email, string wayToFindBlog, string favoriteDrink, List<Hobby> hobbies)
        {
            Name = name;
            RegistrationDate= DateTime.Today;
            Email = email;
            WayToFindBlog = wayToFindBlog;
            FavoriteDrink = favoriteDrink;
            Hobbies = hobbies;
        }
        public Profile(string name, string email, string wayToFindBlog, string favoriteDrink)
        {
            Name = name;
            RegistrationDate = DateTime.Today;
            Email = email;
            WayToFindBlog = wayToFindBlog;
            FavoriteDrink = favoriteDrink;
            Hobbies = new List<Hobby>();
        }
    }
}
