using System;
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
                    Database.SetInitializer<BaseContext>(new DbDeleteandInit());
                    Console.WriteLine("Удаление и создание базы");
                    //Железобетон
                    Product pr1 = new Product { Name = "ФБС - фундаментные блоки сплошные", NameGroup = Namegroup.IronBeton, Price = 250 };
                    Product pr2 = new Product { Name = "ФЛ - фундаментная подушка", NameGroup = Namegroup.IronBeton, Price = 2000 };
                    db.Products.Add(pr1);
                    db.Products.Add(pr2);
                    db.Products.Add(new Product { Name = "П - плиты перекрытий и покрытий", NameGroup = Namegroup.IronBeton, Price = 2200 });
                    db.Products.Add(new Product { Name = "ПЛ - плиты лоджий", NameGroup = Namegroup.IronBeton, Price = 1900 });
                    db.Products.Add(new Product { Name = "ПП - плиты парапетные", NameGroup = Namegroup.IronBeton, Price = 220 });
                    //асфальтобетон
                    db.Products.Add(new Product { Name = "Литой асфальтобетон", NameGroup = Namegroup.AsphaltBeton, Price = 5500 });
                    db.Products.Add(new Product { Name = "Горячие и теплые смеси", NameGroup = Namegroup.AsphaltBeton, Price = 10000 });
                    db.Products.Add(new Product { Name = "Холодный асфальтобетон", NameGroup = Namegroup.AsphaltBeton, Price = 4500 });
                    //керамзитобетон
                    db.Products.Add(new Product { Name = "Конструктивный", NameGroup = Namegroup.KeramzBeton, Price = 2505 });
                    db.Products.Add(new Product { Name = "Теплоизоляционный", NameGroup = Namegroup.KeramzBeton, Price = 3000 });
                    db.Products.Add(new Product { Name = "теплоизоляционно-конструктивный", NameGroup = Namegroup.KeramzBeton, Price = 5600 });
                    //силикатный бетон
                    db.Products.Add(new Product { Name = "Тяжелый силикатный бетон", NameGroup = Namegroup.SilicBeton, Price = 3200 });
                    db.Products.Add(new Product { Name = "Легкий силикатный бетон", NameGroup = Namegroup.SilicBeton, Price = 2200 });
                    db.Products.Add(new Product { Name = "Ячеистый силикатный бетон", NameGroup = Namegroup.SilicBeton, Price = 4000 });
                    db.Products.Add(new Product { Name = "Мелкозернистыми", NameGroup = Namegroup.SilicBeton, Price = 5000 });
                    //гидротехнический бетон
                    db.Products.Add(new Product { Name = "Надводный", NameGroup = Namegroup.HidroBeton, Price = 3000 });
                    db.Products.Add(new Product { Name = "Подводный", NameGroup = Namegroup.HidroBeton, Price = 3500 });
                    db.Products.Add(new Product { Name = "Промежуточный", NameGroup = Namegroup.HidroBeton, Price = 4000 });
                    //перлитобетон
                    db.Products.Add(new Product { Name = "Мелкозернистый циркониевый", NameGroup = Namegroup.PerlitBeton, Price = 5000 });
                    db.Products.Add(new Product { Name = "Жаростойкий шамотный", NameGroup = Namegroup.PerlitBeton, Price = 4090 });
                    db.SaveChanges();

                    //покупки
                    Purchase pur1 = new Purchase { Fio = "Масленников Сергей Андреевич", PasportId = "12839011", Telephone = "8937510144", IdProduct = pr1.IdProduct, Price = 10000, Counttovar = 40, Date = DateTime.Now };
                    Purchase pur2 = new Purchase { Fio = "Бальзамов Александр Витальевич", PasportId = "1122221", Telephone = "89093280505", IdProduct = pr2.IdProduct, Price = 12000, Counttovar = 2, Date = DateTime.Now };
                    db.Purchases.Add(pur1);
                    db.Purchases.Add(pur2);

                    db.SaveChanges();
                    Console.WriteLine("Изменения сохранены");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

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