using System.Collections;
using System.Data;
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
        }


        private void ImageDistortion_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            pictureBoxOutput.AllowDrop = true;
            pictureBoxOutput.SizeMode = PictureBoxSizeMode.Zoom;
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
                pictureBoxInput.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxInput.Image = bmp;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (pictureBoxOutput.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = @"PNG|*.png}";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxInput.Image.Save(sfd.FileName, ImageFormat.Png);
                }
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (pictureBoxInput.Image != null || pictureBoxOutput.Image != null)
            {
                DialogResult dialogResult = MessageBox.Show("Hành động này sẽ xóa ảnh hiện tại.", "Image not save?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (pictureBoxInput.Image != null)
                    {
                        pictureBoxInput.Image.Dispose();
                        pictureBoxInput.Image = null;
                    }

                    if (pictureBoxOutput.Image != null)
                    {
                        pictureBoxOutput.Image.Dispose();
                        pictureBoxOutput.Image = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa có ảnh!", "Image Null");
            }

        }



        private void btn_Convert_Click(object sender, EventArgs e)
        {
            if (pictureBoxInput.Image != null)
            {
                btnMucXam.Text = "Loading...";
                btnMucXam.Enabled = false;
                if (ChuyenAnhXam(bmp))
                    pictureBoxOutput.Image = bmp;
                btnMucXam.Enabled = true;
                btnMucXam.Text = "ẢNH XÁM";
            }
            else
            {
                MessageBox.Show("Chưa có ảnh đầu vào!", "Image Null");
            }
        }



        // ChuyenAnhXam
        public static bool ChuyenAnhXam(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color bmpColor = bmp.GetPixel(i, j);
                    int red = bmpColor.R;
                    int green = bmpColor.G;
                    int blue = bmpColor.B;
                    int alpha = bmpColor.A;

                    //chuyển đổi qua ảnh xám
                    int gray = (byte)(.299 * red + .587 * green + .114 * blue);
                    red = gray;
                    green = gray;
                    blue = gray;

                    bmp.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }
            return true;
        }



        //Drag & Drop
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
                    pictureBoxOutput.Image = Image.FromFile(fileNames[0]);
                }
            }
        }

        private void pictureBox2_SizeModeChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBoxInput.Image != null)
            {
                btnKhuNhieu.Text = "Loading...";
                btnKhuNhieu.Enabled = false;
                if (LocTrungVi(bmp))
                {
                    pictureBoxOutput.Image = bmp;
                }
                btnKhuNhieu.Enabled = true;
                btnKhuNhieu.Text = "KHỬ NHIỄU";

            }
            else
            {
                MessageBox.Show("Chưa có ảnh đầu vào!", "Image Null");
            }
        }
        unsafe

        //Loc trung vi
        public static bool LocTrungVi(Bitmap img)
        {
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (pictureBoxInput.Image != null)
            {
                btnNhiPhan.Text = "Loading...";
                btnNhiPhan.Enabled = false;
                pictureBoxOutput.Image = ChuyenAnhNhiPhan(bmp, 128);
                btnNhiPhan.Enabled = true;
                btnNhiPhan.Text = "NHỊ PHÂN";
            }
            else
            {
                MessageBox.Show("Chưa có ảnh đầu vào!", "Image Null");
            }
        }
        unsafe

        //ChuyenAnhNhiPhan
       private Bitmap ChuyenAnhNhiPhan(Bitmap bmp, byte nguong)
        {
            Bitmap imgtmp = new Bitmap(bmp);
            imgtmp = bmp;

            BitmapData imgdata = imgtmp.LockBits(new Rectangle(0, 0, imgtmp.Width, imgtmp.Height),
                                                ImageLockMode.ReadWrite,
                                                imgtmp.PixelFormat);

            int offset = imgdata.Stride - imgtmp.Width * 3;

            byte* p = (byte*)imgdata.Scan0;

            for (int i = 0; i < imgtmp.Height; i++)
            {
                for (int j = 0; j < imgtmp.Width; j++)
                {
                    //Xử lý 3 byte của 1 pixel
                    int t = (p[0] + p[1] + p[2]) / 3;
                    if ((byte)t < nguong)
                    {
                        t = 0;
                    }
                    else t = 255;
                    p[0] = (byte)t;
                    p[1] = (byte)t;
                    p[2] = (byte)t;
                    p += 3;
                }
                p += offset;
            }
            imgtmp.UnlockBits(imgdata);
            return imgtmp;
        }

        private void btnAmBan_Click(object sender, EventArgs e)
        {
            if (pictureBoxInput.Image != null)
            {
                btnAmBan.Text = "Loading...";
                btnAmBan.Enabled = false;
                pictureBoxOutput.Image = ChuyenAnhAmBan(bmp);
                btnAmBan.Enabled = true;
                btnAmBan.Text = "ÂM BẢN";
            }
            else
            {
                MessageBox.Show("Chưa có ảnh đầu vào!", "Image Null");
            }
        }
        unsafe

        //ChuyenAnhAmBan
        private Bitmap ChuyenAnhAmBan(Bitmap img)
        {
            Bitmap imgtmp = new Bitmap(img.Width, img.Height);
            imgtmp = img;
            BitmapData imgdata = imgtmp.LockBits(new Rectangle(0, 0, imgtmp.Width, imgtmp.Height), ImageLockMode.ReadWrite, imgtmp.PixelFormat);
            int offset = imgdata.Stride - 3 * imgtmp.Width;

            byte* p = (byte*)imgdata.Scan0;
            for (int i = 0; i < imgtmp.Height; i++)
            {
                for (int j = 0; j < imgtmp.Width; j++)
                {
                    int t = (p[0] + p[1] + p[2]) / 3;
                    t = 255 - t;
                    p[0] = (byte)t;
                    p[1] = (byte)t;
                    p[2] = (byte)t;

                    p += 3;
                }
                p += offset;
            }
            imgtmp.UnlockBits(imgdata);
            return imgtmp;
        }

        private void btnBrightness_Click(object sender, EventArgs e)
        {
            if (pictureBoxInput.Image != null)
            {
                btnBrightness.Text = "Loading...";
                btnBrightness.Enabled = false;
                BrightnessForm bf = new BrightnessForm();
                bf.ShowDialog();
                bmp = new Bitmap(this.pictureBoxInput.Image);
                IncreasePicture.increaseBrightness(bmp, bf.getBrightness());
                this.pictureBoxOutput.Image = bmp;
                btnBrightness.Enabled = true;
                btnBrightness.Text = "ĐỘ SÁNG";
            }
            else
            {
                MessageBox.Show("Chưa có ảnh đầu vào!", "Image Null");
            }
        }

        private void btnContrast_Click(object sender, EventArgs e)
        {
            if (pictureBoxInput.Image != null)
            {
                btnContrast.Text = "Loading...";
                btnContrast.Enabled = false;
                ContrastForm cf = new ContrastForm();
                cf.ShowDialog();
                bmp = new Bitmap(this.pictureBoxInput.Image);
                IncreasePicture.increaseContrast(bmp, cf.getContrast());
                this.pictureBoxOutput.Image = bmp;
                btnContrast.Enabled = true;
                btnContrast.Text = "ĐỘ TƯƠNG PHẢN";
            }
            else
            {
                MessageBox.Show("Chưa có ảnh đầu vào!", "Image Null");
            }
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang hoàn thiện! 😊");

        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang hoàn thiện! 😊");

        }

        private void btnReduceImage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang hoàn thiện! 😊");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (pictureBoxOutput.Image != null)
            {
                pictureBoxOutput.Image = null;
            }
        }
    }
}