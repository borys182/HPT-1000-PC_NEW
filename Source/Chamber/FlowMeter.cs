using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    public class FlowMeter : ChamberObject
    {
        private List<FlowMeter> flowMeters = new List<FlowMeter>();
        // Parametry przeplywek
        private int    id = 0;                              //powiazanie obiketu po stronie PC z obiektem po stronie PLC
        private bool   enabled = false;                     //flaga okresla czy przplywka wchodzi w sklad danej konfiguracji komory 
        private double maxFlow = 0;
        private double actualVoltage = 0;                   //wartosc napiecia sterujacego przeplywka
        private string gasName = "none";
        private double factor = 1;                          //okresleneie factora dla danego gazu podpietego do danej przeplywki. Przeplywki
                                                            //sa skalibrowane na jeden gaz i podpiecie innego wymusza ustawienie factora dla poprawnych przeliczen przeplywu
        private Types.UnitFlow unit = Types.UnitFlow.sccm;
        
        //parametry vaporaitora
        private double cycleTime = 0;                       //dla przpleywki typu vaporatior (id = 3) jest to okrelsenie dlugosc trwania cyklu "PWM"
        private double onTime = 0;                          //czas wlaczenia przeplywki w danym cyklu (czas nie moze byc wiekszy niz czas cyklu)

        //pomocnicze zmienne
        private const int rangeVoltage = 10000;           //okreslenie zakresu napieciowego pracy przeplywki
        
        private FlowMeter(int aID)
        {
            id = aID;
            type = Types.TypeObject.FM;
        }
        public FlowMeter()
        {
            flowMeters.Add(new FlowMeter(0));
            flowMeters.Add(new FlowMeter(1));
            flowMeters.Add(new FlowMeter(2));
            flowMeters.Add(new FlowMeter(3));

        }
        //Ustwa aktualny przeplyw dla wszystkich przeplywek
        override public void UpdateData(int[] aData)
        {
            //z PLC dostaje DWORD ktorego nalezy przekonwertowac na double
            flowMeters[0].actualVoltage = Types.ConvertDWORDToDouble(aData, Types.OFFSET_ACTUAL_FLOW_1);
            flowMeters[1].actualVoltage = Types.ConvertDWORDToDouble(aData, Types.OFFSET_ACTUAL_FLOW_2);
            flowMeters[2].actualVoltage = Types.ConvertDWORDToDouble(aData, Types.OFFSET_ACTUAL_FLOW_3);

            flowMeters[3].cycleTime     = Types.ConvertDWORDToDouble(aData, Types.OFFSET_CYCLE_TIME);
            flowMeters[3].onTime        = Types.ConvertDWORDToDouble(aData, Types.OFFSET_ON_TIME);
        }

        //Funkcja umozliwia ustawianie dango przeplwyu na przeplywce
        public int SetFlow(int aId , float aValue , Types.UnitFlow aUnit)
        {
            int iResult = 0;
            double aVoltage = 0; 
            //przlicz wartosc podana w danych jednostach na napiecie
            switch(aUnit)
            {
                case Types.UnitFlow.percent:
                    aVoltage = aValue * rangeVoltage / 100;
                    break;
                case Types.UnitFlow.sccm:
                    //TO DO;
                    break;
            }
            string aAddr = "";
            if (id == 0) aAddr = Types.ADDR_FLOW_1_CTR;
            if (id == 1) aAddr = Types.ADDR_FLOW_1_CTR;
            if (id == 2) aAddr = Types.ADDR_FLOW_1_CTR;

            if (aAddr.Length > 0)
            {
                if (plc != null)
                    iResult = plc.WriteRealData(aAddr, aValue);
                else
                    iResult = Types.ERROR_PLC_PTR_NULL;
            }
            else
                iResult = Types.ERROR_BAD_FLOW_ID;

            return iResult;
        }
        //Funkcja umozliwia ustawienie czasu cyklu dla sterowania zaworem szybkim
        public int SetCycleTime(float aCycleTime)
        {
            int iResult = 0;

            if (plc != null)
            
                iResult = plc.WriteRealData(Types.ADDR_FP_CTRL, aCycleTime); 
            else
                iResult = Types.ERROR_PLC_PTR_NULL;

            return iResult;
        }
        //Funkcja umozliwia ustawienie czasu jak dlugo ma byc wlaczany zawor szybki
        public int SetOnTime(float aOnTime)
        {
            int iResult = 0;

            if (plc != null)

                iResult = plc.WriteRealData(Types.ADDR_FP_CTRL, aOnTime);
            else
                iResult = Types.ERROR_PLC_PTR_NULL;

            return iResult;
        }

        public double GetActualFlow()
        {
            double actualFlow = 0;
            switch(unit)
            {
                case Types.UnitFlow.sccm:
                    //TO DO
                    break;
                case Types.UnitFlow.percent:
                    if (actualVoltage < 0) actualFlow = 0;
                    if (actualVoltage > 10000) actualFlow = 100;
                    if (actualVoltage > 0 && actualVoltage < rangeVoltage)
                    {
                        actualFlow = actualVoltage / rangeVoltage;
                    }

                    
                    break;
            }
            return actualFlow;
        }

        public double GetCycleTime()
        {
            return flowMeters[3].cycleTime;
        }
        public double GetOnTime()
        {
            return flowMeters[3].onTime;
        }

        public void SetUnit(Types.UnitFlow aUnit)
        {
            unit = aUnit;
        }
        public Types.UnitFlow GetUnit()
        {
            return unit;
        }

        public void SetActive(bool aState)
        {
            enabled = aState;
        }
        public bool GetActive()
        {
            return enabled;
        }
    }
}
  
