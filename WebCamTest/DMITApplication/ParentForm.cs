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

    public partial class ParentForm : Form
    {
        Form1 clientForm;
        CreateUser createUserForm;
        public ParentForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientForm == null || clientForm.IsDisposed)
            {
                clientForm = new Form1();
            }

            CloseAll(false);
            clientForm.MdiParent = this;
            clientForm.Show();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (createUserForm == null || createUserForm.IsDisposed)
            {
                createUserForm = new CreateUser();
            }

            CloseAll(false);
            createUserForm.MdiParent = this;
            createUserForm.Show();
        }

        private void CloseAll(bool isDisposing)
        {

            try
            {
                if (createUserForm != null)
                {
                    if (isDisposing)
                    {
                        createUserForm.Close();
                    }
                    else
                    {
                        createUserForm.Hide();
                    }
                }

                if (clientForm != null)
                {
                    if (isDisposing)
                    {
                        clientForm.Close();
                    }
                    else
                    {
                        clientForm.Hide();
                    }
                }
            }
            catch { }
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseAll(true);
        }
    }
}
