using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLE.Models
{
    public class User
    {


        public int Id { get; set; }
        public int TelegramIdentify { get; set; }
       
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public int Salt { get; set; }
        public string PasswordHashed { get; set; }
        public string PasswordSaltedHashed { get; set; }
        public List<Routine> Routines{ get; set; }
    }
}
