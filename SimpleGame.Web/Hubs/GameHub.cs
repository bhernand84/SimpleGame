using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SimpleGame.Common.Entities;
using SimpleGame.Web.ServiceBus;

namespace SimpleGame.Web.Hubs
{
    public class GameHub : Hub<IGameHub>
    {
        public GameHub(GameNotify notifier)
        {
            if (!notifier.IsRegistered)
            {
                notifier.Game += (sender, game) => { Update(game); };
            }
        }
        public void Update(Game game)
        {
            Clients.All.update(game);
        }
    }

    
}