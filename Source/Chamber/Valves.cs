using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
    /// <summary>
    /// Klasa reprezentuje zawor komory. Umożliwia sterowanie zaworem i prezentuje jego stan 
    /// </summary>
    public class Valve : ChamberObject
    {
        private List<Valve>         valves              = new List<Valve>();    //lista wszystkich zaworow dostepmna w komorze
        private string              name                = "No name";
        private int                 id                  = 0;                    //parametr wiaze dany zawor z zaworem po stronie PLC 
        private Types.StateValve    state               = Types.StateValve.Error;
      

        private Valve(int ID , string Name)
        {
            name = Name;
            id = ID;
        }

        public Valve()
        {
            CreateValves();
        }

        //Funkacja ma za zadanie utworzenie listy zaworow dostepnych w systemie
        private void CreateValves()
        {
            string []ValvesType = Enum.GetNames(typeof(Types.TypeValve));

            for (int i = 0; i < ValvesType.Length; i++)
            {
                int ID = (int)Enum.GetValues(typeof(Types.TypeValve)).GetValue(i);
                string  Name = ValvesType[i];
                valves.Add(new Valve(ID, Name));
            }
        }

        //Funkcja ma za zadanie ustawienie stanow zaworow odczytane z PLC
        override public void UpdateData(int []aData)
        {
            foreach(Valve valve in valves)//ustaw stany zaworow dla wszystkich zaworow zawartych w systemie
            {
                int aShiftBits = valve.id * 2; // o ile musze przesunac bity slowa aby uzyskac dane interesujacego mnie zaworu
                if (valve.id == 0) aShiftBits = 0;
                int aMask = 0x03 << aShiftBits;                          //maska bitowa wyodrebniajace stan danego zaworu
                int aState = (aData[Types.INDEX_STATE_VALVES] & aMask) >> (int)aShiftBits;

                if (Enum.IsDefined(typeof(Types.StateValve), aState))
                    valve.state = (Types.StateValve)Enum.Parse(typeof(Types.StateValve), (aState).ToString()); // konwertuj int na Enum
                else
                    valve.state = Types.StateValve.Error;
            }
        }
        //Zwroc stan danego zaworu
        public Types.StateValve GetState(Types.TypeValve KindValve)
        {
            Types.StateValve State = Types.StateValve.Error;
            foreach(Valve valve in valves)
            {
                if (valve.id == (int)KindValve)
                {
                    State = valve.state;
                    break;
                }
            }
            return State;
        }

        public int SetState(Types.StateValve state, Types.TypeValve kindValve)
        {
            int iResult = 0;
            int []ctrlValve = {0};

            //ustaw na odpowidnim miejscu bity sterujace zgodnie z ID zaworu powiazanego z PLC
            int ShiftBits = (int)kindValve * 2; // o ile musze przesunac bity slowa aby uzyskac dane interesujacego mnie zaworu
            
            if (state == Types.StateValve.Open)
                ctrlValve[0] = 0x02 << ShiftBits;                          
            if(state == Types.StateValve.Close)
                ctrlValve[0] = 0x01 << ShiftBits;

            if (state == Types.StateValve.Close || state == Types.StateValve.Open)
            {
                if (plc != null)
                    iResult = plc.WriteWords(Types.ADDR_VALVES_CTRL, 1, ctrlValve);
                else
                    iResult = Types.ERROR_PLC_PTR_NULL;
            }
            else
                iResult = Types.ERROR_CALL_INCORRECT_OPERATION;


            return iResult;
        }
    }
}
