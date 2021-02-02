namespace UI
{
    partial class AboutProgram
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutProgram));
            this.abouttext = new System.Windows.Forms.Label();
            this.buttonok = new System.Windows.Forms.Button();
            this.KhaiPicture = new System.Windows.Forms.PictureBox();
            this.cucumbertip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.KhaiPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // abouttext
            // 
            this.abouttext.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.abouttext.Location = new System.Drawing.Point(12, 162);
            this.abouttext.Name = "abouttext";
            this.abouttext.Size = new System.Drawing.Size(389, 78);
            this.abouttext.TabIndex = 0;
            this.abouttext.Text = "Данные часы сделал студент 525и группы Шипунов Никита. Буду рад если они пригодят" +
    "ся";
            this.abouttext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonok
            // 
            this.buttonok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonok.Location = new System.Drawing.Point(181, 259);
            this.buttonok.Name = "buttonok";
            this.buttonok.Size = new System.Drawing.Size(58, 52);
            this.buttonok.TabIndex = 1;
            this.buttonok.Text = "OK";
            this.buttonok.UseVisualStyleBackColor = true;
            this.buttonok.Click += new System.EventHandler(this.CloseWindow);
            // 
            // KhaiPicture
            // 
            this.KhaiPicture.Image = ((System.Drawing.Image)(resources.GetObject("KhaiPicture.Image")));
            this.KhaiPicture.Location = new System.Drawing.Point(135, 42);
            this.KhaiPicture.Name = "KhaiPicture";
            this.KhaiPicture.Size = new System.Drawing.Size(152, 87);
            this.KhaiPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.KhaiPicture.TabIndex = 2;
            this.KhaiPicture.TabStop = false;
            // 
            // AboutProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 341);
            this.ControlBox = false;
            this.Controls.Add(this.KhaiPicture);
            this.Controls.Add(this.buttonok);
            this.Controls.Add(this.abouttext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)(this.KhaiPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label abouttext;
        private System.Windows.Forms.Button buttonok;
        private System.Windows.Forms.PictureBox KhaiPicture;
        private System.Windows.Forms.ToolTip cucumbertip;
    }
}