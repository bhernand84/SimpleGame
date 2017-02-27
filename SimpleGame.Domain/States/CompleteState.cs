using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Common.Enum;

namespace SimpleGame.Domain.States
{
    public class CompleteState : BaseState
    {
        public override GameStatus Status
        {
            get
            {
                return GameStatus.Complete;
            }
        }
    }
}
