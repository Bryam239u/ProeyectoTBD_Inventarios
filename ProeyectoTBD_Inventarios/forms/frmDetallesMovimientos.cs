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
    public partial class frmDetallesMovimientos : Form
    {
        // Variable para guardar el ID del Movimiento Padre (FK)
        private int _idMovimientoActual;

        // 1. Modificamos el constructor para PEDIR el ID
        public frmDetallesMovimientos(int idMovimiento)
        {
            InitializeComponent();
            _idMovimientoActual = idMovimiento;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Llena el ComboBox con los productos disponibles
        private void CargarProductos()
        {
            data db = new data();
            // Reutilizamos el método de productos que hicimos antes
            DataTable dt = db.ObtenerProductos();

            cmbProducto.DataSource = dt;
            cmbProducto.DisplayMember = "Producto"; // Nombre de la columna en el SELECT de Productos
            cmbProducto.ValueMember = "Código";     // OJO: Aquí necesitamos el ID real (IdProducto). 
                                                    // Si tu método anterior devolvía SKU, asegúrate de que devuelva IdProducto también.
                                                    // *Ver nota abajo*
        }

        private void frmDetallesMovimientos_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarTablaDetalles();
        }

        private void CargarTablaDetalles()
        {
            data db = new data();
            DataTable dt = db.ObtenerDetallesPorMovimiento(_idMovimientoActual);
            dgvDetalles.DataSource = dt;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (cmbProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.");
                return;
            }

            // Insertar
            data db = new data();
            // Asumimos que el ValueMember del combo nos da el IdProducto (int)
            int idProducto = Convert.ToInt32(cmbProducto.SelectedValue);

            string resultado = db.InsertarDetalle(_idMovimientoActual, idProducto, cantidad);

            if (resultado == "OK")
            {
                // Limpiar campos y recargar la lista
                nudCantidad.Value = 0;
                CargarTablaDetalles();
                // Opcional: Dar foco al combo para meter el siguiente rápido
                cmbProducto.Focus();
            }
            else
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}