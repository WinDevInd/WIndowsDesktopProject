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
    public partial class CreateUser : Form
    {
        private string Config = Util.GetConfigFilepath();

        public CreateUser()
        {
            InitializeComponent();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

            cmbUserType.DataSource = Enum.GetValues(typeof(UserType));
            cmbUserType.SelectedItem = UserType.Type1;
            LoadConfig();
        }

        public enum UserType
        {
            Type1 = 1,
            Type2 = 2
        }

        private void LoadConfig()
        {
            if (!System.IO.File.Exists(Config))
            {
                Application.Exit();
                return;
            }
            fSDataSet.ReadXml(Config);
            this.userBindingSource.DataSource = fSDataSet;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                DataRow user = fSDataSet.Tables[0].NewRow();
                user[1] = txtName.Text;
                user[2] = txtPassword.Text.ToString().GetHashCode();
                user[3] = Enum.GetName(typeof(UserType), cmbUserType.SelectedItem);
                user[4] = txtDesignation.Text;
                user[5] = txtUsername.Text;
                fSDataSet.Tables[0].Rows.Add(user);
                fSDataSet.WriteXml(Config);
            }
            //Validation faileds
        }


        private bool Validate()
        {
            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fSDataSet.Clear();
            fSDataSet.ReadXml(Config);
            this.userBindingSource.DataSource = fSDataSet;
                       
        }
    }
}
