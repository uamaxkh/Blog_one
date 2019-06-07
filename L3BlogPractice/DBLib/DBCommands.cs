using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLib.Models;

namespace DBLib
{
    public static class DBCommands
    {
        //Отримання всіх статей
        public static List<Article> GetAllArticles()
        {
            using(DataContext db = new DataContext())
            {
                var articlesDB = db.Articles.ToList();

                return articlesDB;
            }
        }

        //Отримання всіх коментарів
        public static List<Review> GetAllReviews()
        {
            using (DataContext db = new DataContext())
            {
                return db.Reviews.ToList();
            }
        }

        //Отримання останнього користувача
        public static Profile GetLastUser ()
        {
            DataContext db = new DataContext();
            try
            {
                //Сортуємо по спаданню й беремо одного - він буде останній
                //Include підвантажує пов'язані дані - хобі
                Profile profile = db.Profiles.OrderByDescending(x => x.Id).Take(1).Include(us => us.Hobbies).Single();
                return profile;
            }
            catch
            {
                //Якщо щось пішло не так, повертаємо null
                //Після обробки null перейде на сторінку з помилкою
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }


        //Додавання нового відгуку
        public static void AddReview(Review review)
        {
            //Отримання сьогоднішньої дати
            DateTime thisDay = DateTime.Now;

            using (DataContext db = new DataContext())
            {
                review.Date = thisDay;

                db.Reviews.Add(review);
                db.SaveChanges();
            }
        }

        //Додавання нового користувача (анкета)
        public static void AddUser(string nName, string nEmail,
            string nWayToFindBlog, List<string> nHobbies, string nFavoriteDrink)
        {
            using (DataContext db = new DataContext())
            {
                //Створення об'єкту профілю
                Profile profile = new Profile(nName, nEmail, nWayToFindBlog, nFavoriteDrink);

                //Прив'язуємо об'єкти хобі до профілю
                foreach(string hobbyString in nHobbies)
                {
                    Hobby hobby = db.Hobbies.Where(hb => hb.Name == hobbyString).Single();
                    profile.Hobbies.Add(hobby);
                }

                //Додаємо й зберігаємо в БД
                db.Profiles.Add(profile);
                db.SaveChanges();
            }
        }

        public static void AddUser(Profile profile, List<string> nHobbies)
        {
            using (DataContext db = new DataContext())
            {
                //Прив'язуємо об'єкти хобі до профілю
                foreach (string hobbyString in nHobbies)
                {
                    Hobby hobby = db.Hobbies.Where(hb => hb.Name == hobbyString).Single();
                    profile.Hobbies.Add(hobby);
                }

                //Додаємо й зберігаємо в БД
                db.Profiles.Add(profile);
                db.SaveChanges();
            }
        }

        //Отримання списку можливих хобі у вигляді рядків
        public static List<string> GetHobbiesStringList()
        {
            using (DataContext db = new DataContext())
            {
                List<Hobby> hobbiesList = db.Hobbies.ToList();
                List<string> hobbiesStringList = new List<string>();

                //Переводимо у список рядків
                foreach(var hb in hobbiesList)
                {
                    hobbiesStringList.Add(hb.Name);
                }

                return hobbiesStringList;
            }
        }

        public static Article GetArticleById(int Id)
        {
            using (DataContext db = new DataContext())
            {
                Article article = db.Articles.Where(art => art.Id == Id).Include(art => art.Tags).Single();
                return article;
            }
        }

        public static List<Voting> GetVotingList()
        {
            using (DataContext db = new DataContext())
            {
                List<Voting> votingList = db.Votings.ToList();
                return votingList;
            }
        }

        public static void SaveVoting(int voteId)
        {
            using (DataContext db = new DataContext())
            {
                Voting vote = db.Votings.Where(v => v.Id == voteId).Single();
                vote.Voted = ++vote.Voted;
                db.Entry(vote).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
