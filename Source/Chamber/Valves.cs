using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPT1000.Source.Driver;

namespace HPT1000.Source.Chamber
{
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
        public void SetState(int Data)
        {
            foreach(Valve valve in valves)//ustaw stany zaworow dla wszystkich zaworow zawartych w systemie
            {
                int ShiftBits = (int)System.Math.Pow(2, valve.id); // o ile musze przesunac bity slowa aby uzyskac dane interesujacego mnie zaworu
                int Mask = 0x03 << ShiftBits;                          //maska bitowa wyodrebniajace stan danego zaworu
                int State = (Data & Mask) >> (int)ShiftBits;

                valve.state = (Types.StateValve)Enum.Parse(typeof(Types.StateValve), (State).ToString()); // konwertuj int na Enum
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

        public int ControlValve(Types.Operation operation)
        {
            int iResult = 0;

            if(plc != null)
            {

            }

            return iResult;
        }
    }
}
