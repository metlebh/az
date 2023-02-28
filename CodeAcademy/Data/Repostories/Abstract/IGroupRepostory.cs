using Core1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repostories.Abstract
{
    public interface IGroupRepostory:IRepository<Group>
    {
        Group GetByName(string name);

    }
}
