using SimpleGame.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Entities
{
    public interface State
    {
        event EventHandler<GameEventArgs> OnChanged;
        GameStatus Status { get; }
        string Output { get; set; }
        void Init(Game game);
        void Play(Game game, Player player, Space space, Position position);
        void Join(Game game, Player player);
        void Leave(Game game, Player player);
    }
}
