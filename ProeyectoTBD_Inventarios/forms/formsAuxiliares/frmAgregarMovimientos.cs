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

namespace ProeyectoTBD_Inventarios.forms.formsAuxiliares
{
    public partial class frmAgregarMovimientos : Form
    {
        data db = new data();

        public frmAgregarMovimientos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtIdSesion.Text) || string.IsNullOrWhiteSpace(txtTipoMovimiento.Text))
            {
                MessageBox.Show("El ID de Sesión y el Tipo de Movimiento son obligatorios.");
                return;
            }

            try
            {
                // 2. Parseo de datos (Conversión de Texto a Tipos de C#)
                int idSesion = int.Parse(txtIdSesion.Text);
                string tipo = txtTipoMovimiento.Text.ToUpper().Trim(); // Forzamos mayúscula ('E', 'S', 'T')
                DateTime fecha = dtpFecha.Value;
                string observaciones = txtObservaciones.Text;

                // Lógica especial para Origen y Destino (permitir vacíos = NULL)
                int? idOrigen = null;
                if (!string.IsNullOrWhiteSpace(txtIdOrigen.Text))
                {
                    idOrigen = int.Parse(txtIdOrigen.Text);
                }

                int? idDestino = null;
                if (!string.IsNullOrWhiteSpace(txtIdDestino.Text))
                {
                    idDestino = int.Parse(txtIdDestino.Text);
                }

                // 3. Validar restricción CHECK de Oracle antes de enviar
                if (tipo != "E" && tipo != "S" && tipo != "T")
                {
                    MessageBox.Show("El Tipo de Movimiento debe ser 'E', 'S' o 'T'.");
                    return;
                }

                // 4. Llamada a la base de datos
                string resultado = db.InsertarMovimiento(idSesion, tipo, fecha, idOrigen, idDestino, observaciones);

                if (resultado == "OK")
                {
                    MessageBox.Show("Movimiento agregado correctamente.");
                    this.Dispose(); // Cerramos el formulario para volver al grid
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar:\n" + resultado);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, asegúrate de que los campos ID sean números válidos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }
    }
}
