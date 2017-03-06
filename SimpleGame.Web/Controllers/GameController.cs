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
using SimpleGame.Common.Models;
using SimpleGame.Domain.Models;

namespace SimpleGame.Web.Controllers
{
    public class GameController : Controller
    {
        protected GameManager manager;

        public JsonResult GetGames()
        {
            var games = manager.GetGames();
            return Json(games, JsonRequestBehavior.AllowGet);
        }
        public ActionResult JoinGame(string gameid, string playerName, string playerId)
        {
            var game = manager.Get(gameid);
            var player = new BasicPlayer(playerId, playerName);
            manager.Join(player, game);
            return RedirectToAction("Game", new { gameid = gameid });
        }

        public ActionResult CreateGame(string playerName, string playerId)
        {
            var game = manager.Create();
            return JoinGame(game.ID.ToString(), playerName, playerId);
        }
         
        public ActionResult Game(string gameid)
        {
            return View(gameid);
        }

        public GameController(GameManager manager)
        {
            this.manager = manager;
        }
    }
}