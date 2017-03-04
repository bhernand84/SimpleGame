using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Common.Enum;
using SimpleGame.Common.Entities;
using SimpleGame.Common.Constants;
using SimpleGame.Common.Exceptions;

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
        protected void SetActivePlayer(Game game)
        {
            if (ActivePlayerIndex < PlayerOrder.Count())
            {
                game.ActivePlayer = PlayerOrder[ActivePlayerIndex];
                ActivePlayerIndex++;
            }
            else
            {
                //change state
                game.SetState(new CompleteState());
            }
        }
        public override void Play(Game game, Player player, Space space, Position position)
        {
            if (player.ID == game.ActivePlayer.ID)
            {
                game.Board.Add(space, position);
                SetActivePlayer(game);
            }
            else
            {
                throw new InvalidMoveException(Messages.PlayerInvalidNotYourTurn);
            }
        }
    }
}
