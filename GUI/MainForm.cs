﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPT1000.Source.Driver;
using HPT1000.Source.Chamber;

namespace HPT1000.GUI
{
    ///<summary>
    ///Klasa jest odpowiedzialna za reprezentowanie glownego okna programu
    ///</summary>
    public partial class MainForm : Form
    {
        #region Private

        private HPT1000.Source.Driver.HPT1000 hpt = new HPT1000.Source.Driver.HPT1000();

        #endregion

        public MainForm()
        {
            InitializeComponent();
            //   StateValve state = hpt.GetStateValves(TypeValve.SV);
            //   state = hpt.GetStateValves(Types.TypeValve.VV);

            float test = 255;
            byte[] input = new byte[4];
            input = BitConverter.GetBytes(test);

            int[] aData = new int[2];
            aData[0] = (int)(input[1] << 8 | input[0]);
            aData[1] = (int)(input[3] << 8 | input[2]);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBoxMsg.Text = "Connecting ...";
            
            int aRes = hpt.Connect();

            if (aRes == 0)
                txtBoxMsg.Text = "Connection OK";
            else
                txtBoxMsg.Text = "Connection faild " + String.Format("0x{0:x8}", aRes);
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            int[] aData = new int[1];
            aData[0] = Int32.Parse(txtBoxValue.Text);
            int aRes = hpt.WriteWords(txtBoxAddr.Text,1,aData);

            if (aRes == 0)
                txtBoxMsg.Text = "Write OK";
            else
                txtBoxMsg.Text = "Write faild " + String.Format("0x{0:x8}", aRes);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            int[] aData = new int[1];

            int aRes = hpt.ReadWords(txtBoxAddr.Text, 1, aData);
            txtBoxValue.Text = String.Format("0x{0:x8}", aData[0]);
            if (aRes == 0)
                txtBoxMsg.Text = "Read OK";
            else
                txtBoxMsg.Text = "Read faild " + String.Format("0x{0:x8}", aRes);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int iRes = 0;
            if (rBtnOpen.Checked)
                iRes = hpt.SetStateValve(Types.StateValve.Open, Types.TypeValve.VV);
            else
                iRes = hpt.SetStateValve(Types.StateValve.Close, Types.TypeValve.VV);

            if (iRes == 0)
                txtBoxMsg.Text = "Set OK";
            else
                txtBoxMsg.Text = "Set faild " + String.Format("0x{0:x8}", iRes);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            hpt.Run();
        }

        private void btnGetState_Click(object sender, EventArgs e)
        {

            Types.StateValve state = hpt.GetStateValve(Types.TypeValve.SV);
            state = hpt.GetStateValve(Types.TypeValve.VV);
            state = hpt.GetStateValve(Types.TypeValve.V2);
            state = hpt.GetStateValve(Types.TypeValve.V3);
            state = hpt.GetStateValve(Types.TypeValve.V4);
            state = hpt.GetStateValve(Types.TypeValve.Flow1);
            state = hpt.GetStateValve(Types.TypeValve.Flow2);
        }
    }
}
