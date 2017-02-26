using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Entities
{
    public interface GameRepository
    {
        void Save(Game game);
        Game Get(string id);
        IEnumerable<Game> GetAll();

    }
}
