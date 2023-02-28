using Core1.Entities;
using Data.Contexts;
using Data.Repostories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Concret
{
    public class Grouprepositery : IGroupRepostory
    {
        static int id;
        public List<Group> GetAll(List<Group> groups)
        {
            return DbContext.Groups;
        }
        public Group Get(int id)
        {
            return DbContext.Groups.FirstOrDefault(g => g.Id == id);
        }
        public Group GetByName(string name)
        {
            return DbContext.Groups.FirstOrDefault(g => g.Name == name);
        }
        public void Add(Group group)
        {
            id++;
            group.Id = id;
            group.CreatedAt = DateTime.Now;
            DbContext.Groups.Add(group);
        }
        public void Update(Group group)
        {
            var dbGroup = DbContext.Groups.FirstOrDefault(g => g.Id == group.Id);
            if (dbGroup is null)
            {
                dbGroup.Name = group.Name;
                dbGroup.MaxSize = group.MaxSize;
                dbGroup.StartDate = group.StartDate;
                dbGroup.EndDate = group.EndDate;
                dbGroup.ModifiedAt = DateTime.Now; 


            }
        }
        public void Delete(Group group)
        {
            DbContext.Groups.Remove(group);
        }
        public void GetAllGroupByTeacher()
        {

        }
        public List<Group> GetAll()
        {
            return DbContext.Groups;
        }
    }
}
