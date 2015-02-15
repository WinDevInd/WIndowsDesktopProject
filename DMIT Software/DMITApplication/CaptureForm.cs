using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP.Capture;

namespace FingerPrintApplication
{
    delegate void Function(); // delegate to invoke to GUI

    public partial class CaptureForm : Form, DPFP.Capture.EventHandler
    {
        Capture captureObj;
        protected PictureBox currentSelectedPictureBox;
        protected string selectedFinger = "";
        protected string selectedProfile = "";

        public CaptureForm()
        {
            InitializeComponent();
        }

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            try
            {
                captureObj = new Capture();
                captureObj.EventHandler = this;
                captureObj.StartCapture();
                captureObj.StopCapture();
                HandSelectionComboBox.SelectedIndex = 0;
            }
            catch (DPFP.Error.SDKException ex)
            {
                MessageBox.Show("Error occured ! " + ex.Message, "Device SDK Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error occured ! " + ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (captureObj != null)
                {
                    captureObj.StopCapture();
                }
            }
        }

        protected void StartCapture()
        {
            try
            {
                if (captureObj != null)
                {
                    captureObj.StartCapture();
                }
                else
                {
                    MessageBox.Show("Can not initilized with Device ! ", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (DPFP.Error.SDKException ex)
            {
                MessageBox.Show("Error occured ! " + ex.Message, "Device SDK Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (captureObj != null)
                {
                    captureObj.StopCapture();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error occured ! " + ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (captureObj != null)
                {
                    captureObj.StopCapture();
                }
            }
        }

        protected void StopCapture()
        {
            if (captureObj != null)
            {
                captureObj.StopCapture();
            }
        }

        private void handSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FingerSelectionComboBox.SelectedIndex = 0;
        }

        private void FingerSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFinger = Convert.ToString(HandSelectionComboBox.Items[HandSelectionComboBox.SelectedIndex]) + "_" +
                Convert.ToString(FingerSelectionComboBox.Items[FingerSelectionComboBox.SelectedIndex]);

            EnableAllButtonAndResetLabel();
            ClearAllPicture();
        }

        private void ClearAllPicture()
        {
            pictureBoxCennterProfile.Image = pictureBoxLeftProfile.Image = pictureBoxRightProfile.Image = null;
        }

        private void ProfileSelectionChanged(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnProfile = sender as Button;
                switch (btnProfile.Name)
                {
                    case "buttonCenterProfile":
                        pictureBoxCennterProfile.Image = null;
                        currentSelectedPictureBox = pictureBoxCennterProfile;
                        break;
                    case "buttonLeftProfile":
                        pictureBoxLeftProfile.Image = null;
                        currentSelectedPictureBox = pictureBoxLeftProfile;
                        break;
                    case "buttonRightProfile":
                        pictureBoxRightProfile.Image = null;
                        currentSelectedPictureBox = pictureBoxRightProfile;
                        break;
                }
                this.DisableAllButtons();
                this.labelSelectedProfile.Text = selectedProfile = btnProfile.Text;
                this.labelNoOfSamples.Text = "4";
                StartCapture();
            }
        }

        protected void EnableAllButtonAndResetLabel()
        {
            buttonCenterProfile.Enabled = buttonLeftProfile.Enabled = buttonRightProfile.Enabled = true;
            this.labelSelectedProfile.Text = "Not Selected";
            this.labelfingerPrintQuality.Text = "Not Measured";
        }

        private void DisableAllButtons()
        {
            buttonCenterProfile.Enabled = buttonLeftProfile.Enabled = buttonRightProfile.Enabled = false;
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //Not required
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //Not Required
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            this.Invoke(new Function(delegate() { this.labelDeviceStatus.Text = "Connected"; }));
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            this.Invoke(new Function(delegate() { this.labelDeviceStatus.Text = "Disconnected"; }));
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            //not required
        }

        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }

        protected virtual void Process(DPFP.Sample Sample)
        {
            // Draw fingerprint sample image.
            //DrawPicture(ConvertSampleToBitmap(Sample));
        }

        private void CaptureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopCapture();
            this.captureObj.EventHandler = null;
            this.captureObj = null;
        }
    }
}
