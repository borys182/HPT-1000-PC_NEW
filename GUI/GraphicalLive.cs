using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using HPT1000.Source.Chamber;
using HPT1000.Source.Driver;

namespace HPT1000.GUI
{
    /*Panel jest odpowiedzialny za rysowanie aktualnych danych na wykresie liniowym
    Wykres powinien zawierac:
        - pokaz danych z danego okna
        - automatyczne przesuwanie sie wykresu z nowymi danymi
        - mozliwosc zobaczenia danych spoza danego okna
        - zoom
    */
    public partial class GraphicalLive : UserControl
    {
        //Serie danych
        Series seriePressure = new System.Windows.Forms.DataVisualization.Charting.Series("Pressure: [mBar]");
        Series seriePower    = new System.Windows.Forms.DataVisualization.Charting.Series("Power: [W]");
        Series serieVoltage  = new System.Windows.Forms.DataVisualization.Charting.Series("Voltage: [V]");
        Series serieCurent   = new System.Windows.Forms.DataVisualization.Charting.Series("Curent: [A]");
        Series serieFlow1    = new System.Windows.Forms.DataVisualization.Charting.Series("Gas flow 1: [sccm]");
        Series serieFlow2    = new System.Windows.Forms.DataVisualization.Charting.Series("Gas flow 2: [sccm]");
        Series serieFlow3    = new System.Windows.Forms.DataVisualization.Charting.Series("Gas flow 3: [sccm]");

        //serie danhych wykorzystywanych do dodania do wykresu aby przy braku zadnej seri wykres sie nie chowal
        Series serieEmpty_Pressure  = new System.Windows.Forms.DataVisualization.Charting.Series("EmptyPressure");
        Series serieEmpty_Power     = new System.Windows.Forms.DataVisualization.Charting.Series("EmptyPower");
        Series serieEmpty_MFC       = new System.Windows.Forms.DataVisualization.Charting.Series("EmptyMFC");

        //wskazniki obiektow z ktorych czytane sa dane
        PressureControl presure         = null;
        ForePump        forePump        = null;
        MFC             mfc             = null;
        PowerSupplay    powerSupplay    = null;
        Vaporizer       vaporizer       = null;

        //wskaznik na forme jest potrzebny do wyliczania poprawnej pozycji kursora na formatce
        Form mainForm = null;

        //Szerokosc okna danych - okresla ile danych jest pokazanych jednorazowan na wykresie
        double windowSize = 200;

        //Zmienne pomocnioecze przy przesuwanieu wykresu. Okreslaja poczatkowe klikniecie myszka w wykres podczas przesuwania
        Point scrollStartPoint_Pressure;
        Point scrollStartPoint_Power;
        Point scrollStartPoint_MFC;

        //Mamy mozliwosc prezentacji danych zbiorczych na jednym wykresie lub podzilonych na trzy wykresy
        ChartArea chartAreaPressure = null;
        ChartArea chartAreaPower    = null;
        ChartArea chartAreaMFC      = null;

        //Flagi automatycznego scrolowania danego wykresu
        bool autoScroll_Pressure    = true;
        bool autoScroll_Power       = true;
        bool autoScroll_MFC         = true;

        //-------------------------------------------------------------------------------
        public Form MainForm
        {
            set { mainForm = value; }
        }
        //-------------------------------------------------------------------------------
        public GraphicalLive()
        {
            InitializeComponent();
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

            toolStripBtnClear.Image = clearIcone;
        }
        //-------------------------------------------------------------------------------
        //Funkcja ma za zadanie przygotowanie konfiguracji seri i wykresu
        private void ConfigChart()
        {
            //Ustaw koory serii
            seriePressure.Color = Color.Blue;
            seriePower.Color    = Color.Red;
            serieVoltage.Color  = Color.Green;
            serieCurent.Color   = Color.DeepPink;
            serieFlow1.Color    = Color.DarkOrange;
            serieFlow2.Color    = Color.DarkViolet;
            serieFlow3.Color    = Color.DeepSkyBlue;
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
            }
            //Ustaw BackColor checkBoxom odpowiedzialnym za wizualizacje danej serii
            cBoxPressure.ForeColor  = seriePressure.Color;
            cBoxPower.ForeColor     = seriePower.Color;
            cBoxVoltage.ForeColor   = serieVoltage.Color;
            cBoxCurent.ForeColor    = serieCurent.Color;
            cBoxFlow1.ForeColor     = serieFlow1.Color;
            cBoxFlow2.ForeColor     = serieFlow2.Color;
            cBoxFlow3.ForeColor     = serieFlow3.Color;

            //ustaw widocznosc serii tak jak sa poustawiane checkboxy
            cBox_CheckedChanged(null,EventArgs.Empty);
            //przypisz na sztywno puste serie dla konkretnych chart area aby wykres sie nie chowal gdy nie ma zadnej serii
            serieEmpty_Pressure.ChartArea = "ChartAreaPressure";
            serieEmpty_Power.ChartArea    = "ChartAreaPower";
            serieEmpty_MFC.ChartArea      = "ChartAreaMFC";
            //Dodaj punktu do pustych seri aby wykres sie wyswietlil
            serieEmpty_MFC.Points.AddY(0);
            serieEmpty_Power.Points.AddY(0);
            serieEmpty_Pressure.Points.AddY(0);
            //Inicjalizacja ChartArea danych wykresow
            chartAreaPressure   = chart.ChartAreas.FindByName("ChartAreaPressure");
            chartAreaPower      = chart.ChartAreas.FindByName("ChartAreaPower");
            chartAreaMFC        = chart.ChartAreas.FindByName("ChartAreaMFC");
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

            //Ustawiam widok charta od 0 - przesuniecie wykresu do poczatku ukladu wspolrzednych
            if (chartAreaPressure != null)
                chartAreaPressure.AxisX.ScaleView.Scroll(0.0);
            if (chartAreaPower != null)
                chartAreaPower.AxisX.ScaleView.Scroll(0.0);
            if (chartAreaMFC != null)
                chartAreaMFC.AxisX.ScaleView.Scroll(0.0);
        }
        //-------------------------------------------------------------------------------
        //Aktualizacja danych na wykresie. Funkcja wywolywana z watku glownego aplikacji po odczytaniuy danych z PLC
        public void UpdateData()
        {
            //Odczytaj dane z danych obiektow i dodaj jako punkty do konkretnej serii
            if (presure != null)
                seriePressure.Points.AddY(presure.GetPressure());

            if (powerSupplay != null)
            {
                seriePower.Points.AddY(powerSupplay.Power);
                serieVoltage.Points.AddY(powerSupplay.Voltage);
                serieCurent.Points.AddY(powerSupplay.Curent);
            }
            if (mfc != null)
            {
                serieFlow1.Points.AddY(mfc.GetActualFlow(1,Types.UnitFlow.sccm));
                serieFlow2.Points.AddY(mfc.GetActualFlow(2,Types.UnitFlow.sccm));
                serieFlow3.Points.AddY(mfc.GetActualFlow(3,Types.UnitFlow.sccm));
            }
            //Wywolaj funkcje skalujace wykres, to znaczy przesuwajace okno zgodnie z nadchodzacymi nowymi wartosciami
            ScaleChartWindow(chartAreaPressure, seriePressure.Points.Count, autoScroll_Pressure);
            ScaleChartWindow(chartAreaPower,    seriePower.Points.Count,    autoScroll_Power);
            ScaleChartWindow(chartAreaMFC,      serieFlow1.Points.Count,    autoScroll_MFC);
        }
        //-------------------------------------------------------------------------------
        //Funkcja ma za zadanie przedstawienie na ekranie tylko zadanej liczby probek dla danego wykresu (zgodnie z parametrem window size)
        private void ScaleChartWindow(ChartArea chartArea, double curentPoint,bool aAutoScroll)
        {
            if (chartArea != null)
            {
                //scroluj wykres do nowego punktu chyba ze go aktulnie przesuwam
                if (curentPoint > chartArea.AxisX.ScaleView.Size && aAutoScroll && (MouseButtons != MouseButtons.Right || (MouseButtons == MouseButtons.Right && !ChecMousekArea(chartArea.Position))))
                    chartArea.AxisX.ScaleView.Scroll(curentPoint);

                chartArea.AxisX.ScaleView.Size = windowSize;
                chartArea.AxisX.ScrollBar.Enabled = false;
            }
        }
        //-------------------------------------------------------------------------------
        //Funkcja ustawia widocznosc wykresow zgodnie z wybranymi preferenacjimi. Widok danych albo na jednym albo na trzech wykreseach
        private void ShowDataOnChart(bool togheter)
        {
            if (chartAreaPressure != null && chartAreaPower != null && chartAreaMFC != null)
            {
                if (togheter)
                {
                    chartAreaPressure.AxisY.Title = "value";
                    chartAreaPower.Visible        = false;
                    chartAreaMFC.Visible          = false;

                    seriePressure.ChartArea = "ChartAreaPressure";
                    seriePower.ChartArea    = "ChartAreaPressure";
                    serieVoltage.ChartArea  = "ChartAreaPressure";
                    serieCurent.ChartArea   = "ChartAreaPressure";
                    serieFlow1.ChartArea    = "ChartAreaPressure";
                    serieFlow2.ChartArea    = "ChartAreaPressure";
                    serieFlow3.ChartArea    = "ChartAreaPressure";
                }
                else
                {
                    chartAreaPressure.AxisY.Title = "pressure [mBar]";
                    chartAreaPower.Visible        = true;
                    chartAreaMFC.Visible          = true;

                    seriePressure.ChartArea = "ChartAreaPressure";
                    seriePower.ChartArea    = "ChartAreaPower";
                    serieVoltage.ChartArea  = "ChartAreaPower";
                    serieCurent.ChartArea   = "ChartAreaPower";
                    serieFlow1.ChartArea    = "ChartAreaMFC";
                    serieFlow2.ChartArea    = "ChartAreaMFC";
                    serieFlow3.ChartArea    = "ChartAreaMFC";
                }
            }
        }
        //-------------------------------------------------------------------------------
        //Grupa funkcji aktualizujaca wskazniki obiektow z ktorych sa czytane dane
        public void SetPresureObjPtr(PressureControl aPressure)
        {
            presure = aPressure;
        }
        //-------------------------------------------------------------------------------
        public void SetForePumpObjPtr(ForePump aPump)
        {
            forePump = aPump;
        }
        //-------------------------------------------------------------------------------
        public void SetMFCObjPtr(MFC aMFC)
        {
            mfc = aMFC;
        }
        //-------------------------------------------------------------------------------
        public void SetPowerSupplayObjPtr(PowerSupplay aPowerSupply)
        {
            powerSupplay = aPowerSupply;
        }
        //-------------------------------------------------------------------------------
        public void SetVaporizerObjPtr(Vaporizer aVaporizer)
        {
            vaporizer = aVaporizer;
        }
        //-------------------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearChart();
        }
        //-------------------------------------------------------------------------------
        //Ustaw widocznosc danej serii
        private void cBox_CheckedChanged(object sender, EventArgs e)
        {
            seriePressure.Enabled   = cBoxPressure.Checked;
            seriePower.Enabled      = cBoxPower.Checked;
            serieVoltage.Enabled    = cBoxVoltage.Checked;
            serieCurent.Enabled     = cBoxCurent.Checked;
            serieFlow1.Enabled      = cBoxFlow1.Checked;
            serieFlow2.Enabled      = cBoxFlow2.Checked;
            serieFlow3.Enabled      = cBoxFlow3.Checked;

            serieEmpty_Pressure.Enabled = false;
            serieEmpty_Power.Enabled    = false;
            serieEmpty_MFC.Enabled      = false;

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

            double minX = chartAreaPosition.X / 100 * chart.Width;
            double maxX = minX + chartAreaPosition.Width  * chart.Width / 100;
            double minY = chartAreaPosition.Y / 100 * chart.Height;
            double maxY = minY + chartAreaPosition.Height * chart.Height / 100;

            double mouseX = MousePosition.X - mainForm.Location.X - Location.X;
            double mouseY = MousePosition.Y - mainForm.Location.Y - Location.Y - 55;

            if (minX < mouseX && maxX > mouseX && minY < mouseY && maxY > mouseY)
                aRes = true;

            return aRes;
        }   
        //-------------------------------------------------------------------------------
        //Funkcja ustawia poczatkowy punkt wzgledem ktroego bedzie sie przesuwal wykres oraz wylacza autoscrol danego wykresu
        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
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
        }
        //-------------------------------------------------------------------------------
        //Funkcja przesuwa wykres zgdonie z ruchem myszki pod warunkeimn ze prawy przycisk myszy jest zlapany
        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
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
                    double aMove   = startX - e.X;
                    chartArea.AxisX.ScaleView.Scroll(aMove);
                }
            }
        }
        //-------------------------------------------------------------------------------
        //Wlaczenie autoscrolu gdy wykres zostal przesuniety do nowych wartosci
        private void chart_MouseUp(object sender, MouseEventArgs e)
        {
            if(chartAreaPressure != null && ChecMousekArea(chartAreaPressure.Position) && seriePressure.Points.Count - windowSize < chartAreaPressure.AxisX.ScaleView.ViewMaximum)
                autoScroll_Pressure = true;

            if (chartAreaPower != null && ChecMousekArea(chartAreaPower.Position) && seriePower.Points.Count - windowSize < chartAreaPower.AxisX.ScaleView.ViewMaximum)
                autoScroll_Power = true;

            if (chartAreaMFC != null && ChecMousekArea(chartAreaMFC.Position) && serieFlow1.Points.Count - windowSize < chartAreaMFC.AxisX.ScaleView.ViewMaximum)
                autoScroll_MFC = true;
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

    }
}
