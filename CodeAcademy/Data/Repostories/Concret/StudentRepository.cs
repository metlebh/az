using Core.Entities;
using Data.Contexts;
using Data.Repostories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Concret
{
    public class StudentRepository : IStudentRepository
    {
        static int id;
        public List<Student> GetAll()
        {
            return DbContext.Students;
        }

        public Student Get(int id)
        {
            return DbContext.Students.FirstOrDefault(s => s.Id == id);
        }

 
        public void Add(Student student)
        {
            student.Id++;
            DbContext.Students.Add(student);

        }
        public void Update(Student student)
        {
            var dbstudent = DbContext.Students.FirstOrDefault(s => s.Id == student.Id);
            if (dbstudent is not null)
            {
                dbstudent.Name = student.Name;
                dbstudent.Surname = student.Surname;
                dbstudent.BirthDate = student.BirthDate;

            }
        }

        public void Delete(Student student)
        {
            DbContext.Students.Remove(student);
        }

        public bool IsDublicateEmail(string email)
        {
           return DbContext.Students.Any(s => s.Email == email);
        }
    }
}
