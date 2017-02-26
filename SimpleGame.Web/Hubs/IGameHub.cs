using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleGame.Web.Hubs
{
    public interface IGameHub
    {
        void update(Game game);
    }
}