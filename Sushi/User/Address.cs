using Newtonsoft.Json;
using Sushi.BL.Logger;
using Sushi.Property;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sushi.User
{
    class Address
    {
        private static IList<Order> _order = new List<Order>();
        private int _counter = 1;
        internal void AddAddressForCourier(double prise)
        {
            Order order = new Order();
            MyLogger logger = new MyLogger();
            Address a = new Address();

            Console.WriteLine("Осталось совсем немного! \nКуда доставим суши?\n Укажите улицу:");
            order.Street = Console.ReadLine();
            Console.WriteLine("Укажите дом:");
            order.House = Console.ReadLine();
            Console.WriteLine("Укажите квартиру (Если это офисное здание или частный дом нажмите Enter для продолжения)");
            order.Apartment = Console.ReadLine();
            Console.WriteLine("Укажите номер телефона для связи в формате +375_________");
            order.Number = Console.ReadLine();
            Console.WriteLine("Данные будут переданы курьеру, с вами свяжутся");
            Console.WriteLine("Благодарим за заказ. До новых встреч!");
            order.Prise = prise;
           
            _order.Add(order);
            using (StreamWriter fileOrder = File.CreateText(@"OrderToCourier"+_counter+".txt"))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(fileOrder, _order);
                logger.Info("Create file orderToCourier", a.GetType().ToString());
            }
            _counter++;
        }
    }
}
