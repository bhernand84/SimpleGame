﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Common.Entities
{
    public interface Player
    {
        string ID { get; set; }
        string Name { get; set; }
    }
}