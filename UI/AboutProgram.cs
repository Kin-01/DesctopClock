using System;
using System.Windows.Forms;

namespace UI
{
    public partial class AboutProgram : Form
    {
        public AboutProgram()
        {
            InitializeComponent();
            cucumbertip.SetToolTip(this.buttonok, "Набирай cucmber смело!");
        }
        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }   // Закрыть окно
    }
}
