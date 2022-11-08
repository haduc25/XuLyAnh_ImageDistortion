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
    public partial class ContrastForm : Form
    {
        public ContrastForm()
        {
            InitializeComponent();
        }
        private double contrastValue = 0;

        private void btnOk_Click(object sender, EventArgs e)
        {
            contrastValue = String.IsNullOrEmpty(txtContrast.Text) ? 0 : Convert.ToDouble(txtContrast.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public double getContrast()
        {
            return contrastValue;
        }

        private void ContrastForm_Load(object sender, EventArgs e)
        {
            txtContrast.Text = contrastValue.ToString();
            txtContrast.MaxLength = 8;
        }

        private void txtContrast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
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
