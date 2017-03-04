using SimpleGame.Common.Entities;
using SimpleGame.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Data.DataAccessLayers
{
    public interface DAL
    {
        Game Get(Guid gameId);
        IEnumerable<Game> Get(GameStatus gameStatus);
        void Save(Game game);
        IEnumerable<Game> Get();
    }
}
