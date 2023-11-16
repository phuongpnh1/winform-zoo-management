namespace Zoo.Management.WinformApp
{
    partial class CageForm
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
            lbTitle = new Label();
            lbId = new Label();
            lbName = new Label();
            cbArea = new ComboBox();
            lbArea = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            dgvListCage = new DataGridView();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnCurrentCages = new Button();
            btnDeletedCages = new Button();
            btnRecover = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListCage).BeginInit();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbTitle.Location = new Point(129, 27);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(65, 30);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "CAGE";
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(57, 66);
            lbId.Name = "lbId";
            lbId.Size = new Size(17, 15);
            lbId.TabIndex = 1;
            lbId.Text = "Id";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(57, 108);
            lbName.Name = "lbName";
            lbName.Size = new Size(39, 15);
            lbName.TabIndex = 2;
            lbName.Text = "Name";
            // 
            // cbArea
            // 
            cbArea.FormattingEnabled = true;
            cbArea.Location = new Point(143, 139);
            cbArea.Name = "cbArea";
            cbArea.Size = new Size(121, 23);
            cbArea.TabIndex = 3;
            // 
            // lbArea
            // 
            lbArea.AutoSize = true;
            lbArea.Location = new Point(57, 147);
            lbArea.Name = "lbArea";
            lbArea.Size = new Size(31, 15);
            lbArea.TabIndex = 4;
            lbArea.Text = "Area";
            // 
            // txtId
            // 
            txtId.Location = new Point(143, 65);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(121, 23);
            txtId.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(143, 100);
            txtName.Name = "txtName";
            txtName.Size = new Size(121, 23);
            txtName.TabIndex = 6;
            // 
            // dgvListCage
            // 
            dgvListCage.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListCage.Location = new Point(339, 66);
            dgvListCage.Name = "dgvListCage";
            dgvListCage.RowTemplate.Height = 25;
            dgvListCage.Size = new Size(449, 337);
            dgvListCage.TabIndex = 7;
            dgvListCage.CellDoubleClick += dgvListCage_CellDoubleClick;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(48, 188);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 8;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Enabled = false;
            btnUpdate.Location = new Point(129, 188);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(210, 188);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(48, 229);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCurrentCages
            // 
            btnCurrentCages.Enabled = false;
            btnCurrentCages.Location = new Point(586, 37);
            btnCurrentCages.Name = "btnCurrentCages";
            btnCurrentCages.Size = new Size(98, 23);
            btnCurrentCages.TabIndex = 12;
            btnCurrentCages.Text = "Current Cages";
            btnCurrentCages.UseVisualStyleBackColor = true;
            btnCurrentCages.Click += btnCurrentCages_Click;
            // 
            // btnDeletedCages
            // 
            btnDeletedCages.Location = new Point(690, 37);
            btnDeletedCages.Name = "btnDeletedCages";
            btnDeletedCages.Size = new Size(98, 23);
            btnDeletedCages.TabIndex = 13;
            btnDeletedCages.Text = "Deleted Cages";
            btnDeletedCages.UseVisualStyleBackColor = true;
            btnDeletedCages.Click += btnDeletedCages_Click;
            // 
            // btnRecover
            // 
            btnRecover.Enabled = false;
            btnRecover.Location = new Point(129, 229);
            btnRecover.Name = "btnRecover";
            btnRecover.Size = new Size(75, 23);
            btnRecover.TabIndex = 14;
            btnRecover.Text = "Recover";
            btnRecover.UseVisualStyleBackColor = true;
            btnRecover.Click += btnRecover_Click;
            // 
            // CageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRecover);
            Controls.Add(btnDeletedCages);
            Controls.Add(btnCurrentCages);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(dgvListCage);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Controls.Add(lbArea);
            Controls.Add(cbArea);
            Controls.Add(lbName);
            Controls.Add(lbId);
            Controls.Add(lbTitle);
            Name = "CageForm";
            Text = "CageForm";
            ((System.ComponentModel.ISupportInitialize)dgvListCage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Label lbId;
        private Label lbName;
        private ComboBox cbArea;
        private Label lbArea;
        private TextBox txtId;
        private TextBox txtName;
        private DataGridView dgvListCage;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnCurrentCages;
        private Button btnDeletedCages;
        private Button btnRecover;
    }
}