using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPT1000.Source.Chamber
{
    /* Klasa prezentuje tablice Device z bazy danych i jest odpowiedzialan za powiazanie fizycznych urzadzen komory z obiektami bazy danych
     */ 
    public class Device
    {
       //TO DO - zapisz id do pliku configuracyjnego !!!!
        private int             id_DB;      //ID urzadzenia zapisanego w bazie danych
        private string          name;       //Nazwa urzadzenia ktora musi byc unikalna dla calego systemu. Jest ona nadawana w konstruktorze urzadzenia a poznij dopiero zapisywana w bazie danych
                                            //Jezeli urzadzenie nie ma byc rejestrowane w bazie danych to nie ustawiam pola name
        private List<Parameter> parameters = new List<Parameter>(); //Lista parametrow urzadzenia ktore sa zapisywane w bazie danych

        //---------------------------------------------------------------------------------------------------------------------------
        public int ID_DB
        {
            set { id_DB = value; }
            get { return id_DB; }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        public Parameter AddParameter(string name, Value value, string unit)
        {
            Parameter para  = new Parameter();
            para.Name       = name;
            para.ValuePtr   = value;
            para.Unit       = unit;
            parameters.Add(para);

            return para;       
        }
        //---------------------------------------------------------------------------------------------------------------------------
        public List<Parameter> GetParameters()
        {
            return parameters;
        }
        //---------------------------------------------------------------------------------------------------------------------------

    }
}
