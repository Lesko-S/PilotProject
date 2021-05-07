using Sushi.BL.Logger;
using Sushi.BL.Sushi.Repository;
using System;

namespace Sushi.BL.Sushi
{
    class AdminRoot
    {
        static object locker = new object();
        internal void Logic()
        {
            SushiProp sushiProp = new SushiProp();
            SushiRepository sushi = new SushiRepository();
            AdminRoot ar = new AdminRoot();
            MyLogger logger = new MyLogger();
            int userChoice = 5;
            Console.WriteLine("Вы зашли под правами администратора!!!");
            while (userChoice != 0)
            {
                Console.WriteLine("Что желате сделать? \n " +
                    "1. Создать и добавить новые суши \n " +
                    "2. Удалить имеющиеся суши \n " +
                    "3. Изменить имеющиеся суши \n " +
                    "0. Все сделано. Завершить программу");
                int.TryParse(Console.ReadLine(), out userChoice);
                switch (userChoice)
                {
                    case 1:
                        lock (sushiProp)
                        {
                        Console.WriteLine("Введите название новых суши:");
                        sushiProp.SushiName = Console.ReadLine();
                        Console.WriteLine("Введите описание новых суши:");
                        sushiProp.Description = Console.ReadLine();
                        Console.WriteLine("Введите колличество новых суши:");
                        sushiProp.NumberOfRolls = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите вес новых суши:");
                        sushiProp.Weight = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите цену на новые суши");
                        sushiProp.Price = Convert.ToDouble(Console.ReadLine());
                        sushi.Create(sushiProp);
                        logger.Info("Create new sushi by Admin", ar.GetType().ToString());
                        }
                        break;
                    case 2:
                        lock (sushiProp)
                        {
                            Console.WriteLine("Введите название суши которые хотите удалить:");
                            sushiProp.SushiName = Console.ReadLine();
                            sushi.Delete(sushiProp.SushiName);
                            logger.Info("Delete sushi by Admin", ar.GetType().ToString());
                        }
                        break;
                    case 3:
                        lock (sushiProp)
                        {
                            Console.WriteLine("Введите название суши которые хотите изменить:");
                            sushiProp.SushiName = Console.ReadLine();
                            sushi.Update(sushiProp.SushiName);
                            logger.Info("Update sushi by Admin", ar.GetType().ToString());
                        }
                        break;
                    default:
                        lock (sushiProp)
                        {
                            userChoice = 0;
                            logger.Info("Admin clos app", ar.GetType().ToString());
                        }
                        break;
                }
            }
        }
    }
}
