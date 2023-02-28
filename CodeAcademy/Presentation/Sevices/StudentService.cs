using Core.Constant.Extensions;
using Core.Entities;
using Core.Helpers;
using Data.Repostories.Concret;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Presentation.Sevices
{
    public class StudentService
    {
        private readonly GroupService _groupService;
        private readonly Grouprepositery _grouprepositery;
        private readonly StudentRepository _studentRepository;
        private readonly AdminRepository _adminRepository;

        public StudentService()
        {
            _groupService = new GroupService();
            _grouprepositery = new Grouprepositery();
            _studentRepository = new StudentRepository();
        }
        public void Creat(Admin admin)
        {
            if (_grouprepositery.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("First you need to create a group", ConsoleColor.DarkRed);
                return;
            }


            ConsoleHelper.WriteWithColor("Enter Student name", ConsoleColor.DarkCyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter Student surname", ConsoleColor.DarkCyan);
            string surname = Console.ReadLine();
        EmailCheck: ConsoleHelper.WriteWithColor("Enter Student emil", ConsoleColor.DarkCyan);
            string email = Console.ReadLine();
            if (!email.IsEmail())
            {
                ConsoleHelper.WriteWithColor("Email is not corecct format", ConsoleColor.DarkRed);
                goto EmailCheck;
            }
            if (_studentRepository.IsDublicateEmail(email))
            {
                ConsoleHelper.WriteWithColor("This email allready used", ConsoleColor.DarkRed);
                goto EmailCheck;

            }

        DateTimeDes: ConsoleHelper.WriteWithColor("****Enter Birth Date****", ConsoleColor.DarkCyan);
            DateTime BirthDate;
            bool isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out BirthDate);
            if (!(isSucceeded))
            {
                ConsoleHelper.WriteWithColor("*Birth Date is not correct format\n*Example:dd.mm.yyyy", ConsoleColor.DarkRed);
                goto DateTimeDes;
            }

        GroupDes: _groupService.GetAll();

            ConsoleHelper.WriteWithColor("****Enter Group Id****", ConsoleColor.DarkCyan);

            int groupId;
            isSucceeded = int.TryParse(Console.ReadLine(), out groupId);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Group Id is not correct format");
                goto GroupDes;
            }
            var group = _grouprepositery.Get(groupId);
            if (group is null)
            {
                ConsoleHelper.WriteWithColor("Group is not exist in this id", ConsoleColor.DarkRed);
                goto GroupDes;
            }
            if (group.MaxSize <= group.Students.Count)
            {
                ConsoleHelper.WriteWithColor("This group is full", ConsoleColor.DarkRed);
                return;
            }


            var student = new Student
            {
                Name = name,
                Surname = surname,
                Email = email,
                BirthDate = BirthDate,
                Group = group,
                GroupId = groupId,
                CreatedBy = admin.UserName
            };

            group.Students.Add(student);
            _studentRepository.Add(student);
            ConsoleHelper.WriteWithColor($"{student.Name} {student.Surname} is succesfully added", ConsoleColor.DarkGreen);






        }
        public void Update(Admin admin)
        {
            GetAll();

        Iddes: ConsoleHelper.WriteWithColor("ENTER ID", ConsoleColor.DarkCyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Id is nor coorect format", ConsoleColor.DarkRed);
                goto Iddes;
            }
            var student = _studentRepository.Get(id);
            if (student is null)
            {
                ConsoleHelper.WriteWithColor("There is no any student this ID", ConsoleColor.DarkRed);
            }

            ConsoleHelper.WriteWithColor("****Enter new name****", ConsoleColor.DarkCyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("****Enter new surname****", ConsoleColor.DarkCyan);
            string surname = Console.ReadLine();
            DateTimeDes: ConsoleHelper.WriteWithColor("****Enter new Birth Date****", ConsoleColor.DarkCyan);
            DateTime BirthDate;
            isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out BirthDate);
            if (!(isSucceeded))
            {
                ConsoleHelper.WriteWithColor("*Birth Date is not correct format\n*Example:dd.mm.yyyy", ConsoleColor.DarkRed);
                goto DateTimeDes;
            }
            _groupService.GetAll();
            NewGroupDes: ConsoleHelper.WriteWithColor("****Enter new group****", ConsoleColor.DarkCyan);
            int groupId;
            isSucceeded = int.TryParse(Console.ReadLine(), out groupId);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Group Id is not correct format", ConsoleColor.DarkRed);
                goto NewGroupDes;
            }

            var group=_grouprepositery.Get(groupId);
            if (group is null)
            {
                ConsoleHelper.WriteWithColor("There is no group this id", ConsoleColor.DarkRed);
                goto NewGroupDes;
            }

            student.Name = name;
            student.Surname = surname;
            student.BirthDate = BirthDate;
            student.Group = group;
            student.GroupId = groupId;
            student.ModifiedBy = admin.UserName;

            _studentRepository.Update(student);

            ConsoleHelper.WriteWithColor($"{student.Name} {student.Surname} succesfully updated", ConsoleColor.DarkGreen);
                

        }
        public void GetAllStudentByGroup()
        {
            ConsoleHelper.WriteWithColor("Enter Group ID", ConsoleColor.DarkCyan);

            int groupId;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out groupId);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Group ID is not correct format", ConsoleColor.DarkRed);
            }

            var group = _grouprepositery.Get(groupId);
            if (group is null)
            {
                ConsoleHelper.WriteWithColor("There is no any group this id", ConsoleColor.DarkRed);
            }

            if (group.Students.Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no student this group", ConsoleColor.DarkRed);

            }
            else
            {
                foreach (var student in group.Students)
                {
                    ConsoleHelper.WriteWithColor($"--ID-{student.Id}\n--FULL NAME-{student.Surname} {student.Name}");

                }

            }


        }
        public void GetAll()
        {
            var students = _studentRepository.GetAll();
            ConsoleHelper.WriteWithColor("**** ALL STUDENTS ****", ConsoleColor.DarkCyan);
            foreach (var student in students)
            {
                ConsoleHelper.WriteWithColor($"--ID-{student.Id}\n--FULL NAME-{student.Surname} {student.Name}\n--Group-{student.Group?.Name}");
            }
        }
        public void Delete()
        {
            GetAll();
        IdDes: ConsoleHelper.WriteWithColor("Enter Student Id", ConsoleColor.DarkCyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Id is not correct format", ConsoleColor.DarkRed);
                goto IdDes;
            }
            var student = _studentRepository.Get(id);
            if (student is null)
            {
                ConsoleHelper.WriteWithColor("There is no student this ID", ConsoleColor.DarkRed);
                goto IdDes;
            }
            _studentRepository.Delete(student);
            ConsoleHelper.WriteWithColor($"{student.Name} {student.Surname} is succesfuly Deleted", ConsoleColor.DarkGreen);

        }
    }
}

