using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HPT1000.Source;
namespace HPT1000.GUI
{
    public partial class Login : Form
    {
        private Source.DB db = null;

        //-------------------------------------------------------------------------------------------------------------
        public Login()
        {        
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------
        public void SetDB(DB dbPtr)
        {
            db = dbPtr;
        }
        //-------------------------------------------------------------------------------------------------------------
        private void TryLogin()
        {
            if (db != null)
            {
                User user = (User)cBoxUsers.SelectedItem;
                bool aRes = db.ChangeUserApp(user, tBoxPassword.Text);

                if (aRes)
                {
                    Hide();
                }
                else
                    MessageBox.Show("User can't be login. Wrong password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------------------------------------------------------------------------------------
        private void ShowUsers()
        {
            int index = -1;
            if (db != null)
            {
                int i = 0;
                cBoxUsers.Items.Clear();
                foreach (User user in db.Users)
                {
                    cBoxUsers.Items.Add(user);
                    if (DB.LoggedUser.Equals(user))
                        index = i;
                    i++;
                }
            }
            cBoxUsers.SelectedIndex = index;
        }
        //-------------------------------------------------------------------------------------------------------------
        private void btnLogin_Click(object sender, EventArgs e)
        {
            TryLogin();
        }
        //-------------------------------------------------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        //-------------------------------------------------------------------------------------------------------------
        private void Login_Activated(object sender, EventArgs e)
        {
            ShowUsers();
        }
        //-------------------------------------------------------------------------------------------------------------
        private void Login_Deactivate(object sender, EventArgs e)
        {
            cBoxUsers.SelectedIndex = -1;
            tBoxPassword.Text = "";
        }
        //-------------------------------------------------------------------------------------------------------------
        private void tBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TryLogin();
        }
        //-------------------------------------------------------------------------------------------------------------

    }
}
