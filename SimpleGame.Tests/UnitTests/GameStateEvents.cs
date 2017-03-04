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
            game.Expect(m => m.Players).Return(MockRepository.GenerateStub<PlayerContainer>());

            setupState.Join(game, player);
            bool eventRaised = false;
            setupState.OnChanged += (s, e) => { eventRaised = true; };
            setupState.Leave(game, player);
            Assert.IsFalse(eventRaised);
        }
    }
}
