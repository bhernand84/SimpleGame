using SimpleGame.Common.Entities;
using SimpleGame.Web.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace SimpleGame.Web.Controllers
{
    public class TestController : Controller
    {
        protected GameNotify Notifier;
        protected GameRepository GameRepository;

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimpleGame()
        {
            return View();
        }

        public void FireEvent()
        {
         
            var game = GameRepository.Get(Guid.Empty.ToString());
            Notifier.Update(game);
        }

        public TestController (GameNotify notifier, GameRepository gameRepository)
        {
            Notifier = notifier;
            GameRepository = gameRepository;
        }

    }
}