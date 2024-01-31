using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Model
{
   public interface ISavingsRepository
    {
        void Add(SavingsModel savings);
        void Edit(SavingsModel savings);
        void Delete(int  id);

        IEnumerable<SavingsModel> GetAll();
        IEnumerable<SavingsModel> GetByValue(String value);
        IEnumerable<SavingsModel> GetMembers();
    }
}
