using SimpleGame.Common.Constants;
using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Common.Enum;
using SimpleGame.Domain.Settings;

namespace SimpleGame.Domain.States
{
    public class SetupState : BaseState
    {
        public override GameStatus Status
        {
            get
            {
                return GameStatus.Starting;
            }
        }
        public override string Output
        { get; set; }

        public override void Join(Game game, Player player)
        {
            if (game.CanJoin(player))
            {
                game.Players.Add(player);
                OnStateChanged(GameEventArgsSettings.PlayerJoinedEvent);
                if (game.GameFull())
                {
                    game.SetState(new ActiveState());
                }
            }
            else
                throw new InvalidOperationException(Messages.GameFullMessage);
        }

        public override void Leave(Game game, Player player)
        {
            if (game.Players.Players.Contains(player))
            {
                game.Players.Remove(player);
                OnStateChanged(GameEventArgsSettings.PlayerLeftEvent);
            }
        }
    }
}
