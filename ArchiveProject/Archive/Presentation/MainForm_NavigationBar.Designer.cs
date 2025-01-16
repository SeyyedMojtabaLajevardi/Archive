namespace Archive
{
    partial class MainForm_NavigationBar
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
            this.radNavigationView1 = new Telerik.WinControls.UI.RadNavigationView();
            this.radPageViewDashboard = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewDocumentList = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewSearch = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewCreateDocument = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewReport = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPageManagement = new Telerik.WinControls.UI.RadPageViewPage();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            ((System.ComponentModel.ISupportInitialize)(this.radNavigationView1)).BeginInit();
            this.radNavigationView1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radNavigationView1
            // 
            this.radNavigationView1.Controls.Add(this.radPageViewDashboard);
            this.radNavigationView1.Controls.Add(this.radPageViewDocumentList);
            this.radNavigationView1.Controls.Add(this.radPageViewSearch);
            this.radNavigationView1.Controls.Add(this.radPageViewCreateDocument);
            this.radNavigationView1.Controls.Add(this.radPageViewReport);
            this.radNavigationView1.Controls.Add(this.radPageViewPageManagement);
            this.radNavigationView1.DisplayMode = Telerik.WinControls.UI.NavigationViewDisplayModes.Auto;
            this.radNavigationView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radNavigationView1.HeaderHeight = 30;
            this.radNavigationView1.HierarchyPopupExpandMode = Telerik.WinControls.UI.NavigationViewHierarchyPopupExpandMode.OnItemClick;
            this.radNavigationView1.ItemExpandCollapseMode = Telerik.WinControls.UI.NavigationViewItemExpandCollapseMode.OnItemClick;
            this.radNavigationView1.Location = new System.Drawing.Point(0, 0);
            this.radNavigationView1.Name = "radNavigationView1";
            this.radNavigationView1.PageBackColor = System.Drawing.Color.White;
            this.radNavigationView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radNavigationView1.SelectedPage = this.radPageViewPageManagement;
            this.radNavigationView1.Size = new System.Drawing.Size(1454, 720);
            this.radNavigationView1.TabIndex = 0;
            // 
            // radPageViewDashboard
            // 
            this.radPageViewDashboard.ItemSize = new System.Drawing.SizeF(106F, 33F);
            this.radPageViewDashboard.Location = new System.Drawing.Point(1, 31);
            this.radPageViewDashboard.Name = "radPageViewDashboard";
            this.radPageViewDashboard.Size = new System.Drawing.Size(1172, 688);
            this.radPageViewDashboard.Text = "داشبورد";
            // 
            // radPageViewDocumentList
            // 
            this.radPageViewDocumentList.ItemSize = new System.Drawing.SizeF(106F, 33F);
            this.radPageViewDocumentList.Location = new System.Drawing.Point(1, 31);
            this.radPageViewDocumentList.Name = "radPageViewDocumentList";
            this.radPageViewDocumentList.Size = new System.Drawing.Size(1172, 688);
            this.radPageViewDocumentList.Text = "لیست اسناد";
            // 
            // radPageViewSearch
            // 
            this.radPageViewSearch.ItemSize = new System.Drawing.SizeF(106F, 33F);
            this.radPageViewSearch.Location = new System.Drawing.Point(1, 31);
            this.radPageViewSearch.Name = "radPageViewSearch";
            this.radPageViewSearch.Size = new System.Drawing.Size(1172, 688);
            this.radPageViewSearch.Text = "جستجوی پیشرفته";
            this.radPageViewSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.radPageViewSearch_Paint);
            // 
            // radPageViewCreateDocument
            // 
            this.radPageViewCreateDocument.ItemSize = new System.Drawing.SizeF(106F, 33F);
            this.radPageViewCreateDocument.Location = new System.Drawing.Point(1, 31);
            this.radPageViewCreateDocument.Name = "radPageViewCreateDocument";
            this.radPageViewCreateDocument.Size = new System.Drawing.Size(1172, 688);
            this.radPageViewCreateDocument.Text = "ایجاد سند";
            // 
            // radPageViewReport
            // 
            this.radPageViewReport.ItemSize = new System.Drawing.SizeF(106F, 33F);
            this.radPageViewReport.Location = new System.Drawing.Point(1, 31);
            this.radPageViewReport.Name = "radPageViewReport";
            this.radPageViewReport.Size = new System.Drawing.Size(1172, 688);
            this.radPageViewReport.Text = "گزارشات";
            // 
            // radPageViewPageManagement
            // 
            this.radPageViewPageManagement.ItemSize = new System.Drawing.SizeF(106F, 33F);
            this.radPageViewPageManagement.Location = new System.Drawing.Point(1, 31);
            this.radPageViewPageManagement.Name = "radPageViewPageManagement";
            this.radPageViewPageManagement.Size = new System.Drawing.Size(1172, 688);
            this.radPageViewPageManagement.Text = "پنل مدیریت";
            // 
            // MainForm_NavigationBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 720);
            this.Controls.Add(this.radNavigationView1);
            this.Name = "MainForm_NavigationBar";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.radNavigationView1)).EndInit();
            this.radNavigationView1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadNavigationView radNavigationView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewDashboard;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewSearch;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewCreateDocument;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewDocumentList;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewReport;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPageManagement;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
    }
}