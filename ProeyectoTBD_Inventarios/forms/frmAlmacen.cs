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
    public partial class frmAlmacen : Form
    {
        public frmAlmacen()
        {
            InitializeComponent();
        }

        private void CargarTabla()
        {
            // 1. Instanciar la clase
            ProeyectoTBD_Inventarios.clases.data db = new ProeyectoTBD_Inventarios.clases.data();

            // 2. Obtener datos
            DataTable dtAlmacenes = db.ObtenerAlmacenes();

            // 3. Asignar al DataGridView
            dataGridView1.DataSource = dtAlmacenes;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregarAlmacen agregarAlmacen = new frmAgregarAlmacen();
            agregarAlmacen.ShowDialog();
            if(agregarAlmacen.IsDisposed)
            {
                CargarTabla();
            }
        }

        private void frmAlmacen_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }
    }
}