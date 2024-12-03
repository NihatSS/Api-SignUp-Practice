using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper.Responses
{
    public class SignUpResponse
    {
        public bool IsSuccessed { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
