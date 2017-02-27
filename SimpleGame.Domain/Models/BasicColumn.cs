using SimpleGame.Common.Constants;
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
                throw new InvalidMoveException(Messages.ColumnIsFull);
            spaces.Add(space);
        }
        public void Remove(Space space)
        {
            var currentSpace = spaces.FirstOrDefault(m => m.Id == space.Id);
            if (currentSpace != null)
            {
                spaces.Remove(currentSpace);
            }
            else
            {
                throw new InvalidMoveException(Messages.SpaceDoesNotExist);
            }
        }
        public BasicColumn() : this(10) { }

        public BasicColumn(int size)
        {
            maxSize = size;
            spaces = new List<Space>();
        }
    }
}
