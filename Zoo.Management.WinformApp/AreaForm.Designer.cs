namespace Zoo.Management.WinformApp
{
    partial class AreaForm
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
            dgvArea = new DataGridView();
            lbArea = new Label();
            lbId = new Label();
            lbName = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            btnCreate = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCurrentArea = new Button();
            btnDeletedArea = new Button();
            btnRecovery = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvArea).BeginInit();
            SuspendLayout();
            // 
            // dgvArea
            // 
            dgvArea.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArea.Location = new Point(511, 84);
            dgvArea.Margin = new Padding(4, 5, 4, 5);
            dgvArea.Name = "dgvArea";
            dgvArea.RowHeadersWidth = 51;
            dgvArea.RowTemplate.Height = 25;
            dgvArea.Size = new Size(596, 475);
            dgvArea.TabIndex = 0;
            dgvArea.CellDoubleClick += dgvArea_CellDoubleClick;
            // 
            // lbArea
            // 
            lbArea.AutoSize = true;
            lbArea.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbArea.Location = new Point(150, 15);
            lbArea.Margin = new Padding(4, 0, 4, 0);
            lbArea.Name = "lbArea";
            lbArea.Size = new Size(112, 47);
            lbArea.TabIndex = 1;
            lbArea.Text = "AREA";
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(102, 175);
            lbId.Margin = new Padding(4, 0, 4, 0);
            lbId.Name = "lbId";
            lbId.Size = new Size(28, 25);
            lbId.TabIndex = 2;
            lbId.Text = "Id";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(71, 249);
            lbName.Margin = new Padding(4, 0, 4, 0);
            lbName.Name = "lbName";
            lbName.Size = new Size(59, 25);
            lbName.TabIndex = 3;
            lbName.Text = "Name";
            // 
            // txtId
            // 
            txtId.Location = new Point(168, 161);
            txtId.Margin = new Padding(4, 5, 4, 5);
            txtId.Name = "txtId";
            txtId.Size = new Size(142, 31);
            txtId.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Location = new Point(168, 244);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(142, 31);
            txtName.TabIndex = 5;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(18, 340);
            btnCreate.Margin = new Padding(4, 5, 4, 5);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(108, 39);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(168, 340);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(108, 39);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(321, 344);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(108, 39);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCurrentArea
            // 
            btnCurrentArea.Location = new Point(839, 35);
            btnCurrentArea.Margin = new Padding(4, 5, 4, 5);
            btnCurrentArea.Name = "btnCurrentArea";
            btnCurrentArea.Size = new Size(118, 39);
            btnCurrentArea.TabIndex = 9;
            btnCurrentArea.Text = "Current Area";
            btnCurrentArea.UseVisualStyleBackColor = true;
            btnCurrentArea.Click += btnCurrentArea_Click;
            // 
            // btnDeletedArea
            // 
            btnDeletedArea.Location = new Point(990, 35);
            btnDeletedArea.Margin = new Padding(4, 5, 4, 5);
            btnDeletedArea.Name = "btnDeletedArea";
            btnDeletedArea.Size = new Size(118, 39);
            btnDeletedArea.TabIndex = 10;
            btnDeletedArea.Text = "Deleted Area";
            btnDeletedArea.UseVisualStyleBackColor = true;
            btnDeletedArea.Click += btnDeletedArea_Click;
            // 
            // btnRecovery
            // 
            btnRecovery.Location = new Point(321, 424);
            btnRecovery.Margin = new Padding(4, 5, 4, 5);
            btnRecovery.Name = "btnRecovery";
            btnRecovery.Size = new Size(108, 39);
            btnRecovery.TabIndex = 11;
            btnRecovery.Text = "Recovery";
            btnRecovery.UseVisualStyleBackColor = true;
            btnRecovery.Visible = false;
            btnRecovery.Click += btnRecovery_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(18, 424);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(108, 39);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // AreaForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1142, 750);
            Controls.Add(btnRecovery);
            Controls.Add(btnDeletedArea);
            Controls.Add(btnCurrentArea);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnCreate);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Controls.Add(lbName);
            Controls.Add(lbId);
            Controls.Add(lbArea);
            Controls.Add(dgvArea);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AreaForm";
            Text = "AreaForm";
            ((System.ComponentModel.ISupportInitialize)dgvArea).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvArea;
        private Label lbArea;
        private Label lbId;
        private Label lbName;
        private TextBox txtId;
        private TextBox txtName;
        private Button btnCreate;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCurrentArea;
        private Button btnDeletedArea;
        private Button btnRecovery;
        private Button btnClear;
    }
}