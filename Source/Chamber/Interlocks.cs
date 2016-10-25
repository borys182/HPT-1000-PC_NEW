using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    public class Interlock : ChamberObject
    {
        private List<Interlock>     interlocks      = new List<Interlock>();    //lista wszystkich zaworow dostepmna w komorze

        private Types.StateValve    state           = Types.StateValve.Error;
        private Types.TypeInterlock typeInterlock   = Types.TypeInterlock.None;

        //-----------------------------------------------------------------------------------------
        public Types.TypeInterlock TypeInterlock
        {
            get { return typeInterlock; }
        }
        //-----------------------------------------------------------------------------------------
        private Interlock(Types.TypeInterlock type)
        {
            typeInterlock = type;
        }
        //-----------------------------------------------------------------------------------------
        public Interlock()
        {
            CreateInterlocks();
        }
        //-----------------------------------------------------------------------------------------
        //Funkacja ma za zadanie utworzenie listy zaworow dostepnych w systemie
        private void CreateInterlocks()
        {
            string[] aInterlockType = Enum.GetNames(typeof(Types.TypeInterlock));
            for (int i = 0; i < aInterlockType.Length; i++)
            {
                Types.TypeInterlock aTypeInterlock ;
                Enum.TryParse<Types.TypeInterlock>(aInterlockType[i],out aTypeInterlock);

                interlocks.Add(new Interlock(aTypeInterlock));
            }
        }
        //-----------------------------------------------------------------------------------------
        //Funkcja ma za zadanie aktualizacje stanow zaworow odczytane z PLC
        override public void UpdateData(int[] aData)
        {
            if (aData.Length > Types.OFFSET_INTERLOCKS)
            {
                foreach (Interlock interlock in interlocks)//ustaw stany zaworow dla wszystkich zaworow zawartych w systemie
                {
                    int aInterlockState = aData[Types.OFFSET_INTERLOCKS];

                    int aShiftBits = (int)interlock.TypeInterlock * 2; // o ile musze przesunac bity slowa aby uzyskac dane interesujacego mnie zaworu
                    int aMask = 0x03 << aShiftBits;                          //maska bitowa wyodrebniajace stan danego zaworu
                    int aState = (aInterlockState & aMask) >> (int)aShiftBits;

                    if (Enum.IsDefined(typeof(Types.StateValve), aState))
                        interlock.state = (Types.StateValve)Enum.Parse(typeof(Types.StateValve), (aState).ToString()); // konwertuj int na Enum
                    else
                        interlock.state = Types.StateValve.Unknown;
                }
            }
            base.UpdateData(aData);
        }
        //-----------------------------------------------------------------------------------------
        //Zwroc stan danego zaworu
        public Types.StateValve GetState(Types.TypeInterlock aTypeInt)
        {
            Types.StateValve aState = Types.StateValve.Unknown;
            foreach (Interlock interlock in interlocks)
            {
                if (interlock.TypeInterlock == aTypeInt)
                {
                    aState = interlock.state;
                    break;
                }
            }
            return aState;
        }
        //-----------------------------------------------------------------------------------------
    }
}

