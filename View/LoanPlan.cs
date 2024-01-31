using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem.View
{
    public partial class LoanPlan : Form,IplanView
    {
        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public LoanPlan()
        {
            InitializeComponent();
            AssociatedAndRaiseViewEvents();

            //
        }

        private void AssociatedAndRaiseViewEvents()
        {
            //Onclick events
            //save button
            SaveBtn2.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful )
                {
                    MessageBox.Show("Plan Save Successful");
                }
            };

            //edit button

            Editbtn2.Click += delegate 
            { 
                EditEvent?.Invoke(this, EventArgs.Empty);

            };

            // delete button

            DeleteBtn2.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the above?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }

            };

            Cancelbtn2.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public string Id { get => PlanId.Text; set => PlanId.Text=value; }
        public string Months { get => MonthsTxt.Text; set => MonthsTxt.Text=value; }
        public string Interest { get => InterestTxt.Text; set => InterestTxt.Text=value; }
        public string Rates { get => PenaltyTxt.Text; set => PenaltyTxt.Text=value; }
        public bool IsEdit { get => isEdit; set => isEdit=value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful=value; }
        public string Message { get => message; set => message=value; }

        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetPlanListBindingSource(BindingSource planlist)
        {
           PlanGridView.DataSource = planlist;
        }

        // show form

        private static LoanPlan instance;



        public static LoanPlan GetInstance(Main mainPanel)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new LoanPlan();
                instance.TopLevel = false;
                mainPanel.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
                instance.FormClosed += (sender, args) => { instance = null; };
                // Handle the FormClosing event
                instance.FormClosing += (sender, args) =>
                {
                    // Prevent the form from being disposed
                    args.Cancel = true;
                    // Hide the form instead of closing
                    instance.Hide();
                };
                /// instance.Show();

            }
            else
            {
                if (!instance.Visible)
                {
                    instance.Show();
                }
                instance.BringToFront();
            }
            return instance;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
