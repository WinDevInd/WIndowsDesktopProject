namespace FingerPrintApplication
{
    partial class CaptureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxCennterProfile = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeftProfile = new System.Windows.Forms.PictureBox();
            this.pictureBoxRightProfile = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSelectedProfile = new System.Windows.Forms.Label();
            this.FingerSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.HandSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCenterProfile = new System.Windows.Forms.Button();
            this.buttonLeftProfile = new System.Windows.Forms.Button();
            this.buttonRightProfile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNoOfSamples = new System.Windows.Forms.Label();
            this.labelDeviceStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelfingerPrintQuality = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCennterProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCennterProfile
            // 
            this.pictureBoxCennterProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCennterProfile.Location = new System.Drawing.Point(12, 67);
            this.pictureBoxCennterProfile.Name = "pictureBoxCennterProfile";
            this.pictureBoxCennterProfile.Size = new System.Drawing.Size(112, 130);
            this.pictureBoxCennterProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCennterProfile.TabIndex = 0;
            this.pictureBoxCennterProfile.TabStop = false;
            // 
            // pictureBoxLeftProfile
            // 
            this.pictureBoxLeftProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLeftProfile.Location = new System.Drawing.Point(140, 67);
            this.pictureBoxLeftProfile.Name = "pictureBoxLeftProfile";
            this.pictureBoxLeftProfile.Size = new System.Drawing.Size(112, 130);
            this.pictureBoxLeftProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeftProfile.TabIndex = 1;
            this.pictureBoxLeftProfile.TabStop = false;
            // 
            // pictureBoxRightProfile
            // 
            this.pictureBoxRightProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRightProfile.Location = new System.Drawing.Point(268, 67);
            this.pictureBoxRightProfile.Name = "pictureBoxRightProfile";
            this.pictureBoxRightProfile.Size = new System.Drawing.Size(112, 130);
            this.pictureBoxRightProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRightProfile.TabIndex = 2;
            this.pictureBoxRightProfile.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Current Profile :";
            // 
            // labelSelectedProfile
            // 
            this.labelSelectedProfile.AutoSize = true;
            this.labelSelectedProfile.Location = new System.Drawing.Point(488, 91);
            this.labelSelectedProfile.Name = "labelSelectedProfile";
            this.labelSelectedProfile.Size = new System.Drawing.Size(69, 13);
            this.labelSelectedProfile.TabIndex = 7;
            this.labelSelectedProfile.Text = "Not Selected";
            // 
            // FingerSelectionComboBox
            // 
            this.FingerSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FingerSelectionComboBox.FormattingEnabled = true;
            this.FingerSelectionComboBox.Items.AddRange(new object[] {
            "Thumb_0",
            "Fore_1",
            "Middle_2",
            "Ring_3",
            "Tiny_4"});
            this.FingerSelectionComboBox.Location = new System.Drawing.Point(258, 12);
            this.FingerSelectionComboBox.Name = "FingerSelectionComboBox";
            this.FingerSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.FingerSelectionComboBox.TabIndex = 8;
            this.FingerSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.FingerSelectionComboBox_SelectedIndexChanged);
            // 
            // HandSelectionComboBox
            // 
            this.HandSelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HandSelectionComboBox.FormattingEnabled = true;
            this.HandSelectionComboBox.Items.AddRange(new object[] {
            "Left",
            "RIght"});
            this.HandSelectionComboBox.Location = new System.Drawing.Point(57, 12);
            this.HandSelectionComboBox.Name = "HandSelectionComboBox";
            this.HandSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.HandSelectionComboBox.TabIndex = 9;
            this.HandSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.handSelectionComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hand :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Finger :";
            // 
            // buttonCenterProfile
            // 
            this.buttonCenterProfile.Location = new System.Drawing.Point(31, 210);
            this.buttonCenterProfile.Name = "buttonCenterProfile";
            this.buttonCenterProfile.Size = new System.Drawing.Size(75, 23);
            this.buttonCenterProfile.TabIndex = 12;
            this.buttonCenterProfile.Text = "Center";
            this.buttonCenterProfile.UseVisualStyleBackColor = true;
            this.buttonCenterProfile.Click += new System.EventHandler(this.ProfileSelectionChanged);
            // 
            // buttonLeftProfile
            // 
            this.buttonLeftProfile.Location = new System.Drawing.Point(158, 210);
            this.buttonLeftProfile.Name = "buttonLeftProfile";
            this.buttonLeftProfile.Size = new System.Drawing.Size(75, 23);
            this.buttonLeftProfile.TabIndex = 13;
            this.buttonLeftProfile.Text = "Left";
            this.buttonLeftProfile.UseVisualStyleBackColor = true;
            this.buttonLeftProfile.Click += new System.EventHandler(this.ProfileSelectionChanged);
            // 
            // buttonRightProfile
            // 
            this.buttonRightProfile.Location = new System.Drawing.Point(285, 210);
            this.buttonRightProfile.Name = "buttonRightProfile";
            this.buttonRightProfile.Size = new System.Drawing.Size(75, 23);
            this.buttonRightProfile.TabIndex = 14;
            this.buttonRightProfile.Text = "Right";
            this.buttonRightProfile.UseVisualStyleBackColor = true;
            this.buttonRightProfile.Click += new System.EventHandler(this.ProfileSelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "No of Samples :";
            // 
            // labelNoOfSamples
            // 
            this.labelNoOfSamples.AutoSize = true;
            this.labelNoOfSamples.Location = new System.Drawing.Point(488, 115);
            this.labelNoOfSamples.Name = "labelNoOfSamples";
            this.labelNoOfSamples.Size = new System.Drawing.Size(13, 13);
            this.labelNoOfSamples.TabIndex = 18;
            this.labelNoOfSamples.Text = "4";
            // 
            // labelDeviceStatus
            // 
            this.labelDeviceStatus.AutoSize = true;
            this.labelDeviceStatus.Location = new System.Drawing.Point(488, 67);
            this.labelDeviceStatus.Name = "labelDeviceStatus";
            this.labelDeviceStatus.Size = new System.Drawing.Size(79, 13);
            this.labelDeviceStatus.TabIndex = 20;
            this.labelDeviceStatus.Text = "Not Connected";
            this.labelDeviceStatus.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Device Status :";
            this.label5.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Quality :";
            this.label1.Visible = false;
            // 
            // labelfingerPrintQuality
            // 
            this.labelfingerPrintQuality.AutoSize = true;
            this.labelfingerPrintQuality.Location = new System.Drawing.Point(488, 139);
            this.labelfingerPrintQuality.Name = "labelfingerPrintQuality";
            this.labelfingerPrintQuality.Size = new System.Drawing.Size(74, 13);
            this.labelfingerPrintQuality.TabIndex = 16;
            this.labelfingerPrintQuality.Text = "Not Measured";
            this.labelfingerPrintQuality.Visible = false;
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 260);
            this.Controls.Add(this.labelDeviceStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelNoOfSamples);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelfingerPrintQuality);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRightProfile);
            this.Controls.Add(this.buttonLeftProfile);
            this.Controls.Add(this.buttonCenterProfile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.HandSelectionComboBox);
            this.Controls.Add(this.FingerSelectionComboBox);
            this.Controls.Add(this.labelSelectedProfile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBoxRightProfile);
            this.Controls.Add(this.pictureBoxLeftProfile);
            this.Controls.Add(this.pictureBoxCennterProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaptureForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CaptureForm_FormClosed);
            this.Load += new System.EventHandler(this.CaptureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCennterProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCennterProfile;
        private System.Windows.Forms.PictureBox pictureBoxLeftProfile;
        private System.Windows.Forms.PictureBox pictureBoxRightProfile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSelectedProfile;
        private System.Windows.Forms.ComboBox FingerSelectionComboBox;
        private System.Windows.Forms.ComboBox HandSelectionComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonCenterProfile;
        private System.Windows.Forms.Button buttonLeftProfile;
        private System.Windows.Forms.Button buttonRightProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDeviceStatus;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label labelNoOfSamples;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelfingerPrintQuality;
    }
}