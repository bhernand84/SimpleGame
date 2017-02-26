using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGame.Common.Factories;
using Rhino.Mocks;
using SimpleGame.Domain.Models;
using SimpleGame.Common.Entities;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class SpaceTests
    {
        SpaceFactory spaceFactory;
        PlayerFactory playerFactory;

        [TestInitialize]
        public void Init()
        {
            var blankSpace = new BasicSpace();
            spaceFactory = MockRepository.GenerateMock<SpaceFactory>();
            spaceFactory.Stub(x => x.Get()).Return(blankSpace);

            var blankPlayer = new BasicPlayer();
            playerFactory = MockRepository.GenerateMock<PlayerFactory>();
            playerFactory.Stub(x=>x.Empty).Return(blankPlayer);
        }
        [TestMethod]
        public void SpaceWithoutOwnerIsAvailable()
        {
            //arrange
            var space = spaceFactory.Get();

            Assert.IsTrue(space.Available);
        }

        [TestMethod]
        public void SpaceWithOwnerIsNotAvailable()
        {
            var space = spaceFactory.Get();
            space.Owner = MockRepository.GenerateMock<Player>();
            space.Owner.Stub(m=>m.ID).Return("djdjhd");
            space.Owner.Stub(m=>m.Name).Return("player");

            Assert.IsFalse(space.Available);
        }
    }
}
