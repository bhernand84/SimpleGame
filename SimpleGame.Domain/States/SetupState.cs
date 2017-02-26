using SimpleGame.Common.Constants;
using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Domain.States
{
    public class SetupState : BaseState
    {
        public override string Output
        { get; set; }

        public override void Init(Game game)
        {
            Status = Common.Enum.GameStatus.Starting;
        }

        public override void Join(Game game, Player player)
        {
            if (game.MaxSize > game.Players.Players.Count())
            {
                game.Players.Add(player);
                if (game.MaxSize == game.Players.Players.Count())
                    game.SetState(new ActiveState());
            }
            else
                throw new InvalidOperationException(Messages.GameFullMessage);
        }

        public override void Leave(Game game, Player player)
        {
            game.Players.Remove(player);
        }
    }
}
