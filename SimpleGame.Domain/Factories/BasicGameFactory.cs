using SimpleGame.Common.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Common.Entities;
using SimpleGame.Domain.Models;
using SimpleGame.Domain.States;

namespace SimpleGame.Domain.Factories
{
    public class BasicGameFactory : GameFactory
    {

        BoardFactory boardFactory;
        PlayerContainerFactory playerContainerFactory;

        public Game Get()
        {
            return Get(2);
        }
        public Game Get(int maxsize)
        {
            var game = new BasicGame(boardFactory.Get(), playerContainerFactory.Get(), maxsize);
            game.ID = Guid.NewGuid();
            game.SetState(new SetupState());
            return game;
        }

        public BasicGameFactory(BoardFactory boardFactory,PlayerContainerFactory playerContainerFactory)
        {
            this.boardFactory = boardFactory;
            this.playerContainerFactory = playerContainerFactory;
        }
    }
}
