using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SimpleGame.Common.Entities;
using SimpleGame.Data.Serializers;
using SimpleGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        public void Serializer_CanSavePlayers()
        {
            var players = new BasicPlayer() { ID = "1111", Name = "1112" } ;

            var serializedPlayers = SerializationHelper.Serialize(players);

            Assert.IsNotNull(serializedPlayers);

            Assert.IsTrue(serializedPlayers.Contains("1111"));
            Assert.IsTrue(serializedPlayers.Contains("1112"));
        }

        [TestMethod]
        public void Serializer_CanLoadSavedPlayers()
        {
            var player = new BasicPlayer() { ID = "1111", Name = "1112" };

            var serializedSpace = SerializationHelper.Serialize(player);

            Assert.IsNotNull(serializedSpace);

            var deserializedPlayers = SerializationHelper.Deserialize<BasicPlayer>(serializedSpace);

            Assert.AreEqual(deserializedPlayers.ID, player.ID);
            Assert.AreEqual(deserializedPlayers.Name, player.Name);
        }

        [TestMethod]
        public void Serializer_CanSavePlayerContainer()
        {
            var container = new BasicPlayerContainer();
            for (int i = 0; i < 3; i++)
            {
                var player = new BasicPlayer() { ID = "1111" + i, Name = "1112" + i };
                container.Add(player);
            }

            var serializedContainer = SerializationHelper.Serialize(container);

            Assert.IsNotNull(serializedContainer);


            Assert.IsTrue(serializedContainer.Contains("11110"));
            Assert.IsTrue(serializedContainer.Contains("11111"));
            Assert.IsTrue(serializedContainer.Contains("11112"));
        }

        [TestMethod]
        public void Serializer_CanLoadPlayerContainer()
        {
            var container = new BasicPlayerContainer();
            for (int i = 0; i < 3; i++)
            {
                var player = new BasicPlayer() { ID = "1111" + i, Name = "1112" + i };
                container.Add(player);
            }

            var serializedContainer = SerializationHelper.Serialize(container);

            Assert.IsNotNull(serializedContainer);

            var deserializedContainer = SerializationHelper.Deserialize<BasicPlayerContainer>(serializedContainer);

            Assert.AreEqual(container.Players.First().ID, deserializedContainer.Players.First().ID);
            Assert.AreEqual(container.Players.Skip(1).First().ID, deserializedContainer.Players.Skip(1).First().ID);
            Assert.AreEqual(container.Players.Skip(2).First().ID, deserializedContainer.Players.Skip(2).First().ID);
        }

        [TestMethod]
        public void Serializer_CanLoadSavedSpaces()
        {
            var space = new BasicSpace() { Id = "skjsksjsk", Owner = new BasicPlayer() { ID = "1111", Name = "1112" } };

            var serializedSpace = SerializationHelper.Serialize(space);

            Assert.IsNotNull(serializedSpace);

            var deserializedSpace = SerializationHelper.Deserialize<BasicSpace>(serializedSpace);

            Assert.AreEqual(deserializedSpace.Id, space.Id);
            Assert.AreEqual(deserializedSpace.Owner.ID, space.Owner.ID);
            Assert.AreEqual(deserializedSpace.Owner.Name, space.Owner.Name);
        }

        [TestMethod]
        public void Serializer_CanSaveBoard()
        {
            var board = new BasicBoard()
            {
                Columns = new Column[] { new BasicColumn(4), new BasicColumn(4) },
                Rows = 2
            };

            board.Columns[0].Add(new BasicSpace() { Id = "111", Owner = new BasicPlayer() { ID = "232", Name = "333" } });

            var serializedBoard = SerializationHelper.Serialize(board);

            Assert.IsTrue(serializedBoard.Contains("111"));
            Assert.IsTrue(serializedBoard.Contains("232"));
            Assert.IsTrue(serializedBoard.Contains("333"));
            Assert.IsTrue(serializedBoard.Contains("4"));
        }
        [TestMethod]
        public void Serializer_CanLoadBoard()
        {
            var board = new BasicBoard()
            {
                Columns = new Column[] { new BasicColumn(4), new BasicColumn(4) },
                Rows = 2
            };

            board.Columns[0].Add(new BasicSpace() { Id = "111", Owner = new BasicPlayer() { ID = "232", Name = "333" } });

            var serializedBoard = SerializationHelper.Serialize(board);

            var deserializedBoard = SerializationHelper.Deserialize<BasicBoard>(serializedBoard);

            Assert.AreEqual(board.Cols, deserializedBoard.Cols);
            Assert.AreEqual(board.Rows, deserializedBoard.Rows);
            Assert.AreEqual(board.Columns[0].Spaces.First().Owner.ID, deserializedBoard.Columns[0].Spaces.First().Owner.ID);
            Assert.AreEqual(board.Columns[0].Spaces.First().Owner.Name, deserializedBoard.Columns[0].Spaces.First().Owner.Name);
        }

    }
}
