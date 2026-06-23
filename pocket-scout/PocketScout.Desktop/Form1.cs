using System.Drawing;

namespace PocketScout.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap cardImage = new Bitmap(dialog.FileName);

                pictureBoxCard.Image = cardImage;

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
            if (pictureBoxCard.Image == null)
            {
                lblResolution.Text = "Centering: Load an image first.";
                return;
            }

            Bitmap cardImage = new Bitmap(pictureBoxCard.Image);

            ImageAnalyzer analyzer = new ImageAnalyzer();

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

            lblBorders.Visible = true;
            lblBorders.Text = $"Outer Left: {border.leftBorder}\n" +
                              $"Outer Right: {border.rightBorder}\n" +
                              $"Left Card Border: {centering.LeftBorderSize}px\n" +
                              $"Right Card Border: {centering.RightBorderSize}px\n" +
                              $"Left/Right Centering: {centering.LeftPercent:F1}/{centering.RightPercent:F1}\n" +
                              $"Top/Bottom Centering: {centering.TopPercent:F1}/{centering.BottomPercent:F1}";
        }

        private void pictureBoxCard_Click(object sender, EventArgs e)
        {

        }

    }
}
