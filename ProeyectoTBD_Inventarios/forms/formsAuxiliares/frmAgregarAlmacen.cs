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
    public partial class frmAgregarAlmacen : Form
    {
        public frmAgregarAlmacen()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El nombre del almacén es obligatorio.");
                return;
            }

            // 2. Instanciar tu clase data
            ProeyectoTBD_Inventarios.clases.data db = new ProeyectoTBD_Inventarios.clases.data();

            // 3. Convertir el CheckBox a 1 o 0
            // Si usas TextBox, sería: int estado = txtActivo.Text == "1" ? 1 : 0;
            int estado = textBox3.Text == "1" ? 1 : 0;

            // 4. Llamar al método
            string resultado = db.InsertarAlmacen(textBox1.Text, textBox2.Text, estado);

            // 5. Verificar resultado
            if (resultado == "OK")
            {
                MessageBox.Show("Almacén guardado correctamente.");
                this.Dispose(); // Cierra la ventana de registro
            }
            else
            {
                MessageBox.Show("Ocurrió un error: " + resultado);
            }
        }
    }
}
