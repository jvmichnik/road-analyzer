using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Consoles.ApiClient.Model
{
    public class ApiResultModel<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
    }
}
