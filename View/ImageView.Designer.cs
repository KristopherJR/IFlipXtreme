
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
            this.textBoxCropLocationX = new System.Windows.Forms.TextBox();
            this.textBoxCropWidth = new System.Windows.Forms.TextBox();
            this.textBoxCropLocationY = new System.Windows.Forms.TextBox();
            this.textBoxCropHeight = new System.Windows.Forms.TextBox();
            this.labelCropBoxLocationX = new System.Windows.Forms.Label();
            this.labelCropBoxLocationY = new System.Windows.Forms.Label();
            this.labelCropBoxHeight = new System.Windows.Forms.Label();
            this.labelCropBoxWidth = new System.Windows.Forms.Label();
            this.buttonCrop = new System.Windows.Forms.Button();
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
            this.buttonSave.Location = new System.Drawing.Point(559, 780);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 48);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save and Exit";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Location = new System.Drawing.Point(458, 780);
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
            this.buttonRotateRight90.Location = new System.Drawing.Point(115, 783);
            this.buttonRotateRight90.Name = "buttonRotateRight90";
            this.buttonRotateRight90.Size = new System.Drawing.Size(62, 50);
            this.buttonRotateRight90.TabIndex = 11;
            this.buttonRotateRight90.Text = "Rotate Right 90";
            this.buttonRotateRight90.UseVisualStyleBackColor = true;
            this.buttonRotateRight90.Click += new System.EventHandler(this.buttonRotateRight90_Click);
            // 
            // buttonRotateLeft90
            // 
            this.buttonRotateLeft90.Location = new System.Drawing.Point(47, 783);
            this.buttonRotateLeft90.Name = "buttonRotateLeft90";
            this.buttonRotateLeft90.Size = new System.Drawing.Size(62, 50);
            this.buttonRotateLeft90.TabIndex = 12;
            this.buttonRotateLeft90.Text = "Rotate Left 90";
            this.buttonRotateLeft90.UseVisualStyleBackColor = true;
            this.buttonRotateLeft90.Click += new System.EventHandler(this.buttonRotateLeft90_Click);
            // 
            // buttonFlipVertical
            // 
            this.buttonFlipVertical.Location = new System.Drawing.Point(194, 783);
            this.buttonFlipVertical.Name = "buttonFlipVertical";
            this.buttonFlipVertical.Size = new System.Drawing.Size(81, 50);
            this.buttonFlipVertical.TabIndex = 13;
            this.buttonFlipVertical.Text = "Flip Vertical";
            this.buttonFlipVertical.UseVisualStyleBackColor = true;
            this.buttonFlipVertical.Click += new System.EventHandler(this.buttonFlipVertical_Click);
            // 
            // buttonFlipHorizontal
            // 
            this.buttonFlipHorizontal.Location = new System.Drawing.Point(281, 783);
            this.buttonFlipHorizontal.Name = "buttonFlipHorizontal";
            this.buttonFlipHorizontal.Size = new System.Drawing.Size(81, 50);
            this.buttonFlipHorizontal.TabIndex = 14;
            this.buttonFlipHorizontal.Text = "Flip Horizontal";
            this.buttonFlipHorizontal.UseVisualStyleBackColor = true;
            this.buttonFlipHorizontal.Click += new System.EventHandler(this.buttonFlipHorizontal_Click);
            // 
            // textBoxCropLocationX
            // 
            this.textBoxCropLocationX.Location = new System.Drawing.Point(213, 675);
            this.textBoxCropLocationX.MaxLength = 5;
            this.textBoxCropLocationX.Name = "textBoxCropLocationX";
            this.textBoxCropLocationX.Size = new System.Drawing.Size(100, 20);
            this.textBoxCropLocationX.TabIndex = 16;
            this.textBoxCropLocationX.TextChanged += new System.EventHandler(this.textBoxCropLocationX_TextChanged);
            this.textBoxCropLocationX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCropLocationX_KeyPress);
            // 
            // textBoxCropWidth
            // 
            this.textBoxCropWidth.Location = new System.Drawing.Point(503, 724);
            this.textBoxCropWidth.MaxLength = 5;
            this.textBoxCropWidth.Name = "textBoxCropWidth";
            this.textBoxCropWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxCropWidth.TabIndex = 19;
            this.textBoxCropWidth.TextChanged += new System.EventHandler(this.textBoxCropWidth_TextChanged);
            this.textBoxCropWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCropLocationX_KeyPress);
            // 
            // textBoxCropLocationY
            // 
            this.textBoxCropLocationY.Location = new System.Drawing.Point(213, 724);
            this.textBoxCropLocationY.MaxLength = 5;
            this.textBoxCropLocationY.Name = "textBoxCropLocationY";
            this.textBoxCropLocationY.Size = new System.Drawing.Size(100, 20);
            this.textBoxCropLocationY.TabIndex = 17;
            this.textBoxCropLocationY.TextChanged += new System.EventHandler(this.textBoxCropLocationY_TextChanged);
            this.textBoxCropLocationY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCropLocationX_KeyPress);
            // 
            // textBoxCropHeight
            // 
            this.textBoxCropHeight.Location = new System.Drawing.Point(503, 675);
            this.textBoxCropHeight.MaxLength = 5;
            this.textBoxCropHeight.Name = "textBoxCropHeight";
            this.textBoxCropHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxCropHeight.TabIndex = 18;
            this.textBoxCropHeight.TextChanged += new System.EventHandler(this.textBoxCropHeight_TextChanged);
            this.textBoxCropHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCropLocationX_KeyPress);
            // 
            // labelCropBoxLocationX
            // 
            this.labelCropBoxLocationX.AutoSize = true;
            this.labelCropBoxLocationX.Location = new System.Drawing.Point(100, 678);
            this.labelCropBoxLocationX.Name = "labelCropBoxLocationX";
            this.labelCropBoxLocationX.Size = new System.Drawing.Size(107, 13);
            this.labelCropBoxLocationX.TabIndex = 20;
            this.labelCropBoxLocationX.Text = "Crop Box Location X:";
            // 
            // labelCropBoxLocationY
            // 
            this.labelCropBoxLocationY.AutoSize = true;
            this.labelCropBoxLocationY.Location = new System.Drawing.Point(100, 727);
            this.labelCropBoxLocationY.Name = "labelCropBoxLocationY";
            this.labelCropBoxLocationY.Size = new System.Drawing.Size(107, 13);
            this.labelCropBoxLocationY.TabIndex = 21;
            this.labelCropBoxLocationY.Text = "Crop Box Location Y:";
            // 
            // labelCropBoxHeight
            // 
            this.labelCropBoxHeight.AutoSize = true;
            this.labelCropBoxHeight.Location = new System.Drawing.Point(400, 678);
            this.labelCropBoxHeight.Name = "labelCropBoxHeight";
            this.labelCropBoxHeight.Size = new System.Drawing.Size(87, 13);
            this.labelCropBoxHeight.TabIndex = 22;
            this.labelCropBoxHeight.Text = "Crop Box Height:";
            // 
            // labelCropBoxWidth
            // 
            this.labelCropBoxWidth.AutoSize = true;
            this.labelCropBoxWidth.Location = new System.Drawing.Point(403, 727);
            this.labelCropBoxWidth.Name = "labelCropBoxWidth";
            this.labelCropBoxWidth.Size = new System.Drawing.Size(84, 13);
            this.labelCropBoxWidth.TabIndex = 23;
            this.labelCropBoxWidth.Text = "Crop Box Width:";
            // 
            // buttonCrop
            // 
            this.buttonCrop.Location = new System.Drawing.Point(657, 690);
            this.buttonCrop.Name = "buttonCrop";
            this.buttonCrop.Size = new System.Drawing.Size(53, 39);
            this.buttonCrop.TabIndex = 24;
            this.buttonCrop.Text = "Crop";
            this.buttonCrop.UseVisualStyleBackColor = true;
            this.buttonCrop.Click += new System.EventHandler(this.buttonCrop_Click);
            // 
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 854);
            this.Controls.Add(this.buttonCrop);
            this.Controls.Add(this.labelCropBoxWidth);
            this.Controls.Add(this.labelCropBoxHeight);
            this.Controls.Add(this.labelCropBoxLocationY);
            this.Controls.Add(this.labelCropBoxLocationX);
            this.Controls.Add(this.textBoxCropHeight);
            this.Controls.Add(this.textBoxCropLocationY);
            this.Controls.Add(this.textBoxCropWidth);
            this.Controls.Add(this.textBoxCropLocationX);
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
        private System.Windows.Forms.TextBox textBoxCropLocationX;
        private System.Windows.Forms.TextBox textBoxCropWidth;
        private System.Windows.Forms.TextBox textBoxCropLocationY;
        private System.Windows.Forms.TextBox textBoxCropHeight;
        private System.Windows.Forms.Label labelCropBoxLocationX;
        private System.Windows.Forms.Label labelCropBoxLocationY;
        private System.Windows.Forms.Label labelCropBoxHeight;
        private System.Windows.Forms.Label labelCropBoxWidth;
        private System.Windows.Forms.Button buttonCrop;
    }
}