using Modelo.Conexión_DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modelo.Entidades
{
    public class DbFactura
    {
        private int IdFactura;
        private DateTime FechaEmision;
        private DateTime FechaVencimiento;
        private decimal Descuento;
        private int IdVenta;
        private string Observaciones;

        public DbFactura(int idFactura, DateTime fechaEmisión, DateTime fechaVencimiento, int venta, string observaciones)
        {
            IdFactura = idFactura;
            FechaEmision = fechaEmisión;
            FechaVencimiento = fechaVencimiento;
            IdVenta = venta;
            Observaciones = observaciones;
        }

        public DbFactura()
        {
        }

        public int IdFactura1 { get => IdFactura; set => IdFactura = value; }
        public DateTime FechaEmisión1 { get => FechaEmision; set => FechaEmision = value; }
        public DateTime FechaVencimiento1 { get => FechaVencimiento; set => FechaVencimiento = value; }
        public int Venta1 { get => IdVenta; set => IdVenta = value; }
        public string Observaciones1 { get => Observaciones; set => Observaciones = value; }
        public decimal Descuento1 { get => Descuento; set => Descuento = value; }

        // CARGAR FACTURAS
        public static DataTable CargarRegistrosFacturas()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conectar = Conexion.Conectar())
                {
                    string comando = "SELECT * FROM VerFacturas;";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando, conectar))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 53:
                        MessageBox.Show("No se puede conectar al servidor SQL.", "ERR-SQL-001", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 4060:
                        MessageBox.Show("No se puede acceder a la base de datos.", "ERR-SQL-002", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case -2:
                        MessageBox.Show("Tiempo de espera agotado.", "ERR-SQL-003", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 208:
                    case 207:
                        MessageBox.Show("Tabla, vista o procedimiento no encontrado.", "ERR-SQL-004", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 2812:
                        MessageBox.Show("Procedimiento almacenado inexistente.", "ERR-SQL-012", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 201:
                        MessageBox.Show("Faltan parámetros requeridos.", "ERR-SQL-013", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 8144:
                        MessageBox.Show("Parámetros no válidos.", "ERR-SQL-014", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 18456:
                        MessageBox.Show("Error de autenticación SQL Server.", "ERR-SQL-017", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show("Error SQL inesperado.", "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado.", "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // INSERTAR FACTURA
        public int InsertarFactura()
        {
            string sql = @"INSERT INTO Factura 
                           (FechaEmision, FechaVencimiento, IdVenta, Descuento, Observaciones)
                           VALUES
                           (@FechaEmision, @FechaVencimiento, @IdVenta, @Descuento, @Observaciones);
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@FechaEmision", FechaEmision);
                    cmd.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
                    cmd.Parameters.AddWithValue("@IdVenta", IdVenta);
                    cmd.Parameters.AddWithValue("@Descuento", Descuento);
                    cmd.Parameters.AddWithValue("@Observaciones",
                        string.IsNullOrWhiteSpace(Observaciones) ? (object)DBNull.Value : Observaciones);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Registro duplicado.", "ERR-SQL-005", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case 2601:
                        MessageBox.Show("Índice UNIQUE duplicado.", "ERR-SQL-006", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case 547:
                        MessageBox.Show("Violación de clave foránea o restricción CHECK.", "ERR-SQL-007", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case 515:
                        MessageBox.Show("Campo obligatorio sin valor.", "ERR-SQL-008", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 245:
                        MessageBox.Show("Conversión de datos incorrecta.", "ERR-SQL-009", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 8115:
                        MessageBox.Show("Desbordamiento numérico.", "ERR-SQL-010", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 8152:
                    case 2628:
                        MessageBox.Show("Los datos exceden la longitud permitida.", "ERR-SQL-011", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 53:
                        MessageBox.Show("No se puede conectar al servidor SQL.", "ERR-SQL-001", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 4060:
                        MessageBox.Show("No se puede acceder a la base de datos.", "ERR-SQL-002", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case -2:
                        MessageBox.Show("Tiempo de espera agotado.", "ERR-SQL-003", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 2812:
                        MessageBox.Show("Procedimiento almacenado inexistente.", "ERR-SQL-012", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 201:
                        MessageBox.Show("Faltan parámetros requeridos.", "ERR-SQL-013", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 8144:
                        MessageBox.Show("Parámetros no válidos.", "ERR-SQL-014", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 8114:
                        MessageBox.Show("Error de conversión de valores.", "ERR-SQL-015", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 1205:
                        MessageBox.Show("Bloqueo o deadlock entre transacciones.", "ERR-SQL-016", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 18456:
                        MessageBox.Show("Error de autenticación SQL Server.", "ERR-SQL-017", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show("Error SQL inesperado.", "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                return 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado.", "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // BUSCAR VENTA PARA FACTURA
        public static DataTable BuscarVentaParaFactura(int idVenta)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conectar = Conexion.Conectar())
                {
                    string comando = @"SELECT * 
                                       FROM VerVentasParaFactura 
                                       WHERE [#] = @IdVenta;";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando, conectar))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@IdVenta", idVenta);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                MostrarErrorSql(ex, "buscar la venta para factura");
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado.", "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // CARGAR DETALLE DE VENTA
        public static DataTable CargarDetalleVentaParaFactura(int idVenta)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conectar = Conexion.Conectar())
                {
                    string comando = @"SELECT * 
                                       FROM VerDetalleVenta 
                                       WHERE IdVenta = @IdVenta;";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando, conectar))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@IdVenta", idVenta);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                MostrarErrorSql(ex, "cargar el detalle de la venta");
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado.", "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // CARGAR FACTURA POR ID
        public static DataTable CargarFacturaPorId(int idFactura)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conectar = Conexion.Conectar())
                {
                    string comando = @"SELECT * 
                                       FROM VerFacturaEditar 
                                       WHERE IdFactura = @IdFactura";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando, conectar))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@IdFactura", idFactura);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                MostrarErrorSql(ex, "cargar la factura");
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado.", "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // ACTUALIZAR FACTURA
        public static void ActualizarFactura(int idFactura, DateTime fechaVencimiento, decimal? descuento, string observaciones)
        {
            string sql = @"UPDATE Factura 
                           SET FechaVencimiento = @FechaVencimiento,
                               Descuento = @Descuento,
                               Observaciones = @Observaciones
                           WHERE IdFactura = @IdFactura";

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);
                    cmd.Parameters.AddWithValue("@Descuento", (object)descuento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Observaciones",
                        string.IsNullOrWhiteSpace(observaciones) ? (object)DBNull.Value : observaciones);
                    cmd.Parameters.AddWithValue("@IdFactura", idFactura);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Factura actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la factura seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (SqlException ex)
            {
                MostrarErrorSql(ex, "actualizar la factura");
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado.", "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BUSCAR FACTURAS
        public static DataTable BuscarFacturas(string texto)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                {
                    string consulta = @"SELECT *
                                        FROM VerFacturas
                                        WHERE CAST(IdFactura AS VARCHAR) LIKE '%' + @Texto + '%'
                                        OR Cliente LIKE '%' + @Texto + '%'
                                        ORDER BY IdFactura DESC";

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Texto", texto ?? "");

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(dt);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MostrarErrorSql(ex, "buscar las facturas");
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado.", "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // MÉTODO CENTRALIZADO PARA ERRORES SQL
        private static void MostrarErrorSql(SqlException ex, string operacion)
        {
            switch (ex.Number)
            {
                case 53:
                    MessageBox.Show("No se puede conectar al servidor SQL.", "ERR-SQL-001", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 4060:
                    MessageBox.Show("No se puede acceder a la base de datos.", "ERR-SQL-002", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case -2:
                    MessageBox.Show("Tiempo de espera agotado.", "ERR-SQL-003", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 208:
                case 207:
                    MessageBox.Show("Tabla, vista o procedimiento no encontrado.", "ERR-SQL-004", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 2627:
                    MessageBox.Show("Registro duplicado.", "ERR-SQL-005", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 2601:
                    MessageBox.Show("Índice UNIQUE duplicado.", "ERR-SQL-006", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 547:
                    MessageBox.Show("Violación de clave foránea o restricción CHECK.", "ERR-SQL-007", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 515:
                    MessageBox.Show("Campo obligatorio sin valor.", "ERR-SQL-008", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 245:
                    MessageBox.Show("Conversión de datos incorrecta.", "ERR-SQL-009", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 8115:
                    MessageBox.Show("Desbordamiento numérico.", "ERR-SQL-010", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 8152:
                case 2628:
                    MessageBox.Show("Los datos exceden la longitud permitida.", "ERR-SQL-011", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 2812:
                    MessageBox.Show("Procedimiento almacenado inexistente.", "ERR-SQL-012", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 201:
                    MessageBox.Show("Faltan parámetros requeridos.", "ERR-SQL-013", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 8144:
                    MessageBox.Show("Parámetros no válidos.", "ERR-SQL-014", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 8114:
                    MessageBox.Show("Error de conversión de valores.", "ERR-SQL-015", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 1205:
                    MessageBox.Show("Bloqueo o deadlock entre transacciones.", "ERR-SQL-016", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 18456:
                    MessageBox.Show("Error de autenticación SQL Server.", "ERR-SQL-017", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                default:
                    MessageBox.Show("Error SQL inesperado.", "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}