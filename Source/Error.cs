using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source
{
    /*
     * Klasa reprezentuje akcje w aplikacji
     */
    public class ERROR
    {
        private Types.ERROR_CATEGORY    category     = Types.ERROR_CATEGORY.APLICATION;   // okreslenie kategori bledu
        private Types.ERROR_CODE        code         = 0;                                 // kod bledu
        private int                     extCode      = 0;                                 // dodatkowe informacje na temat bledu (MX Components oraz PLC podaja co sie dokladnie stalo i posiadaja wlasne lsity bledow)
        private DateTime                time         = DateTime.Now;
        private int                     programID    = 0;
        private int                     subprogramID = 0;
        private string                  text         = "";
        private DB                      dataBase = new DB();

        //-----------------------------------------------------------------------------------------
        public ERROR()
        {
        }
        //-----------------------------------------------------------------------------------------
        public ERROR(Types.ERROR_CODE aCode, Types.ERROR_CATEGORY aCategory, int aExtCode)
        {
            category    = aCategory;
            code        = aCode;
            extCode     = aExtCode;
            time        = DateTime.Now;
        }
        //-----------------------------------------------------------------------------------------
        public ERROR(Types.ERROR_CODE aCode, Types.ERROR_CATEGORY aCategory, int aExtCode, DateTime aTime)
        {
            category    = aCategory;
            code        = aCode;
            extCode     = aExtCode;
            time        = aTime;
        }
        //-----------------------------------------------------------------------------------------
        public Types.ERROR_CATEGORY Category
        {            
            get { return category; }
        }
        //-----------------------------------------------------------------------------------------
        public Types.ERROR_CODE Code
        {
            get { return code; }
        }
        //-----------------------------------------------------------------------------------------
        public int ExtCode
        {
            get { return extCode; }
        }
        //-----------------------------------------------------------------------------------------
        public DateTime Time
        {
            get { return time; }
        }
        //-----------------------------------------------------------------------------------------
        public int ProgramID
        {
            get { return programID; }
        }
        //-----------------------------------------------------------------------------------------
        public int SubprogramID
        {
            get { return subprogramID; }
        }//-----------------------------------------------------------------------------------------
        public void SetErrorMXComponents(Types.ERROR_CODE aCode,int aExtCode)
        {
            category = Types.ERROR_CATEGORY.MX_COMPONENTS;
            code     = aCode;
            extCode  = aExtCode;
            time     = DateTime.Now;

            Logger.AddError(this);
        }
        //-----------------------------------------------------------------------------------------
        public void SetErrorApp(Types.ERROR_CODE aCode)
        {
            category = Types.ERROR_CATEGORY.APLICATION;
            code     = aCode;
            extCode  = 0;
            time     = DateTime.Now;

            Logger.AddError(this);
        }
        //-----------------------------------------------------------------------------------------
        public void SetErrorPLC(int aExtCode, DateTime aTime,int aProgramID,int aSubprogramID)
        {
            category     = Types.ERROR_CATEGORY.PLC;
            code         = Types.ERROR_CODE.PLC_ERROR;
            extCode      = aExtCode;
            time         = aTime;
            programID    = aProgramID;
            subprogramID = aSubprogramID;

            Logger.AddError(this);
        }
        //-----------------------------------------------------------------------------------------
        public void SetMessage(string aTxt,Types.MessageType aType)
        {
            text = aTxt;

            if (aType == Types.MessageType.Information)
                extCode = 0;

            if (aType == Types.MessageType.Error)
                extCode = 1;

            category = Types.ERROR_CATEGORY.MESSAGE;
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja zwraca kod bledu. Dla kategori MXComponets oraz PLC kod bledu jest przechowywany w polu ExtCode poniewaz one posiadaja wlasna liste bledow
        public int GetErrorCode()
        {
            int aCode = (int)code;

            if(category == Types.ERROR_CATEGORY.PLC)
                aCode = extCode;

            return aCode;
        }
        //-----------------------------------------------------------------------------------------
        public bool IsError()
        {
            bool aRes = false;

            if ((category == Types.ERROR_CATEGORY.MX_COMPONENTS || category == Types.ERROR_CATEGORY.PLC || category == Types.ERROR_CATEGORY.MESSAGE ) && extCode != 0)
                aRes = true;

            if (category == Types.ERROR_CATEGORY.APLICATION  && code != 0 )
                aRes = true;

            return aRes;
        }
        //-----------------------------------------------------------------------------------------
        public bool IsAction()
        {
            bool aRes = false;

            if ((category == Types.ERROR_CATEGORY.MX_COMPONENTS || category == Types.ERROR_CATEGORY.MESSAGE) && extCode == 0)
                aRes = true;

            return aRes;
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja podaje tekt jaki jest przypisany do danego kodu bledu
        public string GetText()
        {
            string aTxt = "";

            if (category == Types.ERROR_CATEGORY.MESSAGE)
                aTxt = text;
            else
                aTxt = dataBase.GetErrorText(this);

            return aTxt;
        }
        //-----------------------------------------------------------------------------------------
        public override bool Equals(object other)
        {
            bool aRes = false;
            ERROR aOther = (ERROR)other;

            //Porownuje tylko po referencji bo w kilku miejscach sie odnosze do tej samej referencji i cos zmieniam.
            if (other != null && this.GetType() == other.GetType() && code == aOther.Code && category == aOther.Category && extCode == aOther.ExtCode && time == aOther.Time)
                aRes = true;
     
            return aRes;
        //-----------------------------------------------------------------------------------------
        }
    }
}
