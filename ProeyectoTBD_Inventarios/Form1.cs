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

namespace ProeyectoTBD_Inventarios
{
    public partial class Form1 : Form
    {
        data data = new data();
        public Form1()
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
    }
}
