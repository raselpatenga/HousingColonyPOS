using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Responses
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime? TokenExpiry { get; set; }
    }
}
