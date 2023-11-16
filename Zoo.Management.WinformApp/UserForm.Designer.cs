namespace Zoo.Management.WinformApp
{
	partial class UserForm
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
			dgvUser = new DataGridView();
			btnUpdate = new Button();
			btnDelete = new Button();
			btnCreate = new Button();
			dtpDateOfBirth = new DateTimePicker();
			cbRole = new ComboBox();
			cbGender = new ComboBox();
			label8 = new Label();
			label7 = new Label();
			txtPhoneNumber = new TextBox();
			label6 = new Label();
			label5 = new Label();
			txtEmail = new TextBox();
			label4 = new Label();
			txtFullName = new TextBox();
			label2 = new Label();
			txtId = new TextBox();
			label3 = new Label();
			txtUserName = new TextBox();
			lbName = new Label();
			txtPassword = new TextBox();
			label1 = new Label();
			menuStrip1 = new MenuStrip();
			staffToolStripMenuItem = new ToolStripMenuItem();
			areasCagesToolStripMenuItem = new ToolStripMenuItem();
			animalToolStripMenuItem1 = new ToolStripMenuItem();
			cagesToolStripMenuItem = new ToolStripMenuItem();
			zooTrainerToolStripMenuItem = new ToolStripMenuItem();
			animalToolStripMenuItem = new ToolStripMenuItem();
			animalStatusToolStripMenuItem = new ToolStripMenuItem();
			btnRecovery = new Button();
			label9 = new Label();
			txtSearch = new TextBox();
			btnSearch = new Button();
			btnDeletedList = new Button();
			btnCurrentList = new Button();
			btnClear = new Button();
			((System.ComponentModel.ISupportInitialize)dgvUser).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// dgvUser
			// 
			dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvUser.Location = new Point(459, 63);
			dgvUser.Margin = new Padding(2);
			dgvUser.Name = "dgvUser";
			dgvUser.RowHeadersWidth = 51;
			dgvUser.RowTemplate.Height = 33;
			dgvUser.Size = new Size(762, 290);
			dgvUser.TabIndex = 27;
			dgvUser.CellDoubleClick += dgvUser_CellDoubleClick;
			// 
			// btnUpdate
			// 
			btnUpdate.Enabled = false;
			btnUpdate.Location = new Point(198, 321);
			btnUpdate.Margin = new Padding(2);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.Size = new Size(86, 33);
			btnUpdate.TabIndex = 26;
			btnUpdate.Text = "Update";
			btnUpdate.UseVisualStyleBackColor = true;
			btnUpdate.Click += btnUpdate_Click;
			// 
			// btnDelete
			// 
			btnDelete.Enabled = false;
			btnDelete.Location = new Point(334, 321);
			btnDelete.Margin = new Padding(2);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(86, 33);
			btnDelete.TabIndex = 25;
			btnDelete.Text = "Delete";
			btnDelete.UseVisualStyleBackColor = true;
			btnDelete.Click += btnDelete_Click;
			// 
			// btnCreate
			// 
			btnCreate.Location = new Point(63, 321);
			btnCreate.Margin = new Padding(2);
			btnCreate.Name = "btnCreate";
			btnCreate.Size = new Size(86, 33);
			btnCreate.TabIndex = 24;
			btnCreate.Text = "Create";
			btnCreate.UseVisualStyleBackColor = true;
			btnCreate.Click += btnCreate_Click;
			// 
			// dtpDateOfBirth
			// 
			dtpDateOfBirth.Location = new Point(174, 241);
			dtpDateOfBirth.Margin = new Padding(2);
			dtpDateOfBirth.Name = "dtpDateOfBirth";
			dtpDateOfBirth.Size = new Size(246, 27);
			dtpDateOfBirth.TabIndex = 23;
			// 
			// cbRole
			// 
			cbRole.FormattingEnabled = true;
			cbRole.Items.AddRange(new object[] { "Admin", "Staff", "ZooTrainer" });
			cbRole.Location = new Point(174, 270);
			cbRole.Margin = new Padding(2);
			cbRole.Name = "cbRole";
			cbRole.Size = new Size(98, 28);
			cbRole.TabIndex = 22;
			// 
			// cbGender
			// 
			cbGender.FormattingEnabled = true;
			cbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
			cbGender.Location = new Point(174, 182);
			cbGender.Margin = new Padding(2);
			cbGender.Name = "cbGender";
			cbGender.Size = new Size(98, 28);
			cbGender.TabIndex = 21;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(63, 270);
			label8.Margin = new Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new Size(39, 20);
			label8.TabIndex = 14;
			label8.Text = "Role";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(63, 241);
			label7.Margin = new Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new Size(94, 20);
			label7.TabIndex = 12;
			label7.Text = "Date of Birth";
			// 
			// txtPhoneNumber
			// 
			txtPhoneNumber.Location = new Point(174, 211);
			txtPhoneNumber.Margin = new Padding(2);
			txtPhoneNumber.Name = "txtPhoneNumber";
			txtPhoneNumber.Size = new Size(246, 27);
			txtPhoneNumber.TabIndex = 15;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(63, 211);
			label6.Margin = new Padding(2, 0, 2, 0);
			label6.Name = "label6";
			label6.Size = new Size(105, 20);
			label6.TabIndex = 6;
			label6.Text = "phoneNumber";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(63, 182);
			label5.Margin = new Padding(2, 0, 2, 0);
			label5.Name = "label5";
			label5.Size = new Size(57, 20);
			label5.TabIndex = 11;
			label5.Text = "Gender";
			// 
			// txtEmail
			// 
			txtEmail.Location = new Point(174, 152);
			txtEmail.Margin = new Padding(2);
			txtEmail.Name = "txtEmail";
			txtEmail.Size = new Size(246, 27);
			txtEmail.TabIndex = 17;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(63, 152);
			label4.Margin = new Padding(2, 0, 2, 0);
			label4.Name = "label4";
			label4.Size = new Size(46, 20);
			label4.TabIndex = 10;
			label4.Text = "Email";
			// 
			// txtFullName
			// 
			txtFullName.Location = new Point(174, 122);
			txtFullName.Margin = new Padding(2);
			txtFullName.Name = "txtFullName";
			txtFullName.Size = new Size(246, 27);
			txtFullName.TabIndex = 18;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(63, 122);
			label2.Margin = new Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new Size(70, 20);
			label2.TabIndex = 9;
			label2.Text = "fullName";
			// 
			// txtId
			// 
			txtId.Location = new Point(174, 34);
			txtId.Margin = new Padding(2);
			txtId.Name = "txtId";
			txtId.ReadOnly = true;
			txtId.Size = new Size(246, 27);
			txtId.TabIndex = 19;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(63, 34);
			label3.Margin = new Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new Size(24, 20);
			label3.TabIndex = 8;
			label3.Text = "ID";
			// 
			// txtUserName
			// 
			txtUserName.Location = new Point(174, 63);
			txtUserName.Margin = new Padding(2);
			txtUserName.Name = "txtUserName";
			txtUserName.Size = new Size(246, 27);
			txtUserName.TabIndex = 20;
			// 
			// lbName
			// 
			lbName.AutoSize = true;
			lbName.Location = new Point(63, 63);
			lbName.Margin = new Padding(2, 0, 2, 0);
			lbName.Name = "lbName";
			lbName.Size = new Size(76, 20);
			lbName.TabIndex = 7;
			lbName.Text = "userName";
			// 
			// txtPassword
			// 
			txtPassword.Location = new Point(174, 93);
			txtPassword.Margin = new Padding(2);
			txtPassword.Name = "txtPassword";
			txtPassword.Size = new Size(246, 27);
			txtPassword.TabIndex = 16;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(63, 93);
			label1.Margin = new Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new Size(72, 20);
			label1.TabIndex = 13;
			label1.Text = "password";
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(20, 20);
			menuStrip1.Items.AddRange(new ToolStripItem[] { staffToolStripMenuItem, zooTrainerToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(5, 2, 0, 2);
			menuStrip1.Size = new Size(1286, 28);
			menuStrip1.TabIndex = 28;
			menuStrip1.Text = "menuStrip1";
			// 
			// staffToolStripMenuItem
			// 
			staffToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { areasCagesToolStripMenuItem, animalToolStripMenuItem1, cagesToolStripMenuItem });
			staffToolStripMenuItem.Name = "staffToolStripMenuItem";
			staffToolStripMenuItem.Size = new Size(100, 24);
			staffToolStripMenuItem.Text = "Dash Board";
			// 
			// areasCagesToolStripMenuItem
			// 
			areasCagesToolStripMenuItem.Name = "areasCagesToolStripMenuItem";
			areasCagesToolStripMenuItem.Size = new Size(224, 26);
			areasCagesToolStripMenuItem.Text = "Areas";
			areasCagesToolStripMenuItem.Click += areasCagesToolStripMenuItem_Click;
			// 
			// animalToolStripMenuItem1
			// 
			animalToolStripMenuItem1.Name = "animalToolStripMenuItem1";
			animalToolStripMenuItem1.Size = new Size(224, 26);
			animalToolStripMenuItem1.Text = "Animals";
			animalToolStripMenuItem1.Click += animalToolStripMenuItem1_Click;
			// 
			// cagesToolStripMenuItem
			// 
			cagesToolStripMenuItem.Name = "cagesToolStripMenuItem";
			cagesToolStripMenuItem.Size = new Size(224, 26);
			cagesToolStripMenuItem.Text = "Cages";
			cagesToolStripMenuItem.Click += cagesToolStripMenuItem_Click;
			// 
			// zooTrainerToolStripMenuItem
			// 
			zooTrainerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { animalToolStripMenuItem, animalStatusToolStripMenuItem });
			zooTrainerToolStripMenuItem.Name = "zooTrainerToolStripMenuItem";
			zooTrainerToolStripMenuItem.Size = new Size(100, 24);
			zooTrainerToolStripMenuItem.Text = "Logout/Exit";
			// 
			// animalToolStripMenuItem
			// 
			animalToolStripMenuItem.Name = "animalToolStripMenuItem";
			animalToolStripMenuItem.Size = new Size(224, 26);
			animalToolStripMenuItem.Text = "LogOut";
			animalToolStripMenuItem.Click += animalToolStripMenuItem_Click;
			// 
			// animalStatusToolStripMenuItem
			// 
			animalStatusToolStripMenuItem.Name = "animalStatusToolStripMenuItem";
			animalStatusToolStripMenuItem.Size = new Size(224, 26);
			animalStatusToolStripMenuItem.Text = "Exit";
			animalStatusToolStripMenuItem.Click += animalStatusToolStripMenuItem_Click;
			// 
			// btnRecovery
			// 
			btnRecovery.Enabled = false;
			btnRecovery.Location = new Point(334, 396);
			btnRecovery.Margin = new Padding(2);
			btnRecovery.Name = "btnRecovery";
			btnRecovery.Size = new Size(86, 33);
			btnRecovery.TabIndex = 25;
			btnRecovery.Text = "Recovery";
			btnRecovery.UseVisualStyleBackColor = true;
			btnRecovery.Visible = false;
			btnRecovery.Click += btnRecovery_Click;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(638, 372);
			label9.Margin = new Padding(2, 0, 2, 0);
			label9.Name = "label9";
			label9.Size = new Size(60, 20);
			label9.TabIndex = 29;
			label9.Text = "Search: ";
			// 
			// txtSearch
			// 
			txtSearch.Location = new Point(717, 370);
			txtSearch.Margin = new Padding(2);
			txtSearch.Name = "txtSearch";
			txtSearch.Size = new Size(310, 27);
			txtSearch.TabIndex = 30;
			// 
			// btnSearch
			// 
			btnSearch.Location = new Point(1038, 366);
			btnSearch.Margin = new Padding(2);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(86, 33);
			btnSearch.TabIndex = 25;
			btnSearch.Text = "Search";
			btnSearch.UseVisualStyleBackColor = false;
			btnSearch.Click += btnSearch_Click;
			// 
			// btnDeletedList
			// 
			btnDeletedList.Location = new Point(1089, 30);
			btnDeletedList.Margin = new Padding(2);
			btnDeletedList.Name = "btnDeletedList";
			btnDeletedList.Size = new Size(133, 33);
			btnDeletedList.TabIndex = 25;
			btnDeletedList.Text = "Deleted Staff";
			btnDeletedList.UseVisualStyleBackColor = false;
			btnDeletedList.Click += btnDeletedList_Click;
			// 
			// btnCurrentList
			// 
			btnCurrentList.Enabled = false;
			btnCurrentList.Location = new Point(959, 30);
			btnCurrentList.Margin = new Padding(2);
			btnCurrentList.Name = "btnCurrentList";
			btnCurrentList.Size = new Size(133, 33);
			btnCurrentList.TabIndex = 25;
			btnCurrentList.Text = "Current Staff";
			btnCurrentList.UseVisualStyleBackColor = false;
			btnCurrentList.Click += btnCurrentList_Click;
			// 
			// btnClear
			// 
			btnClear.Location = new Point(63, 396);
			btnClear.Margin = new Padding(2);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(86, 33);
			btnClear.TabIndex = 24;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// UserForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1286, 514);
			Controls.Add(txtSearch);
			Controls.Add(label9);
			Controls.Add(dgvUser);
			Controls.Add(btnUpdate);
			Controls.Add(btnCurrentList);
			Controls.Add(btnDeletedList);
			Controls.Add(btnSearch);
			Controls.Add(btnRecovery);
			Controls.Add(btnDelete);
			Controls.Add(btnClear);
			Controls.Add(btnCreate);
			Controls.Add(dtpDateOfBirth);
			Controls.Add(cbRole);
			Controls.Add(cbGender);
			Controls.Add(label8);
			Controls.Add(label7);
			Controls.Add(txtPhoneNumber);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(txtEmail);
			Controls.Add(label4);
			Controls.Add(txtFullName);
			Controls.Add(label2);
			Controls.Add(txtId);
			Controls.Add(label3);
			Controls.Add(txtUserName);
			Controls.Add(lbName);
			Controls.Add(txtPassword);
			Controls.Add(label1);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Margin = new Padding(2);
			Name = "UserForm";
			Text = "UserForm";
			((System.ComponentModel.ISupportInitialize)dgvUser).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dgvUser;
		private Button btnUpdate;
		private Button btnDelete;
		private Button btnCreate;
		private DateTimePicker dtpDateOfBirth;
		private ComboBox cbRole;
		private ComboBox cbGender;
		private Label label8;
		private Label label7;
		private TextBox txtPhoneNumber;
		private Label label6;
		private Label label5;
		private TextBox txtEmail;
		private Label label4;
		private TextBox txtFullName;
		private Label label2;
		private TextBox txtId;
		private Label label3;
		private TextBox txtUserName;
		private Label lbName;
		private TextBox txtPassword;
		private Label label1;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem staffToolStripMenuItem;
		private ToolStripMenuItem areasCagesToolStripMenuItem;
		private ToolStripMenuItem animalToolStripMenuItem1;
		private ToolStripMenuItem zooTrainerToolStripMenuItem;
		private ToolStripMenuItem animalToolStripMenuItem;
		private ToolStripMenuItem animalStatusToolStripMenuItem;
		private Button btnRecovery;
		private Label label9;
		private TextBox txtSearch;
		private Button btnSearch;
		private Button btnDeletedList;
		private Button btnCurrentList;
		private Button btnClear;
		private ToolStripMenuItem cagesToolStripMenuItem;
	}
}