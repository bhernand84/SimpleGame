using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Entities
{
    public interface Board
    {
        Column[] Columns { get; set; }
        IEnumerable<Space> OccupiedSpaces { get; }
        int Cols { get; }
        int Rows { get; set; }
        void Add(Space space, Position position);
        void Remove(Space space, Position position);
        void Init(int numberOfColumns);
    }
}
