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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void fadeOut()
        {
            for (int i = 100; i > 0; i++)
            {
                this.Opacity -= 0.01;
                Application.DoEvents();
                System.Threading.Thread.Sleep(GlobalVariables.fadeOutTime);
            }
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            PNL_Buttons.Left = (this.ClientSize.Width - PNL_Buttons.Width) / 2;
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            //BTN_NewGame.Top = (this.ClientSize.Height - BTN_NewGame.Height) / 2;
            Opacity = 0;
            for (int i = 0; i < 100; i++)
            {
                this.Opacity += 0.01;
                Application.DoEvents();
                System.Threading.Thread.Sleep(GlobalVariables.fadeInTime);
            }


        }


        private void BTN_NewGame_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            Form x = TitleScreenForm.IntroComic;
            x.Show();
            System.Threading.Thread.Sleep(GlobalVariables.FormHideWaitDuration);
            fadeOut();
            this.Hide();
            this.Close();
        }

        private void BTN_Highscores_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Unimplemented heehee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            /*Form x = TitleScreenForm.Highscores;
            x.Show();
            System.Threading.Thread.Sleep(GlobalVariables.FormHideWaitDuration);
            fadeOut();
            this.Hide();*/
        }

        private void BTN_Donate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Unimplemented heehee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            /*Form x = TitleScreenForm.Donate;
            x.Show();
            System.Threading.Thread.Sleep(GlobalVariables.FormHideWaitDuration);
            fadeOut();
            this.Hide();*/
        }

        private void BTN_Credits_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Unimplemented heehee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.TopMost = true;
            Form x = TitleScreenForm.Credits;
            x.Show();
            System.Threading.Thread.Sleep(GlobalVariables.FormHideWaitDuration);
            fadeOut();
            this.Close();
        }

        private void BTN_About_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            Form x = TitleScreenForm.About;
            x.Show();
            System.Threading.Thread.Sleep(GlobalVariables.FormHideWaitDuration);
            fadeOut();
            this.Close();
        }

        private void BTN_QuitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (MessageBox.Show("Are you sure you want to exit the game?", "Life Without Water", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }*/
           
        }
    }
}
