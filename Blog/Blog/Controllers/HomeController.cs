using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using System.Diagnostics; //!del

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> hobbiesList = new List<string>() { "Туризм", "Книги", "Диван", "Спорт", "Сон", "Їжа", "Ігри", "Фільми"};
        public static List<string> parameterListForForm = new List<string>() { "Ім'я", "Дата народження", "Електронна пошта", "Звідки дізналися про нас", "Хоббі", "Що п'єш зранку" };
        public static List<string> wayToFindBlogList = new List<string>() { "Порада друзів", "Реклама", "Соцмережі", "Пошук в Google", "Мама сказала", "Само зайшло", "Вірус" };
        public static List<string> favoriteDrinkList = new List<string>() { "Чай", "Кава", "Молоко", "Сік", "Вода", "Розсіл" };

        public static List<Article> articles = new List<Article>() {
            new Article() {
                Name = "Аквальний ландшафт",
                Date = new DateTime(2010, 2, 16),
                Text = "Аквальний ландшафт — аквальний комплекс у межах ландшафтної оболонки Землі. Вирізняється з-поміж інших походженням, сталим гідрологічним режимом, геологічним фундаментом, однотипним донним рельєфом та біоценозами."
            },
            new Article()
            {
                Name = "Жовті Води",
                Date = new DateTime(2011, 6, 05),
                Text = "Жо́вті Во́ди — місто обласного значення у Дніпропетровській області. Сьоме за чисельністю населення місто області.Жовті Води розташовані на заході Дніпропетровської області на межі з Кіровоградською областю. Через місто протікає річка Жовта, вище за течією на відстані 0,5 км розташоване село Миролюбівка (П'ятихатський район), нижче за течією на відстані 0,5 км розташоване село Мар'янівка (П'ятихатський район)."
            },
            new Article()
            {
                Name = "Фізико-географічне районування",
                Date = new DateTime(2013, 12, 24),
                Text = "Районува́ння фі́зико-географі́чне (рос. райони́рование фи́зико-географи́ческое, англ. physical and geographical regionalization, нім. physikalisch-geographische Rayonierung f) — система територіального поділу земної поверхні на супідрядні природні регіони, які відрізняються комплексом природних властивостей, зумовлених їхнім положенням, історією розвитку та характером фізико-географічних процесів. При цьому виділяються територіальні підрозділи з неповторним комплексом ознак, викликаних місцевими особливостями рельєфу, клімату, рослинності, будовою фундаменту і платформенного чохла, діяльністю людини тощо. На рівнинах виділені райони відрізняються однорідною геологічною будовою, переважанням одного типу рельєфу, єдиним кліматом, однотипним поєднанням гідрогеологічних умов, ґрунтів, біоценозів.У горах райони можуть охоплювати місцеву систему окремих масивів і міжгірських западин і т.д."
            },
            new Article()
            {
                Name = "Ландшафт",
                Date = new DateTime(2014, 01, 15),
                Text = "Ландша́фт  (від нім. Landschaft — вигляд простору, краєвид, місцевість) — конкретна територія, однорідна за своїм походженням та історією розвитку, неподільна за зональними і азольнальними ознаками, що має єдиний геологічний фундамент, однотипний рельєф, спільний клімат, подібним сполученням гідротермічних умов, ґрунтів, біоценезів і певною структурою. Ландшафт є цілісною частиною географічної оболонки Землі, що утворилася в результаті складної й тривалої взаємодії усіх компонентів планети(клімату, гірських порід, рельєфу, води, повітря, біоти тощо) в певних умовах середовища, і як наслідок — набула характерного вигляду в просторі.Відтак, якщо у загальному розумінні, ландшафт — це будь - який простір з характерним виглядом, то у географічному — це простір з характерним виглядом у межах ландшафтної оболонки Землі."
            },
            new Article()
            {
                Name = "Автономні ландшафти",
                Date = new DateTime(2016, 5, 30),
                Text = "Автоно́мні ландша́фти — елементарні ландшафти вододілів, де процеси ґрунтоутворення і розвиток рослинності відбувається незалежно від ґрунтових вод. А.л. характеризуються відсутністю надходження матеріалу шляхом рідкого і твердого бокового стоку: заміна матеріалу здійснюється шляхом стоку і просочування."
            }

        };
        public static List<Review> reviews = new List<Review>() {
            new Review()
            {
                AuthorName = "Username",
                Date = new DateTime(2010, 2, 16),
                Text = "Not bad"
            },
            new Review()
            {
                AuthorName = "Кнопка",
                Date = new DateTime(2011, 6, 05),
                Text = "Very long long long long long long long long long long long comment"
            },
            new Review()
            {
                AuthorName = "Man",
                Date = new DateTime(2013, 12, 24),
                Text = "Hay man"
            },
            new Review()
            {
                AuthorName = "OMG",
                Date = new DateTime(2014, 01, 15),
                Text = "OMG! Wnat happened!?"
            },
            new Review()
            {
                AuthorName = "Comment Author",
                Date = new DateTime(2016, 5, 30),
                Text = "I`m author of this comment"
            },


        };

        public ActionResult Index()
        {
            ViewBag.Title = "Головна";

            return View(articles);
        }

        public ActionResult Guests(string Name, string Comment)
        {

            DateTime thisDay = DateTime.Now;
            ViewBag.Title = "Гостьова";

            if (Name != null && Comment != null)
            {
                reviews.Add(new Review()
                {
                    AuthorName = Name,
                    Date = thisDay,
                    Text = Comment
                });
            }

            return View(reviews);
        }

        public ActionResult ProfileAdd(string Name, string BirthDate, string email, string wayToFindBlog, string[] Hobbies, string favoriteDrink)
        {
            ViewBag.Title = "Анкета";

            if (Name != null || email != null)
            {
                string HobbiesString = "";
                foreach (var str in Hobbies)
                {
                    HobbiesString += str.ToLower() + ", ";
                }
                HobbiesString = HobbiesString.Substring(0, HobbiesString.Length - 2);

                Profile profile = new Profile(Name, BirthDate, email, wayToFindBlog, HobbiesString, favoriteDrink);
                return RedirectToAction("ProfileShow", "Home", profile);
            }

            ViewData["hobbies"] = hobbiesList;
            ViewData["wayToFindBlog"] = wayToFindBlogList;
            ViewData["favoriteDrink"] = favoriteDrinkList;

            return View();
        }
        
        public ActionResult ProfileShow(Profile prof)
        {
            ViewBag.Title = "Анкета заповнена";
            
            ViewData["prof"] = prof;
            ViewData["parameterListForForm"] = parameterListForForm;
            return View();
        }
    }
}