using SimpleGame.Common.Entities;
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
        void Save(Game game);
        IEnumerable<Game> Get();
    }
}
