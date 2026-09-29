using Modelo.Conexión_DB;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Vista.Login;

namespace Vista.Configuracion_Inicial
{
    public partial class ConfiguracionUltimaParte : Form
    {
        public ConfiguracionUltimaParte()
        {
            InitializeComponent();
        }

        private void btnInicioLogin_Click(object sender, EventArgs e)
        {

            frmLogin frm = new frmLogin();

            frm.ShowDialog();
            this.Close();
        }

        private void lblAAdministrador_Click(object sender, EventArgs e)
        {

        }

        private void CargarInformacionEmpresa()
        {
            // INFORMACIÓN DE LA EMPRESA

            lblNombreEmpresa.Text = Modelo.Properties.Settings.Default.NombreEmpresa;

            lblTelefonoEmpresa.Text = "Tel: " + Modelo.Properties.Settings.Default.TelefonoEmpresa;

            lblCorreoEmpresa.Text = Modelo.Properties.Settings.Default.CorreoEmpresa;

            lblDireccionEmpresa.Text = Modelo.Properties.Settings.Default.DireccionEmpresa;


            // LOGO

            string rutaLogo = Modelo.Properties.Settings.Default.LogoEmpresa;

            if (!string.IsNullOrWhiteSpace(rutaLogo) &&
                File.Exists(rutaLogo))
            {
                using (Image imagenOriginal = Image.FromFile(rutaLogo))
                {
                    picLogoEmpresa.Image = new Bitmap(imagenOriginal);
                }

                picLogoEmpresa.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void CargarAdministrador()
        {
            try
            {
                using (SqlConnection conexion = Conexion.Conectar())
                {
                    if (conexion == null)
                    {
                        MessageBox.Show("ERR-ADM-001: No se pudo establecer conexión con la base de datos.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    string consulta = @"SELECT TOP 1 Nombre, Usuario FROM Usuario
                WHERE Estado = 1
                ORDER BY IdUsuario DESC";

                    try
                    {
                        using (SqlCommand comando = new SqlCommand(consulta, conexion))
                        {
                            using (SqlDataReader lector = comando.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    lblNombreAdmin.Text = lector["Nombre"].ToString();

                                    lblUsuarioAdmin.Text = lector["Usuario"].ToString();

                                }
                                else
                                {
                                    MessageBox.Show("ERR-ADM-003: No se encontró ningún administrador registrado.", "Administrador no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    lblNombreAdmin.Text = "No registrado";
                                    lblUsuarioAdmin.Text = "No registrado";
                                }
                            }
                        }
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("ERR-ADM-002: Ocurrió un error al consultar la información del administrador.", "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERR-ADM-004: Ocurrió un error inesperado al cargar la información del administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfiguracionUltimaParte_Load(object sender, EventArgs e)
        {
            CargarInformacionEmpresa();
            CargarAdministrador();
        }
    }
}
