using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGame.Common.Entities;
using Rhino.Mocks;
using SimpleGame.Domain.Models;
using System.Linq;
using SimpleGame.Common.Exceptions;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class PlayerContainerTests
    {

        PlayerContainer playerContainer;

        [TestInitialize]
        public void Init()
        {
            playerContainer = new BasicPlayerContainer();
        }

        [TestMethod]
        public void PlayerContainerCanAddPlayers()
        {
            var player = MockRepository.GenerateMock<Player>();
            playerContainer.Add(player);

            Assert.AreEqual(1, playerContainer.Players.Count());
        }
        [TestMethod]
        public void PlayerContainerCanRemovePlayers()
        {
            var player = MockRepository.GenerateMock<Player>();
            playerContainer.Add(player);
            playerContainer.Remove(player);

            Assert.AreEqual(0, playerContainer.Players.Count());
        }
        [TestMethod]
        [ExpectedException(typeof(GameException))]
        public void SamePlayerCanNotBeAddedTwice()
        {
            var player = MockRepository.GenerateMock<Player>();
            playerContainer.Add(player);
            playerContainer.Add(player);

        }
        [TestMethod]
        public void NullPlayerCannotBeAdded()
        {
            playerContainer.Add(null);

            Assert.AreEqual(0, playerContainer.Players.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(GameException))]
        public void PlayersCannotHaveTheSameName()
        {
            var player = MockRepository.GenerateMock<Player>();
            player.Name = "test";
            playerContainer.Add(player);

            playerContainer.Add(player);
        }
    }
}
