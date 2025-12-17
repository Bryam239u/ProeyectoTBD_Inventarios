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
    public partial class frmLogProductos : Form
    {
        public frmLogProductos()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogProductos_Load(object sender, EventArgs e)
        {
            data db = new data();

            // Suponiendo que tu tabla visual se llama 'dgvLogs'
            dgvLogs.DataSource = db.ObtenerLogs();

            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
