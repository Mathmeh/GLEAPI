using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLEAPI.Dto
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public int Salt { get; set; }
        public string PasswordHashed { get; set; }
        public string PasswordSaltedHashed { get; set; }

    }
}
