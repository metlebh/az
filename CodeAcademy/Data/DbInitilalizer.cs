using Core.Entities;
using Core.Helpers;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DbInitilalizer
    {
        static int id;
        public static void SeeAdmins()
        {
            var admins = new List<Admin>
            {
                new Admin
                {
                  Id=++id,
                  UserName="admin",
                  Password=PasswordHaser.Encrypt("123"),
                  CreatedBy="System"

                },
                new Admin
                {
                  Id=++id,
                  UserName="admin2",
                  Password=PasswordHaser.Encrypt("123"),
                  CreatedBy="System"
                }

            };
            DbContext.Admins.AddRange(admins);
        }

    };

}




