using System.Drawing;

namespace PocketScout.Desktop
{
    public partial class Form1 : Form
    {
        private Bitmap? originalCardImage;

        private float zoom = 1.0f;

        public void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                originalCardImage = new Bitmap(dialog.FileName);

                pictureBoxCard.Image = new Bitmap(originalCardImage);

                lblLoadStatus.Visible = true;
                lblLoadStatus.Text = "Card Successfully Loaded!";
            }
            else
            {
                lblLoadStatus.Visible = true;
                lblLoadStatus.Text = "Card Not Loaded.";
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (originalCardImage == null)
            {
                lblResolution.Text = "Centering: Load an image first.";
                return;
            }

            Bitmap cardImage = new Bitmap(originalCardImage);

            ImageAnalyzer analyzer = new ImageAnalyzer();

            zoom = 1.0f;
            UpdatePictureBoxSize();

            var size = analyzer.GetImageSize(cardImage);

            lblResolution.Visible = true;
            lblResolution.Text = $"Resolution: {size.width}x{size.height}";

            var border = analyzer.GetCardBorder(cardImage);

            var innerBorder = analyzer.GetCardInnerBorder(cardImage,
                border.leftBorder,
                border.rightBorder,
                border.topBorder,
                border.bottomBorder);

            CardGrader grader = new CardGrader();

            CenteringResult centering = grader.CalculateCentering(cardImage, border, innerBorder);

            // Draw border lines on image and display
            pictureBoxCard.Image = analyzer.DrawBorderLines(
                cardImage,
                border.leftBorder,
                border.rightBorder,
                border.topBorder,
                border.bottomBorder,
                innerBorder.leftInnerBorder,
                innerBorder.rightInnerBorder,
                innerBorder.topInnerBorder,
                innerBorder.bottomInnerBorder);

            UpdatePictureBoxSize();

            lblBorders.Visible = true;
            lblBorders.Text = $"Outer Left: {border.leftBorder}\n" +
                              $"Outer Right: {border.rightBorder}\n" +
                              $"Left Card Border: {centering.LeftBorderSize}px\n" +
                              $"Right Card Border: {centering.RightBorderSize}px\n" +
                              $"Top Card Border: {centering.TopBorderSize}px\n" +
                              $"Bottom Card Border: {centering.BottomBorderSize}px\n" +

                              $"Left/Right Centering: {centering.LeftPercent:F1}/{centering.RightPercent:F1}\n" +
                              $"Top/Bottom Centering: {centering.TopPercent:F1}/{centering.BottomPercent:F1}";
        }

        private void pictureBoxCard_Click(object sender, EventArgs e)
        {

        }

        // --- QOL ---

        // Mouse Zoom
        private void pictureBoxCard_MouseWheel(object sender, MouseEventArgs e)
        {
            if(pictureBoxCard.Image == null)
            {
                return;
            }

            if (e.Delta > 0)
            {
                zoom *= 1.1f; // Zoom in
            }
            else
            {
                zoom /= 1.1f; // Zoom out
            }

            UpdatePictureBoxSize();
        }

        private void UpdatePictureBoxSize()
        {
            if(pictureBoxCard.Image == null)
            {
                return;
            }

            int width = (int)(pictureBoxCard.Image.Width * zoom);
            int height = (int)(pictureBoxCard.Image.Height * zoom);

            pictureBoxCard.Size = new Size(width, height);
        }

        private void pictureBoxCard_MouseEnter(object? sender, EventArgs e)
        {
            pictureBoxCard.Focus();
        }


        public Form1()
        {
            InitializeComponent();

            pictureBoxCard.MouseWheel += pictureBoxCard_MouseWheel;
            pictureBoxCard.MouseEnter += pictureBoxCard_MouseEnter;
        }

        private void lblLoadStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
