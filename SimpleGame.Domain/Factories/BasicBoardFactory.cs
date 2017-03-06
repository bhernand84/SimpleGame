using SimpleGame.Common.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Common.Entities;
using SimpleGame.Domain.Models;

namespace SimpleGame.Domain.Factories
{
    public class BasicBoardFactory : BoardFactory
    {
        public Board Get()
        {
           var board = new BasicBoard();
            board.Init(2);
            return board;
        }
    }
}
