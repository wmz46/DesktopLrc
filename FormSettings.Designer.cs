namespace DesktopLrc
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.chkHMode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.trbFontSize = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trbFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // chkHMode
            // 
            this.chkHMode.AutoSize = true;
            this.chkHMode.Location = new System.Drawing.Point(76, 122);
            this.chkHMode.Name = "chkHMode";
            this.chkHMode.Size = new System.Drawing.Size(75, 21);
            this.chkHMode.TabIndex = 0;
            this.chkHMode.Text = "水平歌词";
            this.chkHMode.UseVisualStyleBackColor = true;
            this.chkHMode.CheckedChanged += new System.EventHandler(this.chkHMode_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "字体大小:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(76, 175);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // trbFontSize
            // 
            this.trbFontSize.Location = new System.Drawing.Point(151, 59);
            this.trbFontSize.Maximum = 100;
            this.trbFontSize.Minimum = 10;
            this.trbFontSize.Name = "trbFontSize";
            this.trbFontSize.Size = new System.Drawing.Size(104, 45);
            this.trbFontSize.TabIndex = 3;
            this.trbFontSize.Value = 10;
            this.trbFontSize.ValueChanged += new System.EventHandler(this.trbFontSize_ValueChanged);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 257);
            this.Controls.Add(this.trbFontSize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkHMode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.Text = "设置";
            ((System.ComponentModel.ISupportInitialize)(this.trbFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkHMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TrackBar trbFontSize;
    }
}