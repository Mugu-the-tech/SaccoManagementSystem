using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSystem.View;
using ComponentFactory.Krypton;
using ComponentFactory.Krypton.Toolkit;

namespace ManagementSystem.View
{
    public partial class Borrowers : Form,IBorrowerView
    {
        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        //Constructor
        public Borrowers()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            BorrowerList.TabPages.Remove(tabPage2Details);
        }

        private void AssociateAndRaiseViewEvents()
        {
            SearchBtn.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            SearchTxt.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            ///Add Buttons
            AddBtn.Click += delegate 
            { AddEvent?.Invoke(this, EventArgs.Empty);
                BorrowerList.TabPages.Remove(tabPage1);
                BorrowerList.TabPages.Add(tabPage2Details);
                tabPage2Details.Text = "Add New Borrower";
            };

            ///Edit
            ///

            EditBtn.Click += delegate 
            { EditEvent?.Invoke(this, EventArgs.Empty);
                BorrowerList.TabPages.Remove(tabPage1);
                BorrowerList.TabPages.Add(tabPage2Details);
                tabPage2Details.Text = "Edit Borrower Details";
            };

            ///Delete
            ///
            DeleteBtn.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the above?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
               if(result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };

            ///Cancel
            ///
            CancelBtn1.Click += delegate 
            { 
                CancelEvent?.Invoke(this, EventArgs.Empty);
                BorrowerList.TabPages.Remove(tabPage2Details);
                BorrowerList.TabPages.Add(tabPage1);
            };

            ///Save 
            ///

            SaveBtn1.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty); 
                if(isSuccessful)
                {
                    BorrowerList.TabPages.Remove(tabPage2Details);
                    BorrowerList.TabPages.Add(tabPage1);
                }
                MessageBox.Show(Message);
            };
        }

        //Properties
        public string Id { get => Borrowerid.Text; set => Borrowerid.Text = value; }
        public string Firstname { get => FirstNameTxt.Text; set => FirstNameTxt.Text = value; }
        public string Middlename { get => MiddleNameTxt.Text; set => MiddleNameTxt.Text = value; }
        public string Lastname { get => LastNameTxt.Text; set => LastNameTxt.Text = value; }
        public string Contact { get => ContactTxt.Text; set => ContactTxt.Text = value; }
        public string Address { get => AddressTxt.Text; set => AddressTxt.Text = value; }
        public string Email { get => EmailTxt.Text; set => EmailTxt.Text = value; }
        public string Tax_id { get => TaxtIdTxt.Text; set => TaxtIdTxt.Text = value; }
        public string Date_created { get => DateTxt.Text ; set => DateTxt.Text = value; }
        public string SearchValue { get => SearchTxt.Text; set => SearchTxt.Text = value; }
        public bool IsEdit { get =>  isEdit; set => isEdit = value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message = value; }
       

        //Events
        public event EventHandler SearchEvent;
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        //Method
        public void SetBorrowerListBindingSource(BindingSource borrowerlist)
        {
            dataGridView.DataSource = borrowerlist;
        }

        //Singleton Pattern

        private static Borrowers instance;



        public static Borrowers GetInstance( Main mainPanel)
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new Borrowers();
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
