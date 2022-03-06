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
    public partial class WinFormHehe : Form
    {
        public WinFormHehe()
        {
            InitializeComponent();
        }

        string currentCharacter = "DAD";


        private void WinFormHehe_Load(object sender, EventArgs e)
        {
            LBL_Details.MaximumSize = new Size(818, 0);
            LBL_Details.AutoSize = true;

            LBL_Details.Text = "Congratulations, You have gotten through the 7 days with these stats!";
            switch (GlobalVariables.difficulty)
            {
                case 1:
                    
                    break;
                case 2:

                    break;
                case 3:

                    break;
            }
            if (GlobalVariables.DAD_Health <= 1 || GlobalVariables.MOM_Health <= 1 || GlobalVariables.DAUGHTER_Health <=1 || GlobalVariables.SON_Health <=1)
            {
                LBL_Details.Text = "Sadly, one of the family members has died.";
            }
            else
            {
                LBL_Details.Text = "Congratulations, You lived through the week with all of your family intact";
            }
                        
        }

        private void WinFormHehe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
            //    switch (GlobalVariables.difficulty)
            //    {
            //        case 2: //MEDIUM
            //            MessageBox.Show("Switch diff");
            //            switch (currentCharacter)
            //            {
            //                case "DAD":
            //                    MessageBox.Show("Switch change");
            //                    currentCharacter = "MOM";
            //                    PB_SelectedCharacter.Image = Properties.Resources.MOM;
            //                    break;
            //                case "MOM":
            //                    currentCharacter = "DAD";
            //                    PB_SelectedCharacter.Image = Properties.Resources.DAD;
            //                    break;
            //            }
            //            break;
            //        case 3: //HARD
            //            switch (currentCharacter)
            //            {
            //                case "DAD":
            //                    currentCharacter = "DAUGHTER";
            //                    PB_SelectedCharacter.Image = Properties.Resources.DAUGHTER;
            //                    break;
            //                case "MOM":
            //                    currentCharacter = "DAD";
            //                    PB_SelectedCharacter.Image = Properties.Resources.DAD;
            //                    break;
            //                case "SON":
            //                    currentCharacter = "MOM";
            //                    PB_SelectedCharacter.Image = Properties.Resources.MOM;
            //                    break;
            //                case "DAUGHTER":
            //                    currentCharacter = "SON";
            //                    PB_SelectedCharacter.Image = Properties.Resources.SON;
            //                    break;
            //            }
            //            break;
            //    }
            //}

            //if (e.KeyCode == Keys.D)
            //{
            //    switch (GlobalVariables.difficulty)
            //    {
            //        case 2: //MEDIUM
            //            switch (currentCharacter)
            //            {
            //                case "DAD":
            //                    currentCharacter = "MOM";
            //                    PB_SelectedCharacter.Image = Properties.Resources.MOM;
            //                    break;
            //                case "MOM":
            //                    currentCharacter = "DAD";
            //                    PB_SelectedCharacter.Image = Properties.Resources.DAD;
            //                    break;
            //            }
            //            break;
            //        case 3: //HARD
            //            switch (currentCharacter)
            //            {
            //                case "DAD":
            //                    currentCharacter = "MOM";
            //                    PB_SelectedCharacter.Image = Properties.Resources.MOM;
            //                    break;
            //                case "MOM":
            //                    currentCharacter = "SON";
            //                    PB_SelectedCharacter.Image = Properties.Resources.SON;
            //                    break;
            //                case "SON":
            //                    currentCharacter = "DAUGHTER";
            //                    PB_SelectedCharacter.Image = Properties.Resources.DAUGHTER;
            //                    break;
            //                case "DAUGHTER":
            //                    currentCharacter = "DAD";
            //                    PB_SelectedCharacter.Image = Properties.Resources.DAD;
            //                    break;
            //            }
            //            break;
                }
            }

            //if (e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            //{
            //    characterDataSheet();
            //}
        }
        //private void characterDataSheet()
        //{
        //    //switch (currentCharacter)
        //    //{
        //    //    //case "DAD":
        //    //    //    LBL_Health.Text = GlobalVariables.DAD_Health.ToString();
        //    //    //    LBL_Happiness.Text = GlobalVariables.DAD_Happiness.ToString();
        //    //    //    LBL_Thirst.Text = GlobalVariables.DAD_Thirst.ToString();
        //    //    //    break;
        //    //    //case "MOM":
        //    //    //    LBL_Health.Text = GlobalVariables.MOM_Health.ToString();
        //    //    //    LBL_Happiness.Text = GlobalVariables.MOM_Happiness.ToString();
        //    //    //    LBL_Thirst.Text = GlobalVariables.MOM_Thirst.ToString();
        //    //    //    break;
        //    //    //case "SON":
        //    //    //    LBL_Health.Text = GlobalVariables.SON_Health.ToString();
        //    //    //    LBL_Happiness.Text = GlobalVariables.SON_Happiness.ToString();
        //    //    //    LBL_Thirst.Text = GlobalVariables.SON_Thirst.ToString();
        //    //    //    break;
        //    //    //case "DAUGHTER":
        //    //    //    LBL_Health.Text = GlobalVariables.DAUGHTER_Health.ToString();
        //    //    //    LBL_Happiness.Text = GlobalVariables.DAUGHTER_Happiness.ToString();
        //    //    //    LBL_Thirst.Text = GlobalVariables.DAUGHTER_Thirst.ToString();
        //    //    //    break;
        //    //}
        //}
        
    }