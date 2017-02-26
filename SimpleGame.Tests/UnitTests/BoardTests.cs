using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SimpleGame.Common.Entities;
using SimpleGame.Common.Factories;
using SimpleGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class BoardTests
    { 
        SpaceFactory spaceFactory;

        [TestInitialize]
        public void Init()
        {
            //set up board
            spaceFactory = MockRepository.GenerateMock<SpaceFactory>();
            spaceFactory.Stub(x=>x.Get()).Return(new BasicSpace() { Owner = new BasicPlayer() });
        }

        [TestMethod]
        public void BoardIsInitializedWithNumberOfColumnsSpecified()
        {
            var board = new BasicBoard();
            board.Init(4);
            var board2 = new BasicBoard();
            board2.Init(5);
            var board3 = new BasicBoard();
            board3.Init(6);

            Assert.AreEqual(board.Cols, 4);
            Assert.AreEqual(board2.Cols, 5);
            Assert.AreEqual(board3.Cols, 6);
        }
        [TestMethod]
        public void BoardCanHoldSpaces()
        {
            Board myBoard = new BasicBoard();
            myBoard.Init(5);
            var space = spaceFactory.Get();
            myBoard.Add(space, 1);

            Assert.AreEqual(1, myBoard.OccupiedSpaces.Count());
        }
    }
}
