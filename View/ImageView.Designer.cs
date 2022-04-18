
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
            this.buttonSave.Location = new System.Drawing.Point(655, 695);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 48);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save and Exit";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Location = new System.Drawing.Point(542, 695);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(95, 48);
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
            this.buttonRotateRight90.Location = new System.Drawing.Point(121, 694);
            this.buttonRotateRight90.Name = "buttonRotateRight90";
            this.buttonRotateRight90.Size = new System.Drawing.Size(62, 50);
            this.buttonRotateRight90.TabIndex = 11;
            this.buttonRotateRight90.Text = "Rotate Right 90";
            this.buttonRotateRight90.UseVisualStyleBackColor = true;
            this.buttonRotateRight90.Click += new System.EventHandler(this.buttonRotateRight90_Click);
            // 
            // buttonRotateLeft90
            // 
            this.buttonRotateLeft90.Location = new System.Drawing.Point(53, 694);
            this.buttonRotateLeft90.Name = "buttonRotateLeft90";
            this.buttonRotateLeft90.Size = new System.Drawing.Size(62, 50);
            this.buttonRotateLeft90.TabIndex = 12;
            this.buttonRotateLeft90.Text = "Rotate Left 90";
            this.buttonRotateLeft90.UseVisualStyleBackColor = true;
            this.buttonRotateLeft90.Click += new System.EventHandler(this.buttonRotateLeft90_Click);
            // 
            // buttonFlipVertical
            // 
            this.buttonFlipVertical.Location = new System.Drawing.Point(256, 694);
            this.buttonFlipVertical.Name = "buttonFlipVertical";
            this.buttonFlipVertical.Size = new System.Drawing.Size(81, 50);
            this.buttonFlipVertical.TabIndex = 13;
            this.buttonFlipVertical.Text = "Flip Vertical";
            this.buttonFlipVertical.UseVisualStyleBackColor = true;
            this.buttonFlipVertical.Click += new System.EventHandler(this.buttonFlipVertical_Click);
            // 
            // buttonFlipHorizontal
            // 
            this.buttonFlipHorizontal.Location = new System.Drawing.Point(343, 694);
            this.buttonFlipHorizontal.Name = "buttonFlipHorizontal";
            this.buttonFlipHorizontal.Size = new System.Drawing.Size(81, 50);
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
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 760);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageView";
            this.Text = "ImageView";
            this.Load += new System.EventHandler(this.ImageView_Load);
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
    }
}