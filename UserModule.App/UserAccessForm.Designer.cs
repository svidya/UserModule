namespace UserModule.App
{
    partial class UserAccessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccessForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.userAccessGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserProfileId = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserAccessForm = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblLayoutGridPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.tblLayoutButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.userAccessGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tblLayoutGridPanel.SuspendLayout();
            this.tblLayoutButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(441, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(433, 39);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // userAccessGrid
            // 
            this.userAccessGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userAccessGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userAccessGrid.Location = new System.Drawing.Point(3, 102);
            this.userAccessGrid.Name = "userAccessGrid";
            this.userAccessGrid.RowTemplate.Height = 24;
            this.userAccessGrid.Size = new System.Drawing.Size(871, 441);
            this.userAccessGrid.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUserProfileId);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.lblUserAccessForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 93);
            this.panel1.TabIndex = 19;
            // 
            // lblUserProfileId
            // 
            this.lblUserProfileId.AutoSize = true;
            this.lblUserProfileId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserProfileId.Location = new System.Drawing.Point(599, 34);
            this.lblUserProfileId.Name = "lblUserProfileId";
            this.lblUserProfileId.Size = new System.Drawing.Size(82, 29);
            this.lblUserProfileId.TabIndex = 4;
            this.lblUserProfileId.Text = "User : ";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(687, 40);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 22);
            this.txtUserName.TabIndex = 2;
            // 
            // lblUserAccessForm
            // 
            this.lblUserAccessForm.AutoSize = true;
            this.lblUserAccessForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAccessForm.Location = new System.Drawing.Point(45, 28);
            this.lblUserAccessForm.Name = "lblUserAccessForm";
            this.lblUserAccessForm.Size = new System.Drawing.Size(261, 36);
            this.lblUserAccessForm.TabIndex = 1;
            this.lblUserAccessForm.Text = "User Access Entry";
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(432, 39);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tblLayoutGridPanel);
            this.panel2.Controls.Add(this.lblLoading);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(877, 607);
            this.panel2.TabIndex = 21;
            // 
            // tblLayoutGridPanel
            // 
            this.tblLayoutGridPanel.ColumnCount = 1;
            this.tblLayoutGridPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutGridPanel.Controls.Add(this.panel1, 0, 0);
            this.tblLayoutGridPanel.Controls.Add(this.userAccessGrid, 0, 1);
            this.tblLayoutGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutGridPanel.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutGridPanel.Name = "tblLayoutGridPanel";
            this.tblLayoutGridPanel.RowCount = 3;
            this.tblLayoutGridPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.30972F));
            this.tblLayoutGridPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.64085F));
            this.tblLayoutGridPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLayoutGridPanel.Size = new System.Drawing.Size(877, 607);
            this.tblLayoutGridPanel.TabIndex = 1;
            this.tblLayoutGridPanel.Visible = false;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Location = new System.Drawing.Point(0, 0);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(650, 135);
            this.lblLoading.TabIndex = 0;
            this.lblLoading.Text = "Loading ....";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblLayoutButtonPanel
            // 
            this.tblLayoutButtonPanel.ColumnCount = 2;
            this.tblLayoutButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutButtonPanel.Controls.Add(this.btnSave, 0, 0);
            this.tblLayoutButtonPanel.Controls.Add(this.btnClose, 1, 0);
            this.tblLayoutButtonPanel.Location = new System.Drawing.Point(0, 507);
            this.tblLayoutButtonPanel.Name = "tblLayoutButtonPanel";
            this.tblLayoutButtonPanel.RowCount = 1;
            this.tblLayoutButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutButtonPanel.Size = new System.Drawing.Size(877, 100);
            this.tblLayoutButtonPanel.TabIndex = 22;
            this.tblLayoutButtonPanel.Visible = false;
            // 
            // UserAccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(877, 607);
            this.Controls.Add(this.tblLayoutButtonPanel);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserAccessForm";
            this.Text = "UserAccessForm";
            this.Load += new System.EventHandler(this.UserAccessForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userAccessGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tblLayoutGridPanel.ResumeLayout(false);
            this.tblLayoutButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView userAccessGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUserAccessForm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.TableLayoutPanel tblLayoutGridPanel;
        private System.Windows.Forms.TableLayoutPanel tblLayoutButtonPanel;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserProfileId;
    }
}