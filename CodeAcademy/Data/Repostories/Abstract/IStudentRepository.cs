using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Abstract
{
    public interface IStudentRepository:IRepository<Student>
    {
        bool IsDublicateEmail(string email);        
    }
}

