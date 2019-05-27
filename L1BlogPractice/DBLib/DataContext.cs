namespace DBLib
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using DBLib.Models;

    public class DataContext : DbContext
    {
        // Контекст для використання рядка підключення "DataContext" з файлу конфігурації
        public DataContext()
            : base("DataContext")
        {
        }

        //Списки для зберігання всіх об'єктів основних сутностей
        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Review> Reviews { get; set; }
        public IDbSet<Profile> Profiles { get; set; }
        public IDbSet<Hobby> Hobbies { get; set; }
    }
}