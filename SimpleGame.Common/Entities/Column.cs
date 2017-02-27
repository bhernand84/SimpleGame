using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Entities
{
    public interface Column
    {
        IEnumerable<Space> Spaces { get; }

        void Add(Space space);
        void Remove(Space space);
    }
}
