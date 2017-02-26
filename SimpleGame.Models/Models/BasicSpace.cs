using SimpleGame.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Models
{
    public class BasicSpace : Space
    {
        public bool Available
        {
            get
            {
                return Owner == null || Owner.ID == null || Owner.Name == null;
            }
        }

        public string Id
        { get; set; }

        public Player Owner
        { get; set; }
    }
}
