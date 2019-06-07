using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DBLib.Models
{
    //Клас статті
    public class Article : BaseEntity
    { 
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        //Визначаємо список хобі для можливості їх додавання
        //через Entity Framework (у відношення багато-багато)
        public Article()
        {
            Tags = new List<Tag>();
        }
    }
}