
namespace View
{
    partial class ImageView
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
            this.pictureBoxEditImage = new System.Windows.Forms.PictureBox();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.labelContrast = new System.Windows.Forms.Label();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.trackBarContrast = new System.Windows.Forms.TrackBar();
            this.trackBarSaturation = new System.Windows.Forms.TrackBar();
            this.labelSaturation = new System.Windows.Forms.Label();
            this.trackBarScale = new System.Windows.Forms.TrackBar();
            this.labelScale = new System.Windows.Forms.Label();
            this.buttonRotateRight90 = new System.Windows.Forms.Button();
            this.buttonRotateLeft90 = new System.Windows.Forms.Button();
            this.buttonFlipVertical = new System.Windows.Forms.Button();
            this.buttonFlipHorizontal = new System.Windows.Forms.Button();
            this.buttonStartCrop = new System.Windows.Forms.Button();
            this.buttonEndCrop = new System.Windows.Forms.Button();
            this.labelResolution = new System.Windows.Forms.Label();
            this.labelIsStretched = new System.Windows.Forms.Label();
            this.buttonGrayscaleFilter = new System.Windows.Forms.Button();
            this.buttonSunburnFilter = new System.Windows.Forms.Button();
            this.buttonBlurFilter = new System.Windows.Forms.Button();
            this.buttonRevertChanges = new System.Windows.Forms.Button();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.buttonRandomFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEditImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxEditImage
            // 
            this.pictureBoxEditImage.Location = new System.Drawing.Point(143, 12);
            this.pictureBoxEditImage.Name = "pictureBoxEditImage";
            this.pictureBoxEditImage.Size = new System.Drawing.Size(512, 512);
            this.pictureBoxEditImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxEditImage.TabIndex = 0;
            this.pictureBoxEditImage.TabStop = false;
            this.pictureBoxEditImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxEditImage_MouseDown);
            this.pictureBoxEditImage.MouseLeave += new System.EventHandler(this.pictureBoxEditImage_MouseLeave);
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(143, 530);
            this.trackBarBrightness.Maximum = 100;
            this.trackBarBrightness.Minimum = 1;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(512, 45);
            this.trackBarBrightness.TabIndex = 1;
            this.trackBarBrightness.Value = 50;
            this.trackBarBrightness.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarBrightness_MouseUp);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(701, 694);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(58, 50);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save and Exit";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Location = new System.Drawing.Point(615, 694);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(80, 50);
            this.buttonDiscard.TabIndex = 3;
            this.buttonDiscard.Text = "Exit and Discard Changes";
            this.buttonDiscard.UseVisualStyleBackColor = true;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // labelContrast
            // 
            this.labelContrast.AutoSize = true;
            this.labelContrast.Location = new System.Drawing.Point(39, 562);
            this.labelContrast.Name = "labelContrast";
            this.labelContrast.Size = new System.Drawing.Size(46, 13);
            this.labelContrast.TabIndex = 4;
            this.labelContrast.Text = "Contrast";
            // 
            // labelBrightness
            // 
            this.labelBrightness.AutoSize = true;
            this.labelBrightness.Location = new System.Drawing.Point(35, 530);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(56, 13);
            this.labelBrightness.TabIndex = 5;
            this.labelBrightness.Text = "Brightness";
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.Location = new System.Drawing.Point(143, 562);
            this.trackBarContrast.Maximum = 100;
            this.trackBarContrast.Minimum = 1;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(512, 45);
            this.trackBarContrast.TabIndex = 6;
            this.trackBarContrast.Value = 50;
            this.trackBarContrast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarContrast_MouseUp);
            // 
            // trackBarSaturation
            // 
            this.trackBarSaturation.Location = new System.Drawing.Point(143, 594);
            this.trackBarSaturation.Maximum = 100;
            this.trackBarSaturation.Minimum = 1;
            this.trackBarSaturation.Name = "trackBarSaturation";
            this.trackBarSaturation.Size = new System.Drawing.Size(512, 45);
            this.trackBarSaturation.TabIndex = 8;
            this.trackBarSaturation.Value = 50;
            this.trackBarSaturation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarSaturation_MouseUp);
            // 
            // labelSaturation
            // 
            this.labelSaturation.AutoSize = true;
            this.labelSaturation.Location = new System.Drawing.Point(35, 594);
            this.labelSaturation.Name = "labelSaturation";
            this.labelSaturation.Size = new System.Drawing.Size(55, 13);
            this.labelSaturation.TabIndex = 7;
            this.labelSaturation.Text = "Saturation";
            // 
            // trackBarScale
            // 
            this.trackBarScale.Location = new System.Drawing.Point(143, 624);
            this.trackBarScale.Maximum = 100;
            this.trackBarScale.Minimum = 1;
            this.trackBarScale.Name = "trackBarScale";
            this.trackBarScale.Size = new System.Drawing.Size(512, 45);
            this.trackBarScale.TabIndex = 10;
            this.trackBarScale.Value = 50;
            this.trackBarScale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarScale_MouseUp);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(44, 626);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(34, 13);
            this.labelScale.TabIndex = 9;
            this.labelScale.Text = "Scale";
            // 
            // buttonRotateRight90
            // 
            this.buttonRotateRight90.Location = new System.Drawing.Point(118, 694);
            this.buttonRotateRight90.Name = "buttonRotateRight90";
            this.buttonRotateRight90.Size = new System.Drawing.Size(100, 50);
            this.buttonRotateRight90.TabIndex = 11;
            this.buttonRotateRight90.Text = "Rotate Right 90";
            this.buttonRotateRight90.UseVisualStyleBackColor = true;
            this.buttonRotateRight90.Click += new System.EventHandler(this.buttonRotateRight90_Click);
            // 
            // buttonRotateLeft90
            // 
            this.buttonRotateLeft90.Location = new System.Drawing.Point(12, 694);
            this.buttonRotateLeft90.Name = "buttonRotateLeft90";
            this.buttonRotateLeft90.Size = new System.Drawing.Size(100, 50);
            this.buttonRotateLeft90.TabIndex = 12;
            this.buttonRotateLeft90.Text = "Rotate Left 90";
            this.buttonRotateLeft90.UseVisualStyleBackColor = true;
            this.buttonRotateLeft90.Click += new System.EventHandler(this.buttonRotateLeft90_Click);
            // 
            // buttonFlipVertical
            // 
            this.buttonFlipVertical.Location = new System.Drawing.Point(268, 694);
            this.buttonFlipVertical.Name = "buttonFlipVertical";
            this.buttonFlipVertical.Size = new System.Drawing.Size(100, 50);
            this.buttonFlipVertical.TabIndex = 13;
            this.buttonFlipVertical.Text = "Flip Vertical";
            this.buttonFlipVertical.UseVisualStyleBackColor = true;
            this.buttonFlipVertical.Click += new System.EventHandler(this.buttonFlipVertical_Click);
            // 
            // buttonFlipHorizontal
            // 
            this.buttonFlipHorizontal.Location = new System.Drawing.Point(374, 694);
            this.buttonFlipHorizontal.Name = "buttonFlipHorizontal";
            this.buttonFlipHorizontal.Size = new System.Drawing.Size(100, 50);
            this.buttonFlipHorizontal.TabIndex = 14;
            this.buttonFlipHorizontal.Text = "Flip Horizontal";
            this.buttonFlipHorizontal.UseVisualStyleBackColor = true;
            this.buttonFlipHorizontal.Click += new System.EventHandler(this.buttonFlipHorizontal_Click);
            // 
            // buttonStartCrop
            // 
            this.buttonStartCrop.Location = new System.Drawing.Point(674, 139);
            this.buttonStartCrop.Name = "buttonStartCrop";
            this.buttonStartCrop.Size = new System.Drawing.Size(77, 59);
            this.buttonStartCrop.TabIndex = 24;
            this.buttonStartCrop.Text = "Start Crop";
            this.buttonStartCrop.UseVisualStyleBackColor = true;
            this.buttonStartCrop.Click += new System.EventHandler(this.buttonStartCrop_Click);
            // 
            // buttonEndCrop
            // 
            this.buttonEndCrop.Location = new System.Drawing.Point(674, 229);
            this.buttonEndCrop.Name = "buttonEndCrop";
            this.buttonEndCrop.Size = new System.Drawing.Size(77, 59);
            this.buttonEndCrop.TabIndex = 25;
            this.buttonEndCrop.Text = "End Crop";
            this.buttonEndCrop.UseVisualStyleBackColor = true;
            this.buttonEndCrop.Click += new System.EventHandler(this.buttonEndCrop_Click);
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(698, 486);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(35, 13);
            this.labelResolution.TabIndex = 26;
            this.labelResolution.Text = "label1";
            // 
            // labelIsStretched
            // 
            this.labelIsStretched.Location = new System.Drawing.Point(698, 511);
            this.labelIsStretched.Name = "labelIsStretched";
            this.labelIsStretched.Size = new System.Drawing.Size(125, 144);
            this.labelIsStretched.TabIndex = 27;
            this.labelIsStretched.Text = "label2";
            // 
            // buttonGrayscaleFilter
            // 
            this.buttonGrayscaleFilter.Location = new System.Drawing.Point(30, 82);
            this.buttonGrayscaleFilter.Name = "buttonGrayscaleFilter";
            this.buttonGrayscaleFilter.Size = new System.Drawing.Size(77, 59);
            this.buttonGrayscaleFilter.TabIndex = 28;
            this.buttonGrayscaleFilter.Text = "Grayscale Filter";
            this.buttonGrayscaleFilter.UseVisualStyleBackColor = true;
            this.buttonGrayscaleFilter.Click += new System.EventHandler(this.buttonGrayscaleFilter_Click);
            // 
            // buttonSunburnFilter
            // 
            this.buttonSunburnFilter.Location = new System.Drawing.Point(30, 182);
            this.buttonSunburnFilter.Name = "buttonSunburnFilter";
            this.buttonSunburnFilter.Size = new System.Drawing.Size(77, 59);
            this.buttonSunburnFilter.TabIndex = 29;
            this.buttonSunburnFilter.Text = "Sunburn Filter";
            this.buttonSunburnFilter.UseVisualStyleBackColor = true;
            this.buttonSunburnFilter.Click += new System.EventHandler(this.buttonSunburnFilter_Click);
            // 
            // buttonBlurFilter
            // 
            this.buttonBlurFilter.Location = new System.Drawing.Point(30, 282);
            this.buttonBlurFilter.Name = "buttonBlurFilter";
            this.buttonBlurFilter.Size = new System.Drawing.Size(77, 59);
            this.buttonBlurFilter.TabIndex = 30;
            this.buttonBlurFilter.Text = "Blur Filter";
            this.buttonBlurFilter.UseVisualStyleBackColor = true;
            this.buttonBlurFilter.Click += new System.EventHandler(this.buttonBlurFilter_Click);
            // 
            // buttonRevertChanges
            // 
            this.buttonRevertChanges.Location = new System.Drawing.Point(511, 694);
            this.buttonRevertChanges.Name = "buttonRevertChanges";
            this.buttonRevertChanges.Size = new System.Drawing.Size(100, 50);
            this.buttonRevertChanges.TabIndex = 31;
            this.buttonRevertChanges.Text = "Revert Changes";
            this.buttonRevertChanges.UseVisualStyleBackColor = true;
            this.buttonRevertChanges.Click += new System.EventHandler(this.buttonRevertChanges_Click);
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Location = new System.Drawing.Point(765, 694);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(58, 50);
            this.buttonSaveAs.TabIndex = 32;
            this.buttonSaveAs.Text = "Save as and Exit";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // buttonRandomFilter
            // 
            this.buttonRandomFilter.Location = new System.Drawing.Point(30, 382);
            this.buttonRandomFilter.Name = "buttonRandomFilter";
            this.buttonRandomFilter.Size = new System.Drawing.Size(77, 59);
            this.buttonRandomFilter.TabIndex = 33;
            this.buttonRandomFilter.Text = "Random Filter";
            this.buttonRandomFilter.UseVisualStyleBackColor = true;
            this.buttonRandomFilter.Click += new System.EventHandler(this.buttonRandomFilter_Click);
            // 
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 760);
            this.Controls.Add(this.buttonRandomFilter);
            this.Controls.Add(this.buttonSaveAs);
            this.Controls.Add(this.buttonRevertChanges);
            this.Controls.Add(this.buttonBlurFilter);
            this.Controls.Add(this.buttonSunburnFilter);
            this.Controls.Add(this.buttonGrayscaleFilter);
            this.Controls.Add(this.labelIsStretched);
            this.Controls.Add(this.labelResolution);
            this.Controls.Add(this.buttonEndCrop);
            this.Controls.Add(this.buttonStartCrop);
            this.Controls.Add(this.buttonFlipHorizontal);
            this.Controls.Add(this.buttonFlipVertical);
            this.Controls.Add(this.buttonRotateLeft90);
            this.Controls.Add(this.buttonRotateRight90);
            this.Controls.Add(this.trackBarScale);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.trackBarSaturation);
            this.Controls.Add(this.labelSaturation);
            this.Controls.Add(this.trackBarContrast);
            this.Controls.Add(this.labelBrightness);
            this.Controls.Add(this.labelContrast);
            this.Controls.Add(this.buttonDiscard);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.trackBarBrightness);
            this.Controls.Add(this.pictureBoxEditImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageView";
            this.Text = "ImageView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEditImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxEditImage;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.Label labelContrast;
        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.TrackBar trackBarSaturation;
        private System.Windows.Forms.Label labelSaturation;
        private System.Windows.Forms.TrackBar trackBarScale;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.Button buttonRotateRight90;
        private System.Windows.Forms.Button buttonRotateLeft90;
        private System.Windows.Forms.Button buttonFlipVertical;
        private System.Windows.Forms.Button buttonFlipHorizontal;
        private System.Windows.Forms.Button buttonStartCrop;
        private System.Windows.Forms.Button buttonEndCrop;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.Label labelIsStretched;
        private System.Windows.Forms.Button buttonGrayscaleFilter;
        private System.Windows.Forms.Button buttonSunburnFilter;
        private System.Windows.Forms.Button buttonBlurFilter;
        private System.Windows.Forms.Button buttonRevertChanges;
        private System.Windows.Forms.Button buttonSaveAs;
        private System.Windows.Forms.Button buttonRandomFilter;
    }
}