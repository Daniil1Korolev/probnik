using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing2._0
{
    public class AuthService
    {
        public bool Authenticate(string login, string password)
        {
            using (var context = new UchetContext())
            {
                var user = context.Users.SingleOrDefault(u => u.Login == login && u.Password == password);
                return user != null;
            }
        }
    }
}