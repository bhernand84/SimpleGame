using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleGame.Web.ServiceBus
{
    public class GameNotify 
    {
        public event EventHandler<Game> Game;

        public void Update(Game game)
        {
            Game?.Invoke(this, game);
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