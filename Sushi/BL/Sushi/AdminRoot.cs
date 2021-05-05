using Sushi.BL.Sushi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.BL.Sushi
{
    class AdminRoot
    {
        internal void Logic()
        {
            SushiProp sushiProp = new SushiProp();
            SushiRepository sushi = new SushiRepository();
            int userChoice = 5;
            while (userChoice != 0)
            {
                Console.WriteLine("Вы зашли под правами администратора!!!");
                Console.WriteLine("Что желате сделать? \n " +
                    "1. Создать и добавить новые суши \n " +
                    "2. Удалить имеющиеся суши \n " +
                    "3. Изменить имеющиеся суши \n. " +
                    "0. Все сделано. Завершить программу");
                int.TryParse(Console.ReadLine(), out userChoice);
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Введите название новых суши:");
                        sushiProp.SushiName = Console.ReadLine();
                        Console.WriteLine("Введите колличество новых суши:");
                        sushiProp.NumberOfRolls = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите цену на новые суши");
                        sushiProp.Price = Convert.ToInt32(Console.ReadLine());
                        sushi.Create(sushiProp);
                        break;
                    case 2:
                        Console.WriteLine("Введите название суши которые хотите удалить:");
                        sushiProp.SushiName = Console.ReadLine();
                        sushi.Delete(sushiProp.SushiName);
                        break;
                    case 3:
                        Console.WriteLine("Введите название суши которые хотите изменить:");
                        sushiProp.SushiName = Console.ReadLine();
                        sushi.Update(sushiProp.SushiName);
                        break;
                    default:
                        userChoice = 0;
                        break;
                }

            }
        }
    }
}
