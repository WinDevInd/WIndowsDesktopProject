using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FingerPrintApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private String configFile = Util.GetConfigFilepath();


        private void Login_Load(object sender, EventArgs e)
        {
            if (!Util.CreateDefaultDataSet())
            {
                DialogResult res = MessageBox.Show("Config file is corrupted or missing ! install application again", "Config error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (res == DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
            }

            this.fSDataSet.ReadXml(configFile);

            if (Util.VarifyConfig(fSDataSet))
            {
                MessageBox.Show("Config file is corrupted or missing ! Reseting User Database file", "Config error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Util.CreateDefaultDataSet();
            }

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(2014, 12, 8);

            string userName = txtUserName.Text;
            string pass = txtPassword.Text;

            if (DateTime.Now >= dt)
            {
                MessageBox.Show("Evolution period Expired...! Please contact vendor", "Tral Expired", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (varifyUser(userName, pass))
            {
                ParentForm frm1 = new ParentForm();
                frm1.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Please Enter the valid Username and Password.");
            }
        }

        //check config file
        private bool varifyUser(string userName, string Password)
        {
            foreach (DataRow item in fSDataSet.Tables["User"].Rows)
            {
                string user = item.ItemArray[5].ToString();
                string pass = item.ItemArray[2].ToString();

                if (user.Trim().Equals(userName) && (pass == Password.GetHashCode().ToString()))
                {
                    return true;
                }
            }

            return false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
