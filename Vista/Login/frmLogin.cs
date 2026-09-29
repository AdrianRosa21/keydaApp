using Modelo.Conexión_DB;
using Modelo.Entidades;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Vista.Dashboard;
using Vista.DashboardSecretario;
using Vista.Recuperar_Contraseña;
using Vista.Responsive;

namespace Vista.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            ConfigurarTooltips();
            ConfigurarBotonIngresar();

        }



        private void ConfigurarBotonIngresar()
        {
            btnIngresar.FillColor = Color.FromArgb(121, 75, 45);
            btnIngresar.ForeColor = Color.White;

            btnIngresar.BorderColor = Color.FromArgb(121, 75, 45);
            btnIngresar.BorderThickness = 0;
            btnIngresar.BorderRadius = 15;

            btnIngresar.Font = new Font("Times New Roman", 16, FontStyle.Bold);

            // Efecto Hover
            btnIngresar.HoverState.FillColor = Color.FromArgb(92, 55, 35);
            btnIngresar.HoverState.ForeColor = Color.White;
            btnIngresar.HoverState.BorderColor = Color.FromArgb(92, 55, 35);

            // Efecto al presionar
            btnIngresar.PressedColor = Color.FromArgb(75, 45, 30);

            btnIngresar.Cursor = Cursors.Hand;
        }


        private void ConfigurarTooltips()
        {
            // Crear ToolTip
            ToolTip toolTip1 = new ToolTip();

            // Propiedades del ToolTip
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;

            // Datos de inicio de sesión
            toolTip1.SetToolTip(txtUsuario, "Ingrese su nombre de usuario.");

            toolTip1.SetToolTip(txtContraseña, "Ingrese su contraseña.");

            // Botones
            toolTip1.SetToolTip(btnIngresar, "Inicia sesión con el usuario y contraseña ingresados.");

            toolTip1.SetToolTip(btnRecuperarContrasena, "Permite recuperar su contraseña.");

        }
        private void IniciarSesion()
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Ingrese su nombre de usuario.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Ingrese su contraseña.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtContraseña.Focus();
                return;
            }

            using (SqlConnection conexion = Conexion.Conectar())
            {
                string consulta = @"SELECT IdUsuario, Nombre, Usuario, Contraseña, Rol, Estado FROM Usuario WHERE Usuario COLLATE Latin1_General_CS_AS = @Usuario";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario", usuario);

                    try
                    {
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (!lector.Read())
                            {
                                MessageBox.Show("El usuario o la contraseña son incorrectos.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }

                            // Obtener información del usuario
                            int idUsuario = Convert.ToInt32(lector["IdUsuario"]);


                            string nombre = lector["Nombre"].ToString();
                            string usuarioBD = lector["Usuario"].ToString();
                            if (!string.Equals(usuario, usuarioBD, StringComparison.Ordinal))
                            {
                                MessageBox.Show("El usuario debe coincidir exactamente.\nRespete mayúsculas y minúsculas.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                txtUsuario.Focus();

                                return;
                            }
                            string hashGuardado = lector["Contraseña"].ToString();
                            string rol = lector["Rol"].ToString();
                            bool estado = Convert.ToBoolean(lector["Estado"]);

                            // Con esa informacion , ahora si se puede comprobar si el usuario está activo o no , principalmente con el ESTADO
                            if (!estado)
                            {
                                MessageBox.Show("Este usuario se encuentra desactivado.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                return;
                            }

                            // Verificar contraseña con BCrypt
                            bool contraseñaCorrecta = BCrypt.Net.BCrypt.Verify(contraseña, hashGuardado);
                            // Si algo sale mal y en caso la contraseña sea incorrecta
                            if (!contraseñaCorrecta)
                            {
                                MessageBox.Show("El usuario o la contraseña son incorrectos.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtContraseña.Clear();
                                txtContraseña.Focus();

                                return;
                            }

                            DbUsuarios usuarios = new DbUsuarios(idUsuario, nombre, usuarioBD, hashGuardado, rol, estado);

                            // Abrir Dashboard según el rol
                            if (rol == "Administrador")
                            {
                                frmDashboard dashboard = new frmDashboard();

                                dashboard.Show();
                            }
                            else if (rol == "Secretario")
                            {
                                frmDashboardSecretariocs dashboard = new frmDashboardSecretariocs();

                                dashboard.Show();
                            }

                            // Ocultar Login
                            this.Hide();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al iniciar sesión:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRecuperarContrasena_Click(object sender, EventArgs e)
        {
            frmRecuperarClave recuperar = new frmRecuperarClave();

            recuperar.Show();
        }

        private void CargarLogoEmpresa()
        {
            string rutaLogo = Modelo.Properties.Settings.Default.LogoEmpresa;

            if (!string.IsNullOrWhiteSpace(rutaLogo) && File.Exists(rutaLogo))
            {
                try
                {
                    if (picLogo.Image != null)
                    {
                        picLogo.Image.Dispose();
                        picLogo.Image = null;
                    }

                    using (Image imagenOriginal = Image.FromFile(rutaLogo))
                    {
                        picLogo.Image = new Bitmap(imagenOriginal);
                    }

                    picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    picLogo.Image = null;
                }
            }
            else
            {
                picLogo.Image = null;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            CargarLogoEmpresa();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}

