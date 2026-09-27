using Modelo.Conexión_DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Datos
{
    public class DbDashboard
    {


        // INDICADORES

        public DataTable ObtenerIndicadores()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand("sp_Dashboard_Indicadores", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (SqlException ex)
            {
                MostrarErrorSQL(ex, "obtener los indicadores");
                return new DataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al obtener los indicadores:\n" + ex.Message,
                    "C# - Error inesperado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return new DataTable();
            }
        }

        // PEDIDOS ACTIVOS

        public static int ContarPedidosActivos()
        {
            int total = 0;

            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand("sp_ContarPedidosActivos", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    total = Convert.ToInt32(comando.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                MostrarErrorSQL(ex, "obtener los pedidos activos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al obtener los pedidos activos:\n" + ex.Message, "C# - Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return total;
        }

        // COTIZACIONES POR ESTADO

        public static DataTable ObtenerCotizacionesPorEstado()
        {
            DataTable datos = new DataTable();

            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand("sp_Dashboard_CotizacionesEstado", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(datos);
                    }
                }

                return datos;
            }
            catch (SqlException ex)
            {
                MostrarErrorSQL(ex, "obtener las cotizaciones por estado");
                return new DataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al obtener las cotizaciones por estado:\n" + ex.Message, "C# - Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // PEDIDOS POR ESTADO

        public static DataTable ObtenerPedidosPorEstado()
        {
            DataTable datos = new DataTable();

            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand("sp_Dashboard_PedidosEstado", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(datos);
                    }
                }

                return datos;
            }
            catch (SqlException ex)
            {
                MostrarErrorSQL(ex, "obtener los pedidos por estado");
                return new DataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al obtener los pedidos por estado:\n" + ex.Message, "C# - Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // VENTAS MENSUALES

        public DataTable ObtenerVentasPorMes()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand("sp_Dashboard_VentasMensuales", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Anio", DateTime.Now.Year);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (SqlException ex)
            {
                MostrarErrorSQL(ex, "obtener las ventas mensuales");
                return new DataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al obtener las ventas mensuales:\n" + ex.Message, "C# - Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // INVENTARIO POR ESTADO

        public DataTable ObtenerInventarioEstado()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                using (SqlCommand comando = new SqlCommand("sp_Dashboard_InventarioEstado", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (SqlException ex)
            {
                MostrarErrorSQL(ex, "obtener el estado del inventario");
                return new DataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al obtener el estado del inventario:\n" + ex.Message, "C# - Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        // ERRORES SQL

        private static void MostrarErrorSQL(SqlException ex, string operacion)
        {
            switch (ex.Number)
            {
                case 53:
                    MessageBox.Show("ERR-SQL-001: No se puede conectar al servidor SQL.", "ERR-SQL-001", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 4060:
                    MessageBox.Show("ERR-SQL-002: No se puede acceder a la base de datos.", "ERR-SQL-002", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case -2:
                    MessageBox.Show("ERR-SQL-003: Tiempo de espera agotado.", "ERR-SQL-003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 208:
                    MessageBox.Show("ERR-SQL-004: Tabla, vista o procedimiento no encontrado.", "ERR-SQL-004", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 2627:
                    MessageBox.Show("ERR-SQL-005: Registro duplicado por clave primaria/UNIQUE.", "ERR-SQL-005", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 2601:
                    MessageBox.Show("ERR-SQL-006: Registro duplicado por índice UNIQUE.", "ERR-SQL-006", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 547:
                    MessageBox.Show("ERR-SQL-007: Violación de FK/CHECK.", "ERR-SQL-007", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 515:
                    MessageBox.Show("ERR-SQL-008: Campo NOT NULL sin valor.", "ERR-SQL-008", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 245:
                    MessageBox.Show("ERR-SQL-009: Conversión/formato de datos incorrecto.", "ERR-SQL-009", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 8115:
                    MessageBox.Show("ERR-SQL-010: Desbordamiento numérico.", "ERR-SQL-010", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                default:
                    MessageBox.Show("ERR-SQL-999: Error SQL al " + operacion + ".\nDetalle: " + ex.Message, "ERR-SQL-999", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}