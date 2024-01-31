using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Model
{
    public interface ILoanRepository
    {
        void Add(LoansModel loans);
        void Edit(LoansModel loans);
        void Delete(int id);

        IEnumerable<LoansModel> GetAll();
        IEnumerable<LoansModel> GetByValue(string  value);
        IEnumerable<LoansModel> GetLoanPlans();
        IEnumerable<LoansModel> GetBorrowers();
        IEnumerable<LoansModel> GetLoanType();

    }
}
