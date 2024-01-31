using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Model
{
   public interface IMemberRepository
    {
        void Add(MembersModel member);
        void Edit(MembersModel member);
        void Delete(int member_id);

        IEnumerable<MembersModel> GetAll();
        IEnumerable<MembersModel> GetByValue(String value);
        
    }
}
