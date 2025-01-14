using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJournal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public int AccessId { get; set; }
        //public AccessLevels AccessLevel { get; set; }
        public string? Login {  get; set; }
        public string? Password { get; set; }
    }
}
