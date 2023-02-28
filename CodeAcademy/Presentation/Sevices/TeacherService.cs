using Core.Entities;
using Core.Helpers;
using Data.Repostories.Concret;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Sevices
{
    public class TeacherService
    {
        private readonly TeacherRepository _teacherRepository;

        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();
        }
        public void Create()
        {
            ConsoleHelper.WriteWithColor("Enter Teacher name", ConsoleColor.DarkCyan);
            string name = Console.ReadLine();

            ConsoleHelper.WriteWithColor("Enter Teacher surname", ConsoleColor.DarkCyan);
            string surname = Console.ReadLine();

        DateTimeDes: ConsoleHelper.WriteWithColor("Enter BirthDate", ConsoleColor.DarkCyan);
            DateTime BirthDate;
            bool isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out BirthDate);
            if (!(isSucceeded))
            {
                ConsoleHelper.WriteWithColor("*Birth Date is not correct format\n*Example:dd.mm.yyyy", ConsoleColor.DarkRed);
                goto DateTimeDes;
            }
            ConsoleHelper.WriteWithColor("Enter Teacher Speciality", ConsoleColor.DarkCyan);
            string speciality = Console.ReadLine();

            var teacher = new Teacher
            {
                Name = name,
                Surname = surname,
                BirthDate = BirthDate,
                Speciality = speciality,
                CreatedAt = DateTime.Now
            };

            _teacherRepository.Add(teacher);
            ConsoleHelper.WriteWithColor($"Teacher {teacher.Name} {teacher.Surname} has succesfuly added", ConsoleColor.DarkGreen);


        }

        public void GetAll()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no any Teacher", ConsoleColor.DarkRed);
                return;
            }

            foreach (var teacher in teachers)
            {
                if (teacher.Groups.Count == 0)
                {
                    ConsoleHelper.WriteWithColor("There is no any group this teacher", ConsoleColor.DarkRed);
                }
                ConsoleHelper.WriteWithColor($"{teacher.Name} {teacher.Surname} succesfuly created", ConsoleColor.DarkGreen);
                foreach (var group in teacher.Groups)
                {
                    ConsoleHelper.WriteWithColor($"ID:{group.Id}\nName:{group.Name}");
                }
            }
        }

        public void Delete()
        {
            GetAll();
            if (_teacherRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no teacher", ConsoleColor.DarkRed);
            }
            else
            {
            TeacherIdDes: ConsoleHelper.WriteWithColor("Enter Teacher ID", ConsoleColor.DarkCyan);
                int id;
                bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
                if (!isSucceeded)
                {
                    ConsoleHelper.WriteWithColor("ID is not correct format", ConsoleColor.DarkRed);
                    goto TeacherIdDes;
                }
                var teacher = _teacherRepository.Get(id);
                if (teacher is null)
                {
                    ConsoleHelper.WriteWithColor("There is no any teacher this ID", ConsoleColor.DarkRed);
                }
                _teacherRepository.Delete(teacher);
                ConsoleHelper.WriteWithColor($"{teacher.Name} {teacher.Surname} succesfuly Deleted", ConsoleColor.DarkGreen);
            }


        }

        public void Update()
        {
            GetAll();

            UpdateDes: ConsoleHelper.WriteWithColor("Enter Teavher ID Fir Update", ConsoleColor.DarkCyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("ID is not correct format", ConsoleColor.DarkRed);
                goto UpdateDes;
            }
            _teacherRepository.Get(id);
            var teacher = _teacherRepository.Get(id);
            if (teacher is null)
            {
                ConsoleHelper.WriteWithColor("There is no any teacher in this id", ConsoleColor.DarkRed);
                goto UpdateDes;
            }
            ConsoleHelper.WriteWithColor("Enter new name", ConsoleColor.DarkCyan);
            string name = Console.ReadLine();
            ConsoleHelper.WriteWithColor("Enter new surname", ConsoleColor.DarkCyan);
            string surname= Console.ReadLine();
        DateTimeDes: ConsoleHelper.WriteWithColor("Enter new BirthDate", ConsoleColor.DarkCyan);
            DateTime BirthDate;
            isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out BirthDate);
            if (!(isSucceeded))
            {
                ConsoleHelper.WriteWithColor("*Birth Date is not correct format\n*Example:dd.mm.yyyy", ConsoleColor.DarkRed);
                goto DateTimeDes;
            }
            ConsoleHelper.WriteWithColor("Enter Teacher Speciality", ConsoleColor.DarkCyan);
            string speciality = Console.ReadLine();
            teacher.Name = name;
            teacher.Surname = surname;
            teacher.BirthDate = BirthDate;
            teacher.Speciality = speciality;
            _teacherRepository.Update(teacher);
            ConsoleHelper.WriteWithColor($"{teacher.Name} {teacher.Surname} succesfuly updated", ConsoleColor.DarkGreen);




        }
    }
}
