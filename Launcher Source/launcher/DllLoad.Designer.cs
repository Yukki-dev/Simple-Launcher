namespace launcher
{
    partial class DllLoad
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Status = new System.Windows.Forms.Label();
            this.cLBox_Dll = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 103);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(487, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(9, 9);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(37, 13);
            this.Status.TabIndex = 1;
            this.Status.Text = "Status";
            // 
            // cLBox_Dll
            // 
            this.cLBox_Dll.FormattingEnabled = true;
            this.cLBox_Dll.Location = new System.Drawing.Point(12, 34);
            this.cLBox_Dll.Name = "cLBox_Dll";
            this.cLBox_Dll.Size = new System.Drawing.Size(487, 49);
            this.cLBox_Dll.TabIndex = 2;
            this.cLBox_Dll.Visible = false;
            // 
            // DllLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(511, 133);
            this.Controls.Add(this.cLBox_Dll);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.progressBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DllLoad";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузка компонентов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.CheckedListBox cLBox_Dll;
    }
}