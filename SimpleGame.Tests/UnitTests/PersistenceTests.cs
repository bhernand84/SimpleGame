using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGame.Common.Entities;
using SimpleGame.Common.Factories;
using SimpleGame.Domain.Factories;
using SimpleGame.Domain.Models;
using Rhino.Mocks;
using SimpleGame.Data.DataAccessLayers;
using SimpleGame.Data.Repositories;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class PersistenceTests
    {

        [TestMethod]
        public void RepositoryCallsDALOnSave()
        {
            Game game = MockRepository.GenerateMock<Game>();
            var dal = MockRepository.GenerateMock<DAL>();
            dal.Expect(m => m.Save(game));
            GameRepository repository = new BasicGameRepository(dal);

            repository.Save(game);

            dal.VerifyAllExpectations();
        }
    }
}
