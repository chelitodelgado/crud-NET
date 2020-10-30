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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void alumnosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.alumnosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.registrosDataSet);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'registrosDataSet.Alumnos' Puede moverla o quitarla según sea necesario.
            this.alumnosTableAdapter.Fill(this.registrosDataSet.Alumnos);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                String conect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\NET\registros.accdb";
                OleDbConnection conexion = new OleDbConnection(conect);
                conexion.Open();

                String elilimina = "DELETE FROM Alumnos WHERE Id=@id";
                OleDbCommand cmd = new OleDbCommand(elilimina, conexion);
                //cmd.Parameters.AddWithValue("@flio",textBox1.text);

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos Eliminados");
                conexion.Close();
            }
            catch (DBConcurrencyException ex)
            {
                MessageBox.Show("Error de concurrencia:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }
    }
}
