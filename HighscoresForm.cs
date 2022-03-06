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
    public partial class HighscoresForm : Form
    {
        public HighscoresForm()
        {
            InitializeComponent();
        }

        private void HighscoresForm_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            for (int i = 0; i < 100; i++)
            {
                this.Opacity += 0.01;
                Application.DoEvents();
                System.Threading.Thread.Sleep(GlobalVariables.fadeInTime);
            }
        }

        private void HighscoresForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (MessageBox.Show("Are you sure you want to exit the game?", "Life Without Water", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }*/
        }

        private void HighscoresForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}
