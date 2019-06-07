using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DBLib.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        //Визначаємо список хобі для можливості їх додавання
        //через Entity Framework (у відношення багато-багато)
        public Tag()
        {
            Articles = new List<Article>();
        }
    }
}