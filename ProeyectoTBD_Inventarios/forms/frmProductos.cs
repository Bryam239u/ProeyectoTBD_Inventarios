using ProeyectoTBD_Inventarios.clases;
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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void CargarGrid()
        {
            data db = new data();
            DataTable dt = db.ObtenerProductos();

            // Asignar al DataGridView que tienes en el centro
            dataGridView1.DataSource = dt;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregarProductos agregarProductos = new frmAgregarProductos();
            agregarProductos.ShowDialog();
            if (agregarProductos.IsDisposed)
            {
                CargarGrid();
            }
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}