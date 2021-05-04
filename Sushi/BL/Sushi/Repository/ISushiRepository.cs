using System.Collections.Generic;

namespace Sushi.BL.Sushi.Repository
{
    interface ISushiRepository
    {
        List<SushiProp> Create(SushiProp sushiProp);
        SushiProp Get(int id);
        SushiProp Update(int id);
        SushiProp Delete(int id);
    }
}
