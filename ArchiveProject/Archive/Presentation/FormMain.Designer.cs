namespace Archive
{
    partial class FormMain
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
            this.buttonSpeech = new System.Windows.Forms.Button();
            this.buttonBook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSpeech
            // 
            this.buttonSpeech.Font = new System.Drawing.Font("Dana-FaNum Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonSpeech.Location = new System.Drawing.Point(126, 41);
            this.buttonSpeech.Name = "buttonSpeech";
            this.buttonSpeech.Size = new System.Drawing.Size(194, 70);
            this.buttonSpeech.TabIndex = 0;
            this.buttonSpeech.Text = "ایجاد سند سخنرانی";
            this.buttonSpeech.UseVisualStyleBackColor = true;
            this.buttonSpeech.Click += new System.EventHandler(this.buttonSpeech_Click);
            // 
            // buttonBook
            // 
            this.buttonBook.Font = new System.Drawing.Font("Dana-FaNum Medium", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonBook.Location = new System.Drawing.Point(126, 133);
            this.buttonBook.Name = "buttonBook";
            this.buttonBook.Size = new System.Drawing.Size(194, 70);
            this.buttonBook.TabIndex = 1;
            this.buttonBook.Text = "فرم ایجاد سند کتاب";
            this.buttonBook.UseVisualStyleBackColor = true;
            this.buttonBook.Click += new System.EventHandler(this.buttonBook_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 251);
            this.Controls.Add(this.buttonBook);
            this.Controls.Add(this.buttonSpeech);
            this.Name = "FormMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSpeech;
        private System.Windows.Forms.Button buttonBook;
    }
}