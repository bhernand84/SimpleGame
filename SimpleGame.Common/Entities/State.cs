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
        GameStatus Status { get; set; }
        string Output { get; set; }
        void Init(Game game);
        void Play(Game game, Player player, Space space);
        void Join(Game game, Player player);
        void Leave(Game game, Player player);
    }
}
