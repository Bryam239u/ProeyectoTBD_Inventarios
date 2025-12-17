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
    public partial class frmRegistro : Form
    {
        data db = new data();
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRegistrarse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtbContraseña.Text) ||
                string.IsNullOrWhiteSpace(txtbConfirmarCont.Text))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validación de coincidencia de contraseña
            if (txtbContraseña.Text != txtbConfirmarCont.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Llamada a la clase DATA
            string resultado = db.RegistrarUsuario(txtbUsuario.Text.Trim(), txtbContraseña.Text);

            if (resultado == "OK")
            {
                MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cierra el formulario de registro
            }
            else
            {
                // Mostramos el error que nos devolvió la clase data (ej: "El nombre de usuario ya existe")
                MessageBox.Show(resultado, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
