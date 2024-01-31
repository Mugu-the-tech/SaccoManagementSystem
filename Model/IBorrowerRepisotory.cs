using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Model
{
    public interface IBorrowerRepisotory
    {
        void Add(BorrowerModel borrowerModel);
        void Edit(BorrowerModel borrowerModel);
        void Delete(int  id);
        IEnumerable<BorrowerModel> GetAll();
        IEnumerable<BorrowerModel> GetByValue(string value);
    }
}
