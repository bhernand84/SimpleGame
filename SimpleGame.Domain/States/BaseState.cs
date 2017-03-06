using SimpleGame.Common.Constants;
using SimpleGame.Common.Entities;
using SimpleGame.Common.Enum;
using SimpleGame.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Domain.States
{
    public abstract class BaseState : State
    {
        public virtual event EventHandler<GameEventArgs> OnChanged;

        public virtual GameStatus Status
        {
            get { return GameStatus.Starting; }
        }
        public virtual string Output
        {get;set;}

        
        public virtual void Init(Game game)
        {
        }

        public virtual void Join(Game game, Player player)
        {
            throw new InvalidOperationException(Messages.GameCannotJoinMessage);
        }

        public virtual void Leave(Game game, Player player)
        {
            throw new InvalidOperationException(Messages.GameCannotLeaveMessage);
        }
        public virtual void Play(Game game, Player player, Space space, Position position)
        {
            throw new InvalidMoveException("Sorry you cannot play at this time!");
        }

        protected virtual void OnStateChanged(GameEventArgs e)
        {
            OnChanged?.Invoke(this, e);
        }
    }
}
