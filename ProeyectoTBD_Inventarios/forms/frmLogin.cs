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
            // Limpiamos espacios en blanco por si acaso el usuario metió un espacio al final sin querer
            string user = txtUsuario.Text.Trim();
            string pass = txtPassword.Text; // La contraseña NO se trimea usualmente, pero si quieres, ponle .Trim()

            if (user == "" || pass == "")
            {
                MessageBox.Show("Escribe usuario y contraseña.");
                return;
            }

            data db = new data();

            // Llamamos a nuestro método "manual"
            int resultado = db.ValidarLogin(user, pass);

            if (resultado > 0)
            {
                // --- ÉXITO ---
                MessageBox.Show("¡Login Correcto! ID Usuario: " + resultado);

                // Registrar la sesión (esto ya lo tenías y funcionaba aparte)
                db.RegistrarSesion(resultado);

                // Ocultar login y mostrar menú
                this.Hide();
                 frmMenu menu = new frmMenu(); 
                 menu.Show();
            }
            else if (resultado == -1)
            {
                MessageBox.Show("El usuario es correcto, pero la contraseña está mal.", "Error de Password");
            }
            else if (resultado == 0)
            {
                MessageBox.Show("No se encontró ese nombre de usuario en la base de datos.", "Usuario no existe");
            }
            else
            {
                MessageBox.Show("Error de conexión o base de datos.", "Error Crítico");
            }
        }
    }
}
