using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {

        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        [JsonIgnore]
        public ICollection<BankAccount> BankAccounts { get; set; }

    }
}
