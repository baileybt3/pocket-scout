using System.Windows.Forms;
using PocketScout.Core;

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
            using OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxCard.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if(pictureBoxCard.Image == null)
            {
                lblCentering.Text = "Centering: Load an image first.";
                return;            
            }

            CardGrader grader = new CardGrader();

            string centering = grader.AnalyzeCentering();

            lblCentering.Text = $"Centering: {centering}";
        }
    }
}
