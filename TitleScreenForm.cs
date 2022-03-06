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
    
    public partial class TitleScreenForm : Form
    {
        public void fadeIn()
        {
            Opacity = 0;
            for (int i = 0; i < 100; i++)
            {
                this.Opacity += 0.01;
                Application.DoEvents();
                System.Threading.Thread.Sleep(GlobalVariables.fadeInTime);
            }
        }

        //LOAD ALL FORMS IN THE GAME TO PREVENT DUPLICATE CREATION OF FORMS LATER DOWN THE LINE
        public static Form MainMenu = new MainMenuForm();
        public static Form About = new AboutForm();
        public static Form IntroComic = new IntroComicForm();
        public static Form Highscores = new HighscoresForm();
        public static Form Donate = new DonateForm();
        public static Form Credits = new CreditsForm();
        public static Form Game = new LOCATION_Stiminop();

        public TitleScreenForm()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MainMenu.Show();
                System.Threading.Thread.Sleep(GlobalVariables.FormHideWaitDuration);
                this.Hide();
            }
        }

        private void TitleScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //EXIT PROMPT
            if (MessageBox.Show("Are you sure you want to exit the game?", "Life Without Water", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
