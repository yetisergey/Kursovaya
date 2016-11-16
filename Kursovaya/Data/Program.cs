using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Data
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (BaseContext db = new BaseContext())
                {
                    Database.SetInitializer(new DbDeleteandInit());
                    Console.WriteLine("Удаление и создание базы");
                    //Железобетон
                    db.Products.Add(new Product { Name = "ФБС - фундаментные блоки сплошные", NameGroup = Namegroup.IronBeton, Price = 250, Count = 100 });
                    db.Products.Add(new Product { Name = "ФЛ - фундаментная подушка", NameGroup = Namegroup.IronBeton, Price = 2000, Count = 100 });
                    db.Products.Add(new Product { Name = "П - плиты перекрытий и покрытий", NameGroup = Namegroup.IronBeton, Price = 2200, Count = 100 });
                    db.Products.Add(new Product { Name = "ПЛ - плиты лоджий", NameGroup = Namegroup.IronBeton, Price = 1900, Count = 100 });
                    db.Products.Add(new Product { Name = "ПП - плиты парапетные", NameGroup = Namegroup.IronBeton, Price = 220, Count = 100 });
                    //асфальтобетон
                    db.Products.Add(new Product { Name = "Литой асфальтобетон", NameGroup = Namegroup.AsphaltBeton, Price = 5500, Count = 100 });
                    db.Products.Add(new Product { Name = "Горячие и теплые смеси", NameGroup = Namegroup.AsphaltBeton, Price = 10000, Count = 100 });
                    db.Products.Add(new Product { Name = "Холодный асфальтобетон", NameGroup = Namegroup.AsphaltBeton, Price = 4500, Count = 100 });
                    //керамзитобетон
                    db.Products.Add(new Product { Name = "Конструктивный", NameGroup = Namegroup.KeramzBeton, Price = 2505, Count = 100 });
                    db.Products.Add(new Product { Name = "Теплоизоляционный", NameGroup = Namegroup.KeramzBeton, Price = 3000, Count = 100 });
                    db.Products.Add(new Product { Name = "теплоизоляционно-конструктивный", NameGroup = Namegroup.KeramzBeton, Price = 5600, Count = 100 });
                    db.SaveChanges();

                    //покупки
                    Random rnd = new Random();
                    List<string> fio = new List<string>();
                    fio.Add("Масленников Сергей Андреевич");
                    fio.Add("Бальзамов Александр Витальевич");
                    fio.Add("Кольченко Артём Витальевич");
                    fio.Add("Арташкин Евгений Павлович");
                    fio.Add("Денискин Александр Александрович");
                    //Имена пользователей
                    DateTime st = new DateTime(2016,1,1);
                    DateTime en = new DateTime(2017,1,1);
                    for (var it = 0; it < 100; it++)
                    {
                        Console.WriteLine(it);
                        var tempid = rnd.Next(1, 12);
                        var tempcount = rnd.Next(25, 40);
                        db.Purchases.Add(new Purchase { Fio = fio[rnd.Next(0, 5)], IdProduct = tempid, Price = db.Products.Find(tempid).Price * tempcount, Counttovar = tempcount, Date =GetRandomDate(st,en) });
                    }
                    //пользователи Admin
                    db.UsersAdmin.Add(new User { Login = "sergey", Password = "yeti" });
                    db.SaveChanges();
                    Console.WriteLine("Изменения сохранены");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static readonly Random rnd = new Random();
        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
    }

    public class DbDeleteandInit : DropCreateDatabaseAlways<BaseContext>
    {
        protected override void Seed(BaseContext db)
        {
            base.Seed(db);
        }
    }
    public class DbInit : DropCreateDatabaseIfModelChanges<BaseContext>
    {
        protected override void Seed(BaseContext db)
        {
            base.Seed(db);
        }
    }
}