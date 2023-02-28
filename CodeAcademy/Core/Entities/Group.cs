﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core1.Entities
{
    public class Group : BaseEntity
    {
        public Group()
        {
            Students = new List<Student>();
        }
        public string Name { get; set; }
        public int MaxSize { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate{ get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherID { get; set; }
    }
}
