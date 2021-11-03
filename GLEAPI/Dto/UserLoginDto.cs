using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLEAPI.Dto
{
    public class UserLoginDto
    {
        public string Name { get; set; }
        public string PasswordHashed { get; set; }
    }
}
