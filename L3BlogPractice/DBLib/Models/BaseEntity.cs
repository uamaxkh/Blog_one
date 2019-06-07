using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLib.Models
{
    //Базовий клас для всіх класів моделі БД
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
