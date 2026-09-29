using Modelo.Entidades;
using System;
using System.Windows.Forms;

namespace Vista.Configuracion_Inicial
{
    public partial class ConfiguracionParte3 : Form
    {
        public ConfiguracionParte3()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmConfiguracionparte2 frm = new frmConfiguracionparte2();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            if (string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Ingrese un correo electrónico.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (!ValidarCorreo(correo))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }
            // Verifica que se haya escrito el nombre.
            if (string.IsNullOrWhiteSpace(txtNombreAdministrador.Text))
            {
                errorProvider1.SetError(txtNombreAdministrador, "Ingrese el nombre completo del administrador.");
                txtNombreAdministrador.Focus();
                return;
            }

            // Verifica que se haya escrito el usuario.
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                errorProvider1.SetError(txtUsuario, "Ingrese un nombre de usuario.");
                txtUsuario.Focus();
                return;
            }

            // Verifica que se haya escrito una contraseña.
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                errorProvider1.SetError(txtContrasena, "Ingrese una contraseña.");
                txtContrasena.Focus();
                return;
            }

            // Verifica que se haya confirmado la contraseña.
            if (string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                errorProvider1.SetError(txtConfirmarContrasena, "Confirme la contraseña.");
                txtConfirmarContrasena.Focus();
                return;
            }

            //Verifica que el correo no este nulo
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "Ingrese un correo.");
                txtContrasena.Focus();
                return;
            }

            // Verifica que ambas contraseñas sean iguales.
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                errorProvider1.SetError(txtConfirmarContrasena, "Las contraseñas no coinciden.");
                txtConfirmarContrasena.Focus();
                return;
            }

            // Verifica que el usuario haya aceptado crear la cuenta.
            if (!chkAceptarCondiciones.Checked)
            {
                errorProvider1.SetError(chkAceptarCondiciones, "Debe aceptar la creación de la cuenta principal para continuar.");
                chkAceptarCondiciones.Focus();
                return;
            }
            // Crea un objeto de la clase DbUsuario.
            DbUsuarios usuario = new DbUsuarios();

            // Intenta crear el administrador inicial.
            bool creado = usuario.CrearAdministradorInicial(txtNombreAdministrador.Text.Trim(), txtUsuario.Text.Trim(), txtContrasena.Text, txtCorreo.Text);

            // Si el administrador se creó correctamente...
            if (creado)
            {
                MessageBox.Show("La cuenta de administrador se creó correctamente.\n\nAhora puede iniciar sesión.", "Configuración completada", MessageBoxButtons.OK, MessageBoxIcon.Information);



                ConfiguracionUltimaParte frm = new ConfiguracionUltimaParte();
                frm.ShowDialog();
                Hide();

            }
        }
        private bool ValidarCorreo(string correo)
        {
            try
            {
                System.Net.Mail.MailAddress correoValidado = new System.Net.Mail.MailAddress(correo);

                return correoValidado.Address == correo;
            }
            catch
            {
                return false;
            }
        }


        private void ConfiguracionParte3_Load(object sender, EventArgs e)
        {
            // Oculta la contraseña mostrando puntos.
            txtContrasena.UseSystemPasswordChar = true;

            // Oculta la confirmación de contraseña mostrando puntos.
            txtConfirmarContrasena.UseSystemPasswordChar = true;
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
