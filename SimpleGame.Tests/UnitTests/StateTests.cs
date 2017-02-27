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
using SimpleGame.Common.Exceptions;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class StateTests
    {
       static GameFactory gameFactory;
        Board board;
        PlayerContainer container;

        [TestInitialize]
        public void Init()
        {
            container = new BasicPlayerContainer();
            var containerFactory = MockRepository.GenerateStub<PlayerContainerFactory>();
            containerFactory.Stub(m => m.Get()).Return(container);

            board = MockRepository.GenerateMock<Board>();
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

        [TestMethod]
        public void Game_ActivePlayer_SetWhenStateBecomesActive()
        {
            var game = gameFactory.Get(2);
            var gameStatus = game.GameStatus;
            var gameState = game.GameState;

            var player = new BasicPlayer() { Name = "tom1" };
            var player2 = new BasicPlayer() { Name = "tom2" };

            game.Join(player);
            game.Join(player2);

            Assert.IsNotNull(game.ActivePlayer);
            Assert.IsTrue(game.ActivePlayer.Name == player.Name || game.ActivePlayer.Name == player2.Name);
        }

        [TestMethod]
        public void Game_ActivePlayer_CallsPlay_IsPassedToBoard()
        {
            var game = gameFactory.Get(2);
            var gameStatus = game.GameStatus;
            var gameState = game.GameState;

            var player = new BasicPlayer() { Name = "tom1" };
            var player2 = new BasicPlayer() { Name = "tom2" };
            
            game.Join(player);
            game.Join(player2);

            var position = new Position() { Column = 0 };
            var space = MockRepository.GenerateMock<Space>();
            board.Expect(m => m.Add(space, position));

            game.Play(game.ActivePlayer, space, position);

            board.VerifyAllExpectations();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void Game_InactivePlayer_CallsPlay_ThrowsException()
        {
            var game = gameFactory.Get(2);
            var gameStatus = game.GameStatus;
            var gameState = game.GameState;

            var player = new BasicPlayer() { ID= Guid.NewGuid().ToString(), Name = "tom1" };
            var player2 = new BasicPlayer() { ID = Guid.NewGuid().ToString(), Name = "tom2" };

            game.Join(player);
            game.Join(player2);

            var position = new Position() { Column = 0 };
            var space = MockRepository.GenerateMock<Space>();
            board.Expect(m => m.Add(space, position));

            var inactivePlayer = game.ActivePlayer.Name == player.Name ? player2 : player;

            game.Play(inactivePlayer, space, position);
        }

        [TestMethod]
        public void Game_ActivePlayer_CallsPlay_NextPlayerBecomesActivePlayer()
        {
            var game = gameFactory.Get(2);
            var gameStatus = game.GameStatus;
            var gameState = game.GameState;

            var player = new BasicPlayer() { ID = Guid.NewGuid().ToString(), Name = "tom1" };
            var player2 = new BasicPlayer() { ID = Guid.NewGuid().ToString(), Name = "tom2" };

            game.Join(player);
            game.Join(player2);

            var inactivePlayer = game.ActivePlayer.Name == player.Name ? player2 : player;

            var position = new Position() { Column = 0 };
            var space = MockRepository.GenerateMock<Space>();
            board.Expect(m => m.Add(space, position));

            game.Play(game.ActivePlayer, space, position);

            Assert.AreEqual(game.ActivePlayer.ID, inactivePlayer.ID);
            Assert.AreEqual(game.ActivePlayer.Name, inactivePlayer.Name);
        }

        [TestMethod]
        public void Game_ActiveStateEnds_WhenAllPlayersFinish()
        {
            var game = gameFactory.Get(2);
            var gameStatus = game.GameStatus;
            var gameState = game.GameState;

            var player = new BasicPlayer() { ID = Guid.NewGuid().ToString(), Name = "tom1" };
            var player2 = new BasicPlayer() { ID = Guid.NewGuid().ToString(), Name = "tom2" };

            game.Join(player);
            game.Join(player2);

            var inactivePlayer = game.ActivePlayer.Name == player.Name ? player2 : player;

            var position = new Position() { Column = 0 };
            var space = MockRepository.GenerateMock<Space>();
            board.Expect(m => m.Add(space, position));

            game.Play(game.ActivePlayer, space, position);


            game.Play(game.ActivePlayer, space, position);

            Assert.AreEqual(game.GameState.Status, GameStatus.Complete);

        }


    }
}
