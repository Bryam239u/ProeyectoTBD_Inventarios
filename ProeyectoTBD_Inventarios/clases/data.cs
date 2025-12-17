using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProeyectoTBD_Inventarios.clases
{
    internal class data
    {
        private const string WalletPath = @"C:\Users\jaram\OneDrive\Escritorio\Wallet_TBD2025";

        private const string DbUser = "ADMIN";
        private const string DbPassword = "Sandoval_239u";

        private const string TnsName = "tbd2025_high";

        string connectionString = $"User Id={DbUser};Password={DbPassword};Data Source={TnsName};TNS_ADMIN={WalletPath};Connection Timeout=60;";

        private OracleConnection GetConnection()
        {
            OracleConnection conn = new OracleConnection(connectionString);
            conn.Open();
            return conn;
        }

        public DataTable EjecutarConsulta(string sqlQuery)
        {
            using (OracleConnection conn = GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand(sqlQuery, conn))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public string RealizarTransferencia(int idSesion, int origen, int destino, int prod, int cantidad)
        {
            using (OracleConnection conn = GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand("Sp_Realizar_Transferencia", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_IdSesion", OracleDbType.Int32).Value = idSesion;
                    cmd.Parameters.Add("p_IdAlmacenOrigen", OracleDbType.Int32).Value = origen;
                    cmd.Parameters.Add("p_IdAlmacenDestino", OracleDbType.Int32).Value = destino;
                    cmd.Parameters.Add("p_IdProducto", OracleDbType.Int32).Value = prod;
                    cmd.Parameters.Add("p_Cantidad", OracleDbType.Int32).Value = cantidad;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return "Éxito: Transferencia realizada.";
                    }
                    catch (OracleException ex)
                    {
                        if (ex.Number >= 20000 && ex.Number <= 20999)
                        {
                            return "Error de Negocio: " + ex.Message;
                        }
                        else
                        {
                            return "Error Crítico: " + ex.Message;
                        }
                    }
                }
            }
        }

        public bool TestConnection(out string errorMessage)
        {
            errorMessage = string.Empty;

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT 'OK' FROM DUAL", conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result.ToString() == "OK")
                        {
                            return true;
                        }
                        else
                        {
                            errorMessage = "La conexión abrió, pero la base de datos no respondió correctamente.";
                            return false;
                        }
                    }
                }
                catch (OracleException oraEx)
                {
                    errorMessage = $"Error de Oracle (ORA-{oraEx.Number}): {oraEx.Message}";
                    return false;
                }
                catch (Exception ex)
                {
                    errorMessage = $"Error inesperado: {ex.Message}";
                    return false;
                }
            }
        }

    }
}
