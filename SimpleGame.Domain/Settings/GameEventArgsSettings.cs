using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Domain.Settings
{
    public static class GameEventArgsSettings
    {
        public static GameEventArgs PlayerJoinedEvent = new GameEventArgs("A player has joined");

        public static GameEventArgs PlayerLeftEvent = new GameEventArgs("A player has left");

        public static GameEventArgs PlayerPlayEvent = new GameEventArgs("A player has played");
    }
}
