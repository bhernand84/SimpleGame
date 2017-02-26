using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGame.Common.Exceptions;
using SimpleGame.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class ColumnTests
    {
        [TestMethod]
        public void SpacesCanBeAddedToColumn()
        {
            var myColumn = new BasicColumn();
            var basicSpace = new BasicSpace();
            myColumn.Add(basicSpace);
            Assert.IsTrue(myColumn.Spaces.Contains(basicSpace));
        }

        [TestMethod]
        public void ColumnCanHoldTheMaxNumberOfSpaces()
        {
            int maxSize = 5;
            var myColumn = new BasicColumn(maxSize);
            for (int i = 0; i < maxSize; i++)
            {
                var basicSpace = new BasicSpace();
                myColumn.Add(basicSpace);
            }
            Assert.AreEqual(myColumn.Spaces.Count(), maxSize);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidMoveException))]
        public void ColumnCanNotHoldMoreSpacesThanItsMaxSize()
        {
            int maxSize = 5;
            var myColumn = new BasicColumn(maxSize);
            for (int i = 0; i < maxSize + 1; i++)
            {
                    var basicSpace = new BasicSpace();
                    myColumn.Add(basicSpace);
            }
        }
    }
}
