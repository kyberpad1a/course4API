using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4Course.Models
{
    public class Personel
    {
        public int ID_Personel { get; set; }
        public string Personel_Login { get; set; }
        public string Personel_Password { get; set; }
        public string Personel_Surname { get; set; }
        public string Personel_Name { get; set; }
        public string Personel_Patronymic { get; set; }
        public int Job_ID { get; set; }
    }
}
