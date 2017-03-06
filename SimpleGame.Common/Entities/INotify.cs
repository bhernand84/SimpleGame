using System;
using SimpleGame.Common.Entities;

namespace SimpleGame.Common.Models
{
    public interface INotify
    {
        bool IsRegistered { get; }

        event EventHandler<Game> Game;
        event EventHandler<Game> JoinGame;

        void Join(Game game, Player player);
        void Update(Game game);
    }
}