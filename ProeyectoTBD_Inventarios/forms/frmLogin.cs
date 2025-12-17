using ProeyectoTBD_Inventarios.clases;
using ProeyectoTBD_Inventarios.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProeyectoTBD_Inventarios
{
    public partial class frmLogin : Form
    {
        data data = new data();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensajeerror;
            bool a = data.TestConnection(out mensajeerror);
            if (a)
            {
                MessageBox.Show("¡Conexión establecida EXITOSAMENTE con Oracle Cloud!",
                                "Prueba Correcta",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                // Si falló, mostramos el mensaje exacto que nos devolvió el helper
                MessageBox.Show("No se pudo conectar.\n\nDetalle:\n" + mensajeerror,
                                "Error de Conexión",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmRegistro registro = new frmRegistro();
            registro.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Validar campos vacíos
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Ingrese usuario y contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Instanciar tu clase data
            data db = new data();

            // 3. Validar credenciales
            int idUsuario = db.ValidarLogin(textBox1.Text.Trim(), textBox2.Text);

            if (idUsuario > 0)
            {
                // -- LOGIN CORRECTO --

                // 4. Registrar la sesión en la BD
                int idSesion = db.RegistrarSesion(idUsuario);

                // IMPORTANTE: Guarda idSesion en una variable global o estática 
                // para usarla cuando el usuario cierre el programa (Update FechaFin).
                // Ejemplo: Program.SesionActualId = idSesion;

                MessageBox.Show("Bienvenido al sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. Abrir el menú principal y cerrar login
                // frmMenuPrincipal menu = new frmMenuPrincipal();
                // menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
