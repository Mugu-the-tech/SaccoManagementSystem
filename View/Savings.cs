using ManagementSystem.Model;
using ManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem.View
{
    public partial class Savings : Form, ISavingsView
    {
        private bool isEdit;
        private bool isSuccessful;
        private string message;

        public Savings()
        {
            InitializeComponent();
            AssociateAndRaiseEvents();
            SavingsPage.TabPages.Remove(SavingsPage2);
        }

        private void AssociateAndRaiseEvents()
        {
            //Add Button
            AddBtn4.Click += delegate
            {
                AddSavings?.Invoke(this, EventArgs.Empty);
                SavingsPage.TabPages.Remove(SavingsPage1);
                SavingsPage.TabPages.Add(SavingsPage2);
                MemberTxt.SelectedIndexChanged += MemberTxt_SelectedIndexChanged;
            };

            //Edit button

            EditBtn4.Click += delegate
            {
                EditSavings?.Invoke(this, EventArgs.Empty);
                SavingsPage.TabPages.Remove(SavingsPage1);
                SavingsPage.TabPages.Add(SavingsPage2);
                MemberTxt.SelectedIndexChanged += MemberTxt_SelectedIndexChanged;
            };

            //Delete 

            DeleteBtn4.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the above?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteSavings?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
            //Cancel

            CancelButn.Click += delegate
            {
                CancelSavings?.Invoke(this, EventArgs.Empty);
                SavingsPage.TabPages.Remove(SavingsPage2);
                SavingsPage.TabPages.Add(SavingsPage1);
            };

            // Calculate
            Calculate.Click += delegate
            {
                CalculateSavings?.Invoke(this, EventArgs.Empty);

            };
            //Save

            SaveBtn.Click += delegate
            {
                SaveSavings?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    SavingsPage.TabPages.Remove(SavingsPage2);
                    SavingsPage.TabPages.Add(SavingsPage1);
                }
                MessageBox.Show(Message);
            };

            
        }

        public string id { get => idtxt.Text; set => idtxt.Text = value; }
        public string MemberName { get => MemberTxt.Text; set => MemberTxt.Text = value; }
        public string MonthlySavings { get => MonthlySaveTxt.Text; set => MonthlySaveTxt.Text = value; }
        public string TotalSavings { get =>TotalSavingsTxt.Text; set =>TotalSavingsTxt.Text = value; }
        public string SearchValue { get => SearchTxt1.Text; set => SearchTxt1.Text = value; }
        public bool IsEdit { get => isEdit; set => isEdit =value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message=value; }
         public string CurrentSavings { get => CurrentSavingsTxt.Text; set => CurrentSavingsTxt.Text = value; }
        public string MemberID { get => MemberIdtxt.Text; set => MemberIdtxt.Text = value; }

        public event EventHandler AddSavings;
        public event EventHandler RemoveSavings;
        public event EventHandler EditSavings;
        public event EventHandler CalculateSavings;
        public event EventHandler CancelSavings;
        public event EventHandler DeleteSavings;
        public event EventHandler SaveSavings;

        public void SetSavingsListBindingSource(BindingSource SavingsList)
        {
       
           SavingsDataGridView.DataSource = SavingsList;

        }
        public void SetDropDownBindingSource(BindingSource MemberList)
        {
            MemberTxt.DataSource = MemberList;
           // SavingsDataGridView.DataSource = MemberList;
        }

        //Singleton Pattern

        private static Savings instance;



        public static Savings GetInstance(Main mainPanel)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Savings();
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

        private void MemberTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MemberTxt.SelectedItem != null)
            {
                // Assuming your SavingsModel class has a property named Members_id
                int selectedMemberId = ((SavingsModel)MemberTxt.SelectedItem).Members_id;
                MemberIdtxt.Text = selectedMemberId.ToString();
            }
        }
    }
}
