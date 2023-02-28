using Core.Entities;
using Core.Helpers;
using Data.Contexts;
using Data.Repostories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Concret
{
    public class AdminRepository : IAdminRepository
    {
        public Admin GetByUSerNameAndPassword(string username, string password)
        {
           return DbContext.Admins.FirstOrDefault(a => a.UserName.ToLower() == username.ToLower() && PasswordHaser.Decrypt(a.Password)==password);
        }
    }
}
