﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ValidationException : Exception
    {
        public int Code { get; set; }
        public ValidationException(int code, string message) : base(message)
        {
            this.Code = code;
        }
    }
}
