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
    public partial class DailyHomeDistributionForm : Form
    {
        public DailyHomeDistributionForm()
        {
            InitializeComponent();

            //AESTHETIC stuff
            //Gets actual transparency

            var daysLeftLabelPos = this.PointToScreen(LBL_DaysLeft.Location);
            daysLeftLabelPos = PB_Calendar.PointToClient(daysLeftLabelPos);
            LBL_DaysLeft.Parent = PB_Calendar;
            LBL_DaysLeft.Location = daysLeftLabelPos;

            var actualWaterPos = this.PointToScreen(PB_Water.Location);
            actualWaterPos = PB_WaterBottle.PointToClient(actualWaterPos);
            PB_Water.Parent = PB_WaterBottle;
            PB_Water.Location = actualWaterPos;

            var actualWaterCounterLabelPos = this.PointToScreen(LBL_BottlesOfWater.Location);
            actualWaterCounterLabelPos = PB_WaterBottleCounter.PointToClient(actualWaterCounterLabelPos);
            LBL_BottlesOfWater.Parent = PB_WaterBottleCounter;
            LBL_BottlesOfWater.Location = actualWaterCounterLabelPos;

            var thirstStatPos = this.PointToScreen(LBL_Thirst.Location);
            thirstStatPos = PB_CharacterDataSheet.PointToClient(thirstStatPos);
            LBL_Thirst.Parent = PB_CharacterDataSheet;
            LBL_Thirst.Location = thirstStatPos;

            var happinessStatPos = this.PointToScreen(LBL_Happiness.Location);
            happinessStatPos = PB_CharacterDataSheet.PointToClient(happinessStatPos);
            LBL_Happiness.Parent = PB_CharacterDataSheet;
            LBL_Happiness.Location = happinessStatPos;

            var healthStatPos = this.PointToScreen(LBL_Health.Location);
            healthStatPos = PB_CharacterDataSheet.PointToClient(healthStatPos);
            LBL_Health.Parent = PB_CharacterDataSheet;
            LBL_Health.Location = healthStatPos;

        }


        //DATA CHANGING
        //CHANGING DATA
        bool waterChanging = false;
        float waterChangeAmount = 0.00f;
        char waterChangeType = 'a';
        int waterChangeTimes = 0;
        int waterBottleWaterChanges = 0;
        string currentCharacter = "DAD";

        //SHOWER INTENSITIES
        int DAD_showerIntensity = 0;
        int MOM_showerIntensity = 0;
        int SON_showerIntensity = 0;
        int DAUGHTER_showerIntensity = 0;

        //FLUSH THE BATHROOM
        bool DAD_flushBathroom = false;
        bool MOM_flushBathroom = false;
        bool SON_flushBathroom = false;
        bool DAUGHTER_flushBathroom = false;

        //TIMES TO BRUSH TODAY
        int DAD_timesToBrush = 0;
        int MOM_timesToBrush = 0;
        int SON_timesToBrush = 0;
        int DAUGHTER_timesToBrush = 0;

        //BOTTLES TO DRINK TODAY
        int DAD_bottlesOfWater = 0;
        int MOM_bottlesOfWater = 0;
        int SON_bottlesOfWater = 0;
        int DAUGHTER_bottlesOfWater = 0;

        bool closing = false;
        private void callOnLoad()
        {
            GlobalVariables.currentDay++;
            //SLDR_BottlesOfWater.MaximumValue = 10;
            TMR2.Start();

            GlobalVariables.DAD_Thirst -= 50;
            GlobalVariables.MOM_Thirst -= 50;
            GlobalVariables.SON_Thirst -= 50;
            GlobalVariables.DAUGHTER_Thirst -= 50;

            if(GlobalVariables.DAD_Thirst <= 1)
            {
                GlobalVariables.DAD_Health -= 30;
            }

            if (GlobalVariables.MOM_Thirst <= 1)
            {
                GlobalVariables.MOM_Health -= 30;
            }

            if (GlobalVariables.SON_Thirst <= 1)
            {
                GlobalVariables.SON_Health -= 30;
            }

            if (GlobalVariables.DAUGHTER_Thirst <= 1)
            {
                GlobalVariables.DAUGHTER_Health -= 30;
            }


            LBL_DaysLeft.Text = (7 - GlobalVariables.currentDay).ToString();

            LBL_WaterLeft.Text = GlobalVariables.litersLeft.ToString(); ;

            characterDataSheet();

            Form x = new NewDay_Display();
            x.ShowDialog();


            //SHOWER INTENSITY
            DAD_showerIntensity = 0;
            MOM_showerIntensity = 0;
            SON_showerIntensity = 0;
            DAUGHTER_showerIntensity = 0;

            //FLUSH THE BATHROOM
            DAD_flushBathroom = false;
            MOM_flushBathroom = false;
            SON_flushBathroom = false;
            DAUGHTER_flushBathroom = false;

            //TIMES TO BRUSH TODAY
            DAD_timesToBrush = 0;
            MOM_timesToBrush = 0;
            SON_timesToBrush = 0;
            DAUGHTER_timesToBrush = 0;

            //BOTTLES TO DRINK TODAY
            DAD_bottlesOfWater = 0;
            MOM_bottlesOfWater = 0;
            SON_bottlesOfWater = 0;
            DAUGHTER_bottlesOfWater = 0;

            if(GlobalVariables.DAD_Health < 1 || GlobalVariables.MOM_Health < 1 || GlobalVariables.SON_Health < 1 || GlobalVariables.DAUGHTER_Health < 1)
            {
                Form xx = new WinFormHehe();
                xx.Show();
                this.Close();
            }
        }
        private void DailyHomeDistributionForm_Load(object sender, EventArgs e)
        {
            LBL_WaterLeft.Text = string.Format("{0:0.0}", GlobalVariables.litersLeft);
            callOnLoad();
        }

        private void BTN_Shower_Click(object sender, EventArgs e)
        {
            switch(currentCharacter)
            {
                case "DAD":
                    //CODE
                    switch (DAD_showerIntensity)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            DAD_showerIntensity++;
                            break;
                        case 4:
                            DAD_showerIntensity = 0;
                            break;
                    }

                    //VISUALS
                    switch (DAD_showerIntensity)
                    {
                        case 0:
                            BTN_Shower.LabelText = "Don't Bathe";
                            break;
                        case 1:
                            BTN_Shower.LabelText = "1/4 Pail";
                            break;
                        case 2:
                            BTN_Shower.LabelText = "2/4 Pail";
                            break;
                        case 3:
                            BTN_Shower.LabelText = "3/4 Pail";
                            break;
                        case 4:
                            BTN_Shower.LabelText = "4/4 Pail";
                            break;
                    }
                    break;
                case "MOM":
                    //CODE
                    switch (MOM_showerIntensity)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            MOM_showerIntensity++;
                            break;
                        case 4:
                            MOM_showerIntensity = 0;
                            break;
                    }

                    //VISUALS
                    switch (MOM_showerIntensity)
                    {
                        case 0:
                            BTN_Shower.LabelText = "Don't Bathe";
                            break;
                        case 1:
                            BTN_Shower.LabelText = "1/4 Pail";
                            break;
                        case 2:
                            BTN_Shower.LabelText = "2/4 Pail";
                            break;
                        case 3:
                            BTN_Shower.LabelText = "3/4 Pail";
                            break;
                        case 4:
                            BTN_Shower.LabelText = "4/4 Pail";
                            break;
                    }
                    break;
                case "SON":
                    //CODE
                    switch (SON_showerIntensity)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            SON_showerIntensity++;
                            break;
                        case 4:
                            SON_showerIntensity = 0;
                            break;
                    }

                    //VISUALS
                    switch (SON_showerIntensity)
                    {
                        case 0:
                            BTN_Shower.LabelText = "Don't Bathe";
                            break;
                        case 1:
                            BTN_Shower.LabelText = "1/4 Pail";
                            break;
                        case 2:
                            BTN_Shower.LabelText = "2/4 Pail";
                            break;
                        case 3:
                            BTN_Shower.LabelText = "3/4 Pail";
                            break;
                        case 4:
                            BTN_Shower.LabelText = "4/4 Pail";
                            break;
                    }
                    break;
                case "DAUGHTER":
                    //CODE
                    switch (DAUGHTER_showerIntensity)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            DAUGHTER_showerIntensity++;
                            break;
                        case 4:
                            DAUGHTER_showerIntensity = 0;
                            break;
                    }

                    //VISUALS
                    switch (DAUGHTER_showerIntensity)
                    {
                        case 0:
                            BTN_Shower.LabelText = "Don't Bathe";
                            break;
                        case 1:
                            BTN_Shower.LabelText = "1/4 Pail";
                            break;
                        case 2:
                            BTN_Shower.LabelText = "2/4 Pail";
                            break;
                        case 3:
                            BTN_Shower.LabelText = "3/4 Pail";
                            break;
                        case 4:
                            BTN_Shower.LabelText = "4/4 Pail";
                            break;
                    }
                    break;
            }
            
        }

        private void BTN_FlushBathroom_Click(object sender, EventArgs e)
        {
            switch(currentCharacter)
            {
                case "DAD":
                    DAD_flushBathroom = DAD_flushBathroom ? false : true;
                    BTN_FlushBathroom.LabelText = DAD_flushBathroom ? "Flush" : "Don't Flush";
                    break;
                case "MOM":
                    MOM_flushBathroom = MOM_flushBathroom ? false : true;
                    BTN_FlushBathroom.LabelText = MOM_flushBathroom ? "Flush" : "Don't Flush";
                    break;
                case "SON":
                    SON_flushBathroom = SON_flushBathroom ? false : true;
                    BTN_FlushBathroom.LabelText = SON_flushBathroom ? "Flush" : "Don't Flush";
                    break;
                case "DAUGHTER":
                    DAUGHTER_flushBathroom = DAUGHTER_flushBathroom ? false : true;
                    BTN_FlushBathroom.LabelText = DAUGHTER_flushBathroom ? "Flush" : "Don't Flush";
                    break;
            }
        }

        private void BTN_Brush_Click(object sender, EventArgs e)
        {
            switch(currentCharacter)
            {
                case "DAD":
                    switch (DAD_timesToBrush)
                    {
                        case 0:
                        case 1:
                        case 2:
                            DAD_timesToBrush++;
                            break;
                        case 3:
                            DAD_timesToBrush = 0;
                            break;
                    }

                    //VISUALS
                    switch (DAD_timesToBrush)
                    {
                        case 0:
                            BTN_Brush.LabelText = "Don't Brush";
                            break;
                        case 1:
                            BTN_Brush.LabelText = "Brush Once";
                            break;
                        case 2:
                            BTN_Brush.LabelText = "Brush Twice";
                            break;
                        case 3:
                            BTN_Brush.LabelText = "Brush Thrice";
                            break;
                    }
                    break;
                case "MOM":
                    switch (MOM_timesToBrush)
                    {
                        case 0:
                        case 1:
                        case 2:
                            MOM_timesToBrush++;
                            break;
                        case 3:
                            MOM_timesToBrush = 0;
                            break;
                    }

                    //VISUALS
                    switch (MOM_timesToBrush)
                    {
                        case 0:
                            BTN_Brush.LabelText = "Don't Brush";
                            break;
                        case 1:
                            BTN_Brush.LabelText = "Brush Once";
                            break;
                        case 2:
                            BTN_Brush.LabelText = "Brush Twice";
                            break;
                        case 3:
                            BTN_Brush.LabelText = "Brush Thrice";
                            break;
                    }
                    break;
                case "SON":
                    switch (SON_timesToBrush)
                    {
                        case 0:
                        case 1:
                        case 2:
                            SON_timesToBrush++;
                            break;
                        case 3:
                            SON_timesToBrush = 0;
                            break;
                    }

                    //VISUALS
                    switch (SON_timesToBrush)
                    {
                        case 0:
                            BTN_Brush.LabelText = "Don't Brush";
                            break;
                        case 1:
                            BTN_Brush.LabelText = "Brush Once";
                            break;
                        case 2:
                            BTN_Brush.LabelText = "Brush Twice";
                            break;
                        case 3:
                            BTN_Brush.LabelText = "Brush Thrice";
                            break;
                    }
                    break;
                case "DAUGHTER":
                    switch (DAUGHTER_timesToBrush)
                    {
                        case 0:
                        case 1:
                        case 2:
                            DAUGHTER_timesToBrush++;
                            break;
                        case 3:
                            DAUGHTER_timesToBrush = 0;
                            break;
                    }

                    //VISUALS
                    switch (DAUGHTER_timesToBrush)
                    {
                        case 0:
                            BTN_Brush.LabelText = "Don't Brush";
                            break;
                        case 1:
                            BTN_Brush.LabelText = "Brush Once";
                            break;
                        case 2:
                            BTN_Brush.LabelText = "Brush Twice";
                            break;
                        case 3:
                            BTN_Brush.LabelText = "Brush Thrice";
                            break;
                    }
                    break;
            }
            //CODE
            
        }

        private void BTN_Add_Click(object sender, EventArgs e)
        {
            switch (currentCharacter)
            {
                case "DAD":
                    if(DAD_bottlesOfWater != 9)
                    {
                        DAD_bottlesOfWater++;
                        LBL_BottlesOfWater.Text = DAD_bottlesOfWater.ToString();
                    }
                    break;
                case "MOM":
                    if(MOM_bottlesOfWater != 9)
                    {
                        MOM_bottlesOfWater++;
                        LBL_BottlesOfWater.Text = MOM_bottlesOfWater.ToString();
                    }
                    break;
                case "SON":
                    if(SON_bottlesOfWater != 9)
                    {
                        SON_bottlesOfWater++;
                        LBL_BottlesOfWater.Text = SON_bottlesOfWater.ToString();
                    }
                    break;
                case "DAUGHTER":
                    if(DAUGHTER_bottlesOfWater != 9)
                    {
                        DAUGHTER_bottlesOfWater++;
                        LBL_BottlesOfWater.Text = DAUGHTER_bottlesOfWater.ToString();
                    }
                    break;
            }
        }

        private void BTN_Remove_Click(object sender, EventArgs e)
        {
            switch (currentCharacter)
            {
                case "DAD":
                    if (DAD_bottlesOfWater != 0)
                    {
                        DAD_bottlesOfWater--;
                        LBL_BottlesOfWater.Text = DAD_bottlesOfWater.ToString();
                    }
                    break;
                case "MOM":
                    if (MOM_bottlesOfWater != 0)
                    {
                        MOM_bottlesOfWater--;
                        LBL_BottlesOfWater.Text = MOM_bottlesOfWater.ToString();
                    }
                    break;
                case "SON":
                    if (SON_bottlesOfWater != 0)
                    {
                        SON_bottlesOfWater--;
                        LBL_BottlesOfWater.Text = SON_bottlesOfWater.ToString();
                    }
                    break;
                case "DAUGHTER":
                    if (DAUGHTER_bottlesOfWater != 0)
                    {
                        DAUGHTER_bottlesOfWater--;
                        LBL_BottlesOfWater.Text = DAUGHTER_bottlesOfWater.ToString();
                    }
                    break;
            }
        }

        private void DailyHomeDistributionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                switch(GlobalVariables.difficulty)
                {
                    case 2: //MEDIUM
                        MessageBox.Show("Switch diff");
                        switch (currentCharacter)
                        {
                            case "DAD":
                                currentCharacter = "MOM";
                                PB_SelectedCharacter.Image = Properties.Resources.MOM;
                                LBL_BottlesOfWater.Text = MOM_bottlesOfWater.ToString();
                                switch (DAD_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (DAD_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (MOM_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                            case "MOM":
                                currentCharacter = "DAD";
                                PB_SelectedCharacter.Image = Properties.Resources.DAD;
                                LBL_BottlesOfWater.Text = DAD_bottlesOfWater.ToString();
                                switch (DAD_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (DAD_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (DAD_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                        }
                        break;
                    case 3: //HARD
                        switch (currentCharacter)
                        {
                            case "DAD":
                                currentCharacter = "DAUGHTER";
                                PB_SelectedCharacter.Image = Properties.Resources.DAUGHTER;
                                LBL_BottlesOfWater.Text = DAUGHTER_bottlesOfWater.ToString();

                                switch (DAUGHTER_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch(DAUGHTER_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (DAUGHTER_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                
                                break;
                            case "MOM":
                                currentCharacter = "DAD";
                                PB_SelectedCharacter.Image = Properties.Resources.DAD;
                                LBL_BottlesOfWater.Text = DAD_bottlesOfWater.ToString();
                                switch (DAD_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (DAD_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (DAD_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                            case "SON":
                                currentCharacter = "MOM";
                                PB_SelectedCharacter.Image = Properties.Resources.MOM;
                                LBL_BottlesOfWater.Text = MOM_bottlesOfWater.ToString();
                                switch (MOM_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (MOM_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (MOM_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                            case "DAUGHTER":
                                currentCharacter = "SON";
                                PB_SelectedCharacter.Image = Properties.Resources.SON;
                                LBL_BottlesOfWater.Text = SON_bottlesOfWater.ToString();
                                switch (SON_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (SON_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (SON_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
            if(e.KeyCode == Keys.D)
            {
                switch (GlobalVariables.difficulty)
                {
                    case 2: //MEDIUM
                        switch (currentCharacter)
                        {
                            case "DAD":
                                currentCharacter = "MOM";
                                PB_SelectedCharacter.Image = Properties.Resources.MOM;
                                LBL_BottlesOfWater.Text = MOM_bottlesOfWater.ToString();
                                switch (MOM_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (MOM_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (MOM_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                            case "MOM":
                                currentCharacter = "DAD";
                                PB_SelectedCharacter.Image = Properties.Resources.DAD;
                                LBL_BottlesOfWater.Text = DAD_bottlesOfWater.ToString();
                                switch (DAD_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (DAD_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (DAD_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                        }
                        break;
                    case 3: //HARD
                        switch (currentCharacter)
                        {
                            case "DAD":
                                currentCharacter = "MOM";
                                PB_SelectedCharacter.Image = Properties.Resources.MOM;
                                LBL_BottlesOfWater.Text = MOM_bottlesOfWater.ToString();
                                switch (MOM_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (MOM_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (MOM_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                            case "MOM":
                                currentCharacter = "SON";
                                PB_SelectedCharacter.Image = Properties.Resources.SON;
                                LBL_BottlesOfWater.Text = SON_bottlesOfWater.ToString();
                                switch (SON_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (SON_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (SON_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                            case "SON":
                                currentCharacter = "DAUGHTER";
                                PB_SelectedCharacter.Image = Properties.Resources.DAUGHTER;
                                LBL_BottlesOfWater.Text = DAUGHTER_bottlesOfWater.ToString();
                                switch (DAUGHTER_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (DAUGHTER_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (DAUGHTER_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                            case "DAUGHTER":
                                currentCharacter = "DAD";
                                PB_SelectedCharacter.Image = Properties.Resources.DAD;
                                LBL_BottlesOfWater.Text = DAD_bottlesOfWater.ToString();
                                switch (DAD_showerIntensity)
                                {
                                    case 0:
                                        BTN_Shower.LabelText = "Don't Bathe";
                                        break;
                                    case 1:
                                        BTN_Shower.LabelText = "1/4 Pail";
                                        break;
                                    case 2:
                                        BTN_Shower.LabelText = "2/4 Pail";
                                        break;
                                    case 3:
                                        BTN_Shower.LabelText = "3/4 Pail";
                                        break;
                                    case 4:
                                        BTN_Shower.LabelText = "4/4 Pail";
                                        break;
                                }
                                switch (DAD_flushBathroom)
                                {
                                    case true:
                                        BTN_FlushBathroom.LabelText = "Flush";
                                        break;
                                    case false:
                                        BTN_FlushBathroom.LabelText = "Don't Flush";
                                        break;

                                }
                                switch (DAD_timesToBrush)
                                {
                                    case 0:
                                        BTN_Brush.LabelText = "Don't Brush";
                                        break;
                                    case 1:
                                        BTN_Brush.LabelText = "Brush Once";
                                        break;
                                    case 2:
                                        BTN_Brush.LabelText = "Brush Twice";
                                        break;
                                    case 3:
                                        BTN_Brush.LabelText = "Brush Thrice";
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
            if(e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                characterDataSheet();
            }
        }

        private void characterDataSheet()
        {
            switch (currentCharacter)
            {
                case "DAD":
                    LBL_Health.Text = GlobalVariables.DAD_Health.ToString();
                    LBL_Happiness.Text = GlobalVariables.DAD_Happiness.ToString();
                    LBL_Thirst.Text = GlobalVariables.DAD_Thirst.ToString();
                    break;
                case "MOM":
                    LBL_Health.Text = GlobalVariables.MOM_Health.ToString();
                    LBL_Happiness.Text = GlobalVariables.MOM_Happiness.ToString();
                    LBL_Thirst.Text = GlobalVariables.MOM_Thirst.ToString();
                    break;
                case "SON":
                    LBL_Health.Text = GlobalVariables.SON_Health.ToString();
                    LBL_Happiness.Text = GlobalVariables.SON_Happiness.ToString();
                    LBL_Thirst.Text = GlobalVariables.SON_Thirst.ToString();
                    break;
                case "DAUGHTER":
                    LBL_Health.Text = GlobalVariables.DAUGHTER_Health.ToString();
                    LBL_Happiness.Text = GlobalVariables.DAUGHTER_Happiness.ToString();
                    LBL_Thirst.Text = GlobalVariables.DAUGHTER_Thirst.ToString();
                    break;
            }
        }

        private void waterDisplayChange()
        {
            LBL_WaterLeft.Text = GlobalVariables.litersLeft.ToString();
        }

        private void waterChange(char c, float amount)
        {
                waterChangeAmount = amount;
                waterChanging = true;
                waterChangeType = c;
                waterChangeTimes = 1 + (int)(waterChangeAmount / 0.10f);
                waterBottleWaterChanges = (int)waterChangeAmount;
        }

        private void TMR2_Tick(object sender, EventArgs e)
        {
            LBL_WaterLeft.Text = GlobalVariables.litersLeft.ToString();
            LBL_LITERSLEFTLABEL.Text = "Liters";
            //LBL_WaterLeft.Location = new Point(445, 877);
            //LBL_LITERSLEFTLABEL.Location = new Point(445, 957);
            if(waterChangeTimes == 0) { waterChanging = false; }
            
            if (waterChangeTimes != 0 && waterChanging && waterChangeType == 'a')
            {
              
                
                if (waterChangeTimes == 1)
                {
                    GlobalVariables.litersLeft += 0.001f;
                }
                GlobalVariables.litersLeft += GlobalVariables.waterIncrementAmount;
                LBL_WaterLeft.Text = string.Format("{0:0.0}", GlobalVariables.litersLeft);
                waterChangeTimes--;

                //WATER BOTTLE ANIMATION
                waterDisplayChange();
                waterBottleWaterChanges--;
                if (PB_Water.Height <= 510 && waterBottleWaterChanges > 0)
                {
                    PB_Water.Height++;
                    PB_Water.Location = new Point(PB_Water.Location.X, PB_Water.Location.Y - 1);
                
                   
                }

            }

            if (waterChangeTimes != 0 && waterChanging && waterChangeType == 'r')
            {
                //if (waterChangeTimes == 1)
                //{
                //    GlobalVariables.litersLeft += 0.001f;
                //}
                //else 
                if (waterChangeTimes == 0)
                {
                    waterChanging = false;
                }
                GlobalVariables.litersLeft -= GlobalVariables.waterIncrementAmount;
                LBL_WaterLeft.Text = string.Format("{0:0.0}", GlobalVariables.litersLeft);
                waterChangeTimes--;

                //WATER BOTTLE ANIMATION

                waterBottleWaterChanges--;
                if (1 <= PB_Water.Height && waterBottleWaterChanges > 0)
                {
                    PB_Water.Height--;
                    PB_Water.Location = new Point(PB_Water.Location.X, PB_Water.Location.Y + 1);
                    //LBL_WaterLeft.Location = new Point(LBL_WaterLeft.Location.X, PB_Water.Location.Y + 1);
                    //LBL_LITERSLEFTLABEL.Location = new Point(LBL_LITERSLEFTLABEL.Location.X, PB_Water.Location.Y + 1);


                }
            }

            if (closing)
            {
                TMR2.Stop();
                if (!waterChanging && closing)
                {

                    if (GlobalVariables.currentDay != 8)
                    {
                        //this.TopMost = true;
                        Form x = new LOCATION_Stiminop();
                        System.Threading.Thread.Sleep(GlobalVariables.FormHideWaitDuration);

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
                    else
                    {
                        //this.TopMost = true;
                        Form x = new WinFormHehe();
                        System.Threading.Thread.Sleep(GlobalVariables.FormHideWaitDuration);

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

                }
                
            }
        }

        private void BTN_Continue_Click(object sender, EventArgs e)
        {
            

            switch(GlobalVariables.difficulty)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                  



                    //location of waterLeft = new Point(litersleftlabel.Location.X, litersLeftlabel.location.Y - 5);

                    //SHOWER INTENSITIES
                    switch (DAD_showerIntensity)
                    {
                        case 0:
                            GlobalVariables.DAD_Happiness -= 5;
                            break;
                        case 1:
                            GlobalVariables.DAD_Happiness -= 3;
                            waterChange('r', 6);
                            break;
                        case 2:
                            GlobalVariables.DAD_Happiness += 0;
                            waterChange('r', 12);
                            break;
                        case 3:
                            GlobalVariables.DAD_Happiness += 1;
                            waterChange('r', 18);
                            break;
                        case 4:
                            GlobalVariables.DAD_Happiness += 3;
                            waterChange('r', 24);
                            break;
                    }

                    switch(MOM_showerIntensity)
                    {
                        case 0:
                            GlobalVariables.MOM_Happiness -= 5;
                            break;
                        case 1:
                            GlobalVariables.MOM_Happiness -= 3;
                            waterChange('r', 6);
                            break;
                        case 2:
                            GlobalVariables.MOM_Happiness += 0;
                            waterChange('r', 12);
                            break;
                        case 3:
                            GlobalVariables.MOM_Happiness += 1;
                            waterChange('r', 18);
                            break;
                        case 4:
                            GlobalVariables.MOM_Happiness += 3;
                            waterChange('r', 24);
                            break;
                    }

                    switch (SON_showerIntensity)
                    {
                        case 0:
                            GlobalVariables.SON_Happiness -= 5;
                            break;
                        case 1:
                            GlobalVariables.SON_Happiness -= 3;
                            waterChange('r', 6);
                            break;
                        case 2:
                            GlobalVariables.SON_Happiness += 0;
                            waterChange('r', 12);
                            break;
                        case 3:
                            GlobalVariables.SON_Happiness += 1;
                            waterChange('r', 18);
                            break;
                        case 4:
                            GlobalVariables.SON_Happiness += 3;
                            waterChange('r', 24);
                            break;
                    }

                    switch (DAUGHTER_showerIntensity)
                    {
                        case 0:
                            GlobalVariables.DAUGHTER_Happiness -= 5;
                            break;
                        case 1:
                            GlobalVariables.DAUGHTER_Happiness -= 3;
                            waterChange('r', 6);
                            break;
                        case 2:
                            GlobalVariables.DAUGHTER_Happiness += 0;
                            waterChange('r', 12);
                            break;
                        case 3:
                            GlobalVariables.DAUGHTER_Happiness += 1;
                            waterChange('r', 18);
                            break;
                        case 4:
                            GlobalVariables.DAUGHTER_Happiness += 3;
                            waterChange('r', 24);
                            break;
                    }

                    //FLUMSHIN THE TOIMLET
                    if(DAD_flushBathroom)
                    {
                        waterChange('r', 10);
                    }
                    else
                    {
                        GlobalVariables.DAD_Happiness -= 3;
                    }

                    if (MOM_flushBathroom)
                    {
                        waterChange('r', 10);
                    }
                    else
                    {
                        GlobalVariables.MOM_Happiness -= 3;
                    }

                    if (SON_flushBathroom)
                    {
                        waterChange('r', 10);
                    }
                    else
                    {
                        GlobalVariables.SON_Happiness -= 3;
                    }

                    if (DAUGHTER_flushBathroom)
                    {
                        waterChange('r', 10);
                    }
                    else
                    {
                        GlobalVariables.DAUGHTER_Happiness -= 3;
                    }

                    //BRUMSHIN
                    switch(DAD_timesToBrush)
                    {
                        case 0:
                            GlobalVariables.DAD_Happiness -= 3;
                            GlobalVariables.DAD_Health -= 1;
                            break;
                        case 1:
                            GlobalVariables.litersLeft -= .5f;
                            break;
                        case 2:
                            GlobalVariables.litersLeft -= 1;
                            break;
                        case 3:
                            GlobalVariables.litersLeft -= 1.5f;
                            break;
                    }

                    switch (MOM_timesToBrush)
                    {
                        case 0:
                            GlobalVariables.MOM_Happiness -= 3;
                            GlobalVariables.MOM_Health -= 1;
                            break;
                        case 1:
                            GlobalVariables.litersLeft -= .5f;
                            break;
                        case 2:
                            GlobalVariables.litersLeft -= 1;
                            break;
                        case 3:
                            GlobalVariables.litersLeft -= 1.5f;
                            break;
                    }

                    switch (SON_timesToBrush)
                    {
                        case 0:
                            GlobalVariables.SON_Happiness -= 3;
                            GlobalVariables.SON_Health -= 1;
                            break;
                        case 1:
                            GlobalVariables.litersLeft -= .5f;
                            break;
                        case 2:
                            GlobalVariables.litersLeft -= 1;
                            break;
                        case 3:
                            GlobalVariables.litersLeft -= 1.5f;
                            break;
                    }

                    switch (DAUGHTER_timesToBrush)
                    {
                        case 0:
                            GlobalVariables.DAUGHTER_Happiness -= 3;
                            GlobalVariables.DAUGHTER_Health -= 1;
                            break;
                        case 1:
                            GlobalVariables.litersLeft -= .5f;
                            break;
                        case 2:
                            GlobalVariables.litersLeft -= 1;
                            break;
                        case 3:
                            GlobalVariables.litersLeft -= 1.5f;
                            break;
                    }

                    
                    //BOTTLES OF WATER
                    int totalBottles = DAD_bottlesOfWater + MOM_bottlesOfWater + SON_bottlesOfWater + DAUGHTER_bottlesOfWater;
                    float totalLitersCost = totalBottles * .25f;
                    GlobalVariables.litersLeft -= totalLitersCost;

                    GlobalVariables.DAD_Thirst += DAD_bottlesOfWater * 15;
                    GlobalVariables.MOM_Thirst += MOM_bottlesOfWater * 15;
                    GlobalVariables.SON_Thirst += SON_bottlesOfWater * 15;
                    GlobalVariables.DAUGHTER_Thirst += DAUGHTER_bottlesOfWater * 15;

                    if(9 <= DAD_bottlesOfWater)
                    {
                        GlobalVariables.DAD_Health -= 3;
                    }

                    if(9 <= MOM_bottlesOfWater)
                    {
                        GlobalVariables.MOM_Health -= 3;
                    }

                    if(9 <= SON_bottlesOfWater)
                    {
                        GlobalVariables.MOM_Health -= 3;
                    }

                    if(9 <= DAUGHTER_bottlesOfWater)
                    {
                        GlobalVariables.MOM_Health -= 3;
                    }


                    break;
            }
            closing = true;
            
        }

        private void PB_SelectedCharacter_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
