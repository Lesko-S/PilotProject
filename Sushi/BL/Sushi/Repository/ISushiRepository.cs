using System.Collections.Generic;

namespace Sushi.BL.Sushi.Repository
{
    interface ISushiRepository
    {
        List<SushiProp> Create(SushiProp sushiProp);
        SushiProp Update(string name);
        SushiProp Delete(string name);
    }
}
