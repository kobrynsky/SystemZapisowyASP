using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZapisowy.Models;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface IStudentsGroupRepository: IRepository<StudentsGroup>
    {
        void SignUp(decimal indexNumber, int groupId);
        void RemoveByGroupId(int groupId);
    }
}
