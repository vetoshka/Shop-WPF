using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models;

namespace Store.Domain.Services
{
   public interface IAccountService :IDataService<Account>
   { 
       Account GetByUserName(string username);
       Account GetByEmail(string email);
   }
}
