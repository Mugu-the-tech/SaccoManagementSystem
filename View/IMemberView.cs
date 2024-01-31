using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem.View
{
    public interface IMemberView
    {
        string Member_ID { get; set; }
        string Member_Name { get; set; }
        string Contact { get; set; }
        string Member_Gender { get; set; }
        string Position { get; set; }
        string Next_of_Kin { get; set; }
        string Member_Status { get; set; }
        string SearchValue {  get; set; }

        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        //Events 

        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SearchEvent;
        event EventHandler CancelEvent;
        event EventHandler SaveEvent;

        // binding source

        void SetMemberBindingSource(BindingSource MembersList);
        void Show();

    }
}
