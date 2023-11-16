﻿namespace Zoo.Management.WinformApp
{
	partial class Login
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
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			TxtUserName = new TextBox();
			TxtPassword = new TextBox();
			BtnLogin = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(99, 159);
			label1.Name = "label1";
			label1.Size = new Size(121, 30);
			label1.TabIndex = 0;
			label1.Text = "User Name";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(99, 237);
			label2.Name = "label2";
			label2.Size = new Size(103, 30);
			label2.TabIndex = 1;
			label2.Text = "Password";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
			label3.Location = new Point(251, 45);
			label3.Name = "label3";
			label3.Size = new Size(229, 37);
			label3.TabIndex = 2;
			label3.Text = "Zoo Management";
			// 
			// TxtUserName
			// 
			TxtUserName.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
			TxtUserName.Location = new Point(289, 153);
			TxtUserName.Name = "TxtUserName";
			TxtUserName.Size = new Size(296, 36);
			TxtUserName.TabIndex = 3;
			// 
			// TxtPassword
			// 
			TxtPassword.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
			TxtPassword.Location = new Point(289, 231);
			TxtPassword.Name = "TxtPassword";
			TxtPassword.PasswordChar = '*';
			TxtPassword.Size = new Size(296, 36);
			TxtPassword.TabIndex = 4;
			// 
			// BtnLogin
			// 
			BtnLogin.Location = new Point(251, 311);
			BtnLogin.Name = "BtnLogin";
			BtnLogin.Size = new Size(250, 69);
			BtnLogin.TabIndex = 5;
			BtnLogin.Text = "Login";
			BtnLogin.UseVisualStyleBackColor = true;
			BtnLogin.Click += BtnLogin_Click;
			// 
			// Login
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(BtnLogin);
			Controls.Add(TxtPassword);
			Controls.Add(TxtUserName);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "Login";
			Text = "Login";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private TextBox TxtUserName;
		private TextBox TxtPassword;
		private Button BtnLogin;
	}
}