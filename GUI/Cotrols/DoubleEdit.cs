using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPT1000.GUI.Cotrols
{
    public partial class DoubleEdit : UserControl
    {
        private bool flagChangeFontColor = false;
        private bool flagChangeBackColor = false;
        private bool isOperationOK      = true;   //flaga okresla czy udalo sie wykonac poprawnie operacje w zdarzeniu EnterOn
        private int  counter = 0;
         
        private double minValue { get; set; }
        private double maxValue { get; set; }
        private string mask     { get; set; } 

        public delegate bool MakeOperation();
        public event MakeOperation EnterOn;

        //-----------------------------------------------------------------------------
        public DoubleEdit()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------
        public double MinimumValue
        {
            set { minValue = value; }
            get { return minValue; }
        }
        //-----------------------------------------------------------------------------
        public double MaximumValue
        {
            set { maxValue = value; }
            get { return maxValue; }
        }
        //-----------------------------------------------------------------------------
        public string Mask
        {
            set { mask =  value; }
            get { return mask; }
        }
        //-----------------------------------------------------------------------------
        public bool ReadOnly
        {
            set { tBox.ReadOnly = value; }
            get { return tBox.ReadOnly; }
        }
        //-----------------------------------------------------------------------------
        public double Value
        {
            set
            {
                double aValue = value;
                if (aValue < minValue) aValue = minValue;
                if (aValue > maxValue) aValue = maxValue;
                if (!tBox.Focused && mask != null)
                    tBox.Text = String.Format(GetMask(), aValue);
            }
            get { return GetValue(tBox.Text); }
        }
        //-----------------------------------------------------------------------------
        public string GetMask()
        {
            string aRes = "{0:F}";
            int aPlaceComa = 0;

            if (mask.Contains(",")) aPlaceComa = mask.IndexOf(',');
            if (mask.Contains(".")) aPlaceComa = mask.IndexOf('.');

            if (mask.Contains(",") || mask.Contains("."))
                aRes = "{0:F" + (mask.Length - aPlaceComa - 1).ToString() + "}";
           
            return aRes;
        }
        //-----------------------------------------------------------------------------
        public double GetValue(string aTxt)
        {
            double aValue = 0;

            CheckFloatStringValue(aTxt,out aValue);

            return aValue;
        }
        //-----------------------------------------------------------------------------
        private bool CheckFloatStringValue(string aTxt, out double aValue)
        {
            bool aRes = false;

            if (Double.TryParse(aTxt, out aValue))
                aRes = true;
            else
                aValue = 0;

            return aRes;
        }
        //-----------------------------------------------------------------------------
        private void tBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            double aValue = 0;
            //Jezeli string nie zawiera liczby to nie wpisuj jej do pola 
            if (sender is TextBox && !CheckFloatStringValue(((TextBox)sender).Text + e.KeyChar, out aValue) && (int)e.KeyChar != 8)
                e.Handled = true;
        }
        //-----------------------------------------------------------------------------
        public void tBox_KeyUp(object sender, KeyEventArgs e)
        {
            double aValue = 0;
            if (e.KeyCode == Keys.Enter && CheckFloatStringValue(tBox.Text, out aValue))
            {
                if (EnterOn != null)
                    isOperationOK = EnterOn();
                counter = 0;
                flagChangeFontColor = true;
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
                grBoxFocuse.Focus();
        }
        //-----------------------------------------------------------------------------
        private void timer_Tick(object sender, EventArgs e)
        {
            if (flagChangeFontColor)
            {
                if(isOperationOK)   tBox.ForeColor = Color.Blue;
                else                tBox.ForeColor = Color.Red;
            }
            else
                tBox.ForeColor = Color.Black;

            if (flagChangeBackColor) tBox.BackColor = Color.Red;
            else                     tBox.BackColor = Color.White;

            if (counter > 1)
            {
                flagChangeFontColor = false;
                flagChangeBackColor = false;
            }
            counter++;
        }
        //-----------------------------------------------------------------------------
        private void tBox_Validated(object sender, EventArgs e)
        {
            double aValue = 0;
            CheckFloatStringValue(tBox.Text, out aValue);

            if (aValue < minValue)
            {
                aValue = minValue;
                counter = 0;
                flagChangeBackColor = true;
            }
            if (aValue > maxValue)
            {
                aValue = maxValue;
                counter = 0;
                flagChangeBackColor = true;
            }
            if(mask != null)
                tBox.Text = String.Format(GetMask(), aValue);
        }
        //-----------------------------------------------------------------------------

    }
}
