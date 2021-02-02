namespace UI
{
    partial class ClockForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClockForm));
            this.ClockBox = new System.Windows.Forms.PictureBox();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timersecond = new System.Windows.Forms.Timer(this.components);
            this.timerminute = new System.Windows.Forms.Timer(this.components);
            this.timerhour = new System.Windows.Forms.Timer(this.components);
            this.NotifySettings = new System.Windows.Forms.NotifyIcon(this.components);
            this.CurrDataTimeTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ClockBox)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClockBox
            // 
            this.ClockBox.BackColor = System.Drawing.Color.Transparent;
            this.ClockBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClockBox.Location = new System.Drawing.Point(0, 0);
            this.ClockBox.Name = "ClockBox";
            this.ClockBox.Size = new System.Drawing.Size(300, 300);
            this.ClockBox.TabIndex = 0;
            this.ClockBox.TabStop = false;
            this.ClockBox.Paint += new System.Windows.Forms.PaintEventHandler(this.RefreshClock);
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(174, 100);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.ShowAboutProgramWindows);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.largeToolStripMenuItem});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.sizeToolStripMenuItem.Text = "Размер";
            // 
            // smallToolStripMenuItem
            // 
            this.smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            this.smallToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.smallToolStripMenuItem.Text = "Меленький";
            this.smallToolStripMenuItem.Click += new System.EventHandler(this.SetSmallSize);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.mediumToolStripMenuItem.Text = "Средний";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.SetMediumSize);
            // 
            // largeToolStripMenuItem
            // 
            this.largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            this.largeToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.largeToolStripMenuItem.Text = "Большой";
            this.largeToolStripMenuItem.Click += new System.EventHandler(this.SetLargeSize);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.OpenSettings);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.closeToolStripMenuItem.Text = "Закрыть";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseClock);
            // 
            // timersecond
            // 
            this.timersecond.Interval = 1000;
            this.timersecond.Tick += new System.EventHandler(this.Tick_Second);
            // 
            // timerminute
            // 
            this.timerminute.Interval = 60000;
            this.timerminute.Tick += new System.EventHandler(this.Tick_Minute);
            // 
            // timerhour
            // 
            this.timerhour.Interval = 3600000;
            this.timerhour.Tick += new System.EventHandler(this.Tick_Hour);
            // 
            // NotifySettings
            // 
            this.NotifySettings.ContextMenuStrip = this.MenuStrip;
            this.NotifySettings.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifySettings.Icon")));
            this.NotifySettings.Text = "Settings";
            this.NotifySettings.Visible = true;
            this.NotifySettings.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MaximizeClock);
            // 
            // ClockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.ClockBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ClockForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Clock";
            this.Load += new System.EventHandler(this.LoadSettings);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LetsParty);
            ((System.ComponentModel.ISupportInitialize)(this.ClockBox)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ClockBox;
        private System.Windows.Forms.Timer timersecond;
        private System.Windows.Forms.Timer timerminute;
        private System.Windows.Forms.Timer timerhour;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon NotifySettings;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolTip CurrDataTimeTip;
    }
}

