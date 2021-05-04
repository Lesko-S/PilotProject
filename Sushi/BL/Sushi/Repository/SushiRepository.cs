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
            var item = _sushiProps.FirstOrDefault(x => x.SushiName == name);
            // logic
            return item;
        }
    }
}
