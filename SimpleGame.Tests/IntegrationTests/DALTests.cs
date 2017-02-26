using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGame.Data.DataAccessLayers;
using SimpleGame.Domain.Models;
using Rhino.Mocks;
using SimpleGame.Common.Entities;
using SimpleGame.Common.Factories;
using SimpleGame.Domain.Factories;

namespace SimpleGame.Tests.IntegrationTests
{

    [TestClass]
    public class DALTests
    {
        GameFactory gameFactory;

        [TestInitialize]
        public void Init()
        {
            var container = new BasicPlayerContainer();
            container.Add(new BasicPlayer() { ID = "222", Name = "nicko" });

            var containerFactory = MockRepository.GenerateStub<PlayerContainerFactory>();
            containerFactory.Stub(m => m.Get()).Return(container);

            var board = new BasicBoard()
            {
                Columns = new Column[] { new BasicColumn(3) },
                Rows = 2
            };
            var boardFactory = MockRepository.GenerateStub<BoardFactory>();
            boardFactory.Stub(m => m.Get()).Return(board);

            gameFactory = new BasicGameFactory(boardFactory, containerFactory);
        }

        [TestMethod]
        public void ItemCanBeAddedToTableStorage()
        {
            var basicGame = gameFactory.Get();

            var dal = new GameDAL();
            dal.Save(basicGame);

            var retrievedGame = dal.Get(basicGame.ID);
            Assert.AreEqual(retrievedGame.ID, basicGame.ID);
        }
    }
}
