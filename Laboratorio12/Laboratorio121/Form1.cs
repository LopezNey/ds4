using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio121
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            txtVelocidad.Clear();
            txtTiempo.Clear();
            txtResultado.Clear();
            txtVelocidad.Focus();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double velocidad, tiempo, distancia;

            velocidad = Convert.ToDouble(txtVelocidad.Text);
            tiempo = Convert.ToDouble(txtTiempo.Text);

            distancia = velocidad * tiempo;

            txtResultado.Text = distancia.ToString("0.00");
        }
    }
}
