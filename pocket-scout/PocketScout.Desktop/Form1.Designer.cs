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
            lblLoadStatus = new Label();
            pictureBoxPanel = new Panel();
            headersPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard).BeginInit();
            pictureBoxPanel.SuspendLayout();
            headersPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(3, 9);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(120, 71);
            btnLoadImage.TabIndex = 0;
            btnLoadImage.Text = "Load Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // pictureBoxCard
            // 
            pictureBoxCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxCard.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCard.Location = new Point(0, 0);
            pictureBoxCard.Name = "pictureBoxCard";
            pictureBoxCard.Size = new Size(776, 402);
            pictureBoxCard.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCard.TabIndex = 1;
            pictureBoxCard.TabStop = false;
            pictureBoxCard.Click += pictureBoxCard_Click;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Location = new Point(129, 9);
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
            lblResolution.Location = new Point(267, 37);
            lblResolution.Name = "lblResolution";
            lblResolution.Size = new Size(76, 15);
            lblResolution.TabIndex = 3;
            lblResolution.Text = "lblResolution";
            lblResolution.Visible = false;
            // 
            // lblBorders
            // 
            lblBorders.AutoSize = true;
            lblBorders.Location = new Point(426, 37);
            lblBorders.Name = "lblBorders";
            lblBorders.Size = new Size(60, 15);
            lblBorders.TabIndex = 4;
            lblBorders.Text = "lblBorders";
            lblBorders.Visible = false;
            // 
            // lblLoadStatus
            // 
            lblLoadStatus.AutoSize = true;
            lblLoadStatus.Location = new Point(12, 630);
            lblLoadStatus.Name = "lblLoadStatus";
            lblLoadStatus.Size = new Size(78, 15);
            lblLoadStatus.TabIndex = 5;
            lblLoadStatus.Text = "lblLoadStatus";
            lblLoadStatus.Visible = false;
            lblLoadStatus.Click += lblLoadStatus_Click;
            lblLoadStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            // 
            // pictureBoxPanel
            // 
            pictureBoxPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxPanel.Controls.Add(pictureBoxCard);
            pictureBoxPanel.Location = new Point(12, 204);
            pictureBoxPanel.Name = "pictureBoxPanel";
            pictureBoxPanel.Size = new Size(776, 402);
            pictureBoxPanel.TabIndex = 6;
            // 
            // headersPanel
            // 
            headersPanel.Controls.Add(btnLoadImage);
            headersPanel.Controls.Add(btnAnalyze);
            headersPanel.Controls.Add(lblResolution);
            headersPanel.Controls.Add(lblBorders);
            headersPanel.Location = new Point(12, 12);
            headersPanel.Name = "headersPanel";
            headersPanel.Size = new Size(776, 186);
            headersPanel.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 654);
            Controls.Add(headersPanel);
            Controls.Add(pictureBoxPanel);
            Controls.Add(lblLoadStatus);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard).EndInit();
            pictureBoxPanel.ResumeLayout(false);
            headersPanel.ResumeLayout(false);
            headersPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadImage;
        private PictureBox pictureBoxCard;
        private Button btnAnalyze;
        private Label lblResolution;
        private Label lblBorders;
        private Label lblLoadStatus;
        private Panel pictureBoxPanel;
        private Panel headersPanel;
    }
}
