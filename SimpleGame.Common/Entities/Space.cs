using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Entities
{
    public interface Space
    {
        bool Available { get; }
        Player Owner { get; set; }
        string Id { get; set; }
    }
}
