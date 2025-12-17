using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace ProeyectoTBD_Inventarios
{
    public partial class DetalleMovimiento : Form
    {
        public DetalleMovimiento()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un producto.");
                return;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.");
                return;
            }

            string connectionString = "User Id=TU_USUARIO;Password=TU_PASSWORD;Data Source=TU_DB_ORACLE;";

            string sql = @"INSERT INTO DetalleMovimiento (IdMovimiento, IdProducto, Cantidad) 
                   VALUES (:idMov, :idProd, :cant)";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {

                        cmd.Parameters.Add("idMov", OracleDbType.Int32).Value = 1;
                        cmd.Parameters.Add("idProd", OracleDbType.Int32).Value = cmbProducto.SelectedValue;
                        cmd.Parameters.Add("cant", OracleDbType.Int32).Value = numCantidad.Value;

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Renglón guardado correctamente.");

                        numCantidad.Value = 1;
                        cmbProducto.SelectedIndex = -1;
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Error de Base de Datos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error general: " + ex.Message);
                }

            }
        }
    }
}
