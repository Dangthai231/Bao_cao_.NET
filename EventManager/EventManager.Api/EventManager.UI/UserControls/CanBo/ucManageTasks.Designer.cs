namespace EventManager.UI.UserControls.CanBo
{
    partial class ucManageTasks
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabPage1 = new TabPage();
            txtPlanName = new TextBox();
            label1 = new Label();
            txtObjective = new TextBox();
            label2 = new Label();
            rtbDescription = new RichTextBox();
            label3 = new Label();
            label4 = new Label();
            dtpStartDate = new DateTimePicker();
            label5 = new Label();
            dtpEndDate = new DateTimePicker();
            label6 = new Label();
            txtLocation = new TextBox();
            label7 = new Label();
            txtBudget = new TextBox();
            btnSavePlan = new Button();
            tabControl1 = new TabControl();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnSavePlan);
            tabPage1.Controls.Add(txtBudget);
            tabPage1.Controls.Add(txtLocation);
            tabPage1.Controls.Add(rtbDescription);
            tabPage1.Controls.Add(txtObjective);
            tabPage1.Controls.Add(txtPlanName);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(dtpEndDate);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(dtpStartDate);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1010, 578);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Lập kế hoạch sự kiện";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPlanName
            // 
            txtPlanName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPlanName.Location = new Point(135, 13);
            txtPlanName.Name = "txtPlanName";
            txtPlanName.Size = new Size(845, 23);
            txtPlanName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 16);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 1;
            label1.Text = "Tên kế hoạch:";
            // 
            // txtObjective
            // 
            txtObjective.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtObjective.Location = new Point(135, 55);
            txtObjective.Name = "txtObjective";
            txtObjective.Size = new Size(845, 23);
            txtObjective.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 58);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Mục tiêu:";
            // 
            // rtbDescription
            // 
            rtbDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbDescription.Location = new Point(135, 95);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(845, 185);
            rtbDescription.TabIndex = 4;
            rtbDescription.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 98);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 5;
            label3.Text = "Mô tả:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(22, 298);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 6;
            label4.Text = "Ngày bắt đầu:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(135, 295);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(845, 23);
            dtpStartDate.TabIndex = 7;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(22, 338);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 8;
            label5.Text = "Ngày kết thúc:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtpEndDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(135, 335);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(845, 23);
            dtpEndDate.TabIndex = 9;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(22, 378);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 10;
            label6.Text = "Địa điểm:";
            // 
            // txtLocation
            // 
            txtLocation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLocation.Location = new Point(135, 375);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(845, 23);
            txtLocation.TabIndex = 11;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(22, 418);
            label7.Name = "label7";
            label7.Size = new Size(101, 15);
            label7.TabIndex = 12;
            label7.Text = "Ngân sách (VNĐ):";
            // 
            // txtBudget
            // 
            txtBudget.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBudget.Location = new Point(135, 415);
            txtBudget.Name = "txtBudget";
            txtBudget.Size = new Size(845, 23);
            txtBudget.TabIndex = 13;
            // 
            // btnSavePlan
            // 
            btnSavePlan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSavePlan.Location = new Point(135, 465);
            btnSavePlan.Name = "btnSavePlan";
            btnSavePlan.Size = new Size(845, 35);
            btnSavePlan.TabIndex = 14;
            btnSavePlan.Text = "Lưu kế hoạch";
            btnSavePlan.UseVisualStyleBackColor = true;
            btnSavePlan.Click += btnSavePlan_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1018, 606);
            tabControl1.TabIndex = 0;
            // 
            // ucManageTasks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "ucManageTasks";
            Size = new Size(1018, 606);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage1;
        private Button btnSavePlan;
        private TextBox txtBudget;
        private TextBox txtLocation;
        private RichTextBox rtbDescription;
        private TextBox txtObjective;
        private TextBox txtPlanName;
        private Label label7;
        private Label label6;
        private DateTimePicker dtpEndDate;
        private Label label5;
        private DateTimePicker dtpStartDate;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabControl tabControl1;
    }
}
