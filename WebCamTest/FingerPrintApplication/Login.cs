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

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(2014, 12, 5);

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

        private void button2_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        //check config file
        private bool varifyUser(string userName, string Password)
        {
            if (!System.IO.File.Exists(configFile))
            {
                MessageBox.Show("Configuration does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Util.CreadeDefaultDataSet();
            this.fSDataSet.ReadXml(configFile);

        }
    }
}
