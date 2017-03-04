using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SimpleGame.Common.Entities;
using SimpleGame.Common.Factories;
using SimpleGame.Domain.Factories;
using SimpleGame.Domain.Models;
using SimpleGame.Domain.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class GameStateEvents
    {
        
        [TestMethod]
        public void SetUpState_PlayerJoinsGame_OnChangeFires()
        {
            var setupState = new SetupState();
            var player = new BasicPlayer();
            var game = MockRepository.GenerateMock<Game>();
            game.Expect(m => m.CanJoin(player)).Return(true);
            game.Expect(m => m.Players.Add(player));
            bool eventRaised = false;
            setupState.OnChanged += (s, e) => { eventRaised = true;  };
            setupState.Join(game, player);

            Assert.IsTrue(eventRaised);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Game_PlayerJoinGameFails_OnChangeDoesNotFire()
        {
            var setupState = new SetupState();
            var player = new BasicPlayer();
            var game = MockRepository.GenerateMock<Game>();
            game.Expect(m => m.CanJoin(player)).Return(false);
            game.Expect(m => m.Players).Return(MockRepository.GenerateStub<PlayerContainer>());
            bool eventRaised = false;
            setupState.OnChanged += (s, e) => { eventRaised = true; };
            setupState.Join(game, player);

            Assert.IsFalse(eventRaised);
        }

        [TestMethod]
        public void SetUpState_PlayerLeavesGame_OnChangeFires()
        {
            var setupState = new SetupState();
            var player = new BasicPlayer();
            var game = MockRepository.GenerateMock<Game>();
            game.Expect(m => m.CanJoin(player)).Return(true);
            var playerContainer = MockRepository.GenerateStub<PlayerContainer>();

            playerContainer.Expect(m=> m.Players).Return(new List<Player>() { player });
            game.Expect(m => m.Players).Return(playerContainer);
            setupState.Join(game, player);
            bool eventRaised = false;
            setupState.OnChanged += (s, e) => { eventRaised = true; };
            setupState.Leave(game, player);
            Assert.IsTrue(eventRaised);
        }
        [TestMethod]
        public void SetUpState_PlayerCannotLeaveGame_OnChangeDoesntFire()
        {
            var setupState = new SetupState();
            var player = new BasicPlayer();
            var game = MockRepository.GenerateMock<Game>();
            game.Expect(m => m.CanJoin(player)).Return(true);
            var playerContainer = MockRepository.GenerateStub<PlayerContainer>();

            playerContainer.Expect(m => m.Players).Return(new List<Player>() { });
            game.Expect(m => m.Players).Return(playerContainer);
            setupState.Join(game, player);
            bool eventRaised = false;
            setupState.OnChanged += (s, e) => { eventRaised = true; };
            setupState.Leave(game, player);
            Assert.IsFalse(eventRaised);
        }
        [TestMethod]
        public void ActiveState_PlayerPlays_OnChangeFires()
        {
            var activeState = new ActiveState();
            var player = new BasicPlayer();
            activeState.PlayerOrder = new List<Player>() { new BasicPlayer(), new BasicPlayer(), player };
            var game = MockRepository.GenerateMock<Game>();
            game.Expect(m => m.CanPlay(player)) .Return(true);
            var playerContainer = MockRepository.GenerateStub<PlayerContainer>();
            var board = MockRepository.GenerateStub<Board>();
            var space = MockRepository.GenerateStub<Space>();
            var position = MockRepository.GenerateStub<Position>();
            game.Expect(m => m.Board).Return(board);
            
            //board.Expect(m => m.Add(space, position));
            bool eventRaised = false;
            activeState.OnChanged += (s, e) => { eventRaised = true; };
            activeState.Play(game, player, space, position);
            Assert.IsTrue(eventRaised);
        }
    }
}
