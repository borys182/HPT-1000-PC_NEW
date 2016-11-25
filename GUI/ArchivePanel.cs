using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source.Chamber;
using HPT1000.Source.Driver;
using System.Windows.Forms.DataVisualization.Charting;

namespace HPT1000.GUI
{
    public partial class ArchivePanel : UserControl
    {
        private HPT1000.Source.Driver.HPT1000 hpt1000 = null;
        private Source.DB dataBase = null;

        //Serie danych
        Series seriePressure = new Series("Pressure: [mBar]");
        Series seriePower = new Series("Power: [W]");
        Series serieVoltage = new Series("Voltage: [V]");
        Series serieCurent = new Series("Curent: [A]");
        Series serieFlow1 = new Series("Gas flow 1: [sccm]");
        Series serieFlow2 = new Series("Gas flow 2: [sccm]");
        Series serieFlow3 = new Series("Gas flow 3: [sccm]");

        //serie danhych wykorzystywanych do dodania do wykresu aby przy braku zadnej seri wykres sie nie chowal
        Series serieEmpty_Pressure = new Series("EmptyPressure");
        Series serieEmpty_Power = new Series("EmptyPower");
        Series serieEmpty_MFC = new Series("EmptyMFC");

        //wskazniki obiektow z ktorych czytane sa dane
        PressureControl presure = null;
        MFC mfc = null;
        PowerSupplay powerSupplay = null;

        //Szerokosc okna danych - okresla ile danych jest pokazanych jednorazowan na wykresie
        double windowSize = 200;

        //Zmienne pomocnioecze przy przesuwanieu wykresu. Okreslaja poczatkowe klikniecie myszka w wykres podczas przesuwania
        Point scrollStartPoint_Pressure;
        Point scrollStartPoint_Power;
        Point scrollStartPoint_MFC;

        //Mamy mozliwosc prezentacji danych zbiorczych na jednym wykresie lub podzilonych na trzy wykresy
        ChartArea chartAreaPressure = null;
        ChartArea chartAreaPower = null;
        ChartArea chartAreaMFC = null;

        //Flagi automatycznego scrolowania danego wykresu
        bool autoScroll_Pressure = true;
        bool autoScroll_Power = true;
        bool autoScroll_MFC = true;

        //wskaznik na forme jest potrzebny do wyliczania poprawnej pozycji kursora na formatce
        Form mainForm = null;

