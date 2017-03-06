using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Common.Enum;
using SimpleGame.Common.Entities;
using SimpleGame.Common.Constants;
using SimpleGame.Common.Exceptions;
using SimpleGame.Domain.Settings;

namespace SimpleGame.Domain.States
{
    public class ActiveState : BaseState
    {
        public List<Player> PlayerOrder { get; set; }
        public int ActivePlayerIndex { get; set; }

        public override GameStatus Status
        {
            get
            {
                return GameStatus.Active;
            }
        }

        public override void Init(Game game)
        {
            PlayerOrder = new List<Player>(game.Players.Players);
            SetActivePlayer(game);
        }
        public override void Play(Game game, Player player, Space space, Position position)
        {
            if (game.CanPlay(player))
            {
                game.Board.Add(space, position);
                OnStateChanged(new GameEventArgs(player, GameEventArgsSettings.PlayerPlayEvent));
                SetActivePlayer(game);
            }
            else
            {
                throw new InvalidMoveException(Messages.PlayerInvalidNotYourTurn);
            }
        }
        public virtual void SetActivePlayer(Game game)
        {
            if (ActivePlayerIndex < PlayerOrder.Count())
            {
                game.ActivePlayer = PlayerOrder[ActivePlayerIndex];
                ActivePlayerIndex++;
            }
            else
            {
                game.SetState(new CompleteState());
            }
        }
    }
}
