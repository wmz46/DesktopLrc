using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopLrc
{
    public partial class FormSettings : Form
    {  
        FormLyric formLyric;
        public FormSettings(FormLyric formLyric)
        {
            InitializeComponent(); 
            this.formLyric = formLyric; 
             
             
            trbFontSize.Value = Settings.fontSize;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
          
        } 
 
         
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void chkHMode_CheckedChanged(object sender, EventArgs e)
        {

            Settings.horizontalMode = chkHMode.Checked;
            formLyric.ResizeForm();
            formLyric.PrintForm();
        }

        private void trbFontSize_ValueChanged(object sender, EventArgs e)
        {
            Settings.fontSize = trbFontSize.Value;
            formLyric.PrintForm();
        }
    }
}
