using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Exceptions
{
    public class GameException : InvalidOperationException
    {

        public GameException(string message) : base(message) { }
    }
}
