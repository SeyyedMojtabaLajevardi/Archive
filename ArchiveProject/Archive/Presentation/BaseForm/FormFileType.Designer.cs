namespace Archive
{
    partial class FormFileType
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileType));
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radButtonExit = new Telerik.WinControls.UI.RadButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radGridViewFileType = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radButtonExit)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewFileType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewFileType.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButtonExit
            // 
            this.radButtonExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButtonExit.Location = new System.Drawing.Point(112, 6);
            this.radButtonExit.Name = "radButtonExit";
            this.radButtonExit.Size = new System.Drawing.Size(62, 22);
            this.radButtonExit.TabIndex = 2;
            this.radButtonExit.Text = "بستن";
            this.radButtonExit.Click += new System.EventHandler(this.radButtonExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radButtonExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 354);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 31);
            this.panel1.TabIndex = 1;
            // 
            // radPanel1
            // 
            this.radPanel1.AutoScroll = true;
            this.radPanel1.AutoScrollMargin = new System.Drawing.Size(5, 0);
            this.radPanel1.Controls.Add(this.radGridViewFileType);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(304, 354);
            this.radPanel1.TabIndex = 4;
            // 
            // radGridViewFileType
            // 
            this.radGridViewFileType.AutoScroll = true;
            this.radGridViewFileType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radGridViewFileType.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridViewFileType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridViewFileType.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridViewFileType.ForeColor = System.Drawing.Color.Black;
            this.radGridViewFileType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridViewFileType.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radGridViewFileType.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "FileTypeId";
            gridViewTextBoxColumn1.HeaderText = "شناسه";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "FileTypeId";
            gridViewComboBoxColumn1.DisplayMember = "ContentTypeTitle";
            gridViewComboBoxColumn1.FieldName = "ContentTypeId";
            gridViewComboBoxColumn1.HeaderText = "نوع محتوا";
            gridViewComboBoxColumn1.Name = "ContentTypeId";
            gridViewComboBoxColumn1.Width = 74;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "FileTypeTitle";
            gridViewTextBoxColumn2.HeaderText = "نوع فایل";
            gridViewTextBoxColumn2.Name = "FileTypeTitle";
            gridViewTextBoxColumn2.Width = 154;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "SampleFileTypeTitle";
            gridViewTextBoxColumn3.HeaderText = "SampleFileTypeTitle";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "SampleFileTypeTitle";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn3.Width = 46;
            gridViewCheckBoxColumn1.FieldName = "IsBook";
            gridViewCheckBoxColumn1.HeaderText = "IsBook";
            gridViewCheckBoxColumn1.IsVisible = false;
            gridViewCheckBoxColumn1.Name = "IsBook";
            gridViewTextBoxColumn4.FieldName = "FileTypeTitlePersian";
            gridViewTextBoxColumn4.HeaderText = "FileTypeTitlePersian";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "FileTypeTitlePersian";
            gridViewTextBoxColumn4.Width = 41;
            gridViewCommandColumn1.FieldName = "Confirm";
            gridViewCommandColumn1.HeaderText = "";
            gridViewCommandColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn1.Image")));
            gridViewCommandColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            gridViewCommandColumn1.MaxWidth = 25;
            gridViewCommandColumn1.Name = "Confirm";
            gridViewCommandColumn1.RowSpan = 25;
            gridViewCommandColumn1.Width = 23;
            gridViewCommandColumn2.FieldName = "Remove";
            gridViewCommandColumn2.HeaderText = "";
            gridViewCommandColumn2.Image = ((System.Drawing.Image)(resources.GetObject("gridViewCommandColumn2.Image")));
            gridViewCommandColumn2.MaxWidth = 25;
            gridViewCommandColumn2.Name = "Remove";
            gridViewCommandColumn2.RowSpan = 25;
            gridViewCommandColumn2.Width = 23;
            this.radGridViewFileType.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewComboBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn4,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.radGridViewFileType.MasterTemplate.EnableAlternatingRowColor = true;
            this.radGridViewFileType.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridViewFileType.Name = "radGridViewFileType";
            this.radGridViewFileType.NewRowEnterKeyMode = Telerik.WinControls.UI.RadGridViewNewRowEnterKeyMode.EnterMovesToLastAddedRow;
            this.radGridViewFileType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridViewFileType.ShowGroupPanel = false;
            this.radGridViewFileType.Size = new System.Drawing.Size(304, 354);
            this.radGridViewFileType.TabIndex = 0;
            this.radGridViewFileType.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridViewFileType_CellValueChanged);
            this.radGridViewFileType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radGridViewFileType_KeyDown);
            // 
            // FormFileType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 385);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFileType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت نوع فایل";
            this.Load += new System.EventHandler(this.FormFileType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radButtonExit)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewFileType.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewFileType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadButton radButtonExit;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadGridView radGridViewFileType;
    }
}

