using SimpleGame.Common.Entities;
using SimpleGame.Web.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleGame.Common.Factories;

namespace SimpleGame.Web.Controllers
{
    public class GameController : Controller
    {
        protected GameNotify Notifier;
        protected GameRepository GameRepository;
        protected GameFactory GameFactory;

        public JsonResult GetGames()
        {
            var games = GameRepository.GetAll();
            return Json(games, JsonRequestBehavior.AllowGet);
        }
        public ActionResult JoinGame(string gameid, string playerName, string playerId)
        {
            var game = GameRepository.Get(gameid);
            var player = new Domain.Models.BasicPlayer() { ID = playerId, Name = playerName };
            game.Join(player);
            Notifier.Join(game, player);
            return RedirectToAction("Game", new { gameid = gameid });
        }

        public ActionResult CreateGame(string playerName, string playerId)
        {
            var game = GameFactory.Get();
            return JoinGame(game.ID.ToString(), playerName, playerId);
        }
         
        public ActionResult Game(string gameid)
        {
            return View(gameid);
        }

        public GameController(GameNotify notifier, GameRepository gameRepository)
        {
            Notifier = notifier;
            GameRepository = gameRepository;
        }
    }
}