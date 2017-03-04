using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Common.Enum;

namespace SimpleGame.Common.Entities
{
    public interface Game
    {
        event EventHandler OnChanged;
        Guid ID { get; }
        Board Board { get; }
        PlayerContainer Players { get; }
        State GameState { get; }
        string Output { get; }
        Player ActivePlayer { get; set; }
        GameStatus GameStatus { get; }
        int MaxSize { get;}
        void SetState(State state);
        void Join(Player player);
        void Leave(Player player);
        void Play(Player player, Space space, Position position);
    }
}
