using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDistortion
{
    public partial class BrightnessForm : Form
    {
        public BrightnessForm()
        {
            InitializeComponent();
        }

        private int brightnessValue = 0;

        private void btnOk_Click(object sender, EventArgs e)
        {
            brightnessValue = String.IsNullOrEmpty(txtBrightness.Text) ? 0 : Convert.ToInt32(txtBrightness.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int getBrightness()
        {
            return brightnessValue;
        }

        private void BrightnessForm_Load(object sender, EventArgs e)
        {
            txtBrightness.Text = brightnessValue.ToString();
            txtBrightness.MaxLength = 3;
        }

        private void txtBrightness_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
