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

            return View(articlesDB);
        }

        //Сторінка коментарів
        public ActionResult Guests(string Name, string Comment)
        {
            ViewBag.Title = "Гостьова";


            if (Name != null && Comment != null)
            {
                //Якщо користувач заповнив форму, додаємо коментар в БД
                DBLib.DBCommands.AddReview(Name, Comment);
            }

            //Отримуємо всі коментарі з БД
            List<Review> reviewsDB = DBLib.DBCommands.GetAllReviews();

            return View(reviewsDB);
        }

        //Сторінка з анкетою
        public ActionResult ProfileAdd(string Name, string email, string wayToFindBlog, List<string> Hobbies, string favoriteDrink)
        {
            ViewBag.Title = "Анкета";

            //Перевірка, чи заповнена форма (перевірка всіх полів форми є в самій формі)
            if (Name != null || email != null)
            {
                //Додаємо в БД
                DBLib.DBCommands.AddUser(Name, email, wayToFindBlog, Hobbies, favoriteDrink);

                return RedirectToAction("ProfileShow", "Home");
            }

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

        //Сторінка показу результатів анкетування
        //Навмисне беруться дані з БД для перевірки того, чи коректно були
        //записані дані користувача, хоча можна було просто об'єкт Profile передати
        public ActionResult ProfileShow()
        {
            ViewBag.Title = "Анкета заповнена";

            //Отримання останнього доданого користувача
            Profile profile = DBLib.DBCommands.GetLastUser();

            //Якщо не отримано користувача, виводимо сторінку з помилкою
            if(profile == null)
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
    }
}