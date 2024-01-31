using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem.View
{
    public interface ILoanView
    {
        string id { get; set; }
        string ref_no { get; set; }
        string loant_type_id { get; set; }
        string borrower_id { get; set; }
        string purpose {  get; set; }
        string amount { get; set; }
        string plan_id { get; set; }
        string status { get; set; }
        string date_released { get; set; }
        string date_created { get; set; }

        string SearchValue { get; set; }
        string Message { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }

        // events

        event EventHandler AddLoan;
        event EventHandler DeleteLoan;
        event EventHandler EditLoan;
        event EventHandler CancelLoan;
        event EventHandler CalculateLoan;
        event EventHandler SearchLoan;
        event EventHandler SaveLoan;

        //Binding Source

        void SetLoansBindingSource(BindingSource LoanList);
        void SetLoanTypeBindingSource(BindingSource LoanTypeList);
        void SetLoanPlanBindingSource(BindingSource LoanPlanList);
        void SetBorrowersBindingSource (BindingSource BorrowersList);
        void Show();

    }
}
