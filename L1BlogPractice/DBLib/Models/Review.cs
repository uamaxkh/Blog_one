using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Models
{
    //Клас відгуків для сторінки Гостьова
    public class Review : BaseEntity
    {
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
