using System.Collections;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;

namespace ImageDistortion
{
    public partial class ImageDistortion : Form
    {
        public ImageDistortion()
        {
            InitializeComponent();
        }

        #region Initial Value
        Image image;
        Bitmap bmp;
        Thread thread;
        private void ImageDistortion_Load(object sender, EventArgs e)
        {
            LockTinhNang();
            pictureBoxOutput.AllowDrop = true;
            pictureBoxOutput.SizeMode = PictureBoxSizeMode.Zoom;
        }


        private void LockTinhNang()
        {
            gbChucNang.Enabled = false;
            btnSave.Enabled = false;
            btnDelOutput.Enabled = false;
        }
        private void UnlockTinhNang()
        {
            gbChucNang.Enabled = true;
            btnSave.Enabled = true;
            btnDelOutput.Enabled = true;
        }

        #endregion

        #region Open Image, Save Image, Delete Image, Exit
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

                UnlockTinhNang();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (pictureBoxOutput.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = @"PNG|*.png";
                if (sfd.ShowDialog() == DialogResult.OK)
                    pictureBoxInput.Image.Save(sfd.FileName, ImageFormat.Png);
            }
            else
            {
                MessageBox.Show("Ảnh chưa thay đổi? Vui lòng chọn 1 tính năng", "Image not change");
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
                        LockTinhNang();
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            bmp = null;
            bmp = (Bitmap)pictureBoxInput.Image; //reset filter
            if (pictureBoxOutput.Image != null)
            {
                pictureBoxOutput.Image = null;
            }
            else
            {
                MessageBox.Show("Ảnh chưa thay đổi? Vui lòng chọn 1 tính năng", "Image not change");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn thoát.", "Exit?", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
                Application.Exit();
            return;
        }
        #endregion

        #region Chuyen anh xam
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

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
                try
                {
                    if (ChuyenAnhXam(bmp))
                        pictureBoxOutput.Image = bmp;
                }
                finally
                {
                    this.Invoke(() =>
                    {
                        UnlockTinhNang();
                        btnMucXam.Text = "ẢNH XÁM";
                    });
                }
            });
            btnMucXam.Text = "Processing...";
            LockTinhNang();
            thread.IsBackground = true;
            thread.Start();
        }
        #endregion

        #region Drag & Drop Image
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
        #endregion

        #region Loc trung vi & Khu nhieu
        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
                try
                {
                    if (LocTrungVi(bmp))
                        pictureBoxOutput.Image = bmp;
                }
                finally
                {
                    this.Invoke(() =>
                    {
                        UnlockTinhNang();
                        btnKhuNhieu.Text = "KHỬ NHIỄU";
                    });
                }
            });
            btnKhuNhieu.Text = "Processing...";
            LockTinhNang();
            thread.IsBackground = true;
            thread.Start();
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
        #endregion

        #region Chuyen anh nhi phan
        private void button1_Click_1(object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
                try
                {
                    pictureBoxOutput.Image = ChuyenAnhNhiPhan(bmp, 128);
                }
                finally
                {
                    this.Invoke(() =>
                    {
                        UnlockTinhNang();
                        btnNhiPhan.Text = "NHỊ PHÂN";
                    });
                }
            });
            btnNhiPhan.Text = "Processing...";
            LockTinhNang();
            thread.IsBackground = true;
            thread.Start();
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
        #endregion

        #region Chuyen anh am ban
        private void btnAmBan_Click(object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
                try
                {
                    if (LocTrungVi(bmp))
                        pictureBoxOutput.Image = ChuyenAnhAmBan(bmp);
                }
                finally
                {
                    this.Invoke(() =>
                    {
                        UnlockTinhNang();
                        btnAmBan.Text = "ÂM BẢN";
                    });
                }
            });
            btnAmBan.Text = "Processing...";
            LockTinhNang();
            thread.IsBackground = true;
            thread.Start();
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
        #endregion

        #region Chinh do sang & do tuong phan
        private void btnBrightness_Click(object sender, EventArgs e)
        {
            btnBrightness.Text = "Processing...";
            LockTinhNang();

            BrightnessForm bf = new BrightnessForm();
            bf.ShowDialog();
            bmp = new Bitmap(this.pictureBoxInput.Image);
            IncreasePicture.increaseBrightness(bmp, bf.getBrightness());
            this.pictureBoxOutput.Image = bmp;

            UnlockTinhNang();
            btnBrightness.Text = "ĐỘ SÁNG";
        }

        private void btnContrast_Click(object sender, EventArgs e)
        {

            btnContrast.Text = "Processing...";
            LockTinhNang();

            ContrastForm cf = new ContrastForm();
            cf.ShowDialog();
            bmp = new Bitmap(this.pictureBoxInput.Image);
            IncreasePicture.increaseContrast(bmp, cf.getContrast());
            this.pictureBoxOutput.Image = bmp;

            UnlockTinhNang();
            btnContrast.Text = "ĐỘ TƯƠNG PHẢN";
        }
        #endregion

        #region handle Image: Nen anh & Giai nen
        public string ChuyenAnhThanhChuoi(Image image)
        {

            MemoryStream ms = new MemoryStream();

            image.Save(ms, ImageFormat.Jpeg);

            byte[] imageBytes = ms.ToArray();

            //BitArray o = ms.ToArray<BitArray>();

            string base64String = Convert.ToBase64String(imageBytes);

            return base64String;
        }
        string ChuyenASCsangNhiPhan(string BanRo)
        {

            FileStream file = new FileStream(Directory.GetCurrentDirectory() + @"\ASCtoNhiPhan.txt", FileMode.Open, FileAccess.Read, FileShare.None);

            StreamReader doc = new StreamReader(file);

            //đọc từng dòng một
            string Temp = "", NhiPhan = "", ThapPhan = "", Hex = "", ASC = "";

            string[] MangNhiPhan = new string[BanRo.Length];

            Temp = doc.ReadLine();
            int t = 0;

            while (Temp != null)
            {

                NhiPhan = Temp.Substring(0, 8).ToString();
                ThapPhan = Temp.Substring(9, 3).ToString().Trim();
                Hex = Temp.Substring(13, 2).ToString();
                ASC = Temp.Substring(16, 1);

                for (int i = 0; i < BanRo.Length; i++)
                {
                    if (ASC == BanRo[i].ToString())
                    {
                        MangNhiPhan[i] = NhiPhan;
                        t++;
                    }
                }

                if (t == BanRo.Length) break;

                Temp = doc.ReadLine();
            }

            StringBuilder ChuoiNhiPhan = new StringBuilder("");

            for (int i = 0; i < BanRo.Length; i++)
            {
                ChuoiNhiPhan.Append(MangNhiPhan[i]);
            }

            doc.Close();
            file.Close();

            return ChuoiNhiPhan.ToString();
        }

        string NenChuoiNhiPhan(string str)
        {
            StringBuilder Out = new StringBuilder("");
            int e;
            string p, cr = "";

            if (str[0].ToString() == "0")
            {
                Out.Append("0");
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (i == str.Length - 1) { Out.Append("1"); break; };

                e = 1;
                p = str[i].ToString();

                while (true)
                {
                    if (i + e >= str.Length)
                    {
                        Out.Append(e);
                        i = str.Length;
                        break;
                    }
                    else cr = str[i + e].ToString();

                    if (p == cr)
                        e++;
                    else
                    {
                        Out.Append(e);
                        if (e > 1)
                            i += e - 1;
                        break;
                    }
                }
            }

            return Out.ToString();
        }

        string GiaiNenChuoiNhiPhan(string str)
        {
            StringBuilder Out = new StringBuilder("");

            int e = 0;

            if (string.Equals(str[0].ToString(), "0"))
                e = 1;

            string bit;

            for (int i = e; i < str.Length; i++)
            {
                if (i % 2 == 0) bit = "1";
                else bit = "0";

                int length = Convert.ToInt16(str[i].ToString());

                for (int j = 0; j < length; j++)
                    Out.Append(bit);
            }

            return Out.ToString();
        }
        private void btnCompress_Click(object sender, EventArgs e)
        {
            btnCompress.Text = "Processing...";
            LockTinhNang();
            string base64String = ChuyenAnhThanhChuoi(pictureBoxInput.Image);
            string ChuoiNhiPhan = ChuyenASCsangNhiPhan(base64String);
            string ChuoiNen = NenChuoiNhiPhan(ChuoiNhiPhan);

            SaveFileDialog sfl = new SaveFileDialog();
            sfl.Filter = "Nén (*.NEN)|*.nen";

            if (sfl.ShowDialog() == DialogResult.OK)
            {
                if (pictureBoxInput.Image != null)
                {
                    FileStream file = new FileStream(sfl.FileName, FileMode.Append, FileAccess.Write, FileShare.None);
                    StreamWriter ghi = new StreamWriter(file);
                    ghi.Write(ChuoiNen);

                    ghi.Dispose();
                    ghi.Close();
                    file.Dispose();
                    file.Close();
                }
            }
            UnlockTinhNang();
            btnCompress.Text = "NÉN ẢNH";

        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            btnDecompress.Text = "Processing...";
            LockTinhNang();
            //tạo hộp thoại mở file
            OpenFileDialog ofd = new OpenFileDialog();

            //thiết lập chọn 1 hoặc nhiều file
            ofd.Multiselect = false;
            ofd.Filter = "(*.NEN)|*.nen";

            //cho hiện hộp thoại mở file và xét nếu ấn vào ok thì thực hiện lệnh
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream file = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    StreamReader doc = new StreamReader(file);

                    string ChuoiGiaiNen = GiaiNenChuoiNhiPhan(doc.ReadToEnd());

                    doc.Dispose();
                    doc.Close();
                    file.Dispose();
                    file.Close();

                    string ChuoiAnh = ChuyenNhiPhanSangASC(ChuoiGiaiNen);
                    pictureBoxOutput.Image = ChuyenChuoiThanhAnh(ChuoiAnh);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    MessageBox.Show("Ảnh không hợp lệ, ảnh không đúng định dạng file nén!", "Format image");
                }

            }
            UnlockTinhNang();
            btnDecompress.Text = "GIẢI NÉN ẢNH";
        }

        public Image ChuyenChuoiThanhAnh(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);

            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            ms.Write(imageBytes, 0, imageBytes.Length);

            Image image = Image.FromStream(ms, true);

            return image;
        }

        string ChuyenNhiPhanSangASC(string Input)
        {
            FileStream file = new FileStream(Directory.GetCurrentDirectory() + @"\ASCtoNhiPhan.txt", FileMode.Open, FileAccess.Read, FileShare.None);

            StreamReader doc = new StreamReader(file);

            string Temp, NhiPhan, ThapPhan, Hex, ASC;

            StringBuilder Output = new StringBuilder("");

            string Chuoi;

            for (int i = 0; i < Input.Length; i = i + 8)
            {
                Chuoi = Input.Substring(i, 8);

                //đọc từng dòng một
                Temp = doc.ReadLine();

                while (Temp != null)
                {

                    NhiPhan = Temp.Substring(0, 8).ToString();
                    ThapPhan = Temp.Substring(9, 3).ToString().Trim();
                    Hex = Temp.Substring(13, 2).ToString();
                    ASC = Temp.Substring(16, 1);

                    if (NhiPhan == Chuoi)
                    {
                        Output.Append(ASC);
                        file.Seek(0, SeekOrigin.Begin);
                        break;
                    }

                    Temp = doc.ReadLine();
                }
            }

            doc.Dispose();
            doc.Close();
            file.Dispose();
            file.Close();

            return Output.ToString();
        }
        #endregion

        #region lam net anh
        private void btnReduceImage_Click(object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
                try
                {
                    pictureBoxOutput.Image = sharpen(bmp);
                }
                finally
                {
                    this.Invoke(() =>
                    {
                        UnlockTinhNang();
                        btnSharpen.Text = "LÀM NÉT ẢNH";
                    });
                }
            });
            btnSharpen.Text = "Processing...";
            LockTinhNang();
            thread.IsBackground = true;
            thread.Start();
        }

        private Bitmap sharpen(Bitmap image)
        {
            Bitmap sharpenImage = new Bitmap(image.Width, image.Height);


            int filterWidth = 3;
            int filterHeight = 3;
            int w = image.Width;
            int h = image.Height;

            double[,] filter = new double[filterWidth, filterHeight];

            filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
            filter[1, 1] = 9;

            double factor = 1.0;
            double bias = 0.0;

            Color[,] result = new Color[image.Width, image.Height];

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;
                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (x - filterWidth / 2 + filterX + w) % w;
                            int imageY = (y - filterHeight / 2 + filterY + h) % h;
                            Color imageColor = image.GetPixel(imageX, imageY);

                            red += imageColor.R * filter[filterX, filterY];
                            green += imageColor.G * filter[filterX, filterY];
                            blue += imageColor.B * filter[filterX, filterY];
                        }
                        int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
                        int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
                        int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

                        result[x, y] = Color.FromArgb(r, g, b);
                    }
                }
            }
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                {
                    sharpenImage.SetPixel(i, j, result[i, j]);
                }
            }
            return sharpenImage;
        }
        #endregion

        #region
        //Haduc25 @08/11/2022 15:05pm
        //Github: https://github.com/haduc25/XuLyAnh_ImageDistortion

        #endregion
    }
}