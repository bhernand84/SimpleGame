using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Data.DataAccessLayers;
using SimpleGame.Common.Entities;

namespace SimpleGame.Data.Repositories
{
    public class BasicGameRepository : GameRepository
    {
        DAL dal;

        public void Save(Game game)
        {
            dal.Save(game);
        }
        
        public Game Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAll()
        {
            throw new NotImplementedException();
        }

        public BasicGameRepository(DAL dal)
        {
            this.dal = dal;
        }
    }
}
