using SimpleGame.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Entities
{
    public interface GameManager
    {
        IEnumerable<Game> GetGames();
        Game Get(string id);
        Game Create();
        void Join(Player player, Game game);
    }
}
