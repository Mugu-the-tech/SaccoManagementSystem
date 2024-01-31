namespace ManagementSystem.View
{
    partial class LoanPlan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.PenaltyTxt = new System.Windows.Forms.NumericUpDown();
            this.InterestTxt = new System.Windows.Forms.NumericUpDown();
            this.Cancelbtn2 = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.DeleteBtn2 = new FontAwesome.Sharp.IconButton();
            this.Editbtn2 = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveBtn2 = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.PlanId = new System.Windows.Forms.Label();
            this.PlanGridView = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.MonthsTxt = new System.Windows.Forms.NumericUpDown();
            this.panel3.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PenaltyTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InterestTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanGridView)).BeginInit();
            this.bunifuCards2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonthsTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 36);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.panel3.Controls.Add(this.bunifuCards1);
            this.panel3.Controls.Add(this.PlanId);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(325, 414);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.DodgerBlue;
            this.bunifuCards1.Controls.Add(this.PenaltyTxt);
            this.bunifuCards1.Controls.Add(this.MonthsTxt);
            this.bunifuCards1.Controls.Add(this.InterestTxt);
            this.bunifuCards1.Controls.Add(this.Cancelbtn2);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.DeleteBtn2);
            this.bunifuCards1.Controls.Add(this.Editbtn2);
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.SaveBtn2);
            this.bunifuCards1.Controls.Add(this.label4);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(5, 1);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 30;
            this.bunifuCards1.Size = new System.Drawing.Size(314, 291);
            this.bunifuCards1.TabIndex = 6;
            // 
            // PenaltyTxt
            // 
            this.PenaltyTxt.Location = new System.Drawing.Point(9, 156);
            this.PenaltyTxt.Name = "PenaltyTxt";
            this.PenaltyTxt.Size = new System.Drawing.Size(276, 20);
            this.PenaltyTxt.TabIndex = 8;
            // 
            // InterestTxt
            // 
            this.InterestTxt.Location = new System.Drawing.Point(9, 106);
            this.InterestTxt.Name = "InterestTxt";
            this.InterestTxt.Size = new System.Drawing.Size(276, 20);
            this.InterestTxt.TabIndex = 8;
            // 
            // Cancelbtn2
            // 
            this.Cancelbtn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Cancelbtn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancelbtn2.FlatAppearance.BorderSize = 0;
            this.Cancelbtn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Cancelbtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelbtn2.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelbtn2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Cancelbtn2.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            this.Cancelbtn2.IconColor = System.Drawing.Color.WhiteSmoke;
            this.Cancelbtn2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Cancelbtn2.IconSize = 30;
            this.Cancelbtn2.Location = new System.Drawing.Point(147, 237);
            this.Cancelbtn2.Name = "Cancelbtn2";
            this.Cancelbtn2.Size = new System.Drawing.Size(118, 40);
            this.Cancelbtn2.TabIndex = 7;
            this.Cancelbtn2.Text = "Cancel";
            this.Cancelbtn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Cancelbtn2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Months";
            // 
            // DeleteBtn2
            // 
            this.DeleteBtn2.BackColor = System.Drawing.Color.Red;
            this.DeleteBtn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteBtn2.FlatAppearance.BorderSize = 0;
            this.DeleteBtn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DeleteBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn2.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DeleteBtn2.IconChar = FontAwesome.Sharp.IconChar.Dumpster;
            this.DeleteBtn2.IconColor = System.Drawing.Color.WhiteSmoke;
            this.DeleteBtn2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.DeleteBtn2.IconSize = 30;
            this.DeleteBtn2.Location = new System.Drawing.Point(9, 237);
            this.DeleteBtn2.Name = "DeleteBtn2";
            this.DeleteBtn2.Size = new System.Drawing.Size(118, 40);
            this.DeleteBtn2.TabIndex = 1;
            this.DeleteBtn2.Text = "Delete";
            this.DeleteBtn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteBtn2.UseVisualStyleBackColor = false;
            // 
            // Editbtn2
            // 
            this.Editbtn2.BackColor = System.Drawing.Color.DarkMagenta;
            this.Editbtn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Editbtn2.FlatAppearance.BorderSize = 0;
            this.Editbtn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.Editbtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Editbtn2.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Editbtn2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Editbtn2.IconChar = FontAwesome.Sharp.IconChar.PenClip;
            this.Editbtn2.IconColor = System.Drawing.Color.WhiteSmoke;
            this.Editbtn2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Editbtn2.IconSize = 30;
            this.Editbtn2.Location = new System.Drawing.Point(147, 189);
            this.Editbtn2.Name = "Editbtn2";
            this.Editbtn2.Size = new System.Drawing.Size(118, 40);
            this.Editbtn2.TabIndex = 6;
            this.Editbtn2.Text = "Edit";
            this.Editbtn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Editbtn2.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Interest";
            // 
            // SaveBtn2
            // 
            this.SaveBtn2.BackColor = System.Drawing.Color.SeaGreen;
            this.SaveBtn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveBtn2.FlatAppearance.BorderSize = 0;
            this.SaveBtn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.SaveBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn2.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SaveBtn2.IconChar = FontAwesome.Sharp.IconChar.ShieldHeart;
            this.SaveBtn2.IconColor = System.Drawing.Color.WhiteSmoke;
            this.SaveBtn2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SaveBtn2.IconSize = 30;
            this.SaveBtn2.Location = new System.Drawing.Point(7, 189);
            this.SaveBtn2.Name = "SaveBtn2";
            this.SaveBtn2.Size = new System.Drawing.Size(118, 40);
            this.SaveBtn2.TabIndex = 0;
            this.SaveBtn2.Text = "Save";
            this.SaveBtn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveBtn2.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Monthly Overdue Penalty";
            // 
            // PlanId
            // 
            this.PlanId.AutoSize = true;
            this.PlanId.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlanId.Location = new System.Drawing.Point(119, 43);
            this.PlanId.Name = "PlanId";
            this.PlanId.Size = new System.Drawing.Size(0, 15);
            this.PlanId.TabIndex = 5;
            // 
            // PlanGridView
            // 
            this.PlanGridView.AllowCustomTheming = false;
            this.PlanGridView.AllowUserToAddRows = false;
            this.PlanGridView.AllowUserToDeleteRows = false;
            this.PlanGridView.AllowUserToResizeColumns = false;
            this.PlanGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.PlanGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PlanGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PlanGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.PlanGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlanGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PlanGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PlanGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.PlanGridView.ColumnHeadersHeight = 40;
            this.PlanGridView.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.PlanGridView.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.PlanGridView.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.PlanGridView.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.PlanGridView.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.PlanGridView.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.PlanGridView.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.PlanGridView.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.PlanGridView.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.PlanGridView.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.PlanGridView.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.PlanGridView.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.PlanGridView.CurrentTheme.Name = null;
            this.PlanGridView.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.PlanGridView.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.PlanGridView.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.PlanGridView.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.PlanGridView.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PlanGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.PlanGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlanGridView.EnableHeadersVisualStyles = false;
            this.PlanGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.PlanGridView.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.PlanGridView.HeaderBgColor = System.Drawing.Color.Empty;
            this.PlanGridView.HeaderForeColor = System.Drawing.Color.White;
            this.PlanGridView.Location = new System.Drawing.Point(0, 0);
            this.PlanGridView.Name = "PlanGridView";
            this.PlanGridView.ReadOnly = true;
            this.PlanGridView.RowHeadersVisible = false;
            this.PlanGridView.RowTemplate.Height = 40;
            this.PlanGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PlanGridView.Size = new System.Drawing.Size(475, 414);
            this.PlanGridView.TabIndex = 6;
            this.PlanGridView.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
            // 
            // bunifuCards2
            // 
            this.bunifuCards2.AutoSize = true;
            this.bunifuCards2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCards2.BorderRadius = 20;
            this.bunifuCards2.BottomSahddow = true;
            this.bunifuCards2.color = System.Drawing.Color.DodgerBlue;
            this.bunifuCards2.Controls.Add(this.PlanGridView);
            this.bunifuCards2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards2.LeftSahddow = false;
            this.bunifuCards2.Location = new System.Drawing.Point(325, 36);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(475, 414);
            this.bunifuCards2.TabIndex = 6;
            // 
            // MonthsTxt
            // 
            this.MonthsTxt.Location = new System.Drawing.Point(9, 61);
            this.MonthsTxt.Name = "MonthsTxt";
            this.MonthsTxt.Size = new System.Drawing.Size(276, 20);
            this.MonthsTxt.TabIndex = 8;
            // 
            // LoanPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bunifuCards2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoanPlan";
            this.Text = "LoanPlan";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PenaltyTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InterestTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlanGridView)).EndInit();
            this.bunifuCards2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MonthsTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PlanId;
        private FontAwesome.Sharp.IconButton Editbtn2;
        private FontAwesome.Sharp.IconButton SaveBtn2;
        private FontAwesome.Sharp.IconButton Cancelbtn2;
        private FontAwesome.Sharp.IconButton DeleteBtn2;
        private Bunifu.UI.WinForms.BunifuDataGridView PlanGridView;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private System.Windows.Forms.NumericUpDown InterestTxt;
        private System.Windows.Forms.NumericUpDown PenaltyTxt;
        private System.Windows.Forms.NumericUpDown MonthsTxt;
    }
}