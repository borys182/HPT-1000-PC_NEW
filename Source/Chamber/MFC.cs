using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    public class MFC_Channel : ChamberObject
    {
        private int     id              = 0;                //powiazanie obiketu po stronie PC z obiektem po stronie PLC
        private bool    enabled         = false;            //flaga okresla czy przplywka wchodzi w sklad danej konfiguracji komory 
        private int     actualFlow      = 0;                //wartosc przeplywu wyrazona w sccm
        private string  gasName         = "none";
        private double  factor          = 1;                //okresleneie factora dla danego gazu podpietego do danej przeplywki. Przeplywki
                                                            //sa skalibrowane na jeden gaz i podpiecie innego wymusza ustawienie factora dla poprawnych przeliczen przeplywu
        //zmienne konfigurujace przeplywke
        private int     rangeVoltage = 10000;           //okreslenie zakresu napieciowego pracy przeplywki
        private int     maxFlow_sccm = 10000;           //okreslenie max przeplywu przeplywki wyrazonego w jednostkach sccm

        //-----------------------------------------------------------------------------------------
        public MFC_Channel(int aID)
        {
            id = aID;
        }
        //-----------------------------------------------------------------------------------------
        public int GetID()
        {
            return id;
        }
        //-----------------------------------------------------------------------------------------
        public override void UpdateData(int[] aData)
        {
            int aAddr = 0;

            if (aData.Length > Types.OFFSET_ACTUAL_FLOW_1 && aData.Length > Types.OFFSET_ACTUAL_FLOW_2 && aData.Length > Types.OFFSET_ACTUAL_FLOW_3)
            {
                if (id == 1) aAddr = Types.OFFSET_ACTUAL_FLOW_1;
                if (id == 2) aAddr = Types.OFFSET_ACTUAL_FLOW_2;
                if (id == 3) aAddr = Types.OFFSET_ACTUAL_FLOW_3;

                if(aData.Length > aAddr)
                    actualFlow = aData[aAddr];
            }
        }
        //-----------------------------------------------------------------------------------------
        //Odczytaj ustawienia MFC z PLC
        public override void UpdateSettingsData(int[] aData)
        {
            int aAddrRangeFlow = 0;
            int aAddrRangeVoltage = 0;

            if (id == 1)
            {
                aAddrRangeFlow      = Types.OFFSET_RANGE_FLOW_MFC1;
                aAddrRangeVoltage   = Types.OFFSET_RANGE_VOLTAGE_MFC1;
            }
            if (id == 2)
            {
                aAddrRangeFlow      = Types.OFFSET_RANGE_FLOW_MFC2;
                aAddrRangeVoltage   = Types.OFFSET_RANGE_VOLTAGE_MFC2;
            }
            if (id == 3)
            {
                aAddrRangeFlow      = Types.OFFSET_RANGE_FLOW_MFC3;
                aAddrRangeVoltage   = Types.OFFSET_RANGE_VOLTAGE_MFC3;
            }

            if (aData.Length > aAddrRangeFlow && aData.Length > aAddrRangeVoltage)
            {
                rangeVoltage = aData[aAddrRangeVoltage];
                maxFlow_sccm = aData[aAddrRangeFlow];
            }
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja umozliwia ustawianie dango przeplwyu na przeplywce
        public ERROR SetFlow( double aValue, Types.UnitFlow aUnit)
        {
            ERROR aErr = new ERROR(0,0);

            int aValueSCCM = 0;
            //przlicz wartosc podana w danych jednostach na napiecie
            switch (aUnit)
            {
                case Types.UnitFlow.percent:
                    aValueSCCM = (int)(aValue / 100 * maxFlow_sccm) ;
                    break;
                case Types.UnitFlow.sccm:
                    aValueSCCM = (int)aValue;
                    break;
            }
            string aAddr = "";
            if(controlMode == Types.ControlMode.Automatic)
            {
                if (id == 1) aAddr = Types.ADDR_CONTROL_PROGRAM + Types.OFFSET_SEQ_FLOW_1_FLOW;
                if (id == 2) aAddr = Types.ADDR_CONTROL_PROGRAM + Types.OFFSET_SEQ_FLOW_2_FLOW;
                if (id == 3) aAddr = Types.ADDR_CONTROL_PROGRAM + Types.OFFSET_SEQ_FLOW_3_FLOW;
            }
            if (controlMode == Types.ControlMode.Manual)
            {
                if (id == 1) aAddr = Types.ADDR_FLOW_1_CTR;
                if (id == 2) aAddr = Types.ADDR_FLOW_2_CTR;
                if (id == 3) aAddr = Types.ADDR_FLOW_3_CTR;
            }

            if (aAddr.Length > 0)
            {
                int[] aData = new int[1];
                aData[0] = aValueSCCM;
                if (plc != null)
                    aErr.ErrorCodePLC = plc.WriteWords(aAddr,1, aData);
                else
                    aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;
            }
            else
                aErr.ErrorCode = Types.ERROR_CODE.BAD_FLOW_ID;

            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        public double GetActualFlow(Types.UnitFlow aUnit)
        {
            double aFlow = 0;
            switch (aUnit)
            {
                case Types.UnitFlow.sccm:
                    aFlow = actualFlow;
                    break;
                case Types.UnitFlow.percent:
                    if(maxFlow_sccm > 0)
                        aFlow = actualFlow / maxFlow_sccm * 100;
                    break;
            }
            return aFlow;
        }
        //-----------------------------------------------------------------------------------------
        public void SetActive(bool aState)
        {
            enabled = aState;
        }
        //-----------------------------------------------------------------------------------------
        public bool GetActive()
        {
            return enabled;
        }
        //-----------------------------------------------------------------------------------------
        public int GetMaxFlow()
        {
            return maxFlow_sccm;
        }
        //-----------------------------------------------------------------------------------------
        public int GeRangeVoltage()
        {
            return rangeVoltage;
        }
        //-----------------------------------------------------------------------------------------
        //Ustaw max przeplyw jaki jest mozliwy do ustawienia dla danej przeplywki [sccm]
        public ERROR SetMaxFlow(int aValue)
        {
            ERROR   aErr = new ERROR(0, 0);
            int[]   aData = new int[1];
            int     aAddr = 0;

            if (id == 1) aAddr = Types.OFFSET_RANGE_FLOW_MFC1;
            if (id == 2) aAddr = Types.OFFSET_RANGE_FLOW_MFC2;
            if (id == 3) aAddr = Types.OFFSET_RANGE_FLOW_MFC3;

            aData[0] = aValue;
            if (plc != null)
                aErr.ErrorCodePLC = plc.WriteWords(Types.GetAddress(Types.AddressSpace.Settings, aAddr), 1, aData);
            else
                aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            return aErr;
        }
        //------------------------------------------------------------------------------------------- 
        //Ustaw wartosc max napieica sterujacego dana przeplywka [mV]
        public ERROR SetRangeVoltage(int aValue)
        {
            ERROR aErr = new ERROR(0, 0);
            int[] aData = new int[1];
            int aAddr = 0;

            if (id == 1) aAddr = Types.OFFSET_RANGE_VOLTAGE_MFC1;
            if (id == 2) aAddr = Types.OFFSET_RANGE_VOLTAGE_MFC2;
            if (id == 3) aAddr = Types.OFFSET_RANGE_VOLTAGE_MFC3;

            aData[0] = aValue;
            if (plc != null)
                aErr.ErrorCodePLC = plc.WriteWords(Types.GetAddress(Types.AddressSpace.Settings, aAddr), 1, aData);
            else
                aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            return aErr;
        }
        //------------------------------------------------------------------------------------------- 
    }
    //-----------------------------------------------------------------------------------------
    //------------------------------------MFC-------------------------------------------------
    //-----------------------------------------------------------------------------------------

    public class MFC : ChamberObject
    {
        private List<MFC_Channel>   flowMeters          = new List<MFC_Channel>();

        private int                 timeFlowStability   = 30; //czas oczekiwania na stablizicacje przeplywu po ustawineiu setpointa

        //-----------------------------------------------------------------------------------------
        public int TimeFlowStability
        {
            get { return timeFlowStability; }
        }
        //-----------------------------------------------------------------------------------------
        public MFC()
        {
            flowMeters.Add(new MFC_Channel(1));
            flowMeters.Add(new MFC_Channel(2));
            flowMeters.Add(new MFC_Channel(3));
        }
        //-----------------------------------------------------------------------------------------
        private MFC_Channel GetMFC_Channel(int aId)
        {
            MFC_Channel mfc = null;
            foreach(MFC_Channel mfc_Channel in flowMeters)
            {
                if (mfc_Channel.GetID() == aId)
                    mfc = mfc_Channel;
            }
            return mfc;
        }
        //-----------------------------------------------------------------------------------------
        //Ustwa aktualny przeplyw dla wszystkich przeplywek
        override public void UpdateData(int[] aData)
        {
            //z PLC dostaje DWORD ktorego nalezy przekonwertowac na double
            foreach(MFC_Channel mfc in flowMeters)
            {
                if (mfc != null)
                    mfc.UpdateData(aData);
            }
        }
        //-----------------------------------------------------------------------------------------
        public override void UpdateSettingsData(int[] aData)
        {
            if (aData.Length > Types.OFFSET_TIME_FLOW_STABILITY)
            {
                timeFlowStability = aData[Types.OFFSET_TIME_FLOW_STABILITY];             
            }

            foreach (MFC_Channel mfc in flowMeters)
            {
                if (mfc != null)
                    mfc.UpdateSettingsData(aData);
            }
            base.UpdateSettingsData(aData);
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja umozliwia ustawianie dango przeplwyu na przeplywce
        public ERROR SetFlow(int aId , float aValue , Types.UnitFlow aUnit)
        {
            ERROR aErr = new ERROR(0,0);

            MFC_Channel mfc_Channel = GetMFC_Channel(aId);

            if (mfc_Channel != null)
                aErr = mfc_Channel.SetFlow(aValue, aUnit);
               
            return aErr;
        }
        //-----------------------------------------------------------------------------------------
        public double GetActualFlow(int aId , Types.UnitFlow aUnit)
        {
            double      actualFlow      = 0;
            MFC_Channel mfc_Channel     = GetMFC_Channel(aId);

            if(mfc_Channel != null)
                actualFlow = mfc_Channel.GetActualFlow(aUnit);

            return actualFlow;
        }
        //-----------------------------------------------------------------------------------------
        public void SetActive(int aId, bool aState)
        {
            MFC_Channel mfc_Channel = GetMFC_Channel(aId);

            if (mfc_Channel != null)
                mfc_Channel.SetActive(aState);
        }
        //-----------------------------------------------------------------------------------------
        public bool GetActive(int aId)
        {
            bool aEnabled = false;
            MFC_Channel mfc_Channel = GetMFC_Channel(aId);

            if (mfc_Channel != null)
                aEnabled = mfc_Channel.GetActive();

            return aEnabled;
        }
        //-----------------------------------------------------------------------------------------
        public double GetMaxFlow(int aId)
        {
            double aMaxFlow = 0;
            MFC_Channel mfc_Channel = GetMFC_Channel(aId);

            if (mfc_Channel != null)
                aMaxFlow = mfc_Channel.GetMaxFlow();

            return aMaxFlow;
        }
        //-----------------------------------------------------------------------------------------
        public double GetRangeVoltage(int aId)
        {
            double aRangeVoltage = 0;
            MFC_Channel mfc_Channel = GetMFC_Channel(aId);

            if (mfc_Channel != null)
                aRangeVoltage = mfc_Channel.GeRangeVoltage();

            return aRangeVoltage;
        }
        //-----------------------------------------------------------------------------------------
        public void SetMaxFlow(int aId,int aMaxFlow)
        {
            MFC_Channel mfc_Channel = GetMFC_Channel(aId);

            if (mfc_Channel != null)
                mfc_Channel.SetMaxFlow(aMaxFlow);
        }
        //-----------------------------------------------------------------------------------------
        public void SetRangeVoltage(int aId, int aRangeVoltage)
        {
            MFC_Channel mfc_Channel = GetMFC_Channel(aId);

            if (mfc_Channel != null)
                mfc_Channel.SetRangeVoltage(aRangeVoltage);
        }
        //-----------------------------------------------------------------------------------------
        public override void SetPonterPLC(PLC ptrPLC)
        {
            plc = ptrPLC;
            foreach (MFC_Channel mfc in flowMeters)
            {
                if (mfc != null)
                    mfc.SetPonterPLC(ptrPLC);
            }
        }
        //-----------------------------------------------------------------------------------------
        //Ustaw czas oczekiwania na stabilizacje sie wartosc przeplywu poiedzy zadanymi widelkami programu
        public ERROR SetTimeFlowStability(int aValue)
        {
            ERROR aErr = new ERROR(0, 0);
            int[] aData = new int[1];

            aData[0] = aValue;
            if (plc != null)
                aErr.ErrorCodePLC = plc.WriteWords(Types.GetAddress(Types.AddressSpace.Settings, Types.OFFSET_TIME_FLOW_STABILITY), 1, aData);
            else
                aErr.ErrorCode = Types.ERROR_CODE.PLC_PTR_NULL;

            return aErr;
        }
        //------------------------------------------------------------------------------------------- 
    }
}
  
