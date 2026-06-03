using PocketScout.Core;
using System.Drawing;

namespace PocketScout.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap cardImage = new Bitmap(dialog.FileName);

                pictureBoxCard.Image = cardImage;
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (pictureBoxCard.Image == null)
            {
                lblCentering.Text = "Centering: Load an image first.";
                return;
            }

            Bitmap cardImage = new Bitmap(pictureBoxCard.Image);

            ImageAnalyzer analyzer = new ImageAnalyzer();

            var size = analyzer.GetImageSize(cardImage);

            lblCentering.Text = $"Width: {size.width}, Height: {size.height}";
        }

    }
}
