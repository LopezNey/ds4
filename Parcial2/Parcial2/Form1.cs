using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Parcial2
{
    public partial class Conversor : Form
    {
        string connectionString = @"Server=.\sqlexpress;Database=Conversiones;Trusted_Connection=True;";
        public Conversor()
        {
            InitializeComponent();

        }

        private void btn_Conversor_Click(object sender, EventArgs e)
        {
            int cantidadArchivos = int.Parse(txt_Cantidad.Text);
            double tamanoMB = double.Parse(txt_Tamano.Text);

            //4.7 (1 GB) * 1024 (1 MB) = 4812.8 MB
            int resultado = (int)(4812.8 / tamanoMB);


            txt_Resultado.Text = Convert.ToString(resultado);


            string sql = "INSERT INTO Registros(cantidad, tamano, resultado)"
                          + "VALUES('" + txt_Cantidad.Text + "', '" + txt_Tamano.Text + "', '" + txt_Resultado.Text + "')";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Registro insertado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }


            txt_Resultado.Text = "";
        }
        

        private void btn_Historial_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT cantidad, tamano, resultado FROM dbo.Registros", conexion);
                SqlDataReader lector = cmd.ExecuteReader();

                list_Historial.Items.Clear();
                while (lector.Read())
                {
                    list_Historial.Items.Add($"Cantidad: {lector["cantidad"]}, Tamaño: {lector["tamano"]} MB, Resultado: {lector["resultado"]}");
                }

                lector.Close();
                conexion.Close();
            }
        }
    }
}
