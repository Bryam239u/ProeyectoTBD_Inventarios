using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProeyectoTBD_Inventarios
{
    public partial class Categorias : Form
    {
        string connectionString = "User Id=TU_USUARIO;Password=TU_PASSWORD;Data Source=localhost:1521/xe;";

        public Categorias()
        {
            InitializeComponent();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = "SELECT IdCategoria, Nombre FROM Categorias ORDER BY IdCategoria DESC";
                    OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvCategorias.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbNombre.Text))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.");
                return;
            }

            if (txtbNombre.Text.Length > 50)
            {
                MessageBox.Show("El nombre no puede exceder los 50 caracteres.");
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Categorias (Nombre) VALUES (:nombre)";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("nombre", txtbNombre.Text.Trim()));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Categoría guardada exitosamente.");

                        txtbNombre.Clear();
                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
        }
    }
}