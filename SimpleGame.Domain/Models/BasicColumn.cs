using SimpleGame.Common.Entities;
using SimpleGame.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Domain.Models
{
    public class BasicColumn : Column
    {
        protected List<Space> spaces;
        public int maxSize { get; protected set; }

        public IEnumerable<Space> Spaces
        { get { return spaces; } }

        public void Add(Space space)
        {
            if (maxSize == spaces.Count())
                throw new InvalidMoveException();
            spaces.Add(space);
        }

        public BasicColumn() : this(10) { }

        public BasicColumn(int size)
        {
            maxSize = size;
            spaces = new List<Space>();
        }
    }
}
