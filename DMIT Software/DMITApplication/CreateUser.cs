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
            if (ValidateData())
            {
                DataRow user = fSDataSet.Tables[0].NewRow();
                user[1] = txtName.Text;
                user[2] = txtPassword.Text.ToString().GetHashCode();
                user[3] = Enum.GetName(typeof(UserType), cmbUserType.SelectedItem);
                user[4] = (txtDesignation.Text == String.Empty) ? "Not Spacified" : txtDesignation.Text;
                user[5] = txtUsername.Text;
                fSDataSet.Tables[0].Rows.Add(user);
                fSDataSet.WriteXml(Config);
                MessageBox.Show(txtUsername.Text + " : User created sucessfully.");
                RefreshControls();
            }
            //Validation faileds
        }


        private bool ValidateData()
        {
            StringBuilder sb = new StringBuilder();

            if (txtName.Text == string.Empty)
            {
                sb.Append("Please Enter the Name.");
                sb.Append(Environment.NewLine);
            }

            if (txtPassword.Text == string.Empty)
            {
                sb.Append("Please Enter the password.");
                sb.Append(Environment.NewLine);
            }

            if (txtReTypePassword.Text == string.Empty)
            {
                sb.Append("Please Enter the Re-Type Password.");
                sb.Append(Environment.NewLine);
            }

            if (txtUsername.Text == string.Empty)
            {
                sb.Append("Please Enter Username.");
                sb.Append(Environment.NewLine);
            }

            if (txtPassword.Text != txtReTypePassword.Text)
            {
                sb.Append("Password and Re-Type Password should be same.");
                sb.Append(Environment.NewLine);
            }

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fSDataSet.Clear();
            fSDataSet.ReadXml(Config);
            this.userBindingSource.DataSource = fSDataSet;
            RefreshControls();

        }

        private void RefreshControls()
        {
            txtReTypePassword.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDesignation.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
