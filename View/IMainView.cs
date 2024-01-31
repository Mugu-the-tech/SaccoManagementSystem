using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.View
{
    public interface IMainView
    {
       

        event EventHandler ShowBorrowerView;
        event EventHandler ShowPaymentView;
        event EventHandler ShowLoansView;
        event EventHandler ShowLoanPlanView;
        event EventHandler ShowLoanTypeView;
        event EventHandler ShowMembersView;
        event EventHandler ShowSavingsView;
        

    }
}
