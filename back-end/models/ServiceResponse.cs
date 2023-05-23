using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.models
{
    public class ServiceResponse<T>
    {
        public T? data { get; set; }
        public bool Sucess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}