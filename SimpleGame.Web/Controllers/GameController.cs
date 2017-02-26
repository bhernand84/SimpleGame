using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleGame.Common.Entities;
using SimpleGame.Web.ServiceBus;

namespace SimpleGame.Web.Controllers
{
    public class GameController : ApiController
    {
        protected GameNotify Notifier;
        protected GameRepository GameRepository;

        public IHttpActionResult CreateGame(Player player)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult GetGames()
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult JoinGame(Player player, string gameId)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult LeaveGame(string playerId, string gameId)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Play(string gameId, string playerId, Space space)
        {
            throw new NotImplementedException();
        }

        public GameController(GameNotify notifier, GameRepository gameRepository)
        {

        }
    }
}
