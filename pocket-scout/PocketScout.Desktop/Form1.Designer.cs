namespace PocketScout.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoadImage = new Button();
            pictureBoxCard = new PictureBox();
            btnAnalyze = new Button();
            lblResolution = new Label();
            lblBorders = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard).BeginInit();
            SuspendLayout();
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(12, 12);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(120, 71);
            btnLoadImage.TabIndex = 0;
            btnLoadImage.Text = "Load Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // pictureBoxCard
            // 
            pictureBoxCard.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCard.Location = new Point(31, 112);
            pictureBoxCard.Name = "pictureBoxCard";
            pictureBoxCard.Size = new Size(671, 314);
            pictureBoxCard.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCard.TabIndex = 1;
            pictureBoxCard.TabStop = false;
            pictureBoxCard.Click += pictureBoxCard_Click;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Location = new Point(165, 12);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(116, 71);
            btnAnalyze.TabIndex = 2;
            btnAnalyze.Text = "Analyze Card Centering";
            btnAnalyze.UseVisualStyleBackColor = true;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // lblResolution
            // 
            lblResolution.AutoSize = true;
            lblResolution.Location = new Point(300, 40);
            lblResolution.Name = "lblResolution";
            lblResolution.Size = new Size(76, 15);
            lblResolution.TabIndex = 3;
            lblResolution.Text = "lblResolution";
            // 
            // lblBorders
            // 
            lblBorders.AutoSize = true;
            lblBorders.Location = new Point(478, 40);
            lblBorders.Name = "lblBorders";
            lblBorders.Size = new Size(60, 15);
            lblBorders.TabIndex = 4;
            lblBorders.Text = "lblBorders";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblBorders);
            Controls.Add(lblResolution);
            Controls.Add(btnAnalyze);
            Controls.Add(pictureBoxCard);
            Controls.Add(btnLoadImage);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadImage;
        private PictureBox pictureBoxCard;
        private Button btnAnalyze;
        private Label lblResolution;
        private Label lblBorders;
    }
}
