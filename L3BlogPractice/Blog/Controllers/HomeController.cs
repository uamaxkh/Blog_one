using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBLib.Models;
using System.Diagnostics; //!Debug

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        //Списки, необхідні для створення форм
        //Список для виведення інформації про користувача
        public static List<string> parameterListForForm = new List<string>() { "Ім'я", "Дата реєстрації", "Електронна пошта", "Звідки дізналися про нас", "Що п'єш зранку", "ID" };
        //Список "як знайшли наш блог"
        public static List<string> wayToFindBlogList = new List<string>() { "Порада друзів", "Реклама", "Соцмережі", "Пошук в Google", "Мама сказала", "Само зайшло", "Вірус" };
        //Список "Що п'єш зранку"
        public static List<string> favoriteDrinkList = new List<string>() { "Чай", "Кава", "Молоко", "Сік", "Вода", "Розсіл" };

        //Головна сторінка зі статтями
        public ActionResult Index()
        {
            ViewBag.Title = "Головна";

            //Отримуємо всі статті
            List <Article> articlesDB = DBLib.DBCommands.GetAllArticles();

            //!!!Передавати в part.view
            ViewData["VotingList"] = DBLib.DBCommands.GetVotingList();

            return View(articlesDB);
        }

        [HttpGet]
        public ActionResult Guests()
        {
            ViewBag.Title = "Гостьова";

            List<Review> reviewsDB = DBLib.DBCommands.GetAllReviews();
            ViewBag.reviews = reviewsDB;
            return View();
        }

        //Сторінка коментарів
        [HttpPost]
        public ActionResult Guests(Review review)
        {
            ViewBag.Title = "Гостьова";

            List<Review> reviewsDB;

            if (ModelState.IsValid)
            {
                DBLib.DBCommands.AddReview(review);
            }
            else
            {
                reviewsDB = DBLib.DBCommands.GetAllReviews();
                ViewBag.reviews = reviewsDB;

                return View();
            }

            //Отримуємо всі коментарі з БД
            reviewsDB = DBLib.DBCommands.GetAllReviews();
            ViewBag.reviews = reviewsDB;

            return View();
        }

        //Сторінка з анкетою
        [HttpGet]
        public ActionResult ProfileAdd()
        {
            ViewBag.Title = "Анкета";

            //Передача списків параметрів для створення елементів форми
            List<string> hobbiesList = DBLib.DBCommands.GetHobbiesStringList();
            if(hobbiesList.Count == 0)
            {
                DBLib.Models.MessageBag mb = new DBLib.Models.MessageBag() { Message = "Виникла помилка при відображенні даних: хобі не були завантажені" };
                return RedirectToAction("Error", "Home", mb);
            }
            ViewData["hobbies"] = hobbiesList;
            ViewData["wayToFindBlog"] = wayToFindBlogList;
            ViewData["favoriteDrink"] = favoriteDrinkList;

            return View();
        }
        [HttpPost]
        public ActionResult ProfileAdd(string name, string email, string wayToFindBlog, List<string> hobbies, string favoriteDrink)
        {
            ViewBag.Title = "Анкета";

            Profile profile = new Profile(name, email, wayToFindBlog, favoriteDrink);

            //Додаємо в БД
            DBLib.DBCommands.AddUser(profile, hobbies);
            ViewData["parameterListForForm"] = parameterListForForm;

            return View("ProfileShow", profile);
        }

        //Сторінка показу результатів анкетування
        //Навмисне беруться дані з БД для перевірки того, чи коректно були
        //записані дані користувача, хоча можна було просто об'єкт Profile передати
        public ActionResult ProfileShow()
        {
            ViewBag.Title = "Анкета заповнена";

            //Отримання останнього доданого користувача
            Profile profile = DBLib.DBCommands.GetLastUser();

            //Якщо не отримано користувача, виводимо сторінку з помилкою
            if (profile == null)
            {
                DBLib.Models.MessageBag mb = new DBLib.Models.MessageBag() { Message = "Виникла помилка при відображенні даних" };
                return RedirectToAction("Error", "Home", mb);
            }

            //Передача списку параметрів для відображення
            ViewData["parameterListForForm"] = parameterListForForm;

            //Передача користувача у форму
            return View(profile);
        }

        //Сторінка виведення помилки
        public ActionResult Error(DBLib.Models.MessageBag ErrMessage)
        {
            ViewBag.Title = "Помилка";

            //Передане повідомлення помилки
            return View(ErrMessage);
        }

        [HttpGet]
        public ActionResult ViewMore(int? Id)
        {
            try
            {
                if(Id == null)
                {
                    throw new Exception();
                }
                
                Article article = DBLib.DBCommands.GetArticleById((int)Id);
                return View(article);
            }
            catch
            {
                DBLib.Models.MessageBag mb = new DBLib.Models.MessageBag() { Message = "Такої статті не існує" };
                return RedirectToAction("Error", "Home", mb);
            }
        }

        [HttpGet]
        public ActionResult VoteResults()
        {
                List<Voting> votingList = DBLib.DBCommands.GetVotingList();
                return View(votingList);
        }

        [HttpPost]
        public ActionResult VoteResults(int? voteSelected)
            {
            try
            {
                if (voteSelected != null)
                {
                    DBLib.DBCommands.SaveVoting((int)voteSelected);
                }
                List<Voting> votingList = DBLib.DBCommands.GetVotingList();
                return View(votingList);
            }
            catch
            {
                DBLib.Models.MessageBag mb = new DBLib.Models.MessageBag() { Message = "Помилка при голосуванні - такий варіант відповіді не передбачений. Зверніться до адміністратора." };
                return RedirectToAction("Error", "Home", mb);
            }
        }
    }
}