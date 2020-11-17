using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace RepasoParcial
{
    public partial class FormPpal : Form
    {
        Actividad nuevaActividad;
        
        public FormPpal()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CerrarFormulario()
        {
            if (this.InvokeRequired)
            {

                this.BeginInvoke((MethodInvoker)delegate () { this.Close(); });
            }
            else
                this.Close();

            
        }

        private void FormPpal_Load(object sender, EventArgs e)
        {
            nuevaActividad = new Actividad(10);
            nuevaActividad.TimeOut += CerrarFormulario;
            this.dataGridView1.DataSource = PersonaDAO.TraerPersonas();
        }

        private void FormPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.nuevaActividad.hiloResta.Abort();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CerrarFormulario();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.nuevaActividad.Reactivar();
            FormPersona formPersona = new FormPersona();
            this.nuevaActividad.TimeOut += formPersona.CerrarFormulario;
            formPersona.AuxActividad = this.nuevaActividad;
            formPersona.Show();

        }
    }
}
