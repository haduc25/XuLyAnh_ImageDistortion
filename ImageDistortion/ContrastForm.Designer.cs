namespace ImageDistortion
{
    partial class ContrastForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lbTuongPhan = new System.Windows.Forms.Label();
            this.txtContrast = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(113, 65);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOk.Location = new System.Drawing.Point(1, 65);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 27);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lbTuongPhan
            // 
            this.lbTuongPhan.AutoSize = true;
            this.lbTuongPhan.Location = new System.Drawing.Point(44, 9);
            this.lbTuongPhan.Name = "lbTuongPhan";
            this.lbTuongPhan.Size = new System.Drawing.Size(112, 20);
            this.lbTuongPhan.TabIndex = 5;
            this.lbTuongPhan.Text = "Độ Tương Phản";
            this.lbTuongPhan.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtContrast
            // 
            this.txtContrast.Location = new System.Drawing.Point(14, 32);
            this.txtContrast.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.txtContrast.Name = "txtContrast";
            this.txtContrast.Size = new System.Drawing.Size(180, 27);
            this.txtContrast.TabIndex = 4;
            this.txtContrast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrast_KeyPress);
            // 
            // ContrastForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 97);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbTuongPhan);
            this.Controls.Add(this.txtContrast);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContrastForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contrast";
            this.Load += new System.EventHandler(this.ContrastForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCancel;
        private Button btnOk;
        private Label lbTuongPhan;
        private TextBox txtContrast;
    }
}