﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.EventModels
{
    public class UserLoginEvent
    {
        public UserLoginEvent(Object obj)
        {
            newObj = obj;
        }

        public Object newObj { get; private set; }
    }
}
