using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Entities
{
    public class GameEventArgs : EventArgs 
    {
        public string Message
        { get; set; }

        public GameEventArgs(string message)
        {
            Message = message;
        }
    }
}
