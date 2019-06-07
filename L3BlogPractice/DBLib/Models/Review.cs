using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Models
{
    //Клас відгуків для сторінки Гостьова
    public class Review : BaseEntity
    {
        [Required(ErrorMessage = "Введіть своє ім'я")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Ім'я має містити від 2 до 15 символів")]
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Коментар має містити від 3 до 200 символів")]
        public string Text { get; set; }
    }
}
