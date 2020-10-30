using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace registros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                String conect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\NET\registros.accdb";
                OleDbConnection conexion = new OleDbConnection(conect);
                conexion.Open();

                String inserta = "INSERT INTO Alumnos VALUES(@id,@nombre,@apellido)";
                OleDbCommand cmd = new OleDbCommand(inserta,conexion);
                //cmd.Parameters.AddWithValue("@flio",textBox1.text);

                cmd.Parameters.AddWithValue("@id",Convert.ToInt32(textBox1.Text));
                cmd.Parameters.AddWithValue("@nombre",textBox2.Text);
                cmd.Parameters.AddWithValue("@apellido", textBox3.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro con exito");
                conexion.Close();
            }
            catch(DBConcurrencyException ex)
            {
                MessageBox.Show("Error de concurrencia:\n"+ ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consulta1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void consulta2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }
    }
}
