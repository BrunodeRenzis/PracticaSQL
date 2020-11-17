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
    public partial class FormPersona : Form
    {
        Persona unaPersona;
        public Actividad AuxActividad
        {
            set;
            get;
        }
        public FormPersona()
        {
            InitializeComponent();
        }

        public FormPersona (Persona unaPersona)
        {
            this.unaPersona = unaPersona;
        }

        public void CerrarFormulario()
        {
            this.Close();
        }
        private void FormPersona_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// El objeto auxActividad es el que está contando para lanzar el timeout, si realizo una acción debo reactivarlo para que no llegue a 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.AuxActividad.Reactivar();
            if(unaPersona is null)
            {
                unaPersona = new Persona(this.textBox1.Text,this.textBox2.Text,double.Parse(this.textBox3.Text));
            }
        }
    }
}
