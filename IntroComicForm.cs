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
    public partial class IntroComicForm : Form
    {
        public IntroComicForm()
        {
            InitializeComponent();
        }

        private void IntroComicForm_Load(object sender, EventArgs e)
        {
            //FADE IN
            Opacity = 0;
            for (int i = 0; i < 100; i++)
            {
                Opacity += 0.01;
                Application.DoEvents();
                System.Threading.Thread.Sleep(GlobalVariables.fadeInTime);
            }
            LBL_CanYouSurvive.Left = (this.ClientSize.Width - LBL_CanYouSurvive.Width) / 2;
        }

        private void IntroComicForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.TopMost = true;
                Form x = new DailyHomeDistributionForm();
                x.Show();
                for (int i = 100; i > 0; i++)
                {
                    this.Opacity -= 0.01;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(GlobalVariables.fadeOutTime);
                }
                System.Threading.Thread.Sleep(GlobalVariables.FormHideWaitDuration);
                this.Close();
            }

            //EXIT
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
