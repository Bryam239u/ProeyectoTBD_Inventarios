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

        // --- GESTIÓN DE CATEGORÍAS ---

        // Método 1: Insertar nueva categoría
        public string InsertarCategoria(string nombreCategoria)
        {
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    // SQL simple para insertar. El ID se genera solo (IDENTITY).
                    string sql = "INSERT INTO Categorias (Nombre) VALUES (:Nombre)";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        // Usamos parámetros para evitar problemas con caracteres especiales
                        cmd.Parameters.Add("Nombre", OracleDbType.Varchar2).Value = nombreCategoria;

                        cmd.ExecuteNonQuery();
                        return "OK";
                    }
                }
                catch (OracleException ex)
                {
                    return "Error de Oracle: " + ex.Message;
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }

        // Método 2: Obtener todas las categorías para la tabla
        public DataTable ObtenerCategorias()
        {
            using (OracleConnection conn = GetConnection())
            {
                // Traemos ID y Nombre. Ordenamos por ID para verlas en orden.
                string sql = "SELECT IdCategoria, Nombre FROM Categorias ORDER BY IdCategoria ASC";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
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

        public string InsertarAlmacen(string nombre, string ubicacion, int activo)
        {
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    // Query de inserción. No insertamos IdAlmacen porque es IDENTITY (automático)
                    string sql = "INSERT INTO Almacenes (Nombre, Ubicacion, Activo) VALUES (:Nombre, :Ubicacion, :Activo)";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        // BindByName es importante si el orden de parámetros llegara a cambiar
                        cmd.BindByName = true;

                        cmd.Parameters.Add("Nombre", OracleDbType.Varchar2).Value = nombre;
                        cmd.Parameters.Add("Ubicacion", OracleDbType.Varchar2).Value = ubicacion;
                        // Activo espera un número (1 o 0)
                        cmd.Parameters.Add("Activo", OracleDbType.Int32).Value = activo;

                        cmd.ExecuteNonQuery();
                        return "OK";
                    }
                }
                catch (OracleException ex)
                {
                    return "Error Oracle: " + ex.Message;
                }
                catch (Exception ex)
                {
                    return "Error General: " + ex.Message;
                }
            }
        }

        // METODO 2: Traer datos para la tabla (DataGridView)
        public DataTable ObtenerAlmacenes()
        {
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    // Seleccionamos todo. Usamos DECODE o CASE para que 'Activo' se lea bonito si quieres, 
                    // o lo traemos crudo y lo formatea el DataGrid. Aquí lo traigo directo.
                    string sql = "SELECT IdAlmacen, Nombre, Ubicacion, Activo FROM Almacenes ORDER BY IdAlmacen ASC";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (Exception)
                {
                    // En caso de error retornamos una tabla vacía para no romper el programa
                    return new DataTable();
                }
            }
        }

        // --- GESTIÓN DE PRODUCTOS ---

        // Método 1: Insertar Producto
        // Recibe los tipos de datos correctos (decimal para precio, int para FK)
        public string InsertarProducto(string sku, string nombre, string descripcion, decimal precio, int idCategoria, int activo)
        {
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    string sql = @"
                INSERT INTO Productos (Sku, Nombre, Descripcion, PrecioUnitario, IdCategoria, Activo) 
                VALUES (:Sku, :Nombre, :Descrip, :Precio, :IdCat, 1)";

                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.Parameters.Add("Sku", OracleDbType.Varchar2).Value = sku;
                        cmd.Parameters.Add("Nombre", OracleDbType.Varchar2).Value = nombre;
                        cmd.Parameters.Add("Descrip", OracleDbType.Varchar2).Value = descripcion;
                        cmd.Parameters.Add("Precio", OracleDbType.Decimal).Value = precio;
                        cmd.Parameters.Add("IdCat", OracleDbType.Int32).Value = idCategoria;
                        cmd.Parameters.Add("Activo", OracleDbType.Int32).Value = activo;

                        cmd.ExecuteNonQuery();
                        return "OK";
                    }
                }
                catch (OracleException ex)
                {
                    // Código 1: Violación de restricción única (El SKU ya existe)
                    if (ex.Number == 1)
                    {
                        return "Error: El código SKU '" + sku + "' ya existe en el sistema.";
                    }
                    return "Error de base de datos: " + ex.Message;
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }

        // Método 2: Mostrar Productos (Con JOIN para ver el nombre de la categoría)
        public DataTable ObtenerProductos()
        {
            using (OracleConnection conn = GetConnection())
            {
                // Seleccionamos campos clave y hacemos JOIN con Categorias
                // para mostrar el nombre de la categoría en lugar del ID.
                string sql = @"
                SELECT 
                p.Sku AS ""Código"",
                p.Nombre AS ""Producto"",
                p.PrecioUnitario AS ""Precio"",
                c.Nombre AS ""Categoría"",
                p.Descripcion AS ""Descripción""
                p.Activo AS ""Activo""
                FROM Productos p
                LEFT JOIN Categorias c ON p.IdCategoria = c.IdCategoria
                WHERE p.Activo = 1
                ORDER BY p.Nombre ASC";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
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

    }
}
