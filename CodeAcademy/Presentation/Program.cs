using Core.Constant;
using Core.Helpers;
using Core1.Entities;
using Data;
using Data.Contexts;
using Data.Repostories.Concret;
using Presentation.Sevices;
using System;
using System.Globalization;

namespace Presentation
{

    class Program
    {
        private readonly static GroupService _grooupSevice;
        private readonly static StudentService _studentService;
        private readonly static Grouprepositery _grouprepositery;
        private readonly static AdminService _adminService;
        private readonly static TeacherService _teacherService;
        static Program()
        {
            _grooupSevice = new GroupService();
            _studentService = new StudentService();
            _grouprepositery = new Grouprepositery();
            _adminService = new AdminService();
            _teacherService = new TeacherService();
            DbInitilalizer.SeeAdmins();
        }

        static void Main(string[] args)
        {
           AdminDes: var admin = _adminService.Authorize();
            if (admin is not null)
            {
            CODEDES: ConsoleHelper.WriteWithColor("****Welcome CodeAcademy****", ConsoleColor.Cyan);
                while (true)
                {

                MainMenuDes: ConsoleHelper.WriteWithColor("1-Groups", ConsoleColor.DarkYellow);
                    ConsoleHelper.WriteWithColor("2-Students", ConsoleColor.DarkYellow);
                    ConsoleHelper.WriteWithColor("3-Teachers", ConsoleColor.DarkYellow);
                    ConsoleHelper.WriteWithColor("0-LogOut", ConsoleColor.DarkYellow);

                    int number;
                    ConsoleHelper.WriteWithColor("**** Select Option****", ConsoleColor.Cyan);

                    bool isSucceeded = int.TryParse(Console.ReadLine(), out number);
                    if (!isSucceeded)
                    {
                        ConsoleHelper.WriteWithColor("The entered number is not in the correct format ", ConsoleColor.DarkRed);
                        goto MainMenuDes;
                    }
                    else
                    {
                        switch (number)
                        {
                            case (int)MainMenuOptions.Groups:
                                while (true)
                                {

                                GroupDes: ConsoleHelper.WriteWithColor("1-Creat Group", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("2-Update Group", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("3-Delete Group", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("4-Get All Groups", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("5-Get Group By İd", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("6-Get Group By Name", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("7-Get All Group By Teacher", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("0-Back to main menu", ConsoleColor.DarkYellow);


                                    ConsoleHelper.WriteWithColor("**** Select Option****", ConsoleColor.Cyan);

                                    isSucceeded = int.TryParse(Console.ReadLine(), out number);

                                    if (!(number >= 0 && number <= 6))
                                    {
                                        ConsoleHelper.WriteWithColor("The entered number is not available\nEnter 0-6 digits", ConsoleColor.DarkRed);
                                    }
                                    else
                                    {

                                        switch (number)
                                        {
                                            case (int)Group_options.CreatGroup:
                                                _grooupSevice.Creat(admin);
                                                break;
                                            case (int)Group_options.UpdateGroup:
                                                _grooupSevice.Update(admin);
                                                break;
                                            case (int)Group_options.DeleteGroup:
                                                _grooupSevice.Delete(admin);
                                                break;
                                            case (int)Group_options.GetAllGroups:
                                                _grooupSevice.GetAll();
                                                break;
                                            case (int)Group_options.GetGroupById:
                                                _grooupSevice.GetGroupById(admin);
                                                break;
                                            case (int)Group_options.GetGroupByName:
                                                _grooupSevice.GetGroupByName(admin);
                                                break;
                                            case (int)Group_options.GetAllGroupsByTeacher:
                                                _grooupSevice.GetAllGroupByTeacher();
                                                break;
                                            case (int)Group_options.BackToMainMenu:
                                                goto MainMenuDes;
                                                break;

                                            default:
                                                ConsoleHelper.WriteWithColor("The entered number is not in the correct format ", ConsoleColor.DarkRed);
                                                goto GroupDes;

                                                break;
                                        }
                                    }

                                }
                            case (int)MainMenuOptions.Students:
                                while (true)
                                {
                                StudentDes: ConsoleHelper.WriteWithColor("1-Creat Student", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("2-Update Student", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("3-Delete Student", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("4-Get all Students ", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("5-Get all Students By Group", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("0-Go To Main Menu", ConsoleColor.DarkYellow);

                                    isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                    if (!(number >= 0 && number <= 6))
                                    {
                                        ConsoleHelper.WriteWithColor("The entered number is not available\nEnter 0-5 digits", ConsoleColor.DarkRed);
                                    }
                                    else
                                    {

                                        switch (number)
                                        {
                                            case (int)StudentOptions.CreatStudent:
                                                _studentService.Creat(admin);
                                                break;
                                            case (int)StudentOptions.UpdateStudent:
                                                _studentService.Update(admin);
                                                break;
                                            case (int)StudentOptions.DeleteStudent:
                                                _studentService.Delete();
                                                break;
                                            case (int)StudentOptions.GetAllStudents:
                                                _studentService.GetAll();
                                                break;
                                            case (int)StudentOptions.GetAllStudentsByGroup:
                                                _studentService.GetAllStudentByGroup();
                                                break;
                                            case (int)StudentOptions.GetAllStudentsByID:
                                                break;
                                            case (int)StudentOptions.BackToMainMenu:
                                                goto CODEDES;
                                                break;


                                            default:
                                                ConsoleHelper.WriteWithColor("The entered number is not in the correct format ", ConsoleColor.DarkRed);
                                                goto StudentDes;

                                                break;
                                        }
                                    }
                                }
                            case (int)MainMenuOptions.Teachers:
                                while (true)
                                {
                                StudentDes: ConsoleHelper.WriteWithColor("1-Creat Teacher", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("2-Update Teacher", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("3-Delete Teacher", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("4-Get all Teacher ", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("5-Get all Teacher By Group", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("0-Go To Main Menu", ConsoleColor.DarkYellow);

                                    isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                    if (!(number >= 0 && number <= 6))
                                    {
                                        ConsoleHelper.WriteWithColor("The entered number is not available\nEnter 0-5 digits", ConsoleColor.DarkRed);
                                    }
                                    else
                                    {

                                        switch (number)
                                        {
                                            case (int)TeacherOptions.CreatTeacher:
                                                _teacherService.Create();
                                                break;
                                            case (int)TeacherOptions.UpdateTeacher:
                                                _teacherService.Update();
                                                break;
                                            case (int)TeacherOptions.DeleteTeacher:
                                                _teacherService.Delete();
                                                break;
                                            case (int)TeacherOptions.GetAllTeachers:
                                                _teacherService.GetAll();
                                                break;
                                           case (int)TeacherOptions.BackToMainMenu:
                                                goto MainMenuDes;
                                                break;


                                            default:
                                                ConsoleHelper.WriteWithColor("The entered number is not in the correct format ", ConsoleColor.DarkRed);
                                                goto StudentDes;

                                                break;
                                        }
                                    }
                                }

                            case (int)MainMenuOptions.Logout:
                                goto AdminDes;


                            default:
                                ConsoleHelper.WriteWithColor("The entered number is not available\nEnter 0-2 digits", ConsoleColor.DarkRed);
                                break;
                        }
                    }
                }
            }
           
            
        }
    }
}
