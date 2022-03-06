using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Life_Without_Water__PBL_
{
    public partial class NewDay_Display : Form
    {
        public NewDay_Display()
        {
            InitializeComponent();
        }

        private void NewDay_Display_Load(object sender, EventArgs e)
        {
            LBL_DaysLeft.Text = GlobalVariables.currentDay.ToString();
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
        }

        private void NewDay_Display_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
