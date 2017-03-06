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
    public class BasicPlayerContainerFactory : PlayerContainerFactory
    {
        public PlayerContainer Get()
        {
            return new BasicPlayerContainer();
        }
    }
}
