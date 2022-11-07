using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageDistortion
{
    public partial class ImageDistortion : Form
    {
        Image image;
        Bitmap bitmap;

        public ImageDistortion()
        {
            InitializeComponent();

            //Bitmap bitmap = new Bitmap(@"D:\Coding\CSharp\XuLyAnh\ImageDistortion\img\mai_lan.jpg");

            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //pictureBox1.Image = bitmap;
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            DialogResult dlg = ofd.ShowDialog();

            if (dlg == DialogResult.OK)
            {
                image = Image.FromFile(ofd.FileName);
                bitmap = (Bitmap)image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = bitmap;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = @"PNG|*.png}";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }
    }
}