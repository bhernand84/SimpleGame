using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Constants
{
    public static class Messages
    {
        public const string GameFullMessage = "Sorry, the game is full.";
        public const string GameCannotJoinMessage = "Sorry, you cannot join a game at this time.";
        public const string GameCannotLeaveMessage = "Sorry, you cannot leave at this time";

        public const string SpaceDoesNotExist = "There is no space at the specified position!";
        public const string ColumnIsFull = "There is no space in this column";

        public const string PlayerInvalidNotYourTurn = "It's not your turn!";
    }
}
