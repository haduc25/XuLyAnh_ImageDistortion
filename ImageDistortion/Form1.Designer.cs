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
            this.openBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.delBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnMucXam = new System.Windows.Forms.Button();
            this.btnKhuNhieu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(12, 12);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(123, 43);
            this.openBtn.TabIndex = 0;
            this.openBtn.Text = "Open Image";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(813, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(123, 43);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save Image";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 232);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(432, 319);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(165, 12);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(123, 43);
            this.delBtn.TabIndex = 2;
            this.delBtn.Text = "Delete Image";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pictureBox2.Location = new System.Drawing.Point(522, 232);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(432, 319);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.SizeModeChanged += new System.EventHandler(this.pictureBox2_SizeModeChanged);
            this.pictureBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox2_DragDrop);
            this.pictureBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox2_DragEnter);
            // 
            // btnMucXam
            // 
            this.btnMucXam.Location = new System.Drawing.Point(12, 77);
            this.btnMucXam.Name = "btnMucXam";
            this.btnMucXam.Size = new System.Drawing.Size(123, 43);
            this.btnMucXam.TabIndex = 4;
            this.btnMucXam.Text = "Chỉnh mức xám";
            this.btnMucXam.UseVisualStyleBackColor = true;
            this.btnMucXam.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // btnKhuNhieu
            // 
            this.btnKhuNhieu.Location = new System.Drawing.Point(165, 77);
            this.btnKhuNhieu.Name = "btnKhuNhieu";
            this.btnKhuNhieu.Size = new System.Drawing.Size(123, 43);
            this.btnKhuNhieu.TabIndex = 5;
            this.btnKhuNhieu.Text = "Khử nhiễu";
            this.btnKhuNhieu.UseVisualStyleBackColor = true;
            this.btnKhuNhieu.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImageDistortion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 552);
            this.Controls.Add(this.btnKhuNhieu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnMucXam);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.openBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ImageDistortion";
            this.Text = "ImageDistortion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button openBtn;
        private Button saveBtn;
        private Button delBtn;
        private PictureBox pictureBox2;
        private Button btnMucXam;
        public PictureBox pictureBox1;
        private Button btnKhuNhieu;
    }
}