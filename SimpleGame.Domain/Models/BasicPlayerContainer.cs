using SimpleGame.Common.Entities;
using SimpleGame.Common.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Domain.Models
{
    [Serializable]
    public class BasicPlayerContainer : PlayerContainer
    {
        protected List<Player> players
        { get; private set; }

        public IEnumerable<Player>Players
        {
            get { return players; }
        }

        public virtual void Add(Player player)
        {
            if (ValidatePlayer(player))
                players.Add(player);

        }

        public virtual void Remove(Player player)
        {
            players.Remove(player);
        }

        public BasicPlayerContainer()
        {
            players = new List<Player>();
        }

        protected bool ValidatePlayer(Player player)
        {
            if (player == null)
                return false;
            if (players.Contains(player) || players.Any(m=>m.Name == player.Name))
            {
                throw new GameException("A player is already using that name");
            }
            return true;
        }
    }
}
