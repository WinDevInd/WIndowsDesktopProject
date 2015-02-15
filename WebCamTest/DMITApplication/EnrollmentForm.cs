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
    public partial class EnrollmentForm : CaptureForm
    {
        private DPFP.Processing.Enrollment Enroller;
        public EnrollmentForm()
        {
            InitializeComponent();
        }

        protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);

            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            // Check quality of the sample and add to enroller if it's good
            if (features != null)
                try
                {
                    Enroller.AddFeatures(features);		// Add feature set to template.
                }
                catch { }
                finally
                {

                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            //OnTemplate(Enroller.Template);
                            this.Invoke(new Function(delegate
                            {
                                Bitmap image = this.ConvertSampleToBitmap(Sample);
                                this.currentSelectedPictureBox.Image = image;
                                SaveImage(selectedFinger + "_" + selectedProfile, image);
                                this.labelNoOfSamples.Text = "Image Captured";
                                this.EnableAllButtonAndResetLabel();

                            }));
                            base.StopCapture();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:
                            Enroller.Clear();
                            base.StopCapture();
                            base.StartCapture();
                            break;
                        case DPFP.Processing.Enrollment.Status.Insufficient:
                            this.Invoke(new Function(delegate
                            {
                                this.labelNoOfSamples.Text = Enroller.FeaturesNeeded.ToString() + " more";
                                Bitmap image = this.ConvertSampleToBitmap(Sample);
                                this.currentSelectedPictureBox.Image = image;
                            }));
                            break;
                    }
                }
        }


        private void SaveImage(string fileName, Bitmap image)
        {
            if (!System.IO.Directory.Exists("C:/FingerScan/Temp"))
            {
                System.IO.Directory.CreateDirectory("C:/FingerScan/Temp");
            }

            if (image != null)
            {
                image.Save("C:/FingerScan/Temp/" + fileName + ".jpg");
            }
        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            Enroller = new DPFP.Processing.Enrollment();
        }
    }
}
