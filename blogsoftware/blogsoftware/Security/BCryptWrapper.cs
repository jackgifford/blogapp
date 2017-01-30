using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blogsoftware.Security
{
    public class BCryptWrapper
    {
        public virtual string GetSalt()
        {
            return BCrypt.GenerateSalt();
        }

        public virtual string GetHash(string password, string salt)
        {
            return BCrypt.HashPassword(password, salt);
        }

        public bool CheckPassword(string passwordActual, string passwordUser)
        {
            return BCrypt.CheckPassword(passwordUser, passwordActual);
        }
    }
}