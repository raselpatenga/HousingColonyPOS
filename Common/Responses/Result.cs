using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Responses
{
    public class Result<T> where T : class
    {
       
        public IList<T> results { get; set; }
         
        public long totalCount { get; set; }
        public Result()
        {
            results = new List<T>();
        }
    }
}
