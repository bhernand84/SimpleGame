using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SimpleGame.Common.Entities;
using SimpleGame.Web.ServiceBus;
using SimpleGame.Common.Models;

namespace SimpleGame.Web.Hubs
{
    public class GameHub : Hub<IGameHub>
    {
        public GameHub(INotify notifier)
        {
            if (!notifier.IsRegistered)
            {
                notifier.Game += (sender, game) => { Update(game); };
                notifier.JoinGame += (sender, game) => { JoinGame((Player)sender, game); };
            }
        }

        public void Update(Game game)
        {
            Clients.Group(game.ID.ToString()).update(game);
        }
        public void JoinGame(Player player, Game game)
        {
            Groups.Add(Context.ConnectionId, game.ID.ToString());
            Clients.Group(game.ID.ToString());
        }
        
        public void LeaveGame(string gameid)
        {
            Groups.Remove(Context.ConnectionId, gameid);
        }
    }

    
}