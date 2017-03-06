using SimpleGame.Common.Entities;
using SimpleGame.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleGame.Web.ServiceBus
{
    public class GameNotify : INotify
    {
        public event EventHandler<Game> Game;
        public event EventHandler<Game> JoinGame;

        public void Update(Game game)
        {
            Game?.Invoke(this, game);
        }

        public void Join(Game game, Player player)
        {
            JoinGame?.Invoke(player, game);
        }

        public bool IsRegistered
        {
            get
            {
                return Game != null;
            }
        }
    }
}