namespace Editor_for_launcher
{
    partial class MainWindow
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txtBox_InstallVersion = new System.Windows.Forms.TextBox();
            this.txtBox_UpdVersion = new System.Windows.Forms.TextBox();
            this.txtBox_LauncherVersion = new System.Windows.Forms.TextBox();
            this.checkBox_AppVersion = new System.Windows.Forms.CheckBox();
            this.checkBox_Install = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_Update = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.Location = new System.Drawing.Point(233, 219);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.TabIndex = 2;
            this.btn_Exit.Text = "Выйти";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(220, 54);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(101, 41);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtBox_InstallVersion
            // 
            this.txtBox_InstallVersion.Enabled = false;
            this.txtBox_InstallVersion.Location = new System.Drawing.Point(6, 42);
            this.txtBox_InstallVersion.Name = "txtBox_InstallVersion";
            this.txtBox_InstallVersion.Size = new System.Drawing.Size(149, 20);
            this.txtBox_InstallVersion.TabIndex = 3;
            this.txtBox_InstallVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBox_UpdVersion
            // 
            this.txtBox_UpdVersion.Enabled = false;
            this.txtBox_UpdVersion.Location = new System.Drawing.Point(6, 42);
            this.txtBox_UpdVersion.Name = "txtBox_UpdVersion";
            this.txtBox_UpdVersion.Size = new System.Drawing.Size(149, 20);
            this.txtBox_UpdVersion.TabIndex = 5;
            this.txtBox_UpdVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBox_LauncherVersion
            // 
            this.txtBox_LauncherVersion.Enabled = false;
            this.txtBox_LauncherVersion.Location = new System.Drawing.Point(6, 42);
            this.txtBox_LauncherVersion.Name = "txtBox_LauncherVersion";
            this.txtBox_LauncherVersion.Size = new System.Drawing.Size(149, 20);
            this.txtBox_LauncherVersion.TabIndex = 6;
            this.txtBox_LauncherVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_AppVersion
            // 
            this.checkBox_AppVersion.AutoSize = true;
            this.checkBox_AppVersion.Location = new System.Drawing.Point(6, 19);
            this.checkBox_AppVersion.Name = "checkBox_AppVersion";
            this.checkBox_AppVersion.Size = new System.Drawing.Size(118, 17);
            this.checkBox_AppVersion.TabIndex = 7;
            this.checkBox_AppVersion.Text = "Обновить лаунчер";
            this.checkBox_AppVersion.UseVisualStyleBackColor = true;
            this.checkBox_AppVersion.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox_Install
            // 
            this.checkBox_Install.AutoSize = true;
            this.checkBox_Install.Location = new System.Drawing.Point(6, 19);
            this.checkBox_Install.Name = "checkBox_Install";
            this.checkBox_Install.Size = new System.Drawing.Size(118, 17);
            this.checkBox_Install.TabIndex = 13;
            this.checkBox_Install.Text = "Изменить версию";
            this.checkBox_Install.UseVisualStyleBackColor = true;
            this.checkBox_Install.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBox_InstallVersion);
            this.groupBox1.Controls.Add(this.checkBox_Install);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 72);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обновление установщика";
            // 
            // checkBox_Update
            // 
            this.checkBox_Update.AutoSize = true;
            this.checkBox_Update.Location = new System.Drawing.Point(6, 19);
            this.checkBox_Update.Name = "checkBox_Update";
            this.checkBox_Update.Size = new System.Drawing.Size(118, 17);
            this.checkBox_Update.TabIndex = 15;
            this.checkBox_Update.Text = "Изменить версию";
            this.checkBox_Update.UseVisualStyleBackColor = true;
            this.checkBox_Update.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_Update);
            this.groupBox3.Controls.Add(this.txtBox_UpdVersion);
            this.groupBox3.Location = new System.Drawing.Point(4, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(163, 73);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Обновление";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_AppVersion);
            this.groupBox4.Controls.Add(this.txtBox_LauncherVersion);
            this.groupBox4.Location = new System.Drawing.Point(4, 169);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(163, 73);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Обновление лаунчера";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(353, 250);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Exit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор версий";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txtBox_InstallVersion;
        private System.Windows.Forms.TextBox txtBox_UpdVersion;
        private System.Windows.Forms.TextBox txtBox_LauncherVersion;
        private System.Windows.Forms.CheckBox checkBox_AppVersion;
        private System.Windows.Forms.CheckBox checkBox_Install;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_Update;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

