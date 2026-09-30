using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Vista.Configuracion_Inicial
{
    public partial class ConfiguracionInicial : Form
    {
        private readonly string servidor = @"(localdb)\MSSQLLocalDB";
        private readonly string baseDeDatos = "MueblesKeyda";

        public ConfiguracionInicial()
        {
            InitializeComponent();

            btnSeguir.Enabled = false;

            lblEstadoDB.Text = "No configurada!";
            lblEstadoDB.ForeColor = System.Drawing.Color.Red;
        }


        private void ConfigurarBaseDatos()
        {
            try
            {
                string cadenaMaster = $"Data Source={servidor};Initial Catalog=master;Integrated Security=True;";

                using (SqlConnection conexion = new SqlConnection(cadenaMaster))
                {
                    conexion.Open();

                    if (!ExisteBaseDatos(conexion))
                        EjecutarScript();
                    else
                        VerificarBaseDatos();
                }

                lblEstadoDB.Text = "✓ Configurada";
                lblEstadoDB.ForeColor = System.Drawing.Color.Green;
                btnSeguir.Enabled = true;

                MessageBox.Show("La base de datos se configuró correctamente.", "Muebles Keyda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                lblEstadoDB.Text = "No configurada!";
                lblEstadoDB.ForeColor = System.Drawing.Color.Red;
                btnSeguir.Enabled = false;

                MessageBox.Show(ObtenerMensajeSql(ex), "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblEstadoDB.Text = "No configurada!";
                lblEstadoDB.ForeColor = System.Drawing.Color.Red;
                btnSeguir.Enabled = false;

                MessageBox.Show("No se pudo configurar la base de datos.\n\n" + ex.Message, "Muebles Keyda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ExisteBaseDatos(SqlConnection conexion)
        {
            string consulta = @"SELECT COUNT(*) FROM sys.databases WHERE name = @BaseDeDatos";

            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@BaseDeDatos", baseDeDatos);
                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        private void EjecutarScript()
        {
            string rutaScript = Path.Combine(Application.StartupPath, "MueblesKeyda.sql");

            if (!File.Exists(rutaScript))
                throw new FileNotFoundException("No se encontró el archivo MueblesKeyda.sql.", rutaScript);

            string script = File.ReadAllText(rutaScript);

            string[] bloques = Regex.Split(script, @"^\s*GO\s*(?:--.*)?$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            string cadenaMaster = $"Data Source={servidor};Initial Catalog=master;Integrated Security=True;";

            using (SqlConnection conexion = new SqlConnection(cadenaMaster))
            {
                conexion.Open();

                foreach (string bloque in bloques)
                {
                    string consulta = bloque.Trim();

                    if (string.IsNullOrWhiteSpace(consulta))
                        continue;

                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.CommandTimeout = 120;
                        comando.ExecuteNonQuery();
                    }
                }
            }
        }

        private void VerificarBaseDatos()
        {
            string cadenaConexion = $"Data Source={servidor};Initial Catalog={baseDeDatos};Integrated Security=True;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                string consulta = "SELECT COUNT(*) FROM sys.tables WHERE name = 'Usuario'";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    int existeUsuario = Convert.ToInt32(comando.ExecuteScalar());

                    if (existeUsuario == 0)
                        throw new Exception("La base de datos existe, pero no está configurada correctamente.");
                }
            }
        }

        private string ObtenerMensajeSql(SqlException ex)
        {
            switch (ex.Number)
            {
                case 53:
                    return "ERR-SQL-001 → No se puede conectar al servidor SQL.";

                case 4060:
                    return "ERR-SQL-002 → No se puede acceder a la base de datos.";

                case -2:
                    return "ERR-SQL-003 → Tiempo de espera agotado.";

                case 208:
                    return "ERR-SQL-004 → No se encontró el objeto de la base de datos.";

                case 2627:
                    return "ERR-SQL-005 → Existe un registro duplicado.";

                case 2601:
                    return "ERR-SQL-006 → Existe un registro duplicado.";

                case 547:
                    return "ERR-SQL-007 → No se puede realizar la operación debido a una relación entre tablas.";

                case 515:
                    return "ERR-SQL-008 → No se puede insertar un valor NULL en un campo obligatorio.";

                case 245:
                    return "ERR-SQL-009 → Error de conversión de datos.";

                case 8115:
                    return "ERR-SQL-010 → Se produjo un desbordamiento numérico.";

                case 8152:
                    return "ERR-SQL-011 → Los datos son demasiado largos para el campo.";

                default:
                    return "No se pudo configurar la base de datos.\n\n" + $"Código SQL: {ex.Number}\n" + ex.Message;
            }
        }

        private void btnSeguir_Click(object sender, EventArgs e)
        {
            Navegacion.Ir(this, new frmConfiguracionparte2());
        }


        private void btnConfigurarDB_Click(object sender, EventArgs e)
        {
            ConfigurarBaseDatos();
        }
    }
}