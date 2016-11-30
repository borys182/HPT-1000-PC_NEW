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
    public partial class SettingsPanel : UserControl
    {
        //Referencje na obiekty wymagna przez panel serwisowy
        private Source.Driver.HPT1000   hpt1000  = null;
        private Source.DB               dataBase = null;

        //----------------------------------------------------------------------------------------------------------------------------
        //Ustaw wskaznik na obiekt bazy danych. Jest on wymagany do zapisu parametrow akwizycji
        public Source.DB DataBase
        {
            set { dataBase = value; }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public Source.Driver.HPT1000 Hpt1000
        {
            set { hpt1000 = value; }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Konstruktor klasy jest odpowiedzilny za przygotowania komonentow gradicnzych oraz inicjalizacja ich wartosciami
        public SettingsPanel()
        {
            InitializeComponent();
            //Wypelnij dostepne jezyki
            FillComboBoxLanguge();
            //Wyszarz na poczatek mozliwosc wprwadzania wartosci parametrow bo nie wiesz jaki jest wezel wybrany
            grBoxParameter.Enabled = false;
            //Ustaw poczatkowa wartosc na checked a pozniej reaguj na jego zmiane
            labPressure.Enabled      = cBoxActivePressure.Checked;
            labUnitPressure.Enabled  = cBoxActivePressure.Checked;
            dEditAcqPressure.Enabled = cBoxActivePressure.Checked;
            //Inicjalizuj ComboBoxa Mode wartosciami z Enuma
            FillComboBoxMode();
            //Pokaz dostepne typy komunikacji z PLC
            FillComboBoxCommunication();
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Wypelnij liste dostepnych jezyki dla aplikacji
        private void FillComboBoxLanguge()
        {
            cBoxLanguge.Items.Clear();
            foreach (string aName in Enum.GetNames(typeof(Types.Language)))
            {
                cBoxLanguge.Items.Add(aName);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Odswiez parametry prezentowane na panelu
        public void RefreshSettingsPanel()
        {
            if (hpt1000 != null)
            {
                //Pokaz aktualna konfiguracje urzadzen i parametrow.  nie jest zmieniana dlatego moge ja zalafowac podczas tworzenia formatki
                //Pokaz liste urzadzen
                ShowListDevice();
                //Pokaz parametry akwizycji
                ShowAcqPara();
                //Wyswietl aktualnie wybrany jezyk
                for (int i = 0; i < cBoxLanguge.Items.Count; i++)
                {
                    if (cBoxLanguge.Items[i].ToString() == Source.Driver.HPT1000.LanguageApp.ToString())
                        cBoxLanguge.SelectedIndex = i;
                }
                if (hpt1000.GetPLC() != null)
                {
                    //Przedstaw aktualnie wybrany tryb dummy mode
                    cBoxDummyMode.Checked = hpt1000.GetPLC().GetDummyMode();
                    //Przedstasw aktualnie wybrany typ komunikacji z PLC
                    for (int i = 0; i < cBoxComm.Items.Count; i++)
                    {
                        if (cBoxComm.Items[i].ToString() == hpt1000.GetPLC().GetTypeComm().ToString())
                            cBoxComm.SelectedIndex = i;
                    }
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        //Funkcja wypelnia ComboBoxa dostepnymi rodzajami komunikacji z PLC
        private void FillComboBoxCommunication()
        {
            cBoxComm.Items.Clear();
            foreach (string aName in Enum.GetNames(typeof(Types.TypeComm)))
            {
                cBoxComm.Items.Add(aName);
            }
        }
        //------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie dopisanie do listy combobox wszystkich mozliwych do wybrania trybow pracy
        private void FillComboBoxMode()
        {
            cBoxMode.Items.Clear();
            foreach (string nameMode in Enum.GetNames(typeof(Types.ModeAcq)))
            {
                cBoxMode.Items.Add(nameMode);
            }
        }
        //------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie utworzenie listy urzadzen wraz z jej parametrami
        private void ShowListDevice()
        {
            TreeNode nodeDevices = null;
            //Wyczysc aktualna liste
            treeViewDevices.Nodes.Clear();
            //Utworz pierwszy wezel lsity jezeli jeszcze nie istnieje
            if (treeViewDevices.Nodes.Count == 0)
                treeViewDevices.Nodes.Add("Devices list", "Devices list", 0, 0);
            //Ustaw obiekt pierwszego wezla drzewa
            if (treeViewDevices.Nodes.Count > 0)
                nodeDevices = treeViewDevices.Nodes[0];
            //Utworz drzewo urzadzen wraz z ich parametrami jako liste ale tylko te urzadzenia oraz te parametry ktroe sa przewidziane do archiwizowania czyli posiadaja parametry
            if (hpt1000 != null && hpt1000.Chamber.GetObjects() != null && nodeDevices != null)
            {
                //Pobierz liste wszystkich urzadzen
                foreach (Device device in hpt1000.Chamber.GetObjects())
                {
                    //Utworz wezel urzadzenia tylko dla urzadzen posiadajacych parametry przeznaczone do archiwizowania
                    if (device.GetParameters().Count > 0)
                    {
                        TreeNode nodeDevice = new TreeNode(device.Name, 1, 1);  //Utworz wezle urzadzenia
                        nodeDevice.Tag = device;
                        //Pobierz liste parametrow urzadzenia
                        foreach (Parameter para in device.GetParameters())
                        {
                            TreeNode nodePara = new TreeNode(para.Name, 2, 2);//Utworz wezl parametru
                            nodePara.Tag = para;
                            nodeDevice.Nodes.Add(nodePara);     //Dodaj wezel parametru do wezla urzadzenia
                        }
                        //Doadj wezle urzadzenia do wezla lsity urzadzen
                        if (nodeDevices != null)
                            nodeDevices.Nodes.Add(nodeDevice);
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------
        //Funkcja wyswietla parametry parametru urzadzenia
        private void ShowParameter(Parameter para)
        {
            if (para != null)
            {
                dEditFrqAcq.Value = para.Frequency;
                dEditDifferencesValue.Value = para.Differance;
                cBoxParaActive.Checked = para.EnabledAcq;
                labParaUnit.Text = "[" + para.Unit + "]";

                for (int i = 0; i < cBoxMode.Items.Count; i++)
                {
                    if (cBoxMode.Items[i].ToString() == para.Mode.ToString())
                        cBoxMode.SelectedIndex = i;
                }
            }
        }
        //------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie pokaznie parametrow akwizycji danych zapisanych w obiekcie odpowiedzinalnym za akwizycje danych
        private void ShowAcqPara()
        {
            if (hpt1000 != null)
            {
                dEditAcqPressure.Value = hpt1000.PressureAcq;
                cBoxActivePressure.Checked = hpt1000.ActiveCheckPressureAcq;
                rBtnAcqDuringProcess.Checked = hpt1000.AcqDuringOnlyProcess;
                rBtnAcqAllTime.Checked = hpt1000.AcqAllTime;
                cBoxEnabledAcq.Checked = hpt1000.EnabledAcq;
            }
        }
        //------------------------------------------------------------------------------------------
        //Podaj obiekt parametru z aktualnie wybranego wezla drzewa
        private Parameter GetSelectedPara()
        {
            Parameter para = null;

            if (treeViewDevices.SelectedNode != null && treeViewDevices.SelectedNode.Level == 2)
                para = (Parameter)treeViewDevices.SelectedNode.Tag;

            return para;
        }
        //------------------------------------------------------------------------------------------
        //Funkcja wywolywana akcja klikniecia na dowolny wezel listy urzadzen. Pokaz wartosci parametrow wybranego wezla parametru urzadzenia
        private void treeViewDevices_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Pokaz parametry wybranego wezla
            ShowParameter(GetSelectedPara());
            //Jezeli wybrany wezel nie jest wezlem parametru to wyszarz wartosci parametru
            if (treeViewDevices.SelectedNode != null && treeViewDevices.SelectedNode.Level != 2)
            {
                grBoxParameter.Enabled = false;
            }
            else
                grBoxParameter.Enabled = true;
        }
        //------------------------------------------------------------------------------------------
        //Podswietlaj caly czas aktualnie zaznaczony program/subprogram
        private void LightSelectedNode(TreeNodeCollection nodes)
        {
            if (nodes != null)
            {
                foreach (TreeNode node in nodes)
                {
                    //jezeli mam dzieci to wywolaj funkcje rekurencyjnie jeszcze raz
                    if (node.Nodes.Count > 0)
                        LightSelectedNode(node.Nodes);
                    //Wezel jest zaznaczony to ustaw backcolor jako podswietlony zaznaczony
                    if (node.IsSelected)
                    {
                        node.BackColor = SystemColors.Highlight;
                        node.ForeColor = Color.White;
                    }
                    //Wezel nie jest juz wybrany to ustaw kolor jako nie wybrany
                    else
                    {
                        node.BackColor = Color.Transparent;
                        node.ForeColor = Color.Black;
                    }
                }
            }
        }
        //-------------------------------------------------------------------------------
        private void rBtnAcqDuringProcess_CheckedChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null)
                hpt1000.AcqDuringOnlyProcess = rBtnAcqDuringProcess.Checked;
        }
        //-------------------------------------------------------------------------------
        private void rBtnAcqAllTime_CheckedChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null)
                hpt1000.AcqAllTime = rBtnAcqAllTime.Checked;
        }
        //------------------------------------------------------------------------------------------
        private bool dEditAcqPressure_EnterOn()
        {
            if (hpt1000 != null)
                hpt1000.PressureAcq = dEditAcqPressure.Value;

            return true;
        }
        //------------------------------------------------------------------------------------------
        private bool dEditFrqAcq_EnterOn()
        {
            Parameter para = GetSelectedPara();

            if (para != null)
                para.Frequency = dEditFrqAcq.Value;

            return true;
        }
        //------------------------------------------------------------------------------------------
        private bool dEditDifferencesValue_EnterOn()
        {
            Parameter para = GetSelectedPara();

            if (para != null)
                para.Differance = dEditDifferencesValue.Value;

            return true;
        }
        //------------------------------------------------------------------------------------------
        private void timer_Tick(object sender, EventArgs e)
        {
            //Podswietalj aktulnie zaznaczony wezel caly czas
            LightSelectedNode(treeViewDevices.Nodes);
            //Ustaw widocznosc pol do wprawadzania parametrow akwizycji w zaleznosci od wlaczonej opcji akwizycji danych jak i wybranego wezla
            if (hpt1000 != null)
            {
                //Pola akwizyji urzadzenia sa tylko dezaktywowane gdy jest wylaczona akwizycja
                if (grBoxDevice.Enabled != hpt1000.EnabledAcq)
                    grBoxDevice.Enabled = hpt1000.EnabledAcq;
                //Pola parametrow sa dezaktywowane gdy jest wylaczona akwizycja lub nie jest wybrany wezel parametru
                if (hpt1000.EnabledAcq && treeViewDevices.SelectedNode != null && treeViewDevices.SelectedNode.Level == 2)
                    grBoxParameter.Enabled = true;
                else
                    grBoxParameter.Enabled = false;
            }
        }
        //------------------------------------------------------------------------------------------
        //Wyszaz mozliwosc wprowadzania wartosci prozni gdy opcja jest wylaczona
        private void cBoxActivePressure_CheckedChanged(object sender, EventArgs e)
        {
            labPressure.Enabled      = cBoxActivePressure.Checked;
            labUnitPressure.Enabled  = cBoxActivePressure.Checked;
            dEditAcqPressure.Enabled = cBoxActivePressure.Checked;

            if (hpt1000 != null)
                hpt1000.ActiveCheckPressureAcq = cBoxActivePressure.Checked;
        }
        //------------------------------------------------------------------------------------------
        private void cBoxParaActive_CheckedChanged(object sender, EventArgs e)
        {
            Parameter para = GetSelectedPara();
            if (para != null)
            {
                para.EnabledAcq = cBoxParaActive.Checked;
            }
        }
        //------------------------------------------------------------------------------------------
        private void cBoxMode_SelectedValueChanged(object sender, EventArgs e)
        {
            Parameter para = GetSelectedPara();
            if (para != null)
            {
                para.Mode = (Types.ModeAcq)Enum.Parse(typeof(Types.ModeAcq), cBoxMode.SelectedItem.ToString());
            }
        }
        //------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie zapisanie parametrow wszystkich urzadzen w bazie danych
        private void btnSave_Click(object sender, EventArgs e)
        {
            //SPrawdz czy istnieja referencje na wykorzystywane obiekty
            if (dataBase != null && hpt1000 != null && hpt1000.Chamber.GetObjects() != null)
            {
                //Pobierz liste wszystkich urzadzen
                foreach (Device device in hpt1000.Chamber.GetObjects())
                {
                    //Wykonaj zapis parametrow ale tylko urzadzenia ktore zapisuje parametry w bazie danych
                    if (device.AcqData)
                    {
                        //Pobierz liste parametrow urzadzenia
                        foreach (Parameter para in device.GetParameters())
                        {
                            //wykonaj zapis parametrow danego parametru w bazie dnaych
                            dataBase.ModifyConfigPara(para);
                        }
                    }
                }
                //Zapisz konfigruacje dla urzadzenia
                hpt1000.SaveData();
            }
        }
        //------------------------------------------------------------------------------------------
        //Funckaj ustawia flage wlaczenia/wylacze akwizycji danych
        private void cBoxEnabledAcq_CheckedChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null)
                hpt1000.EnabledAcq = cBoxEnabledAcq.Checked;
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Aktywuj/deaktywuj tryb dumy mode
        private void cBoxDummyMode_CheckedChanged(object sender, EventArgs e)
        {
            if (hpt1000 != null && hpt1000.GetPLC() != null)
                hpt1000.GetPLC().SetDummyMode(cBoxDummyMode.Checked);
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Wybor sciezki do zapisu wygenerowanych raportow z danymi
        private void btnSelectDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                tBoxPath.Text = fbd.SelectedPath;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Zdarzenie powoduje odswiezenie wartosci prezentowanych na panelu
        private void SettingsPanel_Load(object sender, EventArgs e)
        {
            RefreshSettingsPanel();
        }
        //---------------------------------------------------------------------------------------------------------------------------
        //Funkcja ma za zadanie obsluzenie zdarzenia zmiany typu komunikacji z PLC
        private void cBoxComm_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (cBoxComm)
            {
                if (hpt1000 != null && hpt1000.GetPLC() != null)
                {
                    if (cBoxComm.SelectedItem.ToString() == "USB")
                        hpt1000.GetPLC().SetTypeComm(Types.TypeComm.USB);
                    if (cBoxComm.SelectedItem.ToString() == "TCP")
                        hpt1000.GetPLC().SetTypeComm(Types.TypeComm.TCP);
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------        
    }
}
