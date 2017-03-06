using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Common.Models;
using SimpleGame.Common.Factories;

namespace SimpleGame.Domain.Managers
{
    public class BasicGameManager : GameManager
    {
        protected INotify notifier;
        protected GameRepository repository;
        protected GameFactory gameFactory;

        public IEnumerable<Game> GetGames()
        {
            return repository.GetAll();
        }

        public Game Get(string id)
        {
            return repository.Get(id);
        }

        public Game Create()
        {
           return gameFactory.Get();
        }

        public void Join(Player player, Game game)
        {
            game.OnChanged += Game_OnChanged;
            game.Join(player);
        }

        private void Game_OnChanged(object sender, GameEventArgs e)
        {
            var game = (Game)sender;
            if (game != null)
            {
                repository.Save(game);
                notifier.Join(game, e.Player);
            }
        }

        public BasicGameManager(INotify notifier, GameRepository repository)
        {
            this.notifier = notifier;
            this.repository = repository;
        }
    }
}
