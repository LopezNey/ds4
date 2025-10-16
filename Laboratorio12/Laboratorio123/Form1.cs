using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio123
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSemiperimetro_Click(object sender, EventArgs e)
        {
            double lado1, lado2, lado3, semiperimetro;
            lado1 = Convert.ToDouble(txtLadoA.Text);
            lado2 = Convert.ToDouble(txtLadoB.Text);
            lado3 = Convert.ToDouble(txtLadoC.Text);
            semiperimetro = (lado1 + lado2 + lado3) / 2;

            txtSemiperimetro.Text = semiperimetro.ToString("0.00");
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            double lado1, lado2, lado3, semiperimetro, area;
            lado1 = Convert.ToDouble(txtLadoA.Text);
            lado2 = Convert.ToDouble(txtLadoB.Text);
            lado3 = Convert.ToDouble(txtLadoC.Text);
            semiperimetro = (lado1 + lado2 + lado3) / 2;
            area = Math.Sqrt(semiperimetro * (semiperimetro - lado1) * (semiperimetro - lado2) * (semiperimetro - lado3));
            txtArea.Text = area.ToString("0.00");
        }

        private void bnReset_Click(object sender, EventArgs e)
        {
            txtArea.Clear();
            txtLadoA.Clear();
            txtLadoB.Clear();
            txtLadoC.Clear();
            txtSemiperimetro.Clear();
            txtLadoA.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
