using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source.Driver;
namespace HPT1000.Source
{
    //Klasa służy do logowania wszystkich bledow wystepjacych w programie i zbierania ich w jednym miejscu
    class Logger
    {
        public static void AddError(ERROR aErr)
        {
            if(aErr.ErrorCode == Types.ERROR_CODE.NO_PRG_IN_PLC)
            {
                MessageBox.Show(Translate.GetText("PLC not have any program", Language.EN), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
