﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartWithGiveIdException: Exception
    {
        string message;
        public NoCartWithGiveIdException()
        {
            message = "Cart with the given Id is not present";
        }
        public override string Message => message;
    }
}
