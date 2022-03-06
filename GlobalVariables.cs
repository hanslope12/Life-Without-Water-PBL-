using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_Without_Water__PBL_
{
    class GlobalVariables
    {
        //PROGRAM VARIABLES
        public static int fadeInTime = 1;
        public static int fadeOutTime = 1;
        public static int FormHideWaitDuration = 100;


        /// <summary>
        /// THESE ARE GAME VARIABLES STUPID
        /// </summary>
        /// 

        //GENERAL
        public static int difficulty = 3;


        //WATER
        public static float litersLeft = 510.0f;
        public static float waterIncrementAmount = 0.10f;

        //TIME AND DATE
        public static int currentDay = 0;
        public static int timeOfDay = 1;    //morning, afternoon, night
            

        //MONEY
        public static int moneyLeft = 2000;

        //HEALTH
        public static int DAD_Health = 100;
        public static int MOM_Health = 100;
        public static int SON_Health = 100;
        public static int DAUGHTER_Health = 100;

        //HAPPINESS
        public static int DAD_Happiness = 100;
        public static int MOM_Happiness = 100;
        public static int SON_Happiness = 100;
        public static int DAUGHTER_Happiness = 100;

        //THIRST
        public static int DAD_Thirst = 100;
        public static int MOM_Thirst = 100;
        public static int SON_Thirst = 100;
        public static int DAUGHTER_Thirst = 100;
    }
}
