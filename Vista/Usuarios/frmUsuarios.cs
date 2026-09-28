using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Usuarios
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            ConfigurarTooltips();
            ConfigurarBotonesUsuarios();

        }

        // VARIABLES PARA LA PAGINACIÓN
        private DataTable dtUsuarios;
        private int paginaActual = 1;
        private int registrosPorPagina = 20;
        private int totalPaginas = 0;

        private Guna.UI2.WinForms.Guna2Elipse elipseContenedor;
        private Guna.UI2.WinForms.Guna2Elipse elipsePedidoDatos;
        private Guna.UI2.WinForms.Guna2Elipse elipsePedidosRegistrados;




        private void ConfigurarBotonesUsuarios()
        {
            ConfigurarBotonCafe(btnNuevoUsuario);
            ConfigurarBotonCafe(btnGuardarUsuario);
            ConfigurarBotonCafe(btnDesactivarUsuario);
        }

        private void ConfigurarBotonCafe(Guna.UI2.WinForms.Guna2TileButton boton)
        {
            boton.FillColor = Color.FromArgb(235, 218, 198);
            boton.ForeColor = Color.FromArgb(121, 75, 45);

            boton.BorderColor = Color.FromArgb(121, 75, 45);
            boton.BorderThickness = 1;
            boton.BorderRadius = 10;

            boton.HoverState.FillColor = Color.FromArgb(220, 190, 160);
            boton.HoverState.ForeColor = Color.FromArgb(121, 75, 45);
            boton.HoverState.BorderColor = Color.FromArgb(121, 75, 45);

            boton.PressedColor = Color.FromArgb(205, 175, 145);

            boton.Cursor = Cursors.Hand;
        }
























        private void ConfigurarTooltips()
        {
            ToolTip toolTip1 = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 500,
                ReshowDelay = 200,
                ShowAlways = true
            };

            toolTip1.SetToolTip(txtUsuario, "Ingrese el nombre de usuario.");
            toolTip1.SetToolTip(txtCorreo, "Ingrese el correo electrónico del usuario.");
            toolTip1.SetToolTip(txtContrasena, "Ingrese la contraseña del usuario.");
            toolTip1.SetToolTip(cmbRol, "Seleccione el rol que tendrá el usuario.");
            toolTip1.SetToolTip(chkEstado, "Indica si el usuario se encuentra activo.");
            toolTip1.SetToolTip(btnNuevoUsuario, "Limpia el formulario para registrar un nuevo usuario.");
            toolTip1.SetToolTip(btnGuardarUsuario, "Guarda el nuevo usuario en el sistema.");
            toolTip1.SetToolTip(btnDesactivarUsuario, "Desactiva el usuario seleccionado.");
            toolTip1.SetToolTip(dgvUsuariosRegistrados, "Muestra los usuarios registrados. Haz doble clic para consultar sus datos.");
        }

        private void ConfigurarTablaUsuarios()
        {
            dgvUsuariosRegistrados.EnableHeadersVisualStyles = false;
            dgvUsuariosRegistrados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);
            dgvUsuariosRegistrados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuariosRegistrados.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 9, FontStyle.Regular);
            dgvUsuariosRegistrados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuariosRegistrados.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);
            dgvUsuariosRegistrados.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dgvUsuariosRegistrados.DefaultCellStyle.BackColor = Color.White;
            dgvUsuariosRegistrados.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvUsuariosRegistrados.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvUsuariosRegistrados.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUsuariosRegistrados.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);
            dgvUsuariosRegistrados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);
            dgvUsuariosRegistrados.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvUsuariosRegistrados.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsuariosRegistrados.GridColor = Color.FromArgb(220, 220, 220);
            dgvUsuariosRegistrados.RowTemplate.Height = 32;
            dgvUsuariosRegistrados.ColumnHeadersHeight = 30;
            dgvUsuariosRegistrados.ReadOnly = true;
            dgvUsuariosRegistrados.AllowUserToAddRows = false;
            dgvUsuariosRegistrados.AllowUserToDeleteRows = false;
            dgvUsuariosRegistrados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuariosRegistrados.MultiSelect = false;
            dgvUsuariosRegistrados.BorderStyle = BorderStyle.None;
            dgvUsuariosRegistrados.RowHeadersVisible = false;
        }

        private void RegistrarUsuario()
        {
            try
            {
                string nombre = txtUsuario.Text.Trim();
                string usuarioNombre = txtUsuario.Text.Trim();
                string correo = txtCorreo.Text.Trim();
                string contraseña = txtContrasena.Text;
                bool estado = true;

                // Validar nombre
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    errorProvider1.SetError(txtUsuario, "Debe ingresar el nombre del usuario.");
                    txtUsuario.Focus();
                    return;
                }

                // Validar nombre de usuario
                if (string.IsNullOrWhiteSpace(usuarioNombre))
                {
                    errorProvider1.SetError(txtUsuario, "Debe ingresar un nombre de usuario.");
                    txtUsuario.Focus();
                    return;
                }

                // Validar correo
                if (string.IsNullOrWhiteSpace(correo))
                {
                    errorProvider1.SetError(txtCorreo, "Debe ingresar un correo electrónico.");
                    txtCorreo.Focus();
                    return;
                }

                // Validar formato del correo
                if (!correo.Contains("@") || !correo.Contains("."))
                {
                    errorProvider1.SetError(txtCorreo, "Ingrese un correo electrónico válido.");
                    txtCorreo.Focus();
                    return;
                }

                // Validar contraseña
                if (string.IsNullOrWhiteSpace(contraseña))
                {
                    errorProvider1.SetError(txtContrasena, "Debe ingresar una contraseña.");
                    txtContrasena.Focus();
                    return;
                }

                // Validar rol
                if (cmbRol.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cmbRol, "Se debe seleccionar un rol.");
                    cmbRol.Focus();
                    return;
                }

                string rol = cmbRol.Text.Trim();

                // Validar rol válido
                if (rol != "Administrador" && rol != "Secretario")
                {
                    errorProvider1.SetError(cmbRol, "Se debe seleccionar un rol válido.");
                    cmbRol.Focus();
                    return;
                }

                DbUsuarios nuevoUsuario = new DbUsuarios
                {
                    Nombre1 = nombre,
                    Usuario1 = usuarioNombre,
                    Correo1 = correo,
                    Contraseña1 = contraseña,
                    Rol1 = rol,
                    Estado1 = estado
                };
                nuevoUsuario.InsertarUsuario();

                MessageBox.Show("Usuario registrado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                MostrarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al registrar el usuario: " + ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÓN GUARDAR
        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrarUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DESACTIVAR USUARIO
        private void btnDesactivarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuariosRegistrados.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idUsuario = Convert.ToInt32(dgvUsuariosRegistrados.CurrentRow.Cells["#"].Value);
                string estado = dgvUsuariosRegistrados.CurrentRow.Cells["Estado"].Value?.ToString();

                if (estado == "Inactivo")
                {
                    MessageBox.Show("El usuario seleccionado ya está inactivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult respuesta = MessageBox.Show("¿Está seguro de desactivar este usuario?", "Confirmar desactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    DbUsuarios usuario = new DbUsuarios();
                    usuario.DesactivarUsuario(idUsuario);

                    MessageBox.Show("Usuario desactivado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarUsuarios();
                    LimpiarFormulario();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error 245: El identificador del usuario no es válido.", "Error 245", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al desactivar el usuario: " + ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // MOSTRAR USUARIOS
        private void MostrarUsuarios()
        {
            try
            {
                // Cargar todos los usuarios
                dtUsuarios = DbUsuarios.CargarUsuarios();

                // Volver a la primera página
                paginaActual = 1;

                // Calcular el total de páginas
                CalcularPaginasUsuarios();

                // Mostrar la primera página
                MostrarPaginaUsuarios();

                // El estado se controla desde la base de datos
                // Los nuevos usuarios siempre se registran activos
                chkEstado.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los usuarios:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalcularPaginasUsuarios()
        {
            try
            {
                if (dtUsuarios == null || dtUsuarios.Rows.Count == 0)
                {
                    totalPaginas = 1;
                    paginaActual = 1;
                    return;
                }

                totalPaginas = (int)Math.Ceiling((double)dtUsuarios.Rows.Count / registrosPorPagina);

                if (totalPaginas == 0)
                    totalPaginas = 1;

                if (paginaActual > totalPaginas)
                    paginaActual = totalPaginas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al calcular las páginas: " + ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarPaginaUsuarios()
        {
            try
            {
                if (dtUsuarios == null)
                    return;

                DataTable dtPagina = dtUsuarios.Clone();

                int inicio = (paginaActual - 1) * registrosPorPagina;
                int fin = Math.Min(inicio + registrosPorPagina, dtUsuarios.Rows.Count);

                for (int i = inicio; i < fin; i++)
                    dtPagina.ImportRow(dtUsuarios.Rows[i]);

                dgvUsuariosRegistrados.DataSource = null;
                dgvUsuariosRegistrados.DataSource = dtPagina;

                ConfigurarTablaUsuarios();

                lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";
                btnAnterior.Enabled = paginaActual > 1;
                btnSiguiente.Enabled = paginaActual < totalPaginas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al mostrar los usuarios: " + ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPaginaUsuarios();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPaginaUsuarios();
            }
        }

        // CARGAR FORMULARIO
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarUsuarios();
                chkEstado.Visible = false;
                ConfigurarTablaUsuarios();
                CargarLogoEmpresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al cargar el formulario: " + ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // DOBLE CLIC EN UN USUARIO
        private void dgvUsuariosRegistrados_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                // Evitar seleccionar encabezados
                if (e.RowIndex < 0)
                {
                    return;
                }

                DataGridViewRow fila = dgvUsuariosRegistrados.Rows[e.RowIndex];

                // CARGAR DATOS DEL USUARIO

                txtUsuario.Text = fila.Cells["Nombre"].Value?.ToString();

                txtUsuario.Text = fila.Cells["Usuario"].Value?.ToString();

                txtCorreo.Text = fila.Cells["Correo"].Value?.ToString();

                cmbRol.Text = fila.Cells["Rol"].Value?.ToString();

                // CARGAR ESTADO

                string estado = fila.Cells["Estado"].Value?.ToString();

                if (estado == "Activo")
                {
                    chkEstado.Checked = true;
                }
                else
                {
                    chkEstado.Checked = false;
                }

                // NO MOSTRAR LA CONTRASEÑA

                txtContrasena.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al seleccionar el usuario:\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÓN NUEVO USUARIO
        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            txtUsuario.Focus();
        }


        // LIMPIAR FORMULARIO
        private void LimpiarFormulario()
        {
            txtUsuario.Clear();

            txtCorreo.Clear();

            txtContrasena.Clear();

            cmbRol.SelectedIndex = -1;

            chkEstado.Checked = false;
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

    }
}