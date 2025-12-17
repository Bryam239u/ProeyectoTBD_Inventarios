using System.Windows.Forms;

namespace ProeyectoTBD_Inventarios
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btRegistrarse_Click(object sender, System.EventArgs e)
        {
            string username = txtbUsuario.Text.Trim();
            string email = txtbCorreo.Text.Trim();
            string password = txtbContraseña.Text;
            string confirmPassword = txtbConfirmarCont.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            //string resultado = dataInstance.RegistrarUsuario(username, email, password);
            //MessageBox.Show(resultado);
        }
    }
}
