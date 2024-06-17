using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DataLayer.DTO
{
    public class ResetPassDTO
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
