using SimpleGame.Common.Entities;
using SimpleGame.Common.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Models
{
    public class BasicPlayerContainer : PlayerContainer
    {
        List<Player> players;

        public void Add(Player player)
        {
            if (ValidatePlayer(player))
                players.Add(player);

        }

        public void Remove(Player player)
        {
            players.Remove(player);
        }
        public IEnumerator<Player> GetEnumerator()
        {
            return players.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return players.GetEnumerator();
        }

        public BasicPlayerContainer()
        {
            players = new List<Player>();
        }

        protected bool ValidatePlayer(Player player)
        {
            if (player == null)
                return false;
            if (players.Contains(player))
            {
                throw new GameException("A player is already using that name");
            }
            return true;
        }
    }
}
