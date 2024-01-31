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
    public partial class LoanType : Form , ITypeView
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public LoanType()
        {
            InitializeComponent();
            AssociateAndRaiseEvents();
        }

        private void AssociateAndRaiseEvents()
        {
            SaveBtn3.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    MessageBox.Show("Plan Save Successful");
                }
            };

            //Edit Button
            Editbtn3.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
            };

            //Delete Button
            DeleteBtn3.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the above?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };

            Cancelbtn3.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
            };

        }

        public string Id { get => TypeIdTxt.Text; set => TypeIdTxt.Text = value; }
        public string Type_Name { get => LoanTypeTxt.Text; set => LoanTypeTxt.Text = value; }
        public string Type_Description { get => LoanDescriptionTxt.Text; set => LoanDescriptionTxt.Text = value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful=value; }
        public bool IsEdit { get =>isEdit; set => isEdit = value; }
        public string Message { get => message; set => message=value; }

        public event EventHandler Addevent;
        public event EventHandler SaveEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler EditEvent;
        public event EventHandler CancelEvent;

        public void SetLoanTypeBindingSource(BindingSource LoanTypeList)
        {
            TypeGridView.DataSource= LoanTypeList;
        }

        private static LoanType instance;



        public static LoanType GetInstance(Main mainPanel)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new LoanType();
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
    }
}
