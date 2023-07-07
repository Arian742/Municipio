using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        ConexionConBD claseConexion = new ConexionConBD();
        bool alta = false;
        DataTable Tabla = new DataTable();

        private void ConexionAccess_Load(object sender, EventArgs e)
        {
            Tabla.Clear();
            Tabla.Load(claseConexion.Leer("SELECT * FROM Personas ORDER BY Apellido"));
            dgvPersonas.DataSource = Tabla;
            claseConexion.Desconectar();
        }



        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            alta = claseConexion.ABM("INSERT INTO Personas (DNI, Apellido, Nombre, Direccion, Telefono, Telefono2) VALUES('" + txtDni.Text + "', '" + txtApellido.Text + "', '" + txtNombre.Text + "', '" + txtDireccion.Text + "', '" + txtTelefono.Text + "', '" + txtTelefono2.Text + "')");

            if (alta == true)
            {
                MessageBox.Show("Se creó correctamente el registro", "Proceso finalizado:");
                ConexionAccess_Load(null, null);

            }
            else
            {
                MessageBox.Show("No se pudo completar la operación", "Error en el procedimiento:");
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (claseConexion.ABM("DELETE * FROM Personas WHERE DNI=" + txtDni.Text + ";"))
            {
          MessageBox.Show("Se eliminó correctamente el registro", "Proceso finalizado:");
          ConexionAccess_Load(null, null);
            }

           else
           { 
           MessageBox.Show("No se pudo completar la operación", "Error en el procedimiento:");
           }
      
       }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool Modif = false;            Modif = claseConexion.ABM("UPDATE Personas SET Apellido='" + txtApellido.Text + "', Nombre='" + txtNombre.Text + "', Direccion='" + txtDireccion.Text + "', Telefono='" + txtTelefono.Text + "', Telefono2='" + txtTelefono2.Text + "' WHERE DNI=" + txtDni.Text + ";)");            if (Modif == true)            {
                MessageBox.Show("Se modificó correctamente el registro", "Proceso finalizado:");
                ConexionAccess_Load(null, null);            }

            else
            {
                MessageBox.Show("No se pudo completar la operación", "Error en el procedimiento:");
            }
        }

    }
}
