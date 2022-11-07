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

            Bitmap bitmap = new Bitmap(@"D:\Coding\CSharp\XuLyAnh\ImageDistortion\img\mai_lan.jpg");

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = bitmap;
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




        private void btn_Convert_Click(object sender, EventArgs e)
        {
            ProcessImage();
        }


        // Process Image
        public void ProcessImage()
        {
            Bitmap bmp = new Bitmap(@"D:\Coding\CSharp\XuLyAnh\ImageDistortion\img\mai_lan.jpg");

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //Color oldPixel = bmp.GetPixel(i, j);
                    //Color newPixel = oldPixel;
                    //bmp.SetPixel(i, j, newPixel);

                    Color bmpColor = bmp.GetPixel(i, j);
                    int red = bmpColor.R;
                    int green = bmpColor.G;
                    int blue = bmpColor.B;

                    //covert to gray
                    int gray = (byte)(.299 * red + .587 * green + .114 * blue);
                    red = gray;
                    green = gray;
                    blue = gray;

                    bmp.SetPixel(i, j, Color.FromArgb(red, green, blue));

                }
            }

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = bmp;


        }
    }
}