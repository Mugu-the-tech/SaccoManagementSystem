using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem.View
{
   public interface ITypeView
    {
        string Id { get; set; }
        string Type_Name { get; set; }
        string Type_Description { get; set; }

        bool IsSuccessful { get; set; }
        bool IsEdit { get; set; }
        string Message { get; set; }

        //Events

        event EventHandler Addevent;
        event EventHandler SaveEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler CancelEvent;

        //
        void SetLoanTypeBindingSource(BindingSource LoanTypeList);
        void Show();

        
    }
}
