using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BaseResponse<T> where T : class
    {
        public int total { get; set; }
        public List<T> rows { get; set; }
    }
}
