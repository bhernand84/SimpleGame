using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SimpleGame.Common.Entities;
using SimpleGame.Web.ServiceBus;
using SimpleGame.Domain.Models;
using SimpleGame.Domain.Managers;
using SimpleGame.Common.Models;
using SimpleGame.Common.Factories;

namespace SimpleGame.Tests.UnitTests
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void Manager_PlayerJoinsGame_GameIsSaved()
        {
            var repository = MockRepository.GenerateMock<GameRepository>();
            var notifier = MockRepository.GenerateMock<INotify>();
            var factory = MockRepository.GenerateMock<GameFactory>();
            var manager = MockRepository.GenerateMock<BasicGameManager>(notifier, repository, factory);
            var player = new BasicPlayer();

            var game = MockRepository.GenerateMock<Game>();
            game.Expect(m => m.Join(player));

            repository.Expect(m => m.Get(Guid.Empty.ToString())).Return(game);
            manager.Join(player, game);
            game.Raise<Game>(m => m.OnChanged += null,
                game,
                new GameEventArgs(player, "joined"));
            repository.AssertWasCalled(m => m.Save(game));
        }
        [TestMethod]
        public void Manager_PlayerJoinsGame_NotifierIsNotified()
        {
            var repository = MockRepository.GenerateMock<GameRepository>();
            var notifier = MockRepository.GenerateMock<INotify>();
            var factory = MockRepository.GenerateMock<GameFactory>();
            var manager = MockRepository.GenerateMock<BasicGameManager>(notifier, repository, factory);
            var player = new BasicPlayer();

            var game = MockRepository.GenerateMock<Game>();
            game.Expect(m => m.Join(player));

            repository.Expect(m => m.Get(Guid.Empty.ToString())).Return(game);
            manager.Join(player, game);
            game.Raise<Game>(m => m.OnChanged += null,
                game,
                new GameEventArgs(player, "joined"));

            notifier.AssertWasCalled(m => m.Join(game, player));
        }
        [TestMethod]
        public void Manager_JoinGame_RespondsToChangeEvent()
        {
            var repository = MockRepository.GenerateMock<GameRepository>();
            var notifier = MockRepository.GenerateMock<INotify>();
            var factory = MockRepository.GenerateMock<GameFactory>();
            var manager = MockRepository.GenerateMock<BasicGameManager>(notifier, repository, factory);

            var game = MockRepository.GenerateMock<Game>();
            repository.Expect(m => m.Get(Guid.Empty.ToString())).Return(game);
            var player = new BasicPlayer();
            manager.Join(player, game);
        }

        [TestMethod]
        public void Manager_CreateGame_SavesToRepository()
        {
            var repository = MockRepository.GenerateMock<GameRepository>();
            var notifier = MockRepository.GenerateMock<INotify>();
            var factory = MockRepository.GenerateMock<GameFactory>();
            var manager = MockRepository.GenerateMock<BasicGameManager>(notifier, repository, factory);

            var game = MockRepository.GenerateMock<Game>();
            factory.Expect(m => m.Get()).Return(game);
            repository.Expect(m => m.Save(game));
            manager.Create();

            repository.VerifyAllExpectations();
        }
    }
}
