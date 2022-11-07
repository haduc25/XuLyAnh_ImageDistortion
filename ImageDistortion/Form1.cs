using System.Collections;
using System.Drawing.Imaging;


namespace ImageDistortion
{
    public partial class ImageDistortion : Form
    {
        Image image;
        Bitmap bmp;

        public ImageDistortion()
        {
            InitializeComponent();
            saveBtn.Enabled = false;
            pictureBox2.AllowDrop = true;


        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            DialogResult dlg = ofd.ShowDialog();


            if (dlg == DialogResult.OK)
            {
                image = Image.FromFile(ofd.FileName);
                bmp = (Bitmap)image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = bmp;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = @"PNG|*.png}";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);
                }
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
            if (pictureBox1.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Image);

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
                        int alpha = bmpColor.A;

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
            else
            {
                MessageBox.Show("Ảnh trống");
            }
        }




        //test
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Bitmap xImage = new Bitmap(@"D:\Coding\CSharp\XuLyAnh\ImageDistortion\img\mai_lan.jpg");

            Size xImageSize = xImage.Size;
            int Skew = 69;

            //using (Bitmap xNewImage = new Bitmap(120, 120)) //Determine your size
            //{
            //    //using (Graphics xGraphics = Graphics.FromImage(xNewImage))
            //    //{
            //    //    Point[] xPointsA =
            //    //    {
            //    //    new Point(0, Skew), //Upper Left
            //    //    new Point(xImageSize.Width, 0), //Upper Right
            //    //    new Point(0, xImageSize.Height + Skew) //Lower left
            //    //};
            //    //    Point[] xPointsB =
            //    //    {
            //    //    new Point(xImageSize.Width, 0), //Upper Left
            //    //    new Point(xImageSize.Width*2, Skew), //Upper Right
            //    //    new Point(xImageSize.Width, xImageSize.Height) //Lower left
            //    //};
            //    //    Point[] xPointsC =
            //    //    {
            //    //    new Point(xImageSize.Width, xImageSize.Height), //Upper Left
            //    //    new Point(xImageSize.Width*2, xImageSize.Height + Skew), //Upper Right
            //    //    new Point(0, xImageSize.Height + Skew) //Lower left
            //    //};

            //    //    //Draw to new Image
            //    //    xGraphics.DrawImage(xImage, xPointsA);
            //    //    xGraphics.DrawImage(xImage, xPointsB);
            //    //    xGraphics.DrawImage(xImage, xPointsC);
            //    //}
            //    //e.Graphics.DrawImage(xNewImage, new Point()); //Here you would want to assign the new image to the picture box

            //}

            //Image image = new Bitmap(xImage, 260, 340);
            Image image = new Bitmap(xImage);

            Point[] destinationPoints = {
                //new Point(200, 20),   // destination for upper-left point of
                //new Point(110, 100),  // destination for upper-right point of
                //new Point(250, 30)};  // destination for lower-left point of

                //new Point(0, Skew),   // destination for upper-left point of
                //new Point(image.Size.Width, 0),  // destination for upper-right point of
                //new Point(0, image.Size.Height)};  // destination for lower-left point of

                
                //new Point(image.Size.Width, 0),  // destination for upper-right point of
                //new Point(image.Size.Width * 2, 0),  // destination for upper-right point of
                //new Point(0, Skew),   // destination for upper-left point of
                //new Point(0, image.Size.Height)};  // destination for lower-left point of
                                                   // 

                //new Point(0, 0),   // destination for upper-left point of
                //new Point(260, 0),  // destination for upper-right point of
                //new Point(0, 320)};  // destination for lower-left point of


                new Point(0, 600),   // destination for upper-left point of
                new Point(image.Size.Width, 0),  // destination for upper-right point of
                new Point(600, image.Size.Height)};  // destination for lower-left point of




            // Draw the image unaltered with its upper-left corner at (0, 0).
            //e.Graphics.DrawImage(image, 0, 0);

            // Draw the image mapped to the parallelogram.
            //e.Graphics.DrawImage(image, destinationPoints);




            //Graphics g = Graphics.FromImage(image);
            //g.DrawImage(image, new Point(260, 380));
            ////g.DrawImage(image, destinationPoints);

            ////g.Dispose();
            //pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            //pictureBox2.Image = image;
        }

        private void pictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    pictureBox2.Image = Image.FromFile(fileNames[0]);
                }
            }
        }

        private void pictureBox2_SizeModeChanged(object sender, EventArgs e)
        {
            saveBtn.Enabled =  true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {

            }
            else
            {
                MessageBox.Show("loi chua co img");
            }
        }

        //Loc TV
        public static bool LocTrungVi(Bitmap img)
        {
            //Loc trung vi
            Bitmap imgtmp = (Bitmap)img.Clone();
            BitmapData imgdata = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                                ImageLockMode.ReadWrite,
                                PixelFormat.Format24bppRgb);
            BitmapData imgtmpdata = imgtmp.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                                ImageLockMode.ReadWrite,
                                PixelFormat.Format24bppRgb);
            int stride = imgdata.Stride;
            int stride2 = stride * 2;
            ArrayList list;
            unsafe
            {
                byte* p = (byte*)imgdata.Scan0;
                byte* p1 = (byte*)imgtmpdata.Scan0;
                int nOffset = stride - img.Width * 3;
                int nWidth = img.Width - 2;
                //trừ đi các rìa ảnh
                int nHeight = img.Height - 2;
                int nPixel;
                list = new ArrayList();
                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        for (int i = 0; i < 3; ++i)
                        {
                            list.Add(p1[0]);
                            list.Add(p1[3]);
                            list.Add(p1[6]);
                            list.Add(p1[0 + stride]);
                            list.Add(p1[3 + stride]);
                            list.Add(p1[6 + stride]);
                            list.Add(p1[0 + stride2]);
                            list.Add(p1[3 + stride2]);
                            list.Add(p1[6 + stride2]);
                            list.Sort();
                            nPixel = Convert.ToInt32(list[4]);
                            if (nPixel < 0) nPixel = 0;
                            if (nPixel > 255) nPixel = 255;
                            p[3 + stride] = (byte)nPixel;
                            ++p;
                            ++p1;
                            list.Clear();
                        }
                    }
                    p += nOffset;
                    p1 += nOffset;
                }
            }
            img.UnlockBits(imgdata);
            return true;
        }
















    }
}