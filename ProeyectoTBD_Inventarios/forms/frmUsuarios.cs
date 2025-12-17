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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            data db = new data();

            // Suponiendo que tu tabla visual se llama 'dgvUsuarios'
            dgvUsuarios.DataSource = db.ObtenerUsuarios();

            // Esto ajusta las columnas al ancho de la ventana
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
