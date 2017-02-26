using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Factories
{
    public interface GameFactory
    {
        Game Get();
        Game Get(int gamesize);

    }
}
