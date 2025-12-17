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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAlmacen almacen = new frmAlmacen();
            almacen.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmProductos productos = new frmProductos();
            productos.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCategorias categorias = new frmCategorias();
            categorias.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmMovimientos movimientos = new frmMovimientos();
            movimientos.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmDetallesMovimientos detallesMovimientos = new frmDetallesMovimientos();
            detallesMovimientos.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmInventarios inventarios = new frmInventarios();
            inventarios.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSesiones sesiones = new frmSesiones();
            sesiones.ShowDialog();
        }
    }
}
