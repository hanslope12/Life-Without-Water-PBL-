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
    public partial class LOCATION_Stiminop : Form
    {
        //WRITING VARIABLES
        string labelText = "";
        int writingSceneCounter = 0;
        bool writingScene = false;

        int sceneNLBCounter = 0;
        bool writingSceneNLB = false;

        string disclaimerText = "";
        int writingDisclaimerCounter = 0;
        bool writingDisclaimer = false;
        bool disclaimerShowing = false;

        //CHANGING DATA
        bool waterChanging = false;
        float waterChangeAmount = 0.00f;
        char waterChangeType = 'a';
        int waterChangeTimes = 0;
        int waterBottleWaterChanges = 0;

        bool moneyChanging = false;
        float moneyChangeAmount = 0f;
        char moneyChangeType = 'a';

        //GENERAL VARIABLES
        int chosenCharacter = 1; //1dad2mom3son4daughter
        string currentSceneBranch;
        Random rnd = new Random();

        //SCENE VARBOS
        bool SantosFreeWaterAsked = false;
        bool SantosFreeWaterObtained = false;
        public LOCATION_Stiminop()
        {
            InitializeComponent();

            //AESTHETIC 
            //Gets actual transparency

            var daysLeftLabelPos = this.PointToScreen(LBL_DaysLeft.Location);
            daysLeftLabelPos = PB_Calendar.PointToClient(daysLeftLabelPos);
            LBL_DaysLeft.Parent = PB_Calendar;
            LBL_DaysLeft.Location = daysLeftLabelPos;

            var actualWaterPos = this.PointToScreen(PB_Water.Location);
            actualWaterPos = PB_WaterBottle.PointToClient(actualWaterPos);
            PB_Water.Parent = PB_WaterBottle;
            PB_Water.Location = actualWaterPos;

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

        private void GameForm_Load(object sender, EventArgs e)
        {
            //FADE IN
            Opacity = 0;
            for (int i = 0; i < 100; i++)
            {
                this.Opacity += 0.01;
                if (this.Opacity == 0.01)
                {
                    System.Threading.Thread.Sleep(500);
                }
                System.Threading.Thread.Sleep(GlobalVariables.fadeInTime);
            }

            //CONTROL MANIPULATION
            alignCenter(PNL_SceneViewer);

            LBL_SceneDescription.MaximumSize = new Size(818, 0);
            LBL_SceneDescription.AutoSize = true;

            TMR.Start();
            TMR2.Start();
            TMR3.Start();

            //LABEL MANIPULATION, INITIALIZE UI
            LBL_MoneyLeft.Text = GlobalVariables.moneyLeft.ToString();
            LBL_WaterLeft.Text = GlobalVariables.litersLeft.ToString();
            LBL_DaysLeft.Text = (7 - GlobalVariables.currentDay).ToString();
            characterDataSheet();
            //scenePic("https://vignette.wikia.nocookie.net/theamazingworldofgumball/images/a/a3/The_Wattersons%27_House.png/revision/latest?cb=20160522032325");
            PB_SceneViewer.SendToBack();

            //DIFFICULTY SETTINGS
            switch (GlobalVariables.difficulty)
            {
                case 2:
                    BTN_SON.Visible = false;
                    BTN_DAUGHTER.Visible = false;
                    break;
                case 1:
                    BTN_MOM.Visible = false;
                    BTN_SON.Visible = false;
                    BTN_DAUGHTER.Visible = false;
                    break;
            }

            switch (GlobalVariables.timeOfDay)
            {
                case 1:
                    LBL_TimeOfDay.Text = "MORNING";
                    break;
                case 2:
                    LBL_TimeOfDay.Text = "AFTERNOON";
                    break;
                case 3:
                    LBL_TimeOfDay.Text = "NIGHT";
                    break;
            }

            
            w("You stand in the center of your living room. Pictures of you and your family fill up the walls, giving your house a slightly " +
                "cozy feeling.");

            BTN_A1.ButtonText = "Go out to Main Street";
            BTN_A2.ButtonText = "Do Some Freelance Work";
            BTN_A3.ButtonText = "Sleep";
            enable(3);
            currentSceneBranch = "HOME - Inside";
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            //EXIT
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.T)
            {
                waterChange('r', 20);
            }
        }

        private void TMR_Tick(object sender, EventArgs e)
        {
            //WRITING SCENE
            if (writingSceneCounter <= labelText.Length && writingScene)
            {
                LBL_SceneDescription.Text = labelText.Substring(0, writingSceneCounter);
                writingSceneCounter++;
            }

            //FINISHED WRITING SCENE
            if (writingSceneCounter > labelText.Length && writingScene)
            {
                writingScene = false;
                writingSceneCounter = 0;
            }

            //WRITING SCENE NLB
            if (sceneNLBCounter <= labelText.Length && writingSceneNLB)
            {
                LBL_SceneDescription.Text = labelText.Substring(0, sceneNLBCounter);
                sceneNLBCounter++;
            }

            //FINISHED WRITING SCENE NLB
            if (sceneNLBCounter > labelText.Length && writingSceneNLB)
            {
                writingSceneNLB = false;
                sceneNLBCounter = 0;
            }

            //WRITING DISCLAIMER
            if (writingDisclaimerCounter <= disclaimerText.Length && writingDisclaimer)
            {
                LBL_Disclaimer.Text = disclaimerText.Substring(0, writingDisclaimerCounter);
                writingDisclaimerCounter++;
            }

            //FINISHED WRITING DISCLAIMER
            if (writingDisclaimerCounter > disclaimerText.Length && writingDisclaimer)
            {
                System.Threading.Thread.Sleep(700);
                LBL_Disclaimer.Visible = false;
                System.Threading.Thread.Sleep(700);
                LBL_Disclaimer.Visible = true;
                System.Threading.Thread.Sleep(700);
                writingDisclaimer = false;
                writingDisclaimerCounter = 0;
                LBL_Disclaimer.Text = "";
            }

        }

        private void TMR2_Tick(object sender, EventArgs e)
        {
            notWriting();

            if (moneyChangeAmount == 0)
            {
                moneyChanging = false;
            }

            if (waterChangeTimes != 0 && waterChanging && waterChangeType == 'a')
            {
                if (waterChangeTimes == 1)
                {
                    GlobalVariables.litersLeft += 0.001f;
                }
                else if (waterChangeTimes == 0)
                {
                    waterChanging = false;
                }
                GlobalVariables.litersLeft += GlobalVariables.waterIncrementAmount;
                LBL_WaterLeft.Text = string.Format("{0:0.0}", GlobalVariables.litersLeft);
                waterChangeTimes--;

                //WATER BOTTLE ANIMATION
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
                    LBL_WaterLeft.Location = new Point(LBL_WaterLeft.Location.X, PB_Water.Location.Y + 1);
                    LBL_LITERSLEFTLABEL.Location = new Point(LBL_LITERSLEFTLABEL.Location.X, PB_Water.Location.Y + 1);
                }

            }

            //MONEY CHANGING
            if (moneyChangeAmount != 0 && moneyChanging && moneyChangeType == 'a')
            {
                GlobalVariables.moneyLeft++;
                LBL_MoneyLeft.Text = GlobalVariables.moneyLeft.ToString();
                moneyChangeAmount--;
            }

            if (moneyChangeAmount != 0 && moneyChanging && moneyChangeType == 'r')
            {
                GlobalVariables.moneyLeft--;
                LBL_MoneyLeft.Text = GlobalVariables.moneyLeft.ToString();
                moneyChangeAmount--;
            }
        }

        private void TMR3_Tick(object sender, EventArgs e)
        {
            if (disclaimerShowing)
            {
                LBL_Disclaimer.Visible = true;
                disclaimerShowing = false;
            }
            else
            {
                LBL_Disclaimer.Visible = false;
                disclaimerShowing = true;
            }
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        //FUNCTIONS
        private void alignCenter(Control ctrl)
        {
            ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
        }

        private void w(string text)
        {
            writingScene = false;
            writingSceneCounter = 0;

            LBL_SceneDescription.Text = "";
            labelText = text;
            writingScene = true;
        }

        private void wNLB(string text)
        {
            sceneNLBCounter = LBL_SceneDescription.Text.Length;
            labelText = LBL_SceneDescription.Text + text;
            writingSceneNLB = true;
        }

        private bool notWriting()
        {

            if (writingScene == false && writingSceneNLB == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void en(Control ctrl)
        {
            ctrl.Visible = true;
        }

        private void enable(int numberToEnable)
        {
            switch(numberToEnable)
            {
                case 9:
                    en(BTN_C3);
                    goto case 8;
                case 8:
                    en(BTN_C2);
                    goto case 7;
                case 7:
                    en(BTN_C1);
                    goto case 6;
                case 6:
                    en(BTN_B3);
                    goto case 5;
                case 5:
                    en(BTN_B2);
                    goto case 4;
                case 4:
                    en(BTN_B1);
                    goto case 3;
                case 3:
                    en(BTN_A3);
                    goto case 2;
                case 2:
                    en(BTN_A2);
                    goto case 1;
                case 1:
                    en(BTN_A1);
                    break;
            }
        }

        private void dis(Control ctrl)
        {
            ctrl.Visible = false;
        }

        private void disclaimerWrite(string text)
        {
            disclaimerText = text;
            writingDisclaimer = true;
        }

        private void waterDisplayChange()
        {
            LBL_WaterLeft.Text = GlobalVariables.litersLeft.ToString();
        }

        private bool waterChange(char c, float amount)
        {
            if (amount <= GlobalVariables.litersLeft)
            {
                waterChangeAmount = amount;
                waterChanging = true;
                waterChangeType = c;
                waterChangeTimes = 1 + (int)(waterChangeAmount / 0.10f);
                waterBottleWaterChanges = (int)waterChangeAmount;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool moneyChange(char c, int amount)    //PUN INTENDED
        {
            if (amount <= GlobalVariables.moneyLeft)
            {
                moneyChangeAmount = amount;
                moneyChanging = true;
                moneyChangeType = c;

                return true;
            }
            else
            {
                return false;
            }

        }

        private bool timePasses(int times)
        {
            if (GlobalVariables.timeOfDay != 3)
            {
                while (times != 0)
                {
                    GlobalVariables.timeOfDay++;
                    times--;
                    switch(GlobalVariables.timeOfDay)
                    {
                        case 1:
                            LBL_TimeOfDay.Text = "MORNING";
                            break;
                        case 2:
                            LBL_TimeOfDay.Text = "AFTERNOON";
                            break;
                        case 3:
                            LBL_TimeOfDay.Text = "NIGHT";
                            break;
                    }
                    
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void characterDataSheet()
        {
            switch (chosenCharacter)
            {
                case 1:
                    LBL_Health.Text = GlobalVariables.DAD_Health.ToString();
                    LBL_Happiness.Text = GlobalVariables.DAD_Happiness.ToString();
                    LBL_Thirst.Text = GlobalVariables.DAD_Thirst.ToString();

                    break;
                case 2:
                    LBL_Health.Text = GlobalVariables.MOM_Health.ToString();
                    LBL_Happiness.Text = GlobalVariables.MOM_Happiness.ToString();
                    LBL_Thirst.Text = GlobalVariables.MOM_Thirst.ToString();
                    break;
                case 3:
                    LBL_Health.Text = GlobalVariables.SON_Health.ToString();
                    LBL_Happiness.Text = GlobalVariables.SON_Happiness.ToString();
                    LBL_Thirst.Text = GlobalVariables.SON_Thirst.ToString();
                    break;
                case 4:
                    LBL_Health.Text = GlobalVariables.DAUGHTER_Health.ToString();
                    LBL_Happiness.Text = GlobalVariables.DAUGHTER_Happiness.ToString();
                    LBL_Thirst.Text = GlobalVariables.DAUGHTER_Thirst.ToString();
                    break;
            }
        }

        private void changeStat(string stat, string character, char type, int amount)
        {
            switch (type)
            {
                case 'a':
                    switch (stat)
                    {
                        case "Health":
                            switch (character)
                            {
                                case "DAD":
                                    GlobalVariables.DAD_Health += amount;
                                    break;
                                case "MOM":
                                    GlobalVariables.MOM_Health += amount;
                                    break;
                                case "SON":
                                    GlobalVariables.SON_Health += amount;
                                    break;
                                case "DAUGHTER":
                                    GlobalVariables.DAUGHTER_Health += amount;
                                    break;
                            }
                            break;
                        case "Happiness":
                            switch (character)
                            {
                                case "DAD":
                                    GlobalVariables.DAD_Happiness += amount;
                                    break;
                                case "MOM":
                                    GlobalVariables.MOM_Happiness += amount;
                                    break;
                                case "SON":
                                    GlobalVariables.SON_Happiness += amount;
                                    break;
                                case "DAUGHTER":
                                    GlobalVariables.DAUGHTER_Happiness += amount;
                                    break;
                            }
                            break;
                        case "Thirst":
                            switch (character)
                            {
                                case "DAD":
                                    GlobalVariables.DAD_Thirst += amount;
                                    break;
                                case "MOM":
                                    GlobalVariables.MOM_Thirst += amount;
                                    break;
                                case "SON":
                                    GlobalVariables.SON_Thirst += amount;
                                    break;
                                case "DAUGHTER":
                                    GlobalVariables.DAUGHTER_Thirst += amount;
                                    break;
                            }
                            break;
                    }
                    break;

                case 'r':
                    switch (stat)
                    {
                        case "Health":
                            switch (character)
                            {
                                case "DAD":
                                    GlobalVariables.DAD_Health -= amount;
                                    break;
                                case "MOM":
                                    GlobalVariables.MOM_Health -= amount;
                                    break;
                                case "SON":
                                    GlobalVariables.SON_Health -= amount;
                                    break;
                                case "DAUGHTER":
                                    GlobalVariables.DAUGHTER_Health -= amount;
                                    break;
                            }
                            break;
                        case "Happiness":
                            switch (character)
                            {
                                case "DAD":
                                    GlobalVariables.DAD_Happiness -= amount;
                                    break;
                                case "MOM":
                                    GlobalVariables.MOM_Happiness -= amount;
                                    break;
                                case "SON":
                                    GlobalVariables.SON_Happiness -= amount;
                                    break;
                                case "DAUGHTER":
                                    GlobalVariables.DAUGHTER_Happiness -= amount;
                                    break;
                            }
                            break;
                        case "Thirst":
                            switch (character)
                            {
                                case "DAD":
                                    GlobalVariables.DAD_Thirst -= amount;
                                    break;
                                case "MOM":
                                    GlobalVariables.MOM_Thirst -= amount;
                                    break;
                                case "SON":
                                    GlobalVariables.SON_Thirst -= amount;
                                    break;
                                case "DAUGHTER":
                                    GlobalVariables.DAUGHTER_Thirst -= amount;
                                    break;
                            }
                            break;
                    }
                    break;
            }
            characterDataSheet();   //Make sure character data sheet is updated
        }

        private void disAll()
        {
            dis(BTN_A1);
            dis(BTN_A2);
            dis(BTN_A3);
            dis(BTN_B1);
            dis(BTN_B2);
            dis(BTN_B3);
            dis(BTN_C1);
            dis(BTN_C2);
            dis(BTN_C3);
        }

        //CHARACTER BUTTONS

        private void BTN_DAD_Click(object sender, EventArgs e)
        {
            chosenCharacter = 1;
            characterDataSheet();
            BTN_DAD.Image = Properties.Resources.HEAD_DAD_INVERTED;
            BTN_MOM.Image = Properties.Resources.HEAD_MOM;
            BTN_SON.Image = Properties.Resources.HEAD_SON;
            BTN_DAUGHTER.Image = Properties.Resources.HEAD_DAUGHTER;
        }
        private void BTN_MOM_Click(object sender, EventArgs e)
        {
            chosenCharacter = 2;
            characterDataSheet();
            BTN_DAD.Image = Properties.Resources.HEAD_DAD;
            BTN_MOM.Image = Properties.Resources.HEAD_MOM_INVERTED;
            BTN_SON.Image = Properties.Resources.HEAD_SON;
            BTN_DAUGHTER.Image = Properties.Resources.HEAD_DAUGHTER;
        }
        private void BTN_SON_Click(object sender, EventArgs e)
        {
            chosenCharacter = 3;
            characterDataSheet();
            BTN_DAD.Image = Properties.Resources.HEAD_DAD;
            BTN_MOM.Image = Properties.Resources.HEAD_MOM;
            BTN_SON.Image = Properties.Resources.HEAD_SON_INVERTED;
            BTN_DAUGHTER.Image = Properties.Resources.HEAD_DAUGHTER;
        }
        private void BTN_DAUGHTER_Click(object sender, EventArgs e)
        {
            chosenCharacter = 4;
            characterDataSheet();
            BTN_DAD.Image = Properties.Resources.HEAD_DAD;
            BTN_MOM.Image = Properties.Resources.HEAD_MOM;
            BTN_SON.Image = Properties.Resources.HEAD_SON;
            BTN_DAUGHTER.Image = Properties.Resources.HEAD_DAUGHTER_INVERTED;
        }



        //SETTINGS BUTTONS
        private void BTN_Donate_Click(object sender, EventArgs e)
        {
            /*Form x = TitleScreenForm.Donate;
            x.ShowDialog();*/
        }

        private void BTN_About_Click(object sender, EventArgs e)
        {
            Form x = TitleScreenForm.About;
            x.ShowDialog();
        }

        private void BTN_MainMenu_Click(object sender, EventArgs e)
        {
            //EXIT PROMPT
            if (MessageBox.Show("Are you sure you want to return to the Main Menu? All your progress will be lost.", "Life Without Water", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Form x = new MainMenuForm();
                this.Close();
                x.Show();
            }
        }

        private void BTN_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //STORY FUNCTIONS

        //STORY BUTTONS

        private void BTN_A1_Click(object sender, EventArgs e)
        {
            
            switch (currentSceneBranch)
            {
                case "HOME - Living Room":
                    PB_SceneViewer.Image = Properties.Resources.gumball;
                    w("You stand in the center of your living room. Pictures of you and your family fill up the walls, giving your house a slightly " +
                "cozy feeling.");

                    BTN_A1.ButtonText = "Go out to Main Street";
                    BTN_A2.ButtonText = "Do Some Freelance Work";
                    BTN_A3.ButtonText = "Sleep";
                    enable(3);
                    currentSceneBranch = "HOME - Inside";
                    break;

                case "HOME - Inside":
                    disAll();
                    PB_SceneViewer.Image = Properties.Resources.gumball;
                    w("You step out onto the Main Street. You see the houses of your neighbors and the Stiminop.");
                    BTN_A1.ButtonText = "Look Around";
                    enable(1);
                    currentSceneBranch = "Main Street";
                    break;

                case "WORK - Yes or No":
                    disAll();
                    if(timePasses(1))
                    {
                        w("You work on the computer for around a third of the day. +50 PESOS, TIME HAS PASSED.");
                        timePasses(1);
                        moneyChange('a', 50);
                        BTN_A1.ButtonText = "Work More";
                        BTN_A2.ButtonText = "Go back to the Living Room";
                        enable(2);
                        currentSceneBranch = "WORKING";
                    }
                    else
                    {
                        disAll();
                        w("You can't work at night!");
                        BTN_A1.ButtonText = "Continue";
                        enable(1);
                        currentSceneBranch = "HOME - Living Room";
                    }
                    break;
                case "WORKING":
                    disAll();
                    w("You decide to work some more.");
                    BTN_A1.ButtonText = "Continue";
                    enable(1);
                    currentSceneBranch = "WORK - Yes or No";
                    break;

                case "SLEEP - Yes or No":
                    if(GlobalVariables.currentDay != 7)
                    {
                        Form x = new DailyHomeDistributionForm();
                        x.Show();
                        this.Close();
                        break;
                    }
                    else
                    {
                        Form x = new WinFormHehe();
                        x.Show();
                        this.Close();
                        break;
                    }
                    break;


                case "Main Street":
                    PB_SceneViewer.Image = Properties.Resources.gumball;
                    disAll();
                    w("You stand on the sidewalk in front of your house. There's nothing much to see except for the houses of your " +
                        "three neighbors and the Stiminop.");
                    BTN_A1.ButtonText = "Visit The Santos Household";
                    BTN_A2.ButtonText = "Visit The Rizal Household [NOT FULLY IMPLEMENTED]";
                    BTN_A3.ButtonText = "Visit The Mirales Household [NOT FULLY IMPLEMENTED]";
                    BTN_B1.ButtonText = "Visit The Stiminop";
                    BTN_B2.ButtonText = "Go Home";
                    enable(5);
                    currentSceneBranch = "Main Street - Selecting Location";

                    break;

                case "Main Street - Selecting Location":
                    disAll();
                    //scenePic("https://www.windowworldstlouis.com/wp-content/uploads/2019/04/Wincore-Entry-Door.png");
                    w("As you approach the Santos household, you start to hear the faint sounds of singing and a string instrument from inside" +
                        " the household. The Santos household. What do you do now?");

                    BTN_A1.ButtonText = "Ask them for spare water";
                    BTN_A2.ButtonText = "Go back to the street";
                    currentSceneBranch = "Santos Household - Front Door";

                    en(BTN_A1);
                    en(BTN_A2);
                    break;


                case "Santos Household - Front Door":
                    PB_SceneViewer.Image = Properties.Resources.neighbor;
                    disAll();
                    w("After you knock on the front door, the music dies down. The door opens and you see the son of the Santos household, Steven " +
                        "Santos, staring up at you. You ask if you can get some water.");

                    System.Threading.Thread.Sleep(100);
                    if (SantosFreeWaterAsked)
                    {
                        if (SantosFreeWaterObtained)
                        {
                            wNLB("Steven apologizes, saying that they have no more water to give.");

                            BTN_A1.ButtonText = "Go Back To Main Street";
                            currentSceneBranch = "Main Street";

                            en(BTN_A1);
                        }
                        else
                        {
                            wNLB("Steven apologizes, saying that they still have no water to give.");

                            BTN_A1.ButtonText = "Go Back To Main Street";
                            currentSceneBranch = "Main Street";

                            en(BTN_A1);
                        }
                    }
                    else
                    {
                        SantosFreeWaterAsked = true;
                        int diceRoll = rnd.Next(1, 101);
                        if (diceRoll <= 95)  //Get water 95% chance
                        {
                            SantosFreeWaterObtained = true;
                            wNLB("Steven gives you some water and you thank him profusely.");
                            waterChange('a', 1);

                            BTN_A1.ButtonText = "Go Back To Main Street";
                            currentSceneBranch = "Main Street";

                            en(BTN_A1);
                        }
                        else
                        {
                            SantosFreeWaterObtained = false;
                            wNLB("Steven tells you that they sadly don't have any water to give.");

                            BTN_A1.ButtonText = "Go Back To Main Street";
                            currentSceneBranch = "Main Street";

                            en(BTN_A1);
                        }
                    }


                    break;

                case "Rizal Household - Front Door":
                    PB_SceneViewer.Image = Properties.Resources.neighbor;
                    w("You knock on the front door, and you hear the pitter patter of footsteps approaching. After a few seconds, the door opens " +
                        "and a small girl that looks to be a gradeschooler stares up at you. Hi im Josie! After a few seconds, a lanky man steps" +
                        "in front of the small girl. This man is the father of the Rizal Household. What do you do? ");
                    break;

                case "Mirales Household - Front Door":
                    PB_SceneViewer.Image = Properties.Resources.neighbor;
                    w("Mirales");
                    break;











                case "Stiminop - Entrance":
                    disAll();
                    PB_SceneViewer.Image = Properties.Resources.Stiminop;
                    w("It only takes you a bit of walking to reach the Stiminop. The fact that the convenience store is so luckily " +
                        "placed near your house helps a lot in a pinch. As you peek in through the glass door of the Stiminop, you " +
                        "can see that there aren't that many people shopping around. Surprising since you expected a bit of a crowd, " +
                        "water shortage and all. You are now standing outside the Stiminop.");
                    BTN_A1.ButtonText = "Enter The Stiminop";
                    enable(1);
                    currentSceneBranch = "Stiminop - Cashier";
                    break;

                case "Stiminop - Cashier":
                    disAll();
                    w("As you step in, you see a rather bored looking teenager behind the counter, tapping away at his phone. Looking " +
                        "through the store, you spot some things that could help.");
                    BTN_A1.ButtonText = "Check The Bottle Water";
                    BTN_A2.ButtonText = "Check Biggo Water";
                    BTN_A3.ButtonText = "Check Duck-e";
                    BTN_B1.ButtonText = "Check Soda";
                    BTN_B2.ButtonText = "Go Back to Main Street";
                    currentSceneBranch = "Catalogue";
                    enable(5);
                    break;

                case "Catalogue":
                    disAll();
                    w("Plenty of generic looking 250ml bottles of water occupy the shelves of the store. The owner probably thought that " +
                        "more people would buy water from them, seeing as there's a water shortage. According to the label, it costs 15 " +
                        "pesos per bottle.");
                    BTN_A1.ButtonText = "Buy the Bottle Water";
                    BTN_A2.ButtonText = "Go back";
                    enable(2);
                    currentSceneBranch = "checkingBottledWater";
                    break;

                case "checkingBottledWater":
                    disAll();

                    w("You bring a bottle of water to the cashier and purchase it. You're sure that your family will be glad to see that " +
                        "you bought more fresh water for the household. +.25 LITERS, -15 PESOS, +1 HAPPINESS AND HEALTH TO ALL HOUSEHOLD " +
                        "MEMBERS.");

                    BTN_A1.ButtonText = "Continue Shopping";
                    enable(1);

                    waterChange('a', 0.25f);
                    if (moneyChange('r', 15))
                    {
                        moneyChange('r', 15);
                    }

                    changeStat("Health", "DAD", 'a', 1);
                    changeStat("Happiness", "DAD", 'a', 1);

                    changeStat("Health", "MOM", 'a', 1);
                    changeStat("Happiness", "MOM", 'a', 1);
                    
                    changeStat("Health", "SON", 'a', 1);
                    changeStat("Happiness", "SON", 'a', 1);

                    changeStat("Health", "DAUGHTER", 'a', 1);
                    changeStat("Happiness", "DAUGHTER", 'a', 1);
                    characterDataSheet();

                    currentSceneBranch = "Stiminop - Cashier";
                    break;

                case "checkingBiggoWater":
                    disAll();

                    w("You lug a bottle of the Biggo water to the cashier and purchase it. You're sure that your family will be glad to " +
                        "see that you bought more fresh water for the household.  +.5 LITERS, -39 PESOS, +1 HAPPINESS AND HEALTH TO ALL " +
                        "HOUSEHOLD MEMBERS.");

                    BTN_A1.ButtonText = "Continue Shopping";
                    enable(1);

                    waterChange('a', 0.5f);
                    if (moneyChange('r', 39))
                    {
                        moneyChange('r', 39);
                    }

                    changeStat("Health", "DAD", 'a', 1);
                    changeStat("Happiness", "DAD", 'a', 1);

                    changeStat("Health", "MOM", 'a', 1);
                    changeStat("Happiness", "MOM", 'a', 1);

                    changeStat("Health", "SON", 'a', 1);
                    changeStat("Happiness", "SON", 'a', 1);

                    changeStat("Health", "DAUGHTER", 'a', 1);
                    changeStat("Happiness", "DAUGHTER", 'a', 1);
                    characterDataSheet();

                    currentSceneBranch = "Stiminop - Cashier";
                    break;

                case "checkingDucke":
                    disAll();

                    w("The box of Duck-E is heavier than it looks, but you manage to lug the box over to the cashier and purchase it. " +
                        "Your family might be thrilled at the fact that there's chocolate milk, but you're not entirely sure that that's " +
                        "healthy. +1.5 LITERS, -64 PESOS, +3 HAPPINESS AND -3 HEALTH TO ALL HOUSEHOLD MEMBERS.");

                    BTN_A1.ButtonText = "Continue Shopping";
                    enable(1);

                    waterChange('a', 1.5f);
                    changeStat("Health", "DAD", 'r', 3);
                    changeStat("Happiness", "DAD", 'a', 3);

                    changeStat("Health", "MOM", 'r', 3);
                    changeStat("Happiness", "MOM", 'a', 3);

                    changeStat("Health", "SON", 'r', 3);
                    changeStat("Happiness", "SON", 'a', 3);

                    changeStat("Health", "DAUGHTER", 'r', 3);
                    changeStat("Happiness", "DAUGHTER", 'a', 3);
                    characterDataSheet();

                    if (moneyChange('r', 64))
                    {
                        moneyChange('r', 64);
                    }

                    currentSceneBranch = "Stiminop - Cashier";
                    break;

                case "checkingSoda":
                    disAll();

                    w("You grab a Soda and purchase it. Soda's pretty delicious, but it's definitely not healthy. +.5 LITERS, -30 PESOS" +
                        ", +5 HAPPINESS AND -5 HEALTH TO ALL HOUSEHOLD MEMBERS.");

                    BTN_A1.ButtonText = "Continue Shopping";
                    enable(1);

                    waterChange('a', 0.5f);
                    changeStat("Health", "DAD", 'r', 5);
                    changeStat("Happiness", "DAD", 'a', 5);

                    changeStat("Health", "MOM", 'r', 5);
                    changeStat("Happiness", "MOM", 'a', 5);

                    changeStat("Health", "SON", 'r', 5);
                    changeStat("Happiness", "SON", 'a', 5);

                    changeStat("Health", "DAUGHTER", 'r', 5);
                    changeStat("Happiness", "DAUGHTER", 'a', 5);
                    characterDataSheet();

                    if (moneyChange('r', 30))
                    {
                        moneyChange('r', 30);
                    }

                    currentSceneBranch = "Stiminop - Cashier";
                    break;
            }
        }

        private void BTN_A2_Click(object sender, EventArgs e)
        {
            switch (currentSceneBranch)
            {
                case "HOME - Inside":
                    disAll();
                    w("You sit up with your laptop on the dining table. You think that if you spend around a third of the day working, you could " +
                        "probably get around 50 pesos.");
                    BTN_A1.ButtonText = "Work";
                    BTN_A2.ButtonText = "Go back to the Living Room";
                    currentSceneBranch = "WORK - Yes or No";
                    enable(2);
                    break;

                case "WORKING":
                case "WORK - Yes or No":
                case "SLEEP - Yes or No":
                    disAll();
                    w("You decide to move back to the living room.");
                    BTN_A1.ButtonText = "Continue";
                    enable(1);
                    currentSceneBranch = "HOME - Living Room";
                    break;


                case "Main Street - Selecting Location":
                    disAll();
                    //scenePic("https://steemitimages.com/p/6VvuHGsoU2QD2aHbJiivbVZV6nAA4BJrX2xi1YbtxtVT9x8URReDW4kKrVBfUGBwpHQsNfMrvy3Y8jkETnqo6v36A6MMEVSDXRLNZYL2CGmpp7azo4pi4B9womrbNv?format=match&mode=fit&width=640");
                    w("You walk towards their house. Unlike the Santos household's friendliness and the Mirales household's secretiveness, " +
                        "the Rizal household is rather ordinary. What do you do now?");

                    BTN_A1.ButtonText = "Ask them for spare water";
                    BTN_A2.ButtonText = "Go back to the street";
                    currentSceneBranch = "Rizal Household - Front Door";

                    enable(2);
                    break;

                case "Santos Household - Front Door":
                case "Rizal Household - Front Door":
                case "Mirales Household - Front Door":
                    w("You step back onto the sidewalk.");
                    BTN_A1.ButtonText = "Go Back To Main Street";
                    disAll();
                    enable(1);
                    currentSceneBranch = "Main Street";
                    break;


                case "Catalogue":
                    disAll();
                    w("You walk towards a rather big looking container of water. According to the labels, the 500ml 'BIGGO' water costs 39 Pesos ");
                    BTN_A1.ButtonText = "Buy the BIGGO Water";
                    BTN_A2.ButtonText = "Go back";
                    enable(2);

                    currentSceneBranch = "checkingBiggoWater";
                    break;

                case "checkingBottledWater":
                case "checkingBiggoWater":
                case "checkingDucke":
                case "checkingSoda":
                    disAll();
                    w("You decide to check out the other things in the store.");
                    BTN_A1.ButtonText = "Continue";
                    currentSceneBranch = "Stiminop - Cashier";
                    enable(1);
                    break;
            }
        }

        private void BTN_A3_Click(object sender, EventArgs e)
        {
            switch (currentSceneBranch)
            {
                case "HOME - Inside":
                    disAll();
                    w("You're not much of a light sleeper. Anytime you fall asleep, you find yourself waking up the next day.");

                    BTN_A1.ButtonText = "Sleep Time";
                    BTN_A2.ButtonText = "Go back to the Living Room";
                    enable(2);
                    currentSceneBranch = "SLEEP - Yes or No";
                    break;


                case "Main Street - Selecting Location":
                    disAll();
                    //scenePic("https://www.mrrogerswindows.com/wp-content/uploads/2019/03/Front-door-Jan-22-2019-ED.jpg");
                    w("Walking towards the Mirales household, you feel yourself becoming rather tense. Although the Mirales household has been " +
                        "overall rather cordial, the fact that Mr. Mirales is a police officer still kind of makes you uneasy, even if the only " +
                        "crime you've ever committed was eating a grape from the grocery store once. It also doesn't help that whenever you see " +
                        "their teenage son, he's off hurrying to do God knows what. You finally arrive at the front of their doorstep. What do " +
                        "you do now?");

                    BTN_A1.ButtonText = "Ask them for spare water";
                    BTN_A2.ButtonText = "Go back to the street";
                    currentSceneBranch = "Mirales Household - Front Door";

                    enable(2);
                    break;


                case "Catalogue":
                    disAll();
                    w("You see a box of chocolate milk inside one of the fridges. According to the label, the box of 'Duck-e' packets " +
                        "amounts up to 1500ml and costs 64 Pesos.");
                    BTN_A1.ButtonText = "Buy the Duck-E";
                    BTN_A2.ButtonText = "Go back";
                    enable(2);
                    currentSceneBranch = "checkingDucke";
                    break;
            }
        }

        private void BTN_B1_Click(object sender, EventArgs e)
        {
            switch (currentSceneBranch)
            {
                case "Catalogue":
                    disAll();
                    w("You look at the very back of one of the fridges and spot a few 500ml Sodas left. According to the label, it costs" +
                        "30 pesos per Soda.");
                    BTN_A1.ButtonText = "Buy the Soda";
                    BTN_A2.ButtonText = "Go back";
                    enable(2);
                    currentSceneBranch = "checkingSoda";
                    break;

                case "Main Street - Selecting Location":
                    disAll();
                    w("You make a beeline for the Stiminop");
                    BTN_A1.ButtonText = "Walk to the Stiminop";
                    enable(1);
                    currentSceneBranch = "Stiminop - Entrance";
                    break;
            }
        }

        private void BTN_B2_Click(object sender, EventArgs e)
        {
            switch (currentSceneBranch)
            {
                case "Main Street - Selecting Location":
                    disAll();
                    w("You walk back home.");
                    BTN_A1.ButtonText = "Continue";
                    enable(1);
                    currentSceneBranch = "HOME - Living Room";
                    break;


                case "Catalogue":
                    disAll();
                    w("You decide to walk back to Main Street.");
                    BTN_A1.ButtonText = "Continue";
                    currentSceneBranch = "Main Street";
                    enable(1);
                    break;
            }
        }

        private void BTN_B3_Click(object sender, EventArgs e)
        {

        }

        private void BTN_C1_Click(object sender, EventArgs e)
        {

        }

        private void BTN_C2_Click(object sender, EventArgs e)
        {

        }

        private void BTN_C3_Click(object sender, EventArgs e)
        {

        }


    }
}
