using System;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace Vista.Configuracion_Inicial
{
    public partial class frmConfiguracionparte2 : Form
    {
        public frmConfiguracionparte2()
        {
            InitializeComponent();
        }

        private string rutaLogo = "";

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Navegacion.Ir(this, new ConfiguracionInicial());
        }



        private void btnSeleccionarLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirImagen = new OpenFileDialog();

            // Solo permite imágenes JPG, JPEG y PNG
            abrirImagen.Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            abrirImagen.FilterIndex = 1;

            // No permite seleccionar archivos que no sean imágenes
            abrirImagen.CheckFileExists = true;
            abrirImagen.CheckPathExists = true;

            if (abrirImagen.ShowDialog() == DialogResult.OK)
            {
                rutaLogo = abrirImagen.FileName;

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
                catch (Exception)
                {
                    MessageBox.Show("ERR-IMG-001: El archivo seleccionado no es una imagen válida.", "Error de imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    rutaLogo = "";
                }
            }
        }


        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar nombre
                if (string.IsNullOrWhiteSpace(txtNombreEmpresa.Text))
                {
                    errorProvider1.SetError(txtNombreEmpresa, "Ingrese el nombre de la empresa.");
                    txtNombreEmpresa.Focus();
                    return;
                }

                // Validar teléfono
                if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    errorProvider1.SetError(txtTelefono, "Ingrese el teléfono.");
                    txtTelefono.Focus();
                    return;
                }

                // Validar dirección
                if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    errorProvider1.SetError(txtDireccion, "Ingrese la dirección.");
                    txtDireccion.Focus();
                    return;
                }

                // Validar logo
                if (string.IsNullOrWhiteSpace(rutaLogo))
                {
                    errorProvider1.SetError(btnSeleccionarLogo, "Seleccione el logo de la empresa.");
                    btnSeleccionarLogo.Focus();
                    return;
                }

                // Validar correo
                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    errorProvider1.SetError(txtCorreo, "Ingrese el correo electrónico.");
                    txtCorreo.Focus();
                    return;
                }

                if (!ValidarCorreo())
                {
                    errorProvider1.SetError(txtCorreo, "Ingrese un correo electrónico válido.");
                    txtCorreo.Focus();
                    return;
                }

                // GUARDAR DATOS DE LA EMPRESA

                global::Modelo.Properties.Settings.Default.NombreEmpresa = txtNombreEmpresa.Text;

                global::Modelo.Properties.Settings.Default.TelefonoEmpresa = txtTelefono.Text;

                global::Modelo.Properties.Settings.Default.CorreoEmpresa = txtCorreo.Text;

                global::Modelo.Properties.Settings.Default.DireccionEmpresa = txtDireccion.Text;

                // GUARDAR RUTA DEL LOGO

                global::Modelo.Properties.Settings.Default.LogoEmpresa = rutaLogo;

                // GUARDAR PERMANENTEMENTE

                global::Modelo.Properties.Settings.Default.Save();

                MessageBox.Show("La configuración se guardó correctamente.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir siguiente formulario
                Navegacion.Ir(this, new ConfiguracionParte3());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la configuración:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmConfiguracionparte2_Load(object sender, EventArgs e)
        {
            // Cargar datos guardados
            txtNombreEmpresa.Text = Modelo.Properties.Settings.Default.NombreEmpresa;

            txtTelefono.Text = Modelo.Properties.Settings.Default.TelefonoEmpresa;

            txtCorreo.Text = Modelo.Properties.Settings.Default.CorreoEmpresa;

            txtDireccion.Text = Modelo.Properties.Settings.Default.DireccionEmpresa;

            // Cargar ruta del logo
            rutaLogo = Modelo.Properties.Settings.Default.LogoEmpresa;

            // Mostrar logo si existe
            if (!string.IsNullOrWhiteSpace(rutaLogo) &&
                File.Exists(rutaLogo))
            {
                using (Image imagenOriginal = Image.FromFile(rutaLogo))
                {
                    picLogo.Image = new Bitmap(imagenOriginal);
                }

                picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void txtNombreEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, espacios y teclas de control
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != '&' &&
                e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(e.KeyChar) &&
                txtTelefono.Text.Length >= 9)
            {
                e.Handled = true;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar) &&
             e.KeyChar != ',' &&
             e.KeyChar != '.' &&
             e.KeyChar != '#' &&
             e.KeyChar != '-' &&
             e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private bool ValidarCorreo()
        {
            try
            {
                MailAddress correo = new MailAddress(txtCorreo.Text);

                if (correo.Address != txtCorreo.Text)
                {
                    MessageBox.Show("Ingrese un correo válido.", "Configuración",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtCorreo.Focus();
                    return false;
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Ingrese un correo válido.", "Configuración",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != '@' &&
                e.KeyChar != '.' &&
                e.KeyChar != '_' &&
                e.KeyChar != '-' &&
                e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text.Replace("-", "");

            // Solo permitir máximo 8 números
            if (telefono.Length > 8)
            {
                telefono = telefono.Substring(0, 8);
            }

            // Colocar automáticamente el guion
            if (telefono.Length > 4)
            {
                telefono = telefono.Insert(4, "-");
            }

            // Evitar que el evento se repita
            if (txtTelefono.Text != telefono)
            {
                txtTelefono.Text = telefono;
                txtTelefono.SelectionStart = txtTelefono.Text.Length;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }



}


