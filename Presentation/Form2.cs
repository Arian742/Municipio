using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_entidad;
using Domain;


namespace Presentation
{
    public partial class Form2 : Form
    {
        ClassEntidad objent = new ClassEntidad();
       ClassNegocio objneg = new ClassNegocio();

        public Form2()
        {
            InitializeComponent();
        }

        void mantenimiento(string accion)
        {
            objent.Id=txtCodigo.Text;
            objent.Nombres = txtNombre.Text;
            objent.Apellido_s = txtApellido.Text;
            objent.DNI = txtDni.Text;
            objent.Nacionalidad = txtNacionalidad.Text;
            objent.EstadoCivil = txtEstCivil.Text;
            objent.Domicilio = txtDomicilio.Text;
            objent.NumeroDeCalle = txtNcalle.Text;
            objent.Depto = txtDepto.Text;
            objent.Piso = txtPiso.Text;
            objent.Localidad = txtLocalidad.Text;
            objent.Provincia = txtProvincia.Text;
            objent.TelefonoParticular = txtTelefonofij.Text;
            objent.Celular = txtTelefono.Text;
            string men = objneg.N_mantenimiento_trabajador(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtNacionalidad.Text = "";
            txtEstCivil.Text = "";
            txtDomicilio.Text = "";
            txtNcalle.Text = "";
            txtDepto.Text = "";
            txtPiso.Text = "";
            txtLocalidad.Text = "";
            txtProvincia.Text = "";
            txtTelefonofij.Text = "";
            txtTelefono.Text = "";
            dataGridView1.DataSource = objneg.N_listar_trabajadores();
        }


        











        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_trabajadores();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }


        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + " ?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    objent.accion = "1"; // Para operación de registro
                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txtNombre.Text + " ?", "Mensaje",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txtNombre.Text + " ?", "Mensaje",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }

        }

        private void txtBusqueda2_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda2.Text != "")
            {
                objent.DNI = txtBusqueda2.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_trabajadores(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_listar_trabajadores();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila ].Value.ToString();
            txtApellido.Text = dataGridView1[1, fila].Value.ToString();
            txtNombre.Text = dataGridView1[2, fila].Value.ToString();
            txtDni.Text = dataGridView1[3, fila].Value.ToString();
            txtNacionalidad.Text = dataGridView1[4, fila].Value.ToString();
            txtEstCivil.Text = dataGridView1[5, fila].Value.ToString();
            txtDomicilio.Text = dataGridView1[6, fila].Value.ToString();
            txtNcalle.Text = dataGridView1[7, fila].Value.ToString();
            txtDepto.Text = dataGridView1[8, fila].Value.ToString();
            txtPiso.Text = dataGridView1[9, fila].Value.ToString();
            txtLocalidad.Text = dataGridView1[10, fila].Value.ToString();
            txtProvincia.Text = dataGridView1[11, fila].Value.ToString();
            txtTelefonofij.Text = dataGridView1[12, fila].Value.ToString();
            txtTelefono.Text = dataGridView1[13, fila].Value.ToString();


        }
    }
}
