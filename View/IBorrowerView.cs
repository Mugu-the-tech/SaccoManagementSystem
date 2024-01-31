using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem.View
{
    public interface IBorrowerView
    {
        string Id { get; set; }
        string Firstname { get; set; }
        string Middlename { get; set; }
        string Lastname { get; set; }
        string Contact {  get; set; }
        string Address { get; set; }
        string Email { get; set; }
        string Tax_id { get; set; }
        string Date_created { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Events

        event EventHandler SearchEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        // Methods

        void SetBorrowerListBindingSource(BindingSource borrowerlist);
        void Show();
    }
}
