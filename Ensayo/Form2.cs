using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ensayo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //leer archivo de configuracion
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Ensayo.Properties.Settings.SenderosConnectionString"];

            //conectar con la base de datos 
            SqlConnection conn = new SqlConnection(settings.ConnectionString);
            string query =
            "INSERT INTO [Senderos].[dbo].[RUTAS]" +
            "([IDRUTA],[NOMBRE],[DISTANCIA],[DESNIVEL],[FECHA],[LOCALIZACION],[DIFICULTAD]) VALUES( '"+textBoxId.Text+',' + textBox1.Text +','+textBox2.Text+','+textBox3.Text+','+
                dateTimePicker1.Text+','+textBox4.Text+','+ comboBox1.SelectedItem+"')";
            SqlCommand cmdNuevaC = new SqlCommand(query, conn);
         

            try
            {
                //abrir conexion
                conn.Open();
                cmdNuevaC.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se hapodido conectar " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
