using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using FontAwesome.Sharp;
using System.Windows.Media;
using Color = System.Drawing.Color;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using ManagementSystem.View;

namespace ManagementSystem
{
    public partial class Main : Form,IMainView
    {
        //fields

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

  

        public event EventHandler ShowBorrowerView;
        public event EventHandler ShowPaymentView;
        public event EventHandler ShowLoansView;
        public event EventHandler ShowLoanPlanView;
        public event EventHandler ShowLoanTypeView;
        public event EventHandler ShowMembersView;
        public event EventHandler ShowSavingsView;

        public Main()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7,50);
            SideMenu.Controls.Add(leftBorderBtn);
            borrowersBtn.Click += delegate { ShowBorrowerView?.Invoke(this, EventArgs.Empty); };
            LoanPlanbtn.Click += delegate { ShowLoanPlanView?.Invoke(this, EventArgs.Empty); };
            LoantypeBtn.Click += delegate { ShowLoanTypeView?.Invoke(this, EventArgs.Empty); };
            MembersBtn.Click += delegate { ShowMembersView?.Invoke(this, EventArgs.Empty); };
            SavingsBtn.Click += delegate { ShowSavingsView?.Invoke(this, EventArgs.Empty); };
            LoansBtn.Click += delegate { ShowLoansView?.Invoke(this, EventArgs.Empty); };

            //Resize

            /* this.Text = string.Empty;
             this.ControlBox = false;
             this.DoubleBuffered = true;
             this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;*/
        }
        //Structs 

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb (95,77,221);
            public static Color color5 = Color.FromArgb (249,88,155);
            public static Color color6 = Color.FromArgb ( 24,161,251);
        }
        //Methods

        private void ActivateButton(object senderBtn, Color  color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37,36,81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // left border button

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                 // Icon Current

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;


            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
               
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText ;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;



            }
        }
        ///open Child Form
         public void OpenChildForm(Form childForm)
        {
          if (currentChildForm != null)
            {
                //open child form
                currentChildForm.Close();

            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(childForm);
            MainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            ChildFormTtle.Text = childForm.Text;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new Borrowers());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Reset();
            currentChildForm.Close();   
        }

        private void Reset()
        {
            DisableButton();
           leftBorderBtn.Visible = false;

            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.Cyan;
            ChildFormTtle.Text = "Home";
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

       
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
