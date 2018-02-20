namespace launcher
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_PLAY = new System.Windows.Forms.Button();
            this.btn_UPDATE = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_Debug = new System.Windows.Forms.TextBox();
            this.label_status_bar = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_PLAY
            // 
            this.btn_PLAY.Location = new System.Drawing.Point(236, 279);
            this.btn_PLAY.Name = "btn_PLAY";
            this.btn_PLAY.Size = new System.Drawing.Size(160, 65);
            this.btn_PLAY.TabIndex = 0;
            this.btn_PLAY.Text = "Play";
            this.btn_PLAY.UseVisualStyleBackColor = true;
            this.btn_PLAY.Click += new System.EventHandler(this.btn_PLAY_Click);
            // 
            // btn_UPDATE
            // 
            this.btn_UPDATE.Location = new System.Drawing.Point(281, 350);
            this.btn_UPDATE.Name = "btn_UPDATE";
            this.btn_UPDATE.Size = new System.Drawing.Size(75, 23);
            this.btn_UPDATE.TabIndex = 1;
            this.btn_UPDATE.Text = "Update";
            this.btn_UPDATE.UseVisualStyleBackColor = true;
            this.btn_UPDATE.Click += new System.EventHandler(this.btn_UPDATE_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 250);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(596, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_Debug);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 232);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "News";
            // 
            // tbx_Debug
            // 
            this.tbx_Debug.Location = new System.Drawing.Point(6, 19);
            this.tbx_Debug.Multiline = true;
            this.tbx_Debug.Name = "tbx_Debug";
            this.tbx_Debug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_Debug.Size = new System.Drawing.Size(584, 207);
            this.tbx_Debug.TabIndex = 0;
            // 
            // label_status_bar
            // 
            this.label_status_bar.AutoEllipsis = true;
            this.label_status_bar.Location = new System.Drawing.Point(12, 385);
            this.label_status_bar.Name = "label_status_bar";
            this.label_status_bar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_status_bar.Size = new System.Drawing.Size(596, 14);
            this.label_status_bar.TabIndex = 5;
            this.label_status_bar.Text = "label_status_bar";
            this.label_status_bar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(620, 407);
            this.Controls.Add(this.label_status_bar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_UPDATE);
            this.Controls.Add(this.btn_PLAY);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_PLAY;
        private System.Windows.Forms.Button btn_UPDATE;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_status_bar;
        private System.Windows.Forms.TextBox tbx_Debug;
    }
}

