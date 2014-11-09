using RaspberryCam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FingerPrintApplication
{
    public partial class Form1 : Form
    {
        //private WiaSession session;

        const int VIDEODEVICE = 0; // zero based index of video capture device to use
        const int VIDEOWIDTH = 640; // Depends on video device caps
        const int VIDEOHEIGHT = 480; // Depends on video device caps
        const int VIDEOBITSPERPIXEL = 24; // BitsPerPixel values determined by device
        IntPtr m_ip = IntPtr.Zero;
        
        WebCamHelper camHelper = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbGender.DataSource = Enum.GetValues(typeof(Gender));
            cmbGender.SelectedItem = Gender.Male;

            cmbGenderSibling1.DataSource = Enum.GetValues(typeof(Gender));
            cmbGenderSibling1.SelectedItem = Gender.Male;

            cmbGenderSibling2.DataSource = Enum.GetValues(typeof(Gender));
            cmbGenderSibling2.SelectedItem = Gender.Male;


            //var cameras = Cameras.DeclareDevice().Named("Camera 1").WithDevicePath("/dev/video0").Memorize();
            //cameras.Get("Camera 1").SavePicture(new PictureSize(640, 480), "E:/Asp .net vNext/Test1.jpg", 20);

            //WebCam cam= new WebCam();
            //cam.Container = picboxImage;
        }

        public enum Gender
        {
            Male = 1,
            Female = 2
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name");
            sb.Append(" ");
            sb.Append(txtName.Text);
            sb.Append(Environment.NewLine);

            sb.Append("DOB");
            sb.Append(" ");
            sb.Append(dtpDOB.Value.ToShortDateString());
            sb.Append(Environment.NewLine);

            sb.Append("Gender");
            sb.Append(" ");
            sb.Append(cmbGender.SelectedValue.ToString());
            sb.Append(Environment.NewLine);

            sb.Append("Company/School Name");
            sb.Append(" ");
            sb.Append(txtCompanySchoolName.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Designation/Class");
            sb.Append(" ");
            sb.Append(txtDesignation.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Telephone");
            sb.Append(" ");
            sb.Append(txtTelephone.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Mobile");
            sb.Append(" ");
            sb.Append(txtMobile.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Email");
            sb.Append(" ");
            sb.Append(txtEmail.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Address");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);

            sb.Append("House No");
            sb.Append(" ");
            sb.Append(txtHouseNo.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Building Name");
            sb.Append(" ");
            sb.Append(txtBuildingName.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Street Name");
            sb.Append(" ");
            sb.Append(txtStreetName.Text);
            sb.Append(Environment.NewLine);

            sb.Append("State");
            sb.Append(" ");
            sb.Append(txtState.Text);
            sb.Append(Environment.NewLine);

            sb.Append("City");
            sb.Append(" ");
            sb.Append(txtCity.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Postal Code");
            sb.Append(" ");
            sb.Append(txtPostalCode.Text);
            sb.Append(Environment.NewLine);


            sb.Append("ATD-L");
            sb.Append("   ");
            sb.Append("ATD-L");
            sb.Append(" ");
            sb.Append(txtAtdL.Text);
            sb.Append("   ");
            sb.Append("ATD-R");
            sb.Append(" ");
            sb.Append(txtAtdL.Text);

            sb.Append("Consulntant/Franchise Code");
            sb.Append(" ");
            sb.Append(txtFranchiseCode.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Sibling1");
            sb.Append(Environment.NewLine);
            sb.Append("Name");
            sb.Append(" ");
            sb.Append(txtNameSibling1.Text);
            sb.Append(Environment.NewLine);

            sb.Append("DOB");
            sb.Append(" ");
            sb.Append(dtpDOBSibling1.Value.ToShortDateString());
            sb.Append(Environment.NewLine);

            sb.Append("Gender");
            sb.Append(" ");
            sb.Append(cmbGenderSibling1.SelectedValue.ToString());
            sb.Append(Environment.NewLine);


            sb.Append("School");
            sb.Append(" ");
            sb.Append(txtSchoolSibling1.Text);
            sb.Append(Environment.NewLine);


            sb.Append("Class");
            sb.Append(" ");
            sb.Append(txtClassSibling1.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Sibling2");
            sb.Append(Environment.NewLine);
            sb.Append("Name");
            sb.Append(" ");
            sb.Append(txtNameSibling2.Text);
            sb.Append(Environment.NewLine);

            sb.Append("DOB");
            sb.Append(" ");
            sb.Append(dtpDOBSibling2.Value.ToShortDateString());
            sb.Append(Environment.NewLine);

            sb.Append("Gender");
            sb.Append(" ");
            sb.Append(cmbGenderSibling2.SelectedValue.ToString());
            sb.Append(Environment.NewLine);


            sb.Append("School");
            sb.Append(" ");
            sb.Append(txtSchoolSibling2.Text);
            sb.Append(Environment.NewLine);


            sb.Append("Class");
            sb.Append(" ");
            sb.Append(txtClassSibling2.Text);
            sb.Append(Environment.NewLine);


            sb.Append("Father/Husband Name");
            sb.Append(" ");
            sb.Append(txtFatherName.Text);
            sb.Append(Environment.NewLine);


            sb.Append("Father/Husband DOB");
            sb.Append(" ");
            sb.Append(dtpFatherDOB.Value.ToShortDateString());
            sb.Append(Environment.NewLine);

            sb.Append("Father/Husband Occupation");
            sb.Append(" ");
            sb.Append(txtOccupation.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Father/Husband Mobile");
            sb.Append(" ");
            sb.Append(txtMobileNo.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Father/Husband Email");
            sb.Append(" ");
            sb.Append(txtEmailId.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Mother Name");
            sb.Append(" ");
            sb.Append(txtMotherName.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Mother Occupation");
            sb.Append(" ");
            sb.Append(txtMotherOccupation.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Mother Contact No");
            sb.Append(" ");
            sb.Append(txtMotherContactNo.Text);
            sb.Append(Environment.NewLine);

            sb.Append("Mother Email");
            sb.Append(" ");
            sb.Append(txtMotherEmailId.Text);
            sb.Append(Environment.NewLine);

            var sampleFile = File.CreateText("E:/Asp .net vNext/test.txt");
            sampleFile.Write(sb);
            sampleFile.Close();

            ResetValue();

            MessageBox.Show("Data Saved Sucessfully.");
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void ResetValue()
        {
            txtName.Text = string.Empty;
            cmbGender.SelectedItem = Gender.Male;
            txtCompanySchoolName.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtHouseNo.Text = string.Empty;
            txtBuildingName.Text = string.Empty;
            txtStreetName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtAtdL.Text = string.Empty;
            txtAtdR.Text = string.Empty;
            txtFranchiseCode.Text = string.Empty;
            txtNameSibling1.Text = string.Empty;
            cmbGenderSibling1.SelectedItem = Gender.Male;
            txtSchoolSibling1.Text = string.Empty;
            txtClassSibling1.Text = string.Empty;
            txtNameSibling2.Text = string.Empty;
            cmbGenderSibling2.SelectedItem = Gender.Male;
            txtSchoolSibling2.Text = string.Empty;
            txtClassSibling2.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtOccupation.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMotherName.Text = string.Empty;
            txtMotherOccupation.Text = string.Empty;
            txtMotherContactNo.Text = string.Empty;
            txtMotherEmailId.Text = string.Empty;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //WebCam cam = new WebCam();            
            //cam.OpenConnection();
            if (camHelper != null)
            {
                return;
            }

            try
            {
                camHelper = new WebCamHelper(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, picboxImage);
            }
            catch
            {
                MessageBox.Show("No Camera device detected ! Please connect new or update driver");
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            //WebCam cam = new WebCam();
            //cam.SaveImage();
            Cursor.Current = Cursors.WaitCursor;

            // Release any previous buffer
            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }
            
            m_ip = camHelper.Click();
            Bitmap b = new Bitmap(camHelper.Width, camHelper.Height, camHelper.Stride, PixelFormat.Format24bppRgb, m_ip);

            // If the image is upsidedown
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBoxCapturedImage.Image = b;
            
            SaveImage(b, "captured");

            Cursor.Current = Cursors.Default;
        }

        private void SaveImage(Bitmap bitmapImage, string filePath)
        {
            if(bitmapImage != null && !string.IsNullOrWhiteSpace(filePath))
            {
                bitmapImage.Save(filePath +".jpg");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeManagedResources();
        }

        private void DisposeManagedResources()
        {
            if (camHelper != null)
            {
                camHelper.Dispose();
                camHelper = null;
            }

            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }
        }
    }
}