        //------------------------------------------------------------------------------------------
        public ArchivePanel()
        {
            InitializeComponent();
            //Wyszarz na poczatek mozliwosc wprwadzania wartosci parametrow bo nie wiesz jaki jest wezel wybrany
            grBoxParameter.Enabled = false;
            //Ustaw poczatkowa wartosc na checked a pozniej reaguj na jego zmiane
            labPressure.Enabled = cBoxActivePressure.Checked;
            labUnitPressure.Enabled = cBoxActivePressure.Checked;
            dEditAcqPressure.Enabled = cBoxActivePressure.Checked;
            //Inicjalizuj charta
            InitChartData();
        }
        //-------------------------------------------------------------------------------
        public Source.DB DataBase
        {
            set { dataBase = value; }
        }
        //-------------------------------------------------------------------------------
        public Form MainForm
        {
            set { mainForm = value; }
        }
        //------------------------------------------------------------------------------------------
        public Source.Driver.HPT1000 Hpt1000
        {
            set { hpt1000 = value; }
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
        //Pokaz aktualna konfiguracje urzadzen i parametrow. Jest ona raz tworzna podczas tworzenia sie obiektow i nie jest zmieniana dlatego moge ja zalafowac podczas tworzenia formatki
        private void ArchivePanel_Load(object sender, EventArgs e)
        {
            //Pokaz liste urzadzen
            ShowListDevice();
            //Pokaz parametry akwizycji
            ShowAcqPara();
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
        //------------------------------------------------------------------------------------------
        private void cBoxActivePressure_Click(object sender, EventArgs e)
        {
            if (hpt1000 != null)
                hpt1000.ActiveCheckPressureAcq = cBoxActivePressure.Checked;
        }
        //------------------------------------------------------------------------------------------
        private void rBtnAcqDuringProcess_Click(object sender, EventArgs e)
        {
            if (hpt1000 != null)
                hpt1000.AcqDuringOnlyProcess = rBtnAcqDuringProcess.Checked;
        }
        //------------------------------------------------------------------------------------------
        private void rBtnAcqAllTime_Click(object sender, EventArgs e)
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
        }
        //------------------------------------------------------------------------------------------
        //Wyszaz mozliwosc wprowadzania wartosci prozni gdy opcja jest wylaczona
        private void cBoxActivePressure_CheckedChanged(object sender, EventArgs e)
        {
            labPressure.Enabled = cBoxActivePressure.Checked;
            labUnitPressure.Enabled = cBoxActivePressure.Checked;
            dEditAcqPressure.Enabled = cBoxActivePressure.Checked;
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
        //----------------------------------KOD ZWIAZANY Z PREZENACJA DANYCH HISTORYCZNYCH----------
        //------------------------------------------------------------------------------------------
        private void InitChartData()
        {
            ConfigChart();
            ClearChart();
            LoadBitmap();
            PrepareComboBox();
        }
        //-------------------------------------------------------------------------------
        private void PrepareComboBox()
        {
            toolStripComboBoxChart.Items.Add(" Together");
            toolStripComboBoxChart.Items.Add(" Separately");

            //ustaw opcje do rysowania danych na wykresie jednym. W czasie dzialania programu mozna to zmienic na kilka wykresow
            toolStripComboBoxChart.SelectedIndex = 0;
            toolStripComboBoxChart_SelectedIndexChanged(null, EventArgs.Empty);
        }
        //-------------------------------------------------------------------------------
        //Zaladowanie bitmapy do przyciku kasujacego dane wartosci z wykresu
        private void LoadBitmap()
        {
            Bitmap clearIcone = new Bitmap(Properties.Resources.Clear);
            clearIcone.MakeTransparent(Color.White);

            // toolStripBtnClear.Image = clearIcone;
        }
        //-------------------------------------------------------------------------------
        //Funkcja ma za zadanie przygotowanie konfiguracji seri i wykresu
        private void ConfigChart()
        {
            //Ustaw koory serii
            seriePressure.Color = Color.Blue;
            seriePower.Color = Color.Red;
            serieVoltage.Color = Color.Green;
            serieCurent.Color = Color.DeepPink;
            serieFlow1.Color = Color.DarkOrange;
            serieFlow2.Color = Color.DarkViolet;
            serieFlow3.Color = Color.DeepSkyBlue;
            //Dodaj serie do wykresu
            chart.Series.Add(seriePressure);
            chart.Series.Add(seriePower);
            chart.Series.Add(serieVoltage);
            chart.Series.Add(serieCurent);
            chart.Series.Add(serieFlow1);
            chart.Series.Add(serieFlow2);
            chart.Series.Add(serieFlow3);
            chart.Series.Add(serieEmpty_Pressure);
            chart.Series.Add(serieEmpty_Power);
            chart.Series.Add(serieEmpty_MFC);
            //Ustaw grubosvc  lini dla wszystkich serii na jeden rozmiar
            foreach (Series serie in chart.Series)
            {
                serie.BorderWidth = 1;
                serie.ChartType = SeriesChartType.Line;
                serie.XValueType = ChartValueType.DateTime;
            }
            //Ustaw BackColor checkBoxom odpowiedzialnym za wizualizacje danej serii
            cBoxPressure.ForeColor = seriePressure.Color;
            cBoxPower.ForeColor = seriePower.Color;
            cBoxVoltage.ForeColor = serieVoltage.Color;
            cBoxCurent.ForeColor = serieCurent.Color;
            cBoxFlow1.ForeColor = serieFlow1.Color;
            cBoxFlow2.ForeColor = serieFlow2.Color;
            cBoxFlow3.ForeColor = serieFlow3.Color;

            //ustaw widocznosc serii tak jak sa poustawiane checkboxy
            cBox_CheckedChanged(null, EventArgs.Empty);
            //przypisz na sztywno puste serie dla konkretnych chart area aby wykres sie nie chowal gdy nie ma zadnej serii
            serieEmpty_Pressure.ChartArea = "ChartAreaPressure";
            serieEmpty_Power.ChartArea = "ChartAreaPower";
            serieEmpty_MFC.ChartArea = "ChartAreaMFC";
            //Dodaj punktu do pustych seri aby wykres sie wyswietlil
            serieEmpty_MFC.Points.AddY(0);
            serieEmpty_Power.Points.AddY(0);
            serieEmpty_Pressure.Points.AddY(0);
            //Inicjalizacja ChartArea danych wykresow
            chartAreaPressure = chart.ChartAreas.FindByName("ChartAreaPressure");
            chartAreaPower = chart.ChartAreas.FindByName("ChartAreaPower");
            chartAreaMFC = chart.ChartAreas.FindByName("ChartAreaMFC");

        }
        //-------------------------------------------------------------------------------
        //Kasuj dane z wykresu. Wszystkie punkty wykresu zostaja wykasowane
        public void ClearChart()
        {
            foreach (Series serie in chart.Series)
            {
                serie.Points.Clear();
            }
            //Pustych seri nie usuwam
            serieEmpty_MFC.Points.AddY(0);
            serieEmpty_Power.Points.AddY(0);
            serieEmpty_Pressure.Points.AddY(0);
/*
            //Ustawiam widok charta od 0 - przesuniecie wykresu do poczatku ukladu wspolrzednych
            if (chartAreaPressure != null)
                chartAreaPressure.AxisX.ScaleView.Scroll(0.0);
            if (chartAreaPower != null)
                chartAreaPower.AxisX.ScaleView.Scroll(0.0);
            if (chartAreaMFC != null)
                chartAreaMFC.AxisX.ScaleView.Scroll(0.0);
*/        }
        //-------------------------------------------------------------------------------
        //Aktualizacja danych na wykresie. Funkcja wywolywana z watku glownego aplikacji po odczytaniuy danych z PLC
        public void LoadData(DateTime startDate,DateTime endDate)
        {
            ClearChart();
            if (dataBase != null)
            {
                //Pobierz dane z bazy danych
                List<DataBaseData> listData = dataBase.GetHistoryData(startDate, endDate);

                if (listData != null)
                {
                    foreach (DataBaseData data in listData)
                    {
                        //Przydziel dane do odpowiedniej seri
                        switch (GetNameParameter(data.ID_Para))
                        {
                            case "MFC1 Flow":
                                serieFlow1.Points.AddXY(data.Date, data.Value);
                                break;
                            case "MFC2 Flow":
                                serieFlow2.Points.AddXY(data.Date, data.Value);
                                break;
                            case "MFC3 Flow":
                                serieFlow3.Points.AddXY(data.Date, data.Value);
                                break;
                            case "Curent":
                                serieCurent.Points.AddXY(data.Date, data.Value);
                                break;
                            case "Voltage":
                                serieVoltage.Points.AddXY(data.Date, data.Value);
                                break;
                            case "Power":
                                seriePower.Points.AddXY(data.Date ,data.Value);              
                                break;
                            case "Pressure":
                                seriePressure.Points.AddXY(data.Date, data.Value);
                                break;
                        }
                    }
                }
             
                AutoScale(startDate, endDate);
                //Wywolaj funkcje skalujace wykres, to znaczy przesuwajace okno zgodnie z nadchodzacymi nowymi wartosciami
                ScaleChartWindow(chartAreaPressure, seriePressure.Points.Count, autoScroll_Pressure);
                ScaleChartWindow(chartAreaPower, seriePower.Points.Count, autoScroll_Power);
                ScaleChartWindow(chartAreaMFC, serieFlow1.Points.Count, autoScroll_MFC);
            }
        }
        //-------------------------------------------------------------------------------
        //Funkcja ma za zadanie dobranie intervalu oraz formatu osi X w zaleznosci od zakresu punktow ktory prezentuje
        private void GetRangeData(List<DataBaseData> listData,out DateTime minDate,out DateTime maxDate)
        {
            minDate = DateTime.MaxValue;
            maxDate = DateTime.MinValue;
            //Znajdz min/max pkt
            foreach (DataBaseData data in listData)
            {
                if (data.Date < minDate)
                    minDate = data.Date;

                if (data.Date > maxDate)
                    maxDate = data.Date;
            }            
        }
        //-------------------------------------------------------------------------------
        private void AutoScale(DateTime minDate, DateTime maxDate)
        {
            DateTimeIntervalType typeInterval = DateTimeIntervalType.Years;
            string format = "yyyy";
            if (maxDate.AddTicks(-minDate.Ticks).Ticks < DateTime.MinValue.AddYears(1).Ticks)
            {
                typeInterval = DateTimeIntervalType.Months;
                format = "yyyy-MM";
            }
            if (maxDate.AddTicks(-minDate.Ticks).Ticks < DateTime.MinValue.AddMonths(1).Ticks)
            {
                typeInterval = DateTimeIntervalType.Days;
                format = "MM-dd";
            }
            if (maxDate.AddTicks(-minDate.Ticks).Ticks < DateTime.MinValue.AddDays(1).Ticks)
            {
                typeInterval = DateTimeIntervalType.Hours;
                format = "HH:mm";
            }
            if (maxDate.AddTicks(-minDate.Ticks).Ticks < DateTime.MinValue.AddHours(1).Ticks)
            {
                typeInterval = DateTimeIntervalType.Minutes;
                format = "HH:mm:ss";
            }
            foreach (ChartArea chartArea in chart.ChartAreas)
            {
                chartArea.AxisX.LabelStyle.Format = format;
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.IntervalType = typeInterval;
                chartArea.AxisX.IntervalOffset = 1;

                chartArea.AxisX.Minimum = minDate.ToOADate();
                chartArea.AxisX.Maximum = maxDate.ToOADate();

            }
        }
        //-------------------------------------------------------------------------------
        private string GetNameParameter(int idPara)
        {
            string aNamePara = null;

            if (hpt1000 != null)
            {
                foreach (Device device in hpt1000.Chamber.GetObjects())
                {
                    foreach (Parameter para in device.GetParameters())
                    {
                        if (para.ID == idPara)
                            aNamePara = para.Name;
                    }
                }
            }
            return aNamePara;
        }
        //-------------------------------------------------------------------------------
        //Funkcja ma za zadanie przedstawienie na ekranie tylko zadanej liczby probek dla danego wykresu (zgodnie z parametrem window size)
        private void ScaleChartWindow(ChartArea chartArea, double curentPoint, bool aAutoScroll)
        {
      /*      if (chartArea != null)
            {
                //scroluj wykres do nowego punktu chyba ze go aktulnie przesuwam
                if (curentPoint > chartArea.AxisX.ScaleView.Size && aAutoScroll && (MouseButtons != MouseButtons.Right || (MouseButtons == MouseButtons.Right && !ChecMousekArea(chartArea.Position))))
                    chartArea.AxisX.ScaleView.Scroll(curentPoint);

                chartArea.AxisX.ScaleView.Size = windowSize;
                chartArea.AxisX.ScrollBar.Enabled = false;
            }
        */}
        //-------------------------------------------------------------------------------
        //Funkcja ustawia widocznosc wykresow zgodnie z wybranymi preferenacjimi. Widok danych albo na jednym albo na trzech wykreseach
        private void ShowDataOnChart(bool togheter)
        {
            if (chartAreaPressure != null && chartAreaPower != null && chartAreaMFC != null)
            {
                if (togheter)
                {
                    chartAreaPressure.AxisY.Title = "value";
                    chartAreaPower.Visible = false;
                    chartAreaMFC.Visible = false;

                    seriePressure.ChartArea = "ChartAreaPressure";
                    seriePower.ChartArea = "ChartAreaPressure";
                    serieVoltage.ChartArea = "ChartAreaPressure";
                    serieCurent.ChartArea = "ChartAreaPressure";
                    serieFlow1.ChartArea = "ChartAreaPressure";
                    serieFlow2.ChartArea = "ChartAreaPressure";
                    serieFlow3.ChartArea = "ChartAreaPressure";
                }
                else
                {
                    chartAreaPressure.AxisY.Title = "pressure [mBar]";
                    chartAreaPower.Visible = true;
                    chartAreaMFC.Visible = true;

                    seriePressure.ChartArea = "ChartAreaPressure";
                    seriePower.ChartArea = "ChartAreaPower";
                    serieVoltage.ChartArea = "ChartAreaPower";
                    serieCurent.ChartArea = "ChartAreaPower";
                    serieFlow1.ChartArea = "ChartAreaMFC";
                    serieFlow2.ChartArea = "ChartAreaMFC";
                    serieFlow3.ChartArea = "ChartAreaMFC";
                }
            }
        }
        //-------------------------------------------------------------------------------
        //Funkcja ma za zadanie zwrocenie jednej daty jako polaczenie daty i czasu dwoch zmiennych
        private DateTime GetDateTime(DateTime date, DateTime time)
        {
            DateTime dateTime = new DateTime();
            if (date != null && time != null)
            {
                //Poniewaz nie mozna ustawina c wartosci czasu to jednym sposobnem jest ich dodawanie ale najpierw trzeba czas wyzerowac to znaczy ustawic na  00:00:00
                dateTime = date;
                //Ustaw czas na 00:00:00
                dateTime = dateTime.AddHours(-dateTime.Hour);
                dateTime = dateTime.AddMinutes(-dateTime.Minute);
                dateTime = dateTime.AddSeconds(-dateTime.Second);
                //Dodaj czas ktroy nalezy ustawic
                dateTime = dateTime.AddHours(time.Hour);
                dateTime = dateTime.AddMinutes(time.Minute);
                dateTime = dateTime.AddSeconds(time.Second);
            }
            return dateTime;
        }
        //-------------------------------------------------------------------------------
        //Ustaw widocznosc danej serii
        private void cBox_CheckedChanged(object sender, EventArgs e)
        {
            seriePressure.Enabled = cBoxPressure.Checked;
            seriePower.Enabled = cBoxPower.Checked;
            serieVoltage.Enabled = cBoxVoltage.Checked;
            serieCurent.Enabled = cBoxCurent.Checked;
            serieFlow1.Enabled = cBoxFlow1.Checked;
            serieFlow2.Enabled = cBoxFlow2.Checked;
            serieFlow3.Enabled = cBoxFlow3.Checked;

            serieEmpty_Pressure.Enabled = false;
            serieEmpty_Power.Enabled = false;
            serieEmpty_MFC.Enabled = false;

            if (!seriePressure.Enabled)
                serieEmpty_Pressure.Enabled = true;
            if (!seriePower.Enabled && !serieVoltage.Enabled && !serieCurent.Enabled)
                serieEmpty_Power.Enabled = true;
            if (!serieFlow1.Enabled && !serieFlow2.Enabled && !serieFlow3.Enabled)
                serieEmpty_MFC.Enabled = true;
        }
        //-------------------------------------------------------------------------------
        //Wybor preferencji wyswietlania danuych albo na jednym wykresie albo na trzech
        private void toolStripComboBoxChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool togheter = true;

            if (toolStripComboBoxChart.SelectedIndex == 1)
                togheter = false;

            ShowDataOnChart(togheter);
        }
        //-------------------------------------------------------------------------------
        //Funkcja ma za zadanie sprawdzenie nad ktorym ChartArea zostal nacisniety klawisz myszy
        private bool ChecMousekArea(ElementPosition chartAreaPosition)
        {
            bool aRes = false;
            if (mainForm != null)
            {
                double minX = chartAreaPosition.X / 100 * chart.Width;
                double maxX = minX + chartAreaPosition.Width * chart.Width / 100;
                double minY = chartAreaPosition.Y / 100 * chart.Height;
                double maxY = minY + chartAreaPosition.Height * chart.Height / 100;

                double mouseX = MousePosition.X - mainForm.Location.X - Location.X;
                double mouseY = MousePosition.Y - mainForm.Location.Y - Location.Y - 55;

                if (minX < mouseX && maxX > mouseX && minY < mouseY && maxY > mouseY)
                    aRes = true;
            }
            return aRes;
        }
        //-------------------------------------------------------------------------------
        //Funkcja ustawia poczatkowy punkt wzgledem ktroego bedzie sie przesuwal wykres oraz wylacza autoscrol danego wykresu
        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            /*
            int aPosXMouse = 0; // zmienna przechowuje przeliczona wartoasc pozycji myszy na wartosc osi X
            if (chartAreaPressure != null && ChecMousekArea(chartAreaPressure.Position))
            {
                aPosXMouse = (int)(windowSize * e.X / (chartAreaPressure.Position.Width * chart.Width / 100));
                scrollStartPoint_Pressure.X = (int)(chartAreaPressure.AxisX.ScaleView.ViewMinimum + aPosXMouse + e.X);
                autoScroll_Pressure = false;
            }
            if (chartAreaPower != null && ChecMousekArea(chartAreaPower.Position))
            {
                aPosXMouse = (int)(windowSize * e.X / (chartAreaPower.Position.Width * chart.Width / 100));
                scrollStartPoint_Power.X = (int)(chartAreaPower.AxisX.ScaleView.ViewMinimum + aPosXMouse + e.X);
                autoScroll_Power = false;
            }
            if (chartAreaMFC != null && ChecMousekArea(chartAreaMFC.Position))
            {
                aPosXMouse = (int)(windowSize * e.X / (chartAreaMFC.Position.Width * chart.Width / 100));
                scrollStartPoint_MFC.X = (int)(chartAreaMFC.AxisX.ScaleView.ViewMinimum + aPosXMouse + e.X);
                autoScroll_MFC = false;
            }
            */
        }
        //-------------------------------------------------------------------------------
        //Funkcja przesuwa wykres zgdonie z ruchem myszki pod warunkeimn ze prawy przycisk myszy jest zlapany
        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
        /*    if (e.Button == MouseButtons.Right)
            {
                ChartArea chartArea = null;
                double startX = 0;
                if (chartAreaPressure != null && ChecMousekArea(chartAreaPressure.Position))
                {
                    chartArea = chartAreaPressure;
                    startX = scrollStartPoint_Pressure.X;
                }
                if (chartAreaPower != null && ChecMousekArea(chartAreaPower.Position) && chartAreaPower.Visible)
                {
                    chartArea = chartAreaPower;
                    startX = scrollStartPoint_Power.X;
                }
                if (chartAreaMFC != null && ChecMousekArea(chartAreaMFC.Position) && chartAreaMFC.Visible)
                {
                    chartArea = chartAreaMFC;
                    startX = scrollStartPoint_MFC.X;
                }
                if (chartArea != null && Size.Width != 0)
                {
                    double aMove = startX - e.X;
                    chartArea.AxisX.ScaleView.Scroll(aMove);
                }
            }
            */
        }
        //-------------------------------------------------------------------------------
        //Wlaczenie autoscrolu gdy wykres zostal przesuniety do nowych wartosci
        private void chart_MouseUp(object sender, MouseEventArgs e)
        {
            /*
            if (chartAreaPressure != null && ChecMousekArea(chartAreaPressure.Position) && seriePressure.Points.Count - windowSize < chartAreaPressure.AxisX.ScaleView.ViewMaximum)
                autoScroll_Pressure = true;

            if (chartAreaPower != null && ChecMousekArea(chartAreaPower.Position) && seriePower.Points.Count - windowSize < chartAreaPower.AxisX.ScaleView.ViewMaximum)
                autoScroll_Power = true;

            if (chartAreaMFC != null && ChecMousekArea(chartAreaMFC.Position) && serieFlow1.Points.Count - windowSize < chartAreaMFC.AxisX.ScaleView.ViewMaximum)
                autoScroll_MFC = true;
                */
        }
        //-------------------------------------------------------------------------------
        //Kasowanie Zoom danego wykresu
        private void toolStripBtnZoomReset_Click(object sender, EventArgs e)
        {
            if (chartAreaPressure != null)
            {
                chartAreaPressure.AxisX.ScaleView.ZoomReset(0);
                chartAreaPressure.AxisY.ScaleView.ZoomReset(0);
            }

            if (chartAreaPower != null)
            {
                chartAreaPower.AxisX.ScaleView.ZoomReset(0);
                chartAreaPower.AxisY.ScaleView.ZoomReset(0);
            }

            if (chartAreaMFC != null)
            {
                chartAreaMFC.AxisX.ScaleView.ZoomReset(0);
                chartAreaMFC.AxisY.ScaleView.ZoomReset(0);
            }
        }
        //-------------------------------------------------------------------------------
        //Akcja przyciku loadData ma za zadanie pobranie danych z bazy danych
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DateTime startDate = GetDateTime(dateStart.Value, timeStart.Value);
            DateTime endDate = GetDateTime(dateEnd.Value, timeEnd.Value);

            LoadData(startDate, endDate);
        }
        //-------------------------------------------------------------------------------
    }
}

