using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGame.Common.Factories;
using SimpleGame.Domain.Factories;
using SimpleGame.Domain.Models;
using Rhino.Mocks;
using SimpleGame.Common.Enum;
using SimpleGame.Common.Entities;
using SimpleGame.Domain.States;
using System.Linq;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class StateTests
    {
       static GameFactory gameFactory;

        [TestInitialize]
        public void Init()
        {
            var container = new BasicPlayerContainer();
            var containerFactory = MockRepository.GenerateStub<PlayerContainerFactory>();
            containerFactory.Stub(m => m.Get()).Return(container);

            var board = new BasicBoard();
            var boardFactory = MockRepository.GenerateStub<BoardFactory>();
            boardFactory.Stub(m => m.Get()).Return(board);

            gameFactory = new BasicGameFactory(boardFactory, containerFactory);
        }

        [TestMethod]
        public void Game_NewGameIsInWaitingState()
        {
            var game = gameFactory.Get();
            Assert.AreEqual(game.GameStatus, GameStatus.Starting);
            Assert.AreEqual(game.GameState.GetType(), typeof(SetupState));
        }

        [TestMethod]
        public void Game_PlayerCanJoinGameInWaitingState()
        {
            var game = gameFactory.Get();

            var player = new BasicPlayer();

            game.Join(player);

            Assert.AreEqual(game.Players.Players.Count(), 1);
        }
        [TestMethod]
        public void Game_PlayerCanLeaveGameInWaitingState()
        {
            var game = gameFactory.Get();
            var player = new BasicPlayer();

            game.Join(player);
            game.Leave(player);

            Assert.AreEqual(game.Players.Players.Count(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Game_PlayersCannotJoinPastTheMaxGameSize()
        {
            var game = gameFactory.Get(2);
            var player = new BasicPlayer() { Name = "tom" };
            var player2 = new BasicPlayer() { Name = "tom2" };
            var player3 = new BasicPlayer() { Name = "tom3" };

            game.Join(player);
            game.Join(player2);
            game.Join(player3);
        }
        [TestMethod]
        public void Game_WhenAllPlayersJoinTheGameEntersNextState()
        {
            var game = gameFactory.Get(2);
            var gameStatus = game.GameStatus;
            var gameState = game.GameState;

            var player = new BasicPlayer() { Name = "tom1" };
            var player2 = new BasicPlayer() { Name = "tom2" };

            game.Join(player);
            game.Join(player2);

            Assert.AreNotEqual(gameStatus, game.GameStatus);
            Assert.AreNotEqual(gameState, game.GameState);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Game_PlayersCannotJoinActiveGame()
        {
            var game = gameFactory.Get(2);
            var gameStatus = game.GameStatus;
            var gameState = game.GameState;

            var player = new BasicPlayer() { Name = "tom1" };
            var player2 = new BasicPlayer() { Name = "tom2" };
            var player3 = new BasicPlayer() { Name = "tom2" };

            game.Join(player);
            game.Join(player2);
            game.Join(player3);

        }

    }
}
