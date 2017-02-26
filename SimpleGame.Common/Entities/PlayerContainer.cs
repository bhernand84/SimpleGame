using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Entities
{
    public interface PlayerContainer
    {
        IEnumerable<Player> Players { get; }
        void Add(Player player);
        void Remove(Player player);
    }
}
