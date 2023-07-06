using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Guia12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // TODO: esta línea de código carga datos en la tabla 'agendaDataSet.Personas' Puede moverla o quitarla según sea necesario.
            this.personasTableAdapter.Fill(this.agendaDataSet.Personas);
        


        }

        private void dgvPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ConexionAccess_Load(object sender, EventArgs e)
        {

         Tabla.Clear();

         Tabla.Load(claseConexion.Leer("SELECT * FROM Personas ORDER BY Apellido"));
         dgvPersonas.DataSource = Tabla;
         claseConexion.Desconectar();

        }
        ConexionConBD claseConexion = new ConexionConBD();
        DataTable Tabla = new DataTable();

        bool alta = false;
        private void btnAgregar_Click(object sender, EventArgs e)
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
    }
}
