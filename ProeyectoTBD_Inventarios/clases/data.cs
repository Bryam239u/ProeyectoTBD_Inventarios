using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProeyectoTBD_Inventarios.clases
{
    internal class data
    {
        private const string WalletPath = @"C:\Users\sleepyy\Desktop\Wallet_TBD2025";

        private const string DbUser = "INVENTARIOS_ALMACENES";
        private const string DbPassword = "Sandoval_239u";

        private const string TnsName = "tbd2025_high";

        string connectionString = $"User Id={DbUser};Password={DbPassword};Data Source={TnsName};TNS_ADMIN={WalletPath};Connection Timeout=60;";

        private OracleConnection GetConnection()
        {
            try
            {
                OracleConnection conn = new OracleConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception($"Error al conectar a la base de datos: {ex.Message}"); 
            }
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

        public string RegistrarUsuario(string username, string password)
        {
            // Usamos GetConnection que ya tienes configurado con tu Wallet
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    // Query con subconsulta para buscar el ID del rol automáticamente
                    string sql = @"
                    INSERT INTO Usuarios (Username, PasswordHash, IdRol, Estado)
                    VALUES (:Username, :Password, (SELECT IdRol FROM Roles WHERE Nombre = 'usuario de consulta'), 'A')";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        // Usamos parámetros para seguridad
                        cmd.Parameters.Add("Username", OracleDbType.Varchar2).Value = username;
                        cmd.Parameters.Add("Password", OracleDbType.Varchar2).Value = password; 

                        cmd.ExecuteNonQuery();
                        return "OK"; // Retornamos código de éxito
                    }
                }
                catch (OracleException ex)
                {
                    // El error 1 es violación de restricción única (Usuario duplicado)
                    if (ex.Number == 1)
                    {
                        return "El nombre de usuario ya existe.";
                    }
                    return $"Error de Oracle: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"Error inesperado: {ex.Message}";
                }
            }
        }

        // MÉTODO 1: Verificar si el usuario existe y la contraseña es correcta
        // Retorna el IdUsuario si es correcto, o -1 si falla.
        public int ValidarLogin(string username, string password)
        {
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    // Consultamos el ID si el usuario coincide, la pass coincide y el estado es 'A'ctivo
                    string sql = "SELECT IdUsuario FROM Usuarios WHERE Username = :User AND PasswordHash = :Pass AND Estado = 'A'";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("User", OracleDbType.Varchar2).Value = username;
                        cmd.Parameters.Add("Pass", OracleDbType.Varchar2).Value = password;

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result); // Login exitoso, retornamos ID
                        }
                    }
                }
                catch (Exception)
                {
                    // Puedes loguear el error aquí si quieres
                    return -1;
                }
                return -1; // Login fallido
            }
        }

        // MÉTODO 2: Insertar la sesión y devolver el ID generado
        public int RegistrarSesion(int idUsuario)
        {
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    // Obtenemos la IP local de la máquina
                    string ipAddress = GetLocalIPAddress();

                    // SQL con cláusula RETURNING para obtener el ID autogenerado al instante
                    string sql = @"
                    INSERT INTO Sesiones (IdUsuario, IpOrigen) 
                    VALUES (:IdUser, :Ip) 
                    RETURNING IdSesion INTO :IdSalida";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("IdUser", OracleDbType.Int32).Value = idUsuario;
                        cmd.Parameters.Add("Ip", OracleDbType.Varchar2).Value = ipAddress;

                        // Parámetro de salida para recibir el ID de la sesión
                        OracleParameter outputParam = new OracleParameter("IdSalida", OracleDbType.Int32);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        cmd.ExecuteNonQuery();

                        // Retornamos el valor recuperado
                        return int.Parse(outputParam.Value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de error básico
                    return 0;
                }
            }
        }

        // Función auxiliar para obtener IP (puedes ponerla privada dentro de data)
        private string GetLocalIPAddress()
        {
            try
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return "127.0.0.1";
            }
            catch { return "Desconocida"; }
        }

    }
}
