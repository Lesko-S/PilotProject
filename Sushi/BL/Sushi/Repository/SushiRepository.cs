using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.BL.Sushi.Repository
{
    class SushiRepository : ISushiRepository
    {
        private static List<SushiProp> _sushiProps = new List<SushiProp>();
        public List<SushiProp> Create(SushiProp sushiProp)
        {
            _sushiProps.Add(sushiProp);
            return _sushiProps;

        }

        public SushiProp Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SushiProp Get(int id)
        {
            throw new NotImplementedException();
        }

        public SushiProp Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
