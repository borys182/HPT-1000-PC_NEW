using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using HPT1000.Source;
using HPT1000.Source.Program;

namespace HPT1000.GUI
{
    public partial class AlertsPanel : UserControl
    {
        private Source.Driver.HPT1000 hpt1000 = null;

        //---------------------------------------------------------------------------------------
        public Source.Driver.HPT1000 HPT1000
        {
            set { hpt1000 = value; }
            get { return hpt1000; }
        }
        //---------------------------------------------------------------------------------------
        public AlertsPanel()
        {
            InitializeComponent();
        }
        //----------------------------------------------------------------------------------
        public void  RefreshPanel()
        {
            ShowErrorList();
        }
        //----------------------------------------------------------------------------------
        private void ShowErrorList()
        {
            string aNameProgram     = "Program";
            string aNameSubprogram  = "Subprogram";

            for (int i = 0; i < Logger.GetLogList().Count; i++)
            {
                ItemLogger aErr = Logger.GetLogList()[i];

                if (aErr.IsError() && !IsErrorAlreadyExistInList(aErr))
                {
                    aNameProgram    = GetNameProgram(aErr.ProgramID);
                    aNameSubprogram = GetNameSubprogram(aErr.SubprogramID);

                    ListViewItem aItem = new ListViewItem();
                    aItem.Text = "0x" + aErr.GetErrorCode().ToString("X8");
                    aItem.SubItems.Add(aErr.Time.ToString());
                    aItem.SubItems.Add(aErr.GetText());
                    aItem.SubItems.Add("Event");
                    aItem.SubItems.Add(aNameProgram);
                    aItem.SubItems.Add(aNameSubprogram);
                    aItem.SubItems.Add("Administrator");

                    aItem.BackColor = Color.Red;
                    aItem.Tag = aErr;

                    listViewErrors.Items.Add(aItem);
                }
            }
        }
        //----------------------------------------------------------------------------------
        private string GetNameProgram(int aId)
        {
            string aName = "----------";

            if(hpt1000 != null)
            {
                foreach(Program program in hpt1000.GetPrograms())
                {
                    if(program.GetID() == aId)
                    {
                        aName = program.GetName();
                        break;
                    }
                }
            }

            return aName;
        }
        //----------------------------------------------------------------------------------
        private string GetNameSubprogram(int aId)
        {
            string aName = "----------";

            if (hpt1000 != null)
            {
                foreach (Program program in hpt1000.GetPrograms())
                {
                    foreach (Subprogram subprogram in program.GetSubprograms())
                    {
                        if (subprogram.ID == aId)
                        {
                            aName = subprogram.GetName();
                            break;
                        }
                    }
                }
            }
            return aName;
        }
        //----------------------------------------------------------------------------------
        private bool IsErrorAlreadyExistInList(ItemLogger aErr)
        {
            bool aRes = false;

            foreach (ListViewItem aItem in listViewErrors.Items)
            {
                if (aErr.Equals(aItem.Tag))
                    aRes = true;
            }
            return aRes;
        }
        //----------------------------------------------------------------------------------
        private void listViewErrors_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                // Draw the standard header background.
                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont = new Font("Microsoft Sans Serif", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.Black, e.Bounds, sf);
                }

                // Draw the background for an unselected item.
                using (LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, Color.LightBlue, Color.SkyBlue, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
                e.DrawText();
            }
            return;
         }
        //----------------------------------------------------------------------------------
        private void listViewErrors_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
                e.DrawFocusRectangle();
            }
            else
            {
                // Draw the background for an unselected item.
                using (LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, Color.LightGray, Color.Gray, LinearGradientMode.Horizontal))
                {
                 //   e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }

            // Draw the item text for views other than the Details view.
            //e.DrawText();      
        }
        //----------------------------------------------------------------------------------
        private void listViewErrors_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left;

            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        flags = TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        flags = TextFormatFlags.Right;
                        break;
                }

                // Draw the subitem text in red to highlight it. 
                e.Graphics.DrawString(e.SubItem.Text, listViewErrors.Font, Brushes.Red, e.Bounds, sf);
                
                // Draw normal text for a subitem with a nonnegative 
                // or nonnumerical value.
                //         e.DrawText(flags);
            }
        }
        //----------------------------------------------------------------------------------
    }
}
