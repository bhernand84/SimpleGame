using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Domain.Models
{
    public class BasicBoard : Board
    {
        public int Cols
        { get { return Columns.Length; } }

        public Column[] Columns
        { get; set; }

        public IEnumerable<Space> OccupiedSpaces
        { get { return Columns.SelectMany(m => m.Spaces); } }

        public int Rows
        { get; set; }

        public void Add(Space space, int column)
        {

            Columns[column].Add(space);
        }

        public void Remove(Space space, int column)
        {
            throw new NotImplementedException();
        }

        public void Init(int numberOfColumns)
        {
            Columns = new Column[numberOfColumns];
            for (int i = 0; i < numberOfColumns; i++)
            {
                Columns[i] = new BasicColumn();
            }
        }
    }
}
