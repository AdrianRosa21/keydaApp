using Modelo.Conexión_DB;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Modelo.Entidades
{
    public class DbProducción
    {
        private int IdProduccion;
        private int Pedido;
        private string Cliente;
        private string Mueble;
        private DateTime FechaEntrega;
        private string Estado;
        private int Progreso;

        public DbProducción()
        {
        }

        public DbProducción(int idProduccion, int pedido, string cliente, string mueble, DateTime fechaEntrega, string estado, int progreso)
        {
            IdProduccion1 = idProduccion;
            Pedido1 = pedido;
            Cliente1 = cliente;
            Mueble1 = mueble;
            FechaEntrega1 = fechaEntrega;
            Estado1 = estado;
            Progreso1 = progreso;
        }

        public int IdProduccion1 { get => IdProduccion; set => IdProduccion = value; }
        public int Pedido1 { get => Pedido; set => Pedido = value; }
        public string Cliente1 { get => Cliente; set => Cliente = value; }
        public string Mueble1 { get => Mueble; set => Mueble = value; }
        public DateTime FechaEntrega1 { get => FechaEntrega; set => FechaEntrega = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public int Progreso1 { get => Progreso; set => Progreso = value; }

        public static DataTable CargarProducción()
        {
            try
            {
                using (SqlConnection conectar = Conexion.Conectar())
                {
                    string comando = "SELECT * FROM VerProduccion;";

                    SqlDataAdapter adapter = new SqlDataAdapter(comando, conectar);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 208:
                        MessageBox.Show("La vista VerProduccion no existe en la base de datos.", "Error 208", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 53:
                        MessageBox.Show("No se pudo establecer conexión con el servidor.", "Error 53", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 4060:
                        MessageBox.Show("No se pudo acceder a la base de datos.", "Error 4060", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case -2:
                        MessageBox.Show("La consulta tardó demasiado tiempo.", "Error -2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show("Ocurrió un error al cargar las producciones.\n" + ex.Message, "Error " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                return new DataTable();
            }
        }

        public bool ObtenerProduccion()
        {
            string comandoSQL = @"
            SELECT
                IdProduccion,
                IdPedido,
                Cliente,
                Producto,
                [Fecha de Entrega],
                Progreso,
                Estado
            FROM VerProduccion
            WHERE IdProduccion = @IdProduccion;";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                using (SqlCommand comandoObjeto =
                    new SqlCommand(comandoSQL, conexion))
                {
                    comandoObjeto.Parameters.AddWithValue("@IdProduccion", IdProduccion1);

                    try
                    {
                        using (SqlDataReader reader = comandoObjeto.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IdProduccion1 = Convert.ToInt32(reader["IdProduccion"]);

                                Pedido1 = Convert.ToInt32(reader["IdPedido"]);

                                Cliente1 = reader["Cliente"].ToString();

                                Mueble1 = reader["Producto"].ToString();

                                FechaEntrega1 = Convert.ToDateTime(reader["Fecha de Entrega"]);

                                Progreso1 = Convert.ToInt32(reader["Progreso"]);

                                Estado1 = reader["Estado"].ToString();

                                return true;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        switch (ex.Number)
                        {
                            case 208:
                                MessageBox.Show("La vista VerProduccion no existe en la base de datos.", "Error 208", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;

                            case 53:
                                MessageBox.Show("No se pudo establecer conexión con el servidor.", "Error 53", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;

                            case 4060:
                                MessageBox.Show("No se pudo acceder a la base de datos.", "Error 4060", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;

                            case -2:
                                MessageBox.Show("La consulta tardó demasiado tiempo.", "Error -2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;

                            default:
                                MessageBox.Show("Error al consultar la producción.\n" + ex.Message, "Error " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }

                        return false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error inesperado.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
            }

            return false;
        }



        public bool ActualizarProduccion()
        {
            string comandoSQL = @"
        UPDATE Produccion
        SET Progreso = @Progreso
        WHERE IdProduccion = @IdProduccion;

        IF @Progreso = 100
        BEGIN
            UPDATE Pedido
            SET Estado = 'Finalizado'
            WHERE IdPedido = (
                SELECT IdPedido
                FROM Produccion
                WHERE IdProduccion = @IdProduccion
            );
        END";

            using (SqlConnection conexion = Conexion.Conectar())
            {
                SqlTransaction transaccion = null;

                try
                {
                    transaccion = conexion.BeginTransaction();

                    using (SqlCommand comando = new SqlCommand(comandoSQL, conexion, transaccion))
                    {
                        comando.Parameters.Add("@IdProduccion", SqlDbType.Int).Value = IdProduccion;
                        comando.Parameters.Add("@Progreso", SqlDbType.Int).Value = Progreso;

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            transaccion.Rollback();
                            MessageBox.Show("No se encontró la producción que desea actualizar.", "Producción no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        transaccion.Commit();

                        MessageBox.Show("La producción se actualizó correctamente.\nID Producción: " + IdProduccion + " | Progreso: " + Progreso + "%", "Producción actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    if (transaccion != null)
                    {
                        try
                        {
                            transaccion.Rollback();
                        }
                        catch
                        {
                        }
                    }

                    switch (ex.Number)
                    {
                        case 547:
                            MessageBox.Show("No se puede actualizar la producción. Verifique el pedido relacionado.", "Error 547", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case 515:
                            MessageBox.Show("El progreso de la producción es obligatorio.", "Error 515", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case 245:
                            MessageBox.Show("El valor del progreso tiene un formato incorrecto.", "Error 245", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case 8115:
                            MessageBox.Show("El valor ingresado para el progreso es demasiado grande.", "Error 8115", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case 53:
                            MessageBox.Show("No se pudo establecer conexión con el servidor.", "Error 53", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case 4060:
                            MessageBox.Show("No se pudo acceder a la base de datos.", "Error 4060", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case -2:
                            MessageBox.Show("La actualización tardó demasiado tiempo.", "Error -2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        case 208:
                            MessageBox.Show("La tabla Produccion o Pedido no existe.", "Error 208", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        default:
                            MessageBox.Show("Ocurrió un error al actualizar la producción.\n" + ex.Message, "Error " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    if (transaccion != null)
                    {
                        try
                        {
                            transaccion.Rollback();
                        }
                        catch
                        {
                        }
                    }

                    MessageBox.Show("Ocurrió un error inesperado.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static int ContarProduccionesTotales()
        {
            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                {
                    string query = "SELECT COUNT(*) FROM Produccion";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        return Convert.ToInt32(comando.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 208:
                        MessageBox.Show("La tabla Produccion no existe en la base de datos.", "Error 208", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 53:
                        MessageBox.Show("No se pudo establecer conexión con el servidor.", "Error 53", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 4060:
                        MessageBox.Show("No se pudo acceder a la base de datos.", "Error 4060", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case -2:
                        MessageBox.Show("La consulta tardó demasiado tiempo.", "Error -2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show("Error al contar las producciones totales.\n" + ex.Message, "Error " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                return 0;
            }
        }

        public static int ContarProduccionesPendientes()
        {
            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                {
                    string query = @"
                        SELECT COUNT(*)
                        FROM Produccion
                        WHERE Progreso = 0";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        return Convert.ToInt32(comando.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 208:
                        MessageBox.Show("La tabla Produccion no existe en la base de datos.", "Error 208", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 53:
                        MessageBox.Show("No se pudo establecer conexión con el servidor.", "Error 53", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 4060:
                        MessageBox.Show("No se pudo acceder a la base de datos.", "Error 4060", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case -2:
                        MessageBox.Show("La consulta tardó demasiado tiempo.", "Error -2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show("Error al contar las producciones pendientes.\n" + ex.Message, "Error " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                return 0;
            }
        }

        public static int ContarProduccionesEnProceso()
        {
            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                {
                    string query = @"
                        SELECT COUNT(*)
                        FROM Produccion
                        WHERE Progreso BETWEEN 1 AND 99";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        return Convert.ToInt32(comando.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 208:
                        MessageBox.Show("La tabla Produccion no existe en la base de datos.", "Error 208", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 53:
                        MessageBox.Show("No se pudo establecer conexión con el servidor.", "Error 53", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 4060:
                        MessageBox.Show("No se pudo acceder a la base de datos.", "Error 4060", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case -2:
                        MessageBox.Show("La consulta tardó demasiado tiempo.", "Error -2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show("Error al contar las producciones en proceso.\n" + ex.Message, "Error " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                return 0;
            }
        }

        public static int ContarProduccionesFinalizadas()
        {
            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                {
                    string query = @"
                        SELECT COUNT(*)
                        FROM Produccion
                        WHERE Progreso = 100";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        return Convert.ToInt32(comando.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 208:
                        MessageBox.Show("La tabla Produccion no existe en la base de datos.", "Error 208", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 53:
                        MessageBox.Show("No se pudo establecer conexión con el servidor.", "Error 53", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 4060:
                        MessageBox.Show("No se pudo acceder a la base de datos.", "Error 4060", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case -2:
                        MessageBox.Show("La consulta tardó demasiado tiempo.", "Error -2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    default:
                        MessageBox.Show("Error al contar las producciones finalizadas.\n" + ex.Message, "Error " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                return 0;
            }
        }
    }
}