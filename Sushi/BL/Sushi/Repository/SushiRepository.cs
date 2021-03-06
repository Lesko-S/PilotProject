using Newtonsoft.Json;
using Sushi.Property;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sushi.BL.Sushi.Repository
{
    class SushiRepository : ISushiRepository
    {
        private static List<SushiProp> _sushiProps = new List<SushiProp>();
        public List<SushiProp> Create(SushiProp sushiProp)
        {
            _sushiProps.Clear();
            _sushiProps.Add(sushiProp);
            using (StreamReader file = File.OpenText(Constant.WayToSushi))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<SushiProp> sP2 = (List<SushiProp>)serializer
                    .Deserialize(file, typeof(List<SushiProp>));
                _sushiProps.AddRange(sP2);
            }
            using (StreamWriter file = File.CreateText(Constant.WayToSushi))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(file, _sushiProps);
            }
            return _sushiProps;
        }
        public  SushiProp Delete(string name)
        {
            _sushiProps.Clear();
            using (StreamReader file = File.OpenText(Constant.WayToSushi))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<SushiProp> sP2 = (List<SushiProp>)serializer
                    .Deserialize(file, typeof(List<SushiProp>));
                _sushiProps.AddRange(sP2);
            }
            var item = _sushiProps.FirstOrDefault(x => x.SushiName == name);
            _sushiProps.Remove(item);
            using (StreamWriter file = File.CreateText(Constant.WayToSushi))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(file, _sushiProps);
            }
            return null;
        }
        public SushiProp Update(string name)
        {
            _sushiProps.Clear();
            using (StreamReader file = File.OpenText(Constant.WayToSushi))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<SushiProp> sP2 = (List<SushiProp>)serializer
                    .Deserialize(file, typeof(List<SushiProp>));
                _sushiProps.AddRange(sP2);
                var item = _sushiProps.FirstOrDefault(x => x.SushiName == name);
                int userChoice = 6;
                while (userChoice != 0)
                {
                    Console.WriteLine("Что желате поменять? \n " +
                        "1. Название суши \n " +
                        "2. Описание  \n " +
                        "3. Колличество суши \n " +
                        "4. Вес суши \n " +
                        "5. Цену \n " +
                        "0. Все сделано");
                    int.TryParse(Console.ReadLine(), out userChoice);
                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine("Введите новое название:");
                            item.SushiName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Введите описание:");
                            item.Description = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Введите новое колличество суши:");
                            item.NumberOfRolls = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Введите вес суши");
                            item.Weight = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine("Введите новую цену на данные суши");
                            item.Price = Convert.ToDouble(Console.ReadLine());
                            break;
                        default:
                            userChoice = 0;
                            break;
                    }
                }
                return item;
            }
            using (StreamWriter file = File.CreateText(Constant.WayToSushi))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(file, _sushiProps);
            }
        }
    }
}
