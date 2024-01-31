using ManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ManagementSystem.View
{
    public partial class Loans : Form,ILoanView
    {
        private bool isEdit;
        private bool isSuccessfull;
        private string message;

        public Loans()
        {
            InitializeComponent();
            AssociateAndRaiseEvents();
            LoansTabControl.TabPages.Remove(LoanDetails);
        }

        private void AssociateAndRaiseEvents()
        {
            AddBtn4.Click += delegate
            {
                AddLoan?.Invoke(this, EventArgs.Empty);
                LoansTabControl.TabPages.Remove(LoansTab);
                LoansTabControl.TabPages.Add(LoanDetails);
                HidePanel.Hide();
            };

            EditBtn4.Click += delegate
            {
                EditLoan?.Invoke(this, EventArgs.Empty);
                LoansTabControl.TabPages.Remove(LoansTab);
                LoansTabControl.TabPages.Add(LoanDetails);
                HidePanel.Show();
            };

            DeleteBtn4.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the above?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteLoan?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };

            CancelButn.Click += delegate
            {
                CancelLoan?.Invoke(this, EventArgs.Empty);
                LoansTabControl.TabPages.Remove(LoanDetails);
                LoansTabControl.TabPages.Add(LoansTab);
            };


            SaveBtn.Click += delegate
            {
                SaveLoan?.Invoke(this, EventArgs.Empty);
                if (isSuccessfull)
                {
                    LoansTabControl.TabPages.Remove(LoanDetails);
                    LoansTabControl.TabPages.Add(LoansTab);
                }
                MessageBox.Show(Message);
            };

            Calculate.Click += delegate
            {
                CalculateLoan?.Invoke(this, EventArgs.Empty);
            };

        }

        public string id { get => IDtxt.Text; set => IDtxt.Text = value; }
        public string ref_no { get => RefNoTxt.Text; set => RefNoTxt.Text = value; }
        public string loant_type_id { get =>TypeId.Text; set => TypeId.Text = value; }
        public string borrower_id { get => BorrowerID.Text; set => BorrowerID.Text = value; }
        public string purpose { get => purposetxt.Text; set => purposetxt.Text = value; }
        public string amount { get => amounttxt.Text; set => amounttxt.Text = value; }
        public string plan_id { get => PlanID.Text; set => PlanID.Text = value; }
        public string status { get => StatusTxt.Text; set => StatusTxt.Text = value; }
        public string date_released { get => datareleasedtxt.Text; set => datareleasedtxt.Text = value; }
        public string date_created { get => datecreated.Text; set => datecreated.Text = value; }
        public string SearchValue { get => SearchTxt1.Text; set => SearchTxt1.Text = value; }
        public string Message { get => message; set => message = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessful { get => isSuccessfull; set => isSuccessfull= value; }

        public event EventHandler AddLoan;
        public event EventHandler DeleteLoan;
        public event EventHandler EditLoan;
        public event EventHandler CancelLoan;
        public event EventHandler CalculateLoan;
        public event EventHandler SearchLoan;
        public event EventHandler SaveLoan;

        public void SetBorrowersBindingSource(BindingSource BorrowersList)
        {
          BorrowerID.DataSource = BorrowersList;
        }

        public void SetLoanPlanBindingSource(BindingSource LoanPlanList)
        {
           PlanID.DataSource = LoanPlanList;
        }

        public void SetLoansBindingSource(BindingSource LoanList)
        {
            LoansDataGridView.DataSource = LoanList;
        }

        public void SetLoanTypeBindingSource(BindingSource LoanTypeList)
        {
            TypeId.DataSource = LoanTypeList;
        }



        private static Loans instance;



        public static Loans GetInstance(Main mainPanel)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Loans ();
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

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void PlanID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(PlanID.SelectedItem is LoansModel selected)
            {
                string planid = selected.Plan_id.ToString();
            }
        }

        private void TypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TypeId.SelectedItem is LoansModel selected)
            {
                string typeId = selected.Type_name.ToString();
            }
        }

        private void BorrowerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(BorrowerID.SelectedItem is LoansModel selected)
            {
                string BorrowerID = selected.Borrower_id.ToString();
            }
        }
    }
}
