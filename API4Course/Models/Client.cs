using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4Course.Models
{
    public class Client
    {
        public int ID_Client { get; set; }
        public string Client_Login { get; set; }
        public string Client_Password { get; set; }
        public string Client_Surname { get; set; }
        public string Client_Name { get; set; }
        public string Client_Patronymic { get; set; }

    }
}
