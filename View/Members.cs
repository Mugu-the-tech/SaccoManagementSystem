using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace ManagementSystem.View
{
    public partial class Members : Form,IMemberView
    {
        private string message;
        private bool isEdit;
        private bool isSuccessful;
        public Members()
        {
            InitializeComponent();
            AssociateAndRaiseEvents();
            MembersTab.TabPages.Remove(MembersTab1);
        }

        private void AssociateAndRaiseEvents()
        {
            AddBtn4.Click += delegate
            {
                AddEvent?.Invoke(this, EventArgs.Empty);
                MembersTab.TabPages.Remove(MembersDetail);
                MembersTab.TabPages.Add(MembersTab1);
                MembersTab1.Text = "Add New Members";
            };

            //Edit Button

            EditBtn4.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                MembersTab.TabPages.Remove(MembersDetail);
                MembersTab.TabPages.Add(MembersTab1);
                MembersTab1.Text = "Edit Member Details";
            };

            //delete button
            DeleteBtn4.Click += delegate
            {

                var result = MessageBox.Show("Are you sure you want to delete the above?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };

            // Cancel Button

            CancelBtn1.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                MembersTab.TabPages.Remove(MembersTab1);
                MembersTab.TabPages.Add(MembersDetail);
            };


            SearchBtn2.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            SearchTxt1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            //save button

            SaveBtn1.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    MembersTab.TabPages.Remove(MembersTab1);
                   MembersTab.TabPages.Add(MembersDetail);
                }
                MessageBox.Show(Message);

            };

        }

        public string Member_ID { get => MemberID.Text; set => MemberID.Text = value; }
        public string Member_Name { get => MemberNameTxt.Text; set =>MemberNameTxt.Text = value; }
        public string Contact { get => MemberContactTxt.Text; set => MemberContactTxt.Text =value; }
        public string Position { get => PositionTxt.Text; set => PositionTxt.Text =value; }
        public string Next_of_Kin { get => NextofKinTxt.Text; set => NextofKinTxt.Text = value; }
        public string Member_Gender { get => Gender.Text; set => Gender.Text=value; }
        public string Member_Status { get => Status.Text; set => Status.Text =value; }
        public bool IsEdit { get => isEdit; set => isEdit =value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message =value; }
        public string SearchValue { get => SearchTxt1.Text; set => SearchTxt1.Text = value; }

        //events
        public event EventHandler AddEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SearchEvent;
        public event EventHandler CancelEvent;
        public event EventHandler SaveEvent;

        public void SetMemberBindingSource(BindingSource MembersList)
        {
            membersDataGridView.DataSource = MembersList;
        }

        //Singlrton Pattern

        private static Members instance;



        public static Members GetInstance(Main mainPanel)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Members();
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
