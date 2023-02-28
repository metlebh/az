using Core.Constant;
using Core.Entities;
using Core.Helpers;
using Core1.Entities;
using Data;
using Data.Contexts;
using Data.Repostories.Abstract;
using Data.Repostories.Concret;
using Presentation.Sevices;
using System;
using System.Globalization;

namespace Presentation.Sevices
{
    public class AdminService
    {
        private readonly AdminRepository _adminRepository;
        public AdminService()
        {
            _adminRepository = new AdminRepository();
        }
        public Admin Authorize()
        {

           LoginDes: ConsoleHelper.WriteWithColor("**** LOGIN *****", ConsoleColor.DarkCyan);
            ConsoleHelper.WriteWithColor("USER NAME", ConsoleColor.DarkCyan);
            string username = Console.ReadLine();
            ConsoleHelper.WriteWithColor("USER PASSWORD", ConsoleColor.DarkCyan);
            string password = Console.ReadLine();

            var admin = _adminRepository.GetByUSerNameAndPassword(username, password);
            if (admin is null)
            {
                ConsoleHelper.WriteWithColor("Username or password wrong", ConsoleColor.DarkRed);
                goto LoginDes;
            }
            return admin;

        }
    }
}
