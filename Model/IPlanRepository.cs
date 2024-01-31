using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Model
{
    public interface IPlanRepository
    {
        void Add(LoanPlanModel planModel);
        void Edit(LoanPlanModel planModel);
        void Delete(int id2);
        IEnumerable<LoanPlanModel> GetAll();
    }
}
