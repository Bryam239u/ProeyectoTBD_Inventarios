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
    }
}
