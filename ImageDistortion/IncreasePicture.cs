namespace ImageDistortion
{
    internal class IncreasePicture
    {
        public static bool increaseBrightness(Bitmap picture, int value)
        {
<<<<<<< HEAD
            try
            {
                // Vòng lặp
                for (int i = 0; i < picture.Width; i++)
                    for (int j = 0; j < picture.Height; j++)
                    {
                        // Lấy giá trị
                        Color color = picture.GetPixel(i, j);
                        // Tính
                        int red = color.R + value < 255 ? color.R + value : 255;
                        int green = color.G + value < 255 ? color.G + value : 255;
                        int blue = color.B + value < 255 ? color.B + value : 255;
                        // Thiết lập lại
                        picture.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
=======
            // Vòng lặp
            for (int i = 0; i < picture.Width; i++)
                for (int j = 0; j < picture.Height; j++)
                {
                    // Lấy giá trị
                    Color color = picture.GetPixel(i, j);
                    // Tính
                    int red = color.R + value < 255 ? color.R + value : 255;
                    int green = color.G + value < 255 ? color.G + value : 255;
                    int blue = color.B + value < 255 ? color.B + value : 255;
                    // Thiết lập lại
                    picture.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
>>>>>>> 93e55aa0d374f6988b21e0debbc8f3bcadb10887
            return true;
        }


        public static bool increaseContrast(Bitmap picture, double value)
        {
            // Khai báo các biến
            int R = 0, G = 0, B = 0;
            double T;
            Color color;

            if (value <= -100 && value >= 100)
                return false;

            // Tính ban đầu
            value = (100.0 + value) / 100.0;
            value *= value;

<<<<<<< HEAD
            int MaxLength = picture.Height > picture.Width ? picture.Height : picture.Width;
            int Width = picture.Width;
            Boolean isError = true;
            //MessageBox.Show("Height: " + picture.Height + "\nWidth: " + picture.Width);

        handle:
            try
            {
                // Vòng lặp đọc điểm ảnh
                for (int i = 0; i < picture.Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        color = picture.GetPixel(i, j);

                        T = color.R / 255.0;
                        T -= 0.5;
                        T *= value;
                        T += 0.5;
                        T *= 255;
                        if (T > 255)
                            R = 255;
                        else if (T < 0)
                            R = 0;

                        T = color.G / 255.0;
                        T -= 0.5;
                        T *= value;
                        T += 0.5;
                        T *= 255;
                        if (T > 255)
                            G = 255;
                        else if (T < 0)
                            G = 0;

                        T = color.B / 255.0;
                        T -= 0.5;
                        T *= value;
                        T += 0.5;
                        T *= 255;
                        if (T > 255)
                            B = 255;
                        else if (T < 0)
                            B = 0;

                        picture.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }

                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, MaxLength.ToString());
                if (isError)
                {
                    isError = false;
                    Width = MaxLength;
                    goto handle;
=======
            // Vòng lặp đọc điểm ảnh
            for (int i = 0; i < picture.Height; i++)
            {
                for (int j = 0; j < picture.Width; j++)
                {
                    color = picture.GetPixel(i, j);

                    T = color.R / 255.0;
                    T -= 0.5;
                    T *= value;
                    T += 0.5;
                    T *= 255;
                    if (T > 255)
                        R = 255;
                    else if (T < 0)
                        R = 0;

                    T = color.G / 255.0;
                    T -= 0.5;
                    T *= value;
                    T += 0.5;
                    T *= 255;
                    if (T > 255)
                        G = 255;
                    else if (T < 0)
                        G = 0;

                    T = color.B / 255.0;
                    T -= 0.5;
                    T *= value;
                    T += 0.5;
                    T *= 255;
                    if (T > 255)
                        B = 255;
                    else if (T < 0)
                        B = 0;

                    picture.SetPixel(i, j, Color.FromArgb(R, G, B));
>>>>>>> 93e55aa0d374f6988b21e0debbc8f3bcadb10887
                }
            }
            return true;
        }
    }
}