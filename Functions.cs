using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life_Without_Water__PBL_
{
    class Functions
    {
        public void newDay()
        {
            GlobalVariables.DAD_Thirst -= 30;
            GlobalVariables.MOM_Thirst -= 30;
            GlobalVariables.SON_Thirst -= 30;
            GlobalVariables.DAUGHTER_Thirst -= 30;
        }
    }
}
