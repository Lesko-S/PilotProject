using System;

namespace Sushi.BL
{
    class Greating
    {
        public void GoodPartOfDay(int hours)
        {
            switch (hours)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    Console.WriteLine("Доброй ночи!");
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                    Console.WriteLine("Доброе утро!");
                    break;
                case 13:
                case 14:
                case 15:
                    Console.WriteLine("Добрый день!");
                    break;
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    Console.WriteLine("Добрый вечер!");
                    break;
                case 23:
                    Console.WriteLine("Доброй ночи!");
                    break;
                case 24:
                default:
                    Console.WriteLine("Доброго дня суток!");
                    break;
            }
        }
    }
}
