using Newtonsoft.Json;
using Sushi.Property;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Sushi.BL.Sushi
{
    class Byer_sRights
    {
        private static IList<SushiProp> _sushiProps = new List<SushiProp>();
        internal void Logic()
        {
            using (StreamReader file = File.OpenText(Constant.WayToSushi))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<SushiProp> sushiProps = (List<SushiProp>)serializer
                    .Deserialize(file, typeof(List<SushiProp>));
                int userChoice = 1000;
                int counter = 0;
                Console.WriteLine("Какие суши желаете?");
                foreach (var item in sushiProps)
                {
                    Console.WriteLine($@"{counter + 1}. Суши: {item.SushiName},\n
                            Описание: {item.Description},\n 
                            Вес: {item.Weight},\n
                            Колличество суши: {item.NumberOfRolls},\n
                            Цена: {item.Price}p.");
                    counter++;
                }
                Console.WriteLine("0. Я выбрал все что хотел.");
                while (userChoice != 0)
                {
                    int.TryParse(Console.ReadLine(), out userChoice);
                    try
                    {
                        _sushiProps.Add(sushiProps[userChoice]);
                    }
                    catch (Exception)
                    {
                        // log
                        throw;
                    }
                    Console.WriteLine("Желаете еще что-нибудь?");
                }
                Console.WriteLine("Ваш заказ:");
                double allPrise = 0;
                foreach (var item in _sushiProps)
                {
                    Console.WriteLine(item.SushiName);
                    allPrise += item.Price;
                }
                Console.WriteLine($@"Общая стоимость составит: {allPrise}p.");
                SendMail sendMail = new SendMail();
                using (StreamWriter fileOrder = File.CreateText(@"Sushi\BL\Sushi\Repository\Order.txt"))
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    jsonSerializer.Serialize(fileOrder, _sushiProps);
                }
                Program program = new Program();
                Console.WriteLine("Благодарим за заказ");
                if (program.EMail != null)
                {
                    sendMail.SendEmailDefault();
                }
            }
        }
    }
}
