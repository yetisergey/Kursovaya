using System;

namespace Data
{
    class Program
    {
        static void Main(string[] args)
        {

            using (PurchaseContext db = new PurchaseContext())
            {
                // создаем два объекта User
                Purchase pur1 = new Purchase { Id = 1, Fio = "Масленников Сергей Андреевич", PasportId = "12839011", Telephone = "8937510144", Idtovar = "1", Idyslugi = null, Price = 10000 };
                Purchase pur2 = new Purchase { Id = 2, Fio = "Бальзамов Александр Витальевич", PasportId = "1122221", Telephone = "89093280505", Idtovar = "2", Idyslugi = null, Price = 12000 };
                try
                {
                    // добавляем их в бд
                    db.Purchases.Add(pur1);
                    db.Purchases.Add(pur2);
                    db.SaveChanges();
                    Console.WriteLine("Объекты успешно сохранены");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}