namespace ImageDistortion
{
    partial class ImageDistortion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBoxInput = new System.Windows.Forms.PictureBox();
            this.btnDelAll = new System.Windows.Forms.Button();
            this.pictureBoxOutput = new System.Windows.Forms.PictureBox();
            this.btnMucXam = new System.Windows.Forms.Button();
            this.btnKhuNhieu = new System.Windows.Forms.Button();
            this.btnNhiPhan = new System.Windows.Forms.Button();
            this.btnAmBan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSharpen = new System.Windows.Forms.Button();
            this.btnDecompress = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.btnBrightness = new System.Windows.Forms.Button();
            this.btnContrast = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDelOutput = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutput)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOpen.Location = new System.Drawing.Point(6, 26);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(177, 43);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(0, 75);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 43);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // pictureBoxInput
            // 
            this.pictureBoxInput.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBoxInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBoxInput.Image = global::ImageDistortion.Properties.Resources.mai_lan1;
            this.pictureBoxInput.ImageLocation = "";
            this.pictureBoxInput.InitialImage = null;
            this.pictureBoxInput.Location = new System.Drawing.Point(3, 26);
            this.pictureBoxInput.Name = "pictureBoxInput";
            this.pictureBoxInput.Size = new System.Drawing.Size(486, 373);
            this.pictureBoxInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxInput.TabIndex = 0;
            this.pictureBoxInput.TabStop = false;
            // 
            // btnDelAll
            // 
            this.btnDelAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelAll.Location = new System.Drawing.Point(189, 26);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Size = new System.Drawing.Size(177, 43);
            this.btnDelAll.TabIndex = 2;
            this.btnDelAll.Text = "Delete All";
            this.btnDelAll.UseVisualStyleBackColor = true;
            this.btnDelAll.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // pictureBoxOutput
            // 
            this.pictureBoxOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pictureBoxOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBoxOutput.Location = new System.Drawing.Point(3, 26);
            this.pictureBoxOutput.Name = "pictureBoxOutput";
            this.pictureBoxOutput.Size = new System.Drawing.Size(486, 373);
            this.pictureBoxOutput.TabIndex = 3;
            this.pictureBoxOutput.TabStop = false;
            this.pictureBoxOutput.SizeModeChanged += new System.EventHandler(this.pictureBox2_SizeModeChanged);
            this.pictureBoxOutput.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox2_DragDrop);
            this.pictureBoxOutput.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox2_DragEnter);
            // 
            // btnMucXam
            // 
            this.btnMucXam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMucXam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMucXam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMucXam.ForeColor = System.Drawing.Color.White;
            this.btnMucXam.Location = new System.Drawing.Point(206, 87);
            this.btnMucXam.Name = "btnMucXam";
            this.btnMucXam.Size = new System.Drawing.Size(177, 43);
            this.btnMucXam.TabIndex = 4;
            this.btnMucXam.Text = "ẢNH XÁM";
            this.btnMucXam.UseVisualStyleBackColor = false;
            this.btnMucXam.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // btnKhuNhieu
            // 
            this.btnKhuNhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnKhuNhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhuNhieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnKhuNhieu.ForeColor = System.Drawing.Color.White;
            this.btnKhuNhieu.Location = new System.Drawing.Point(6, 26);
            this.btnKhuNhieu.Name = "btnKhuNhieu";
            this.btnKhuNhieu.Size = new System.Drawing.Size(177, 43);
            this.btnKhuNhieu.TabIndex = 5;
            this.btnKhuNhieu.Text = "KHỬ NHIỄU";
            this.btnKhuNhieu.UseVisualStyleBackColor = false;
            this.btnKhuNhieu.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNhiPhan
            // 
            this.btnNhiPhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNhiPhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhiPhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNhiPhan.ForeColor = System.Drawing.Color.White;
            this.btnNhiPhan.Location = new System.Drawing.Point(6, 87);
            this.btnNhiPhan.Name = "btnNhiPhan";
            this.btnNhiPhan.Size = new System.Drawing.Size(177, 43);
            this.btnNhiPhan.TabIndex = 6;
            this.btnNhiPhan.Text = "NHỊ PHÂN";
            this.btnNhiPhan.UseVisualStyleBackColor = false;
            this.btnNhiPhan.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnAmBan
            // 
            this.btnAmBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAmBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAmBan.ForeColor = System.Drawing.Color.White;
            this.btnAmBan.Location = new System.Drawing.Point(206, 26);
            this.btnAmBan.Name = "btnAmBan";
            this.btnAmBan.Size = new System.Drawing.Size(177, 43);
            this.btnAmBan.TabIndex = 7;
            this.btnAmBan.Text = "ÂM BẢN";
            this.btnAmBan.UseVisualStyleBackColor = false;
            this.btnAmBan.Click += new System.EventHandler(this.btnAmBan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxOutput);
            this.groupBox1.Location = new System.Drawing.Point(542, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 402);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBoxInput);
            this.groupBox2.Location = new System.Drawing.Point(12, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(492, 402);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSharpen);
            this.groupBox3.Controls.Add(this.btnDecompress);
            this.groupBox3.Controls.Add(this.btnCompress);
            this.groupBox3.Controls.Add(this.btnBrightness);
            this.groupBox3.Controls.Add(this.btnContrast);
            this.groupBox3.Controls.Add(this.btnNhiPhan);
            this.groupBox3.Controls.Add(this.btnKhuNhieu);
            this.groupBox3.Controls.Add(this.btnAmBan);
            this.groupBox3.Controls.Add(this.btnMucXam);
            this.groupBox3.Location = new System.Drawing.Point(15, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(614, 184);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btnSharpen
            // 
            this.btnSharpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSharpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSharpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSharpen.ForeColor = System.Drawing.Color.White;
            this.btnSharpen.Location = new System.Drawing.Point(405, 141);
            this.btnSharpen.Name = "btnSharpen";
            this.btnSharpen.Size = new System.Drawing.Size(177, 43);
            this.btnSharpen.TabIndex = 12;
            this.btnSharpen.Text = "LÀM NÉT ẢNH";
            this.btnSharpen.UseVisualStyleBackColor = false;
            this.btnSharpen.Click += new System.EventHandler(this.btnReduceImage_Click);
            // 
            // btnDecompress
            // 
            this.btnDecompress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDecompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecompress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDecompress.ForeColor = System.Drawing.Color.White;
            this.btnDecompress.Location = new System.Drawing.Point(206, 141);
            this.btnDecompress.Name = "btnDecompress";
            this.btnDecompress.Size = new System.Drawing.Size(177, 43);
            this.btnDecompress.TabIndex = 11;
            this.btnDecompress.Text = "GIẢI NÉN ẢNH";
            this.btnDecompress.UseVisualStyleBackColor = false;
            this.btnDecompress.Click += new System.EventHandler(this.btnDecompress_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCompress.ForeColor = System.Drawing.Color.White;
            this.btnCompress.Location = new System.Drawing.Point(6, 141);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(177, 43);
            this.btnCompress.TabIndex = 10;
            this.btnCompress.Text = "NÉN ẢNH";
            this.btnCompress.UseVisualStyleBackColor = false;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // btnBrightness
            // 
            this.btnBrightness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBrightness.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrightness.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBrightness.ForeColor = System.Drawing.Color.White;
            this.btnBrightness.Location = new System.Drawing.Point(405, 26);
            this.btnBrightness.Name = "btnBrightness";
            this.btnBrightness.Size = new System.Drawing.Size(177, 43);
            this.btnBrightness.TabIndex = 9;
            this.btnBrightness.Text = "ĐỘ SÁNG";
            this.btnBrightness.UseVisualStyleBackColor = false;
            this.btnBrightness.Click += new System.EventHandler(this.btnBrightness_Click);
            // 
            // btnContrast
            // 
            this.btnContrast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnContrast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContrast.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnContrast.ForeColor = System.Drawing.Color.White;
            this.btnContrast.Location = new System.Drawing.Point(405, 87);
            this.btnContrast.Name = "btnContrast";
            this.btnContrast.Size = new System.Drawing.Size(177, 43);
            this.btnContrast.TabIndex = 8;
            this.btnContrast.Text = "ĐỘ TƯƠNG PHẢN";
            this.btnContrast.UseVisualStyleBackColor = false;
            this.btnContrast.Click += new System.EventHandler(this.btnContrast_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDelOutput);
            this.groupBox4.Controls.Add(this.btnOpen);
            this.groupBox4.Controls.Add(this.btnDelAll);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Location = new System.Drawing.Point(635, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(386, 184);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File";
            // 
            // btnDelOutput
            // 
            this.btnDelOutput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelOutput.Location = new System.Drawing.Point(189, 75);
            this.btnDelOutput.Name = "btnDelOutput";
            this.btnDelOutput.Size = new System.Drawing.Size(177, 43);
            this.btnDelOutput.TabIndex = 3;
            this.btnDelOutput.Text = "Delete Output";
            this.btnDelOutput.UseVisualStyleBackColor = true;
            this.btnDelOutput.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // ImageDistortion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 595);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ImageDistortion";
            this.Text = "ImageDistortion";
            this.Load += new System.EventHandler(this.ImageDistortion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnOpen;
        private Button btnSave;
        private Button btnDelAll;
        private PictureBox pictureBoxOutput;
        private Button btnMucXam;
        public PictureBox pictureBoxInput;
        private Button btnKhuNhieu;
        private Button btnNhiPhan;
        private Button btnAmBan;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button btnBrightness;
        private Button btnContrast;
        private Button btnSharpen;
        private Button btnDecompress;
        private Button btnCompress;
        private Button btnDelOutput;
    }
}