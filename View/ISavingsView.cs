using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem.View
{
    public interface ISavingsView
    {
        string id { get; set; }
        string MemberID { get; set; }
        string MemberName { get; set; }
        string MonthlySavings { get; set; }
        string TotalSavings { get; set; }
        string CurrentSavings { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //
        event EventHandler AddSavings;
        event EventHandler RemoveSavings;
        event EventHandler EditSavings;
        event EventHandler CalculateSavings;
        event EventHandler CancelSavings;
        event EventHandler DeleteSavings;
        event EventHandler SaveSavings;

        ///
        void SetDropDownBindingSource(BindingSource MemberList);
        void SetSavingsListBindingSource(BindingSource SavingsList);
        void Show();
    }
}
