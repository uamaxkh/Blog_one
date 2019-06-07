using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Models
{
    //Клас хобі, які містяться в Profile
    public class Hobby : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }

        //Визначаємо список користувачів для можливості їх додавання
        //через Entity Framework (у відношення багато-багато)
        public Hobby()
        {
            Profiles = new List<Profile>();
        }
    }
}
