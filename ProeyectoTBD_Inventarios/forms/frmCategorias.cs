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
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void CargarTabla()
        {
            data db = new data();
            DataTable dt = db.ObtenerCategorias();

            // Asignamos los datos a la cuadrícula visual
            dgvCategorias.DataSource = dt;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar que no esté vacío
            if (string.IsNullOrWhiteSpace(txtbNombre.Text))
            {
                MessageBox.Show("Escribe un nombre para la categoría.");
                return;
            }

            // 2. Guardar
            data db = new data();
            string resultado = db.InsertarCategoria(txtbNombre.Text.Trim());

            if (resultado == "OK")
            {
                MessageBox.Show("Categoría guardada con éxito.");

                // 3. Limpiar y recargar la tabla para ver el cambio al instante
                txtbNombre.Clear();
                CargarTabla();
            }
            else
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            // Botón cancelar: Limpia o cierra, según prefieras
            txtbNombre.Clear();
            this.Close();
        }

        private void frmCategorias_Load_1(object sender, EventArgs e)
        {
            CargarTabla();
        }
    }
}