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
    public class GameEvents
    {
        GameFactory gameFactory;

        [TestMethod]
        public void JoinGame_FiresUpdatedEvent()
        {
            var player = new BasicPlayer();

            var container = MockRepository.GenerateMock<BasicPlayerContainer>();
            BasicGame game = MockRepository.GenerateMock<BasicGame>(MockRepository.GenerateMock<Board>(), container, 5);
            var state = MockRepository.GenerateMock<State>();
            state.Expect(m => m.Join(game, player));

            game.GameState = state;
            bool wasRaised = false;
            game.OnChanged += (s, e) => { wasRaised = true; };
            game.Join(player);

            Assert.IsTrue(wasRaised);
            //game.a(m => m.OnChanged(Arg<EventArgs>.Is.Anything));
        }
        [TestMethod]
        public void LeaveGame_FiresUpdatedEvent()
        {
            var player = new BasicPlayer();

            var container = MockRepository.GenerateMock<BasicPlayerContainer>();
            BasicGame game = MockRepository.GenerateMock<BasicGame>(MockRepository.GenerateMock<Board>(), container, 5);
            var state = MockRepository.GenerateMock<State>();
            state.Expect(m => m.Leave(game, player));

            game.GameState = state;
            bool wasRaised = false;
            game.OnChanged += (s, e) => { wasRaised = true; };
            game.Leave(player);

            Assert.IsTrue(wasRaised);
        }
    }
}
