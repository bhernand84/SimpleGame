using SimpleGame.Common.Entities;
using SimpleGame.Web.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleGame.Web.Controllers
{
    public class GameController : Controller
    {
        protected GameNotify Notifier;
        protected GameRepository GameRepository;

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