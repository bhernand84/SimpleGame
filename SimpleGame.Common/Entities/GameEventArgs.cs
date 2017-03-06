using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Entities
{
    public class GameEventArgs : EventArgs 
    {
        public Player Player
        { get; set; }
        public string Message
        { get; set; }

        public GameEventArgs(Player player, string message)
        {
            Player = player;
            Message = message;
        }
    }
}
