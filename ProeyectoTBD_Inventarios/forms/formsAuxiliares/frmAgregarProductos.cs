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
    public partial class frmAgregarProductos : Form
    {
        public frmAgregarProductos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSku.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El SKU y el Nombre son obligatorios.");
                return;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione una categoría.");
                return;
            }

            // 2. Validación y Conversión de Precio
            decimal precio = 0;
            if (!decimal.TryParse(textBox3.Text, out precio))
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            // 3. Guardar
            data db = new data();

            // Obtenemos el ID de la categoría seleccionada en el ComboBox
            int idCategoriaSeleccionada = Convert.ToInt32(textBox3.Text);
            int activo = 1; // Asumimos que el producto está activo al crearlo

            string resultado = db.InsertarProducto(
                textBox1.Text.Trim(),
                textBox2.Text.Trim(),
                textBox4.Text.Trim(),
                precio,
                idCategoriaSeleccionada,
                activo
            );

            if (resultado == "OK")
            {
                MessageBox.Show("Producto registrado correctamente.");
                this.Close(); // Cerramos el formulario de registro
            }
            else
            {
                MessageBox.Show(resultado, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
