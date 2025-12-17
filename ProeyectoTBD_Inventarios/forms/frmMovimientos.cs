using ProeyectoTBD_Inventarios.clases;
using ProeyectoTBD_Inventarios.forms.formsAuxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProeyectoTBD_Inventarios.forms
{
    public partial class frmMovimientos : Form
    {
        data db = new data();

        public frmMovimientos()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarDatos()
        {
            // Llenamos el Grid usando el método nuevo
            dataGridView1.DataSource = db.ObtenerMovimientos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregarMovimientos agregarMovimientos = new frmAgregarMovimientos();
            agregarMovimientos.ShowDialog();
            if(agregarMovimientos.IsDisposed)
            {
                CargarDatos();
            }
        }

        private void frmMovimientos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
