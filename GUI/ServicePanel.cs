using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source.Driver;
using HPT1000.Source.Chamber;

namespace HPT1000.GUI
{
    /*Klasa jest odpowiedzialna za ustawienie konfigruacji urzadzenia oraz dodanie typow gazow z ktorych mozemy korzystac
     */ 
    public partial class ServicePanel : UserControl
    {
        private Source.Driver.HPT1000   hpt1000  = null;
        private GasTypes                gasTypes = null;
        private bool                    lastStateCommunication = false;
        //----------------------------------------------------------------------------------------------------------------------------
        //Konstruktor klasy sluzacy do zainicjalizowania poczatkowych wartosci formatki
        public ServicePanel()
        {
            InitializeComponent();
            //Pokaz zapisane typy gazow
            FillComboBoxGases();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja wypelnia ComboBoxa zapisanymi typami gazow. Jezeli jest jakis gaz to wyswietl jego infomracje 
        private void FillComboBoxGases()
        {
            cBoxGasType.Items.Clear();

            if (gasTypes != null)
            {
                //Dodaj do lsity dostepne typy gazow
                foreach (GasType gasType in gasTypes.Items)
                {
                    cBoxGasType.Items.Add(gasType);
                }
            }
            //Ustaw sie na pierwszym typie gazu
            if (cBoxGasType.Items.Count > 0)
                cBoxGasType.SelectedIndex = 0;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie ustawienie referencji na obiekt urzadzenia. Jest on wymagan aby sie dostac do wszystkich obiektow urzadzenia ktorym sa zmieniane ustawienia w tym oknie
        public void SetPtrHPT(Source.Driver.HPT1000 hptPtr)
        {
            hpt1000 = hptPtr;                       //Ustaw referencvje na urzadzenie
            if (hpt1000 != null)
                gasTypes = hpt1000.GetGasTypes();   //Ustaw referencje na typ gazu
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie odswiezanie informacji na temat ustawien danych obiektow
        public void RefreshSettingsPanel()
        {
            if (hpt1000 != null && (hpt1000.GetPLC() != null))
            {
                PowerSupplay    aPowerSupply = hpt1000.GetPowerSupply();
                MFC             aMFC         = hpt1000.GetMFC();
                ForePump        aForePump    = hpt1000.GetForePump();

                RefreshPowerSupply(aPowerSupply);   //Odswiez panel zasilacza to znaczy odczytaj jego ustawienia i je zaprezentuj
                RefreshMFC(aMFC);                   //Odswiez panel MFC to znaczy odczytaj jego ustawienia i je zaprezentuj
                RefreshForePump(aForePump);         //Odswiez panel pompy to znaczy odczytaj jego ustawienia i je zaprezentuj
                //Odswiez liste zapisanych typow gazow
                FillComboBoxGases();         
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie odswiezenie panelu zasilacza to znaczy odczytaj jego ustawienia i je zaprezentuj
        private void RefreshPowerSupply(PowerSupplay powerSupply)
        {
            if (powerSupply != null && hpt1000 != null)
            {
                //Przedstaw parametry urzadzenia
                if (hpt1000.CoonectionPLC)
                {
                    dEditCurentLimit.Value          = powerSupply.LimitCurent;
                    dEditPowerLimit.Value           = powerSupply.LimitPower;
                    dEditVoltageLimit.Value         = powerSupply.LimitVoltage;
                    dEditRangePower.Value           = powerSupply.MaxPower;
                    dEditRangeCurent.Value          = powerSupply.MaxCurent;
                    dEditRangeVoltage.Value         = powerSupply.MaxVoltage;
                    timeSetpointStabilization.Value = Types.ConvertDate((int)powerSupply.TimeWaitSetpoint);
                    timeWaitOnOperate.Value         = Types.ConvertDate((int)powerSupply.TimeWaitOperate);
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie odswiezenie panelu MFC to znaczy odczytaj jego ustawienia i je zaprezentuj
        private void RefreshMFC(MFC mfc)
        {
            if (mfc != null && hpt1000 != null)
            {
                //Przedstaw parametry urzadzenia
                if (hpt1000.CoonectionPLC)
                {
                    dEditMaxFlow_MFC1.Value     = mfc.GetMaxFlow(1);
                    dEditMaxFlow_MFC2.Value     = mfc.GetMaxFlow(2);
                    dEditMaxFlow_MFC3.Value     = mfc.GetMaxFlow(3);
                    dEditRangeVoltageMFC1.Value = mfc.GetRangeVoltage(1);
                    dEditRangeVoltageMFC2.Value = mfc.GetRangeVoltage(2);
                    dEditRangeVoltageMFC3.Value = mfc.GetRangeVoltage(3);
                    timeFlowStabilization.Value = Types.ConvertDate((int)mfc.TimeFlowStability);
                }
                cBoxMFC1.Checked = mfc.GetActive(1);
                cBoxMFC2.Checked = mfc.GetActive(2);
                cBoxMFC3.Checked = mfc.GetActive(3);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie odswiezenie panelu pompy to znaczy odczytaj jego ustawienia i je zaprezentuj
        private void RefreshForePump(ForePump forePump)
        {
            if (forePump != null && hpt1000 != null)
            {
                //Przedstaw parametry urzadzenia
                if (hpt1000.CoonectionPLC)
                {
                    timePumpToSV.Value = Types.ConvertDate((int)forePump.TimePumpToSV);
                    timeWaitPF.Value = Types.ConvertDate((int)forePump.TimeWaitPF);
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie ustawienie komponentow odpowiedizalnych za wizualicjace parametrow urzadzenia MFC na 0
        private void ClearMFComponent()
        {
            dEditMaxFlow_MFC1.Value = 0;
            dEditMaxFlow_MFC2.Value = 0;
            dEditMaxFlow_MFC3.Value = 0;
            dEditRangeVoltageMFC1.Value = 0;
            dEditRangeVoltageMFC2.Value = 0;
            dEditRangeVoltageMFC3.Value = 0;
            timeFlowStabilization.Value = Types.ConvertDate(0);

            SetEnableComponentMFC(false);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie ustawienie komponentow odpowiedizalnych za wizualicjace parametrow urzadzenia PowerSupply na 0
        private void ClearPowerSupplyComponent()
        {
            dEditCurentLimit.Value  = 0;
            dEditPowerLimit.Value   = 0;
            dEditVoltageLimit.Value = 0;
            dEditRangePower.Value   = 0;
            dEditRangeCurent.Value  = 0;
            dEditRangeVoltage.Value = 0;
            timeSetpointStabilization.Value = Types.ConvertDate(0);
            timeWaitOnOperate.Value = Types.ConvertDate(0);

            SetEnableComponentPowerSupply(false);
        } 
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie ustawienie komponentow odpowiedizalnych za wizualicjace parametrow urzadzenia ForePump na 0
        private void ClearPumpComponent()
        {
            timePumpToSV.Value = Types.ConvertDate(0);
            timeWaitPF.Value = Types.ConvertDate(0);

            SetEnableComponentPump(false);
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Uutaw dostepnosc komponentow odpowiedzialnych za prezentacje/ustawianie parametrow MFC
        private void SetEnableComponentMFC(bool enabled)
        {
            //Jezeli jest brak komunikacji to nie moge ustawiac parametrow urzadzenia
            dEditMaxFlow_MFC1.Enabled     = enabled;
            dEditMaxFlow_MFC2.Enabled     = enabled;
            dEditMaxFlow_MFC3.Enabled     = enabled;
            dEditRangeVoltageMFC1.Enabled = enabled;
            dEditRangeVoltageMFC2.Enabled = enabled;
            dEditRangeVoltageMFC3.Enabled = enabled;
            timeFlowStabilization.Enabled = enabled;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Uutaw dostepnosc komponentow odpowiedzialnych za prezentacje/ustawianie parametrow zasilacza
        private void SetEnableComponentPowerSupply(bool enabled)
        {
            dEditCurentLimit.Enabled    = enabled;
            dEditPowerLimit.Enabled     = enabled;
            dEditVoltageLimit.Enabled   = enabled;
            dEditRangePower.Enabled     = enabled;
            dEditRangeCurent.Enabled    = enabled;
            dEditRangeVoltage.Enabled   = enabled;
            timeSetpointStabilization.Enabled = enabled;
            timeWaitOnOperate.Enabled   = enabled;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Uutaw dostepnosc komponentow odpowiedzialnych za prezentacje/ustawianie parametrow fore pump
        private void SetEnableComponentPump(bool enabled)
        {
            timePumpToSV.Enabled = enabled;
            timeWaitPF.Enabled   = enabled;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie konwetowanie obiektu czasu na sekundy poniewaz parametry zapisywane w PLC sa w sekundach
        private int GetSecond(DateTime aDateTime)
        {
            int aSec = 0;
            //Konwersja czasu na sekundy
            aSec = aDateTime.Hour * 3600 + aDateTime.Minute * 60 + aDateTime.Second;

            return aSec;
        }
        //------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private void timePumpToSV_ValueChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null && hpt1000.GetForePump() != null)
                hpt1000.GetForePump().SetTimePumpToSV(GetSecond(timePumpToSV.Value));
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private void timeWaitPF_ValueChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null && hpt1000.GetForePump() != null)
                hpt1000.GetForePump().SetTimeWaitPF((int)GetSecond(timeWaitPF.Value));
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private void timeFlowStabilization_ValueChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null && hpt1000.GetMFC() != null)
                hpt1000.GetMFC().SetTimeFlowStability(GetSecond(timeFlowStabilization.Value));
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditRangeVoltageMFC1_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetRangeVoltage(1, (int)dEditRangeVoltageMFC1.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditRangeVoltageMFC2_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetRangeVoltage(2, (int)dEditRangeVoltageMFC2.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditRangeVoltageMFC3_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetRangeVoltage(3, (int)dEditRangeVoltageMFC3.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private void timeSetpointStabilization_ValueChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null && hpt1000.GetPowerSupply() != null)
                hpt1000.GetPowerSupply().SetWaitTimeSetpoint(GetSecond(timeSetpointStabilization.Value));
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private void timeWaitOnOperate_ValueChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null && hpt1000.GetPowerSupply() != null)
                hpt1000.GetPowerSupply().SetWaitTimeOperate(GetSecond(timeWaitOnOperate.Value));
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditRangeCurent_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetMaxCurent(dEditRangeCurent.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditRangeVoltage_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetMaxVoltage(dEditRangeVoltage.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        private bool dEditRangePower_EnterOn()
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetMaxPower(dEditRangePower.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditMaxFlow_MFC1_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetMaxFlow(1, (int)dEditMaxFlow_MFC1.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditMaxFlow_MFC2_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetMaxFlow(2, (int)dEditMaxFlow_MFC2.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditMaxFlow_MFC3_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetMFC() != null)
            {
                if (!hpt1000.GetMFC().SetMaxFlow(3, (int)dEditMaxFlow_MFC3.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditCurentLimit_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetLimitCurent(dEditCurentLimit.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditVoltageLimit_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetLimitVoltage(dEditVoltageLimit.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu ustawienie parametru
        private bool dEditPowerLimit_EnterOn()
        {
            bool aRes = false;

            if (hpt1000 != null && hpt1000.GetPowerSupply() != null)
            {
                if (!hpt1000.GetPowerSupply().SetLimitPower(dEditPowerLimit.Value).IsError())
                    aRes = true;
            }

            return aRes;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja zdarzenia majaca na celu odczytanie parmaetrow z PLC
        private void btnReadSettings_Click(object sender, EventArgs e)
        {
            if (hpt1000 != null)
                hpt1000.UpdateSettings();

            RefreshSettingsPanel();
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Zdarzenie zmiany wybranego typu gazu. Przedtsw ustawienia dla wybranego gazu
        private void cBoxGasType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GasType gasType = (GasType)cBoxGasType.SelectedItem; //Pobierz typ aktualnie wybranego gazu 

            if (gasType != null)
            {
                //Ustawiony zostal wezel gazu przedstaw jego parametry
                tBoxGasDescription.Text = gasType.Description;
                dEditFactorGas.Value    = gasType.Factor;
                tBoxNameGas.Text        = gasType.Name;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zapisanie parametrow dla wybranego typu gazu. Dane sa zapisywane w bazie danych
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            bool aError = true;
            //Pobierz aktualnie wybrany typ gazu
            GasType gasType = (GasType)cBoxGasType.SelectedItem;
            //Jezeli jest jakis wybrany i jest on rozny od --NEW--
            if (gasType != null)
            {
                //Pole nazwy nie moze byc puste
                if (tBoxNameGas.Text != "")
                {
                    //Uzupelnij obiekt danymi
                    gasType.Factor      = dEditFactorGas.Value;
                    gasType.Description = tBoxGasDescription.Text;
                    gasType.Name        = tBoxNameGas.Text;
                    //Zapisz dane w bazie danych. Jezeli sie to powiedzie to poinformuj o tym usera
                    if (gasType.Modify() == 0)
                    {
                        //Gaz zostal zmodyfikowany to odswiez comboboxa na wypadek gdyby sie zmienila nazwa pamietajac prz tym aktualnie wybrany typ gazu
                        int aSelectedIndex = cBoxGasType.SelectedIndex;
                        FillComboBoxGases();
                        if (cBoxGasType.Items.Count > aSelectedIndex)
                            cBoxGasType.SelectedIndex = aSelectedIndex;

                        aError = false;
                        Source.Logger.AddMsg(Source.Translate.GetText("Ustawienia dla typu gazu " + gasType.Name + " zostal poprawnie zapisane"), Types.MessageType.Message);
                    }
                }
                else
                    Source.Logger.AddMsg(Source.Translate.GetText("Nie udalo sie zapisać zmian typu gazu. Pole Nazawa nie moze byc puste"), Types.MessageType.Error);
            }
            else
                Source.Logger.AddMsg(Source.Translate.GetText("Nie udalo sie zapisać zmian typu gazu. Nie wybrano gazu do edycji"), Types.MessageType.Error);
            //Nie udalo sie zapisac zmian ustaw elementy wizulane na aktualnych wartosciach typu gazu
            if (aError && gasType != null)
            {
                tBoxGasDescription.Text = gasType.Description;
                dEditFactorGas.Value    = gasType.Factor;
                tBoxNameGas.Text        = gasType.Name;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcaj ma za zadanie dodawanie nowego typu gazu
        private void btnNewGas_Click(object sender, EventArgs e)
        {
            if (gasTypes != null)
            {
                GasType gasType = new GasType();
                //Uzupelnij dane nowo utworzonego obiektu
                gasType.Factor      = dEditFactorGas.Value;
                gasType.Description = tBoxGasDescription.Text;
                gasType.Name        = tBoxNameGas.Text;
                //Jezeli dany gaz nie jest jeszcze dodany to go dodaj
                if (!gasTypes.Contains(gasType))
                {
                    //Dodaj nowy gaz do bazy danych. Jezeli operacja sie powiedzie to dodaj go takze do listu lokalnej oraz poinformuj o tym usera
                    if (gasTypes.Add(gasType) == 0)
                    {
                        //Dodaj gaz do lokalnej listy combobox
                        cBoxGasType.Items.Add(gasType);                        
                        FillComboBoxGases();          //Odswiez Comboboxa
                        cBoxGasType.SelectedIndex = cBoxGasType.Items.Count - 1; //ustaw sie na nowo dodanym typie gazu
                        //Poinfomruj usera ze udalo sie daodac gaz
                        Source.Logger.AddMsg(Source.Translate.GetText("Typ gazu " + gasType.Name + " zostal poprawnie dodany"), Types.MessageType.Message);
                    }
                }
                else
                {
                    Source.Logger.AddMsg(Source.Translate.GetText("Typ gazu " + gasType.Name + " juz istnieje"), Types.MessageType.Error);
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkja ustawia konfiguracje dostepnosci przeplywke w systemie
        private void cBoxMFC_Click(object sender, EventArgs e)
        {
            if (hpt1000 != null)
            {
                hpt1000.GetMFC().SetActive(1, cBoxMFC1.Checked);
                hpt1000.GetMFC().SetActive(2, cBoxMFC2.Checked);
                hpt1000.GetMFC().SetActive(3, cBoxMFC3.Checked);
            }

            dEditMaxFlow_MFC1.Enabled = cBoxMFC1.Checked;
            dEditRangeVoltageMFC1.Enabled = cBoxMFC1.Checked;

            dEditMaxFlow_MFC2.Enabled = cBoxMFC2.Checked;
            dEditRangeVoltageMFC2.Enabled = cBoxMFC2.Checked;

            dEditMaxFlow_MFC3.Enabled = cBoxMFC3.Checked;
            dEditRangeVoltageMFC3.Enabled = cBoxMFC3.Checked;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie usuniecie dango typu gazu
        private void btnRemoveGas_Click(object sender, EventArgs e)
        {
            GasType gasType = (GasType)cBoxGasType.SelectedItem; //Pobierz aktulnie wybrany typ gazu

            if (gasType != null && gasTypes != null)
            {
                //Usun typ gazu z bazy danych
                if (gasTypes.Remove(gasType) == 0)
                {
                    //Usuniecie gazu z bazy danych sie powiodlo to odswiez comboboxa
                    int aSelectedIndex = cBoxGasType.SelectedIndex;
                    FillComboBoxGases();
                    cBoxGasType.SelectedIndex = aSelectedIndex - 1;
                    //W przypadku gdy nie ma juz zadnego typu gazu zeruj komponenty wizulane
                    if (cBoxGasType.SelectedIndex < 0)
                    {
                        tBoxNameGas.Text        = "";
                        tBoxGasDescription.Text = "";
                        dEditFactorGas.Value    = 0;
                    }

                    Source.Logger.AddMsg(Source.Translate.GetText("Typu gazu " + gasType.Name + " zostal poprawnie usuniety"), Types.MessageType.Message);
                }
            }
            else
                Source.Logger.AddMsg(Source.Translate.GetText("Nie udalo sie usunac typu gazu. Typ gazu nie zostal wybrany"), Types.MessageType.Error);
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja timera majaca na celu ustawianie widocznosci przycoskow w zaleznosci od sytuacji
        private void timer_Tick(object sender, EventArgs e)
        {
            //Nie mozna modyfikowac i usuwac gdy nie jest wybrany zaden typ gazu
            if (cBoxGasType.SelectedIndex < 0)
            {
                btnSaveSettings.Enabled = false;
                btnRemoveGas.Enabled = false;
            }
            else
            {
                btnSaveSettings.Enabled = true;
                btnRemoveGas.Enabled = true;
            }
            //Brak komunikacji z PLC kasuj widzocznosc komponetow
            if (hpt1000 != null)
            {
                if (!hpt1000.CoonectionPLC)
                {
                    ClearMFComponent();
                    ClearPowerSupplyComponent();
                    ClearPumpComponent();
                }
                //Komunikacja sie pojawila pokaz wartosci parametrow ale tylko raz. Musi to dzialc na zbocze narastajace
                if (!lastStateCommunication && hpt1000.CoonectionPLC)
                {
                    RefreshSettingsPanel();
                    SetEnableComponentMFC(true);
                    SetEnableComponentPowerSupply(true);
                    SetEnableComponentPump(true);
                }
                lastStateCommunication = hpt1000.CoonectionPLC;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Zdarzenie wywolywane w momencie ladowania panelu. W tym czasie odczytaj parametry urzadzenia z PLC i uzupelnij je na formatce
        private void ServicePanel_Load(object sender, EventArgs e)
        {
            //Odczytaj paramtry PLC
            if (hpt1000 != null)
                hpt1000.UpdateSettings();
            //Odseiez formtke
            RefreshSettingsPanel();
        }
        //---------------------------------------------------------------------------------------------------------------------------
    }
}
