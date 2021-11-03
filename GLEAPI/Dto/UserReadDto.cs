using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLEAPI.Dto
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PasswordSaltedHashed { get; set; }
    }
}
