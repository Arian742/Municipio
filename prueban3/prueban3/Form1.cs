using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueban3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'agendaDataSet1.Socios' Puede moverla o quitarla según sea necesario.
            this.sociosTableAdapter1.Fill(this.agendaDataSet1.Socios);
            // TODO: esta línea de código carga datos en la tabla 'agendaDataSet.Socios' Puede moverla o quitarla según sea necesario.
            this.sociosTableAdapter1.Fill(this.agendaDataSet1.Socios);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.sociosTableAdapter1.Insert(txtId.Text, txtNombre.Text, txtTelefono.Text);
            //Actualizamos la grilla
            this.sociosTableAdapter1.Fill(this.agendaDataSet1.Socios);
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            int nuevoId = Convert.ToInt32(dgvSocios.Rows[dgvSocios.Rows.Count - 1].Cells[0].Value) + 1;

        }
    }
}
