using Newtonsoft.Json;
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
            using (StreamReader file = File.OpenText(@"D:\C#\Project\Sushi\BL\Sushi\Repository\sushi.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<SushiProp> sushiProps = (List<SushiProp>)serializer
                    .Deserialize(file, typeof(List<SushiProp>));
                _sushiProps.AddRange(sushiProps);
            }
            _sushiProps.Add(sushiProp);
            using (StreamWriter file = File.CreateText(@"D:\C#\Project\Sushi\BL\Sushi\Repository\sushi.json"))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(file, _sushiProps);
            }
            return _sushiProps;
        }
        public SushiProp Delete(string name)
        {
            using (StreamReader file = File.OpenText(@"D:\C#\Project\Sushi\BL\Sushi\Repository\sushi.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<SushiProp> sushiProps = (List<SushiProp>)serializer
                    .Deserialize(file, typeof(List<SushiProp>));
                _sushiProps.AddRange(sushiProps);
            }
            var item = _sushiProps.FirstOrDefault(x => x.SushiName == name);
            _sushiProps.Remove(item);
            return item;
            using (StreamWriter file = File.CreateText(@"D:\C#\Project\Sushi\BL\Sushi\Repository\sushi.json"))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(file, _sushiProps);
            }
        }
        public SushiProp Update(string name)
        {
            using (StreamReader file = File.OpenText(@"D:\C#\Project\Sushi\BL\Sushi\Repository\sushi.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<SushiProp> sushiProps = (List<SushiProp>)serializer
                    .Deserialize(file, typeof(List<SushiProp>));
                _sushiProps.AddRange(sushiProps);
            }
            var item = _sushiProps.FirstOrDefault(x => x.SushiName == name);
            int userChoice = 5;
            while (userChoice != 0)
            {
                Console.WriteLine("Что желате поменять? \n " +
                    "1. Название суши \n " +
                    "2. Колличество суши \n " +
                    "3. Цену \n. " +
                    "0. Все сделано");
                int.TryParse(Console.ReadLine(), out userChoice);
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Введите новое название:");
                        item.SushiName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Введите новое колличество суши:");
                        item.NumberOfRolls = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Введите новую цену на данные суши");
                        item.Price = Convert.ToDouble (Console.ReadLine());
                        break;
                    default:
                        userChoice = 0;
                        break;
                }
            }
            using (StreamWriter file = File.CreateText(@"D:\C#\Project\Sushi\BL\Sushi\Repository\sushi.json"))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(file, _sushiProps);
            }
            return item;
        }
    }
}
