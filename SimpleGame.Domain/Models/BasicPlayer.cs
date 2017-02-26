using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Domain.Models
{
    [Serializable]
    public class BasicPlayer : Player
    {
        public string ID
        { get; set; }

        public string Name
        { get; set; }
    }
}
