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
using System.Configuration;
namespace Ensayo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rUTASBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.rUTASBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.senderosDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'senderosDataSet.RUTAS' Puede moverla o quitarla según sea necesario.
            this.rUTASTableAdapter.Fill(this.senderosDataSet.RUTAS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["Ensayo.Properties.Settings.SenderosConnectionString"];
            SqlConnection conn = new SqlConnection(setting.ConnectionString);

            //seleccionar los campos de operacion
            string query = "SELECT * FROM[Senderos].[dbo].[RUTAS]";
  
            SqlCommand cmdVerCO = new SqlCommand(query, conn);

            //mostrar en el grid
            try
            {
                //conectamos con la base de dtos
                conn.Open();
                //ejecutar comando
                SqlDataReader rdr = cmdVerCO.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                this.rUTASDataGridView.DataSource = dt;
                //cierro datareader y la conexion
                rdr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se hapodido conectar" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.Show();
        }
    }
}
