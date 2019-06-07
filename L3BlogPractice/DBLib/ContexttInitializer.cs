using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLib.Models;

namespace DBLib
{
    //Клас ініціалізації БД : при кожному запуску - нова БД
    public class ContexttInitializer : DropCreateDatabaseAlways<DataContext>
    {
        //Викликається при запуску
        protected override void Seed(DataContext context)
        {
            //Створюємо списки необхідних об'єктів
            List<Tag> tagList = new List<Tag>
            {
                new Tag(){ Name = "Tag1"},
                new Tag(){ Name = "Tag2"},
                new Tag(){ Name = "Tag3"},
                new Tag(){ Name = "Tag4"},
                new Tag(){ Name = "Tag5"}
            };

            List<Voting> votingList = new List<Voting>
            {
                new Voting(){ Name = "ХНУРЕ", Voted = 10},
                new Voting(){ Name = "ХАІ", Voted = 3},
                new Voting(){ Name = "ХПІ", Voted = 8}
            };
            List<Article> articleList = new List<Article>
            {
                new Article() {
                    Name = "Аквальний ландшафт",
                    Date = new DateTime(2010, 2, 16),
                    Text = "Аквальний ландшафт — аквальний комплекс у межах ландшафтної оболонки Землі. Вирізняється з-поміж інших походженням, сталим гідрологічним режимом, геологічним фундаментом, однотипним донним рельєфом та біоценозами.",
                    Tags = new List<Tag>(){ tagList[0]}
                },
                new Article()
                {
                    Name = "Жовті Води",
                    Date = new DateTime(2011, 6, 05),
                    Text = "Жо́вті Во́ди — місто обласного значення у Дніпропетровській області. Сьоме за чисельністю населення місто області.Жовті Води розташовані на заході Дніпропетровської області на межі з Кіровоградською областю. Через місто протікає річка Жовта, вище за течією на відстані 0,5 км розташоване село Миролюбівка (П'ятихатський район), нижче за течією на відстані 0,5 км розташоване село Мар'янівка (П'ятихатський район).",
                    Tags = new List<Tag>(){ tagList[0]}
                },
                new Article()
                {
                    Name = "Фізико-географічне районування",
                    Date = new DateTime(2013, 12, 24),
                    Text = "Районува́ння фі́зико-географі́чне (рос. райони́рование фи́зико-географи́ческое, англ. physical and geographical regionalization, нім. physikalisch-geographische Rayonierung f) — система територіального поділу земної поверхні на супідрядні природні регіони, які відрізняються комплексом природних властивостей, зумовлених їхнім положенням, історією розвитку та характером фізико-географічних процесів. При цьому виділяються територіальні підрозділи з неповторним комплексом ознак, викликаних місцевими особливостями рельєфу, клімату, рослинності, будовою фундаменту і платформенного чохла, діяльністю людини тощо. На рівнинах виділені райони відрізняються однорідною геологічною будовою, переважанням одного типу рельєфу, єдиним кліматом, однотипним поєднанням гідрогеологічних умов, ґрунтів, біоценозів.У горах райони можуть охоплювати місцеву систему окремих масивів і міжгірських западин і т.д.",
                    Tags = new List<Tag>(){ tagList[0], tagList[1] }
                },
                new Article()
                {
                    Name = "Ландшафт",
                    Date = new DateTime(2014, 01, 15),
                    Text = "Ландша́фт  (від нім. Landschaft — вигляд простору, краєвид, місцевість) — конкретна територія, однорідна за своїм походженням та історією розвитку, неподільна за зональними і азольнальними ознаками, що має єдиний геологічний фундамент, однотипний рельєф, спільний клімат, подібним сполученням гідротермічних умов, ґрунтів, біоценезів і певною структурою. Ландшафт є цілісною частиною географічної оболонки Землі, що утворилася в результаті складної й тривалої взаємодії усіх компонентів планети(клімату, гірських порід, рельєфу, води, повітря, біоти тощо) в певних умовах середовища, і як наслідок — набула характерного вигляду в просторі.Відтак, якщо у загальному розумінні, ландшафт — це будь - який простір з характерним виглядом, то у географічному — це простір з характерним виглядом у межах ландшафтної оболонки Землі.",
                    Tags = new List<Tag>(){ tagList[2], tagList[4] }
                },
                new Article()
                {
                    Name = "Автономні ландшафти",
                    Date = new DateTime(2016, 5, 30),
                    Text = "Автоно́мні ландша́фти — елементарні ландшафти вододілів, де процеси ґрунтоутворення і розвиток рослинності відбувається незалежно від ґрунтових вод. А.л. характеризуються відсутністю надходження матеріалу шляхом рідкого і твердого бокового стоку: заміна матеріалу здійснюється шляхом стоку і просочування.",
                    Tags = new List<Tag>(){ tagList[0], tagList[1] , tagList[3], tagList[4] }
                }
            };

            List<Review> reviewList = new List<Review>
            {
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
                }
            };

            List<Hobby> hobbiesList = new List<Hobby>
            {
                new Hobby()
                {
                    Name = "Туризм"
                },
                new Hobby()
                {
                    Name = "Книги"
                },
                new Hobby()
                {
                    Name = "Диван"
                },
                new Hobby()
                {
                    Name = "Спорт"
                },
                new Hobby()
                {
                    Name = "Сон"
                },
                new Hobby()
                {
                    Name = "Їжа"
                },
                new Hobby()
                {
                    Name = "Ігри"
                },
                new Hobby()
                {
                    Name = "Фільми"
                },
            };

            //Додаємо їх до контексту і зберігаємо
            //Hobbies - обов'язковий для нормальної роботи сайту!
            tagList.ForEach(tag => context.Tags.Add(tag));
            votingList.ForEach(voting => context.Votings.Add(voting));
            hobbiesList.ForEach(hobby => context.Hobbies.Add(hobby));
            articleList.ForEach(article => context.Articles.Add(article));
            reviewList.ForEach(review => context.Reviews.Add(review));
            context.SaveChanges();
        }
    }
}