using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Model
{
    public interface ITypeRepository
    {
        void Add(LoanTypeModel loanTypeModel);
        void Delete (int id);
        void Edit (LoanTypeModel loanTypeModel);

        IEnumerable<LoanTypeModel> GetAll ();
    }
}
