using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGame.Domain.Models;
using SimpleGame.Domain.Factories;
using SimpleGame.Common.Factories;
using Rhino.Mocks;
using SimpleGame.Common.Entities;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class GameTests
    {
        GameFactory gameFactory;

        [TestInitialize]
        public void Init()
        {
            
        }
        [TestMethod]
        public void PlayerJoinsGame_PassedToGameState()
        {
            var player = new BasicPlayer();
            
            var container = MockRepository.GenerateMock<BasicPlayerContainer>();
            var containerFactory = MockRepository.GenerateStub<PlayerContainerFactory>();
            containerFactory.Stub(m => m.Get()).Return(container);

            var boardFactory = MockRepository.GenerateMock<BoardFactory>();
            boardFactory.Stub(m => m.Get()).Return(new BasicBoard());

            gameFactory = new BasicGameFactory(boardFactory, containerFactory);
            BasicGame game = (BasicGame)gameFactory.Get();
            var state = MockRepository.GenerateMock<State>();
            state.Expect(m => m.Join(game, player));
            game.GameState = state;
            game.Join(player);

            state.VerifyAllExpectations();
        }
       
        [TestMethod]
        public void PlayerLeavesGame_RemoveCalledToPlayerContainer()
        {
            var player = new BasicPlayer();

            var container = MockRepository.GenerateMock<BasicPlayerContainer>();
            var containerFactory = MockRepository.GenerateStub<PlayerContainerFactory>();
            containerFactory.Stub(m => m.Get()).Return(container);

            var boardFactory = MockRepository.GenerateMock<BoardFactory>();
            boardFactory.Stub(m => m.Get()).Return(new BasicBoard());

            gameFactory = new BasicGameFactory(boardFactory, containerFactory);
            BasicGame game = (BasicGame)gameFactory.Get();
            var state = MockRepository.GenerateMock<State>();
            state.Expect(m => m.Leave(game, player));
            game.GameState = state;
            game.Leave(player);

            state.VerifyAllExpectations();
        }
    }
}
