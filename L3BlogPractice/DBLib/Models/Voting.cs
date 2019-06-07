using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DBLib.Models
{
    public class Voting : BaseEntity
    {
        public string Name { get; set; }
        public int Voted { get; set; }
    }
}