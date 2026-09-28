using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using Vista.Responsive;


namespace Vista.Proveedores
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            ConfigurarBarraBusqueda();
            ConfigurarBotones();

        }
        private string nombreProveedorOriginal = "";
        private string telefonoProveedorOriginal = "";
        private string correoProveedorOriginal = "";
        private string ubicacionProveedorOriginal = "";
        private const string TextoBusqueda = "Buscar...";
        private readonly Color ColorPlaceholder = Color.LightGray;
        private readonly Color ColorCafe = Color.FromArgb(121, 75, 45);


        private void ConfigurarBarraBusqueda()
        {
            ConfigurarBusqueda(txtBuscar);

        }
        private void ConfigurarBusqueda(Guna2TextBox txtBuscar)
        {
            txtBuscar.Text = TextoBusqueda;
            txtBuscar.ForeColor = ColorPlaceholder;

            txtBuscar.BorderRadius = 10;
            txtBuscar.BorderThickness = 1;
            txtBuscar.BorderColor = Color.LightGray;

            txtBuscar.FocusedState.BorderColor = ColorCafe;

            txtBuscar.Enter += (s, e) =>
            {
                if (txtBuscar.Text == TextoBusqueda)
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }

                txtBuscar.BorderColor = ColorCafe;
                txtBuscar.BorderThickness = 2;
            };

            txtBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = TextoBusqueda;
                    txtBuscar.ForeColor = ColorPlaceholder;
                }

                txtBuscar.BorderColor = Color.LightGray;
                txtBuscar.BorderThickness = 1;
            };
        }

        private void ActualizarBotonEstado()
        {
            if (dgvProveedores.CurrentRow == null)
                return;

            string estado = dgvProveedores.CurrentRow.Cells["Estado"].Value?.ToString();

            if (estado == "Activo")
            {
                btnDesactivarProveedor.Text = "Desactivar";
                btnDesactivarProveedor.FillColor = Color.FromArgb(174, 91, 75);
                btnDesactivarProveedor.ForeColor = Color.White;
                btnDesactivarProveedor.BorderColor = Color.FromArgb(121, 75, 45);

                btnDesactivarProveedor.HoverState.FillColor = Color.FromArgb(195, 110, 90);
                btnDesactivarProveedor.HoverState.ForeColor = Color.White;
                btnDesactivarProveedor.HoverState.BorderColor = Color.FromArgb(121, 75, 45);

                btnDesactivarProveedor.PressedColor = Color.FromArgb(145, 70, 55);
            }
            else
            {
                btnDesactivarProveedor.Text = "Activar";
                btnDesactivarProveedor.FillColor = Color.FromArgb(112, 153, 82);
                btnDesactivarProveedor.ForeColor = Color.White;
                btnDesactivarProveedor.BorderColor = Color.FromArgb(82, 120, 58);

                btnDesactivarProveedor.HoverState.FillColor = Color.FromArgb(135, 175, 100);
                btnDesactivarProveedor.HoverState.ForeColor = Color.White;
                btnDesactivarProveedor.HoverState.BorderColor = Color.FromArgb(82, 120, 58);

                btnDesactivarProveedor.PressedColor = Color.FromArgb(90, 130, 65);
            }
        }

        private void ConfigurarBotones()
        {
            ConfigurarBoton(btnNuevo);
            ConfigurarBoton(btnEditar);
            ConfigurarBoton(btnGuardar);
            ConfigurarBoton(btnGuardarCambios);
            ConfigurarBoton(btnDesactivarProveedor);
        }

        private void ConfigurarBoton(Guna.UI2.WinForms.Guna2Button boton)
        {
            boton.FillColor = Color.FromArgb(230, 215, 198);
            boton.ForeColor = Color.FromArgb(121, 75, 45);

            boton.BorderColor = Color.FromArgb(121, 75, 45);
            boton.BorderThickness = 1;
            boton.BorderRadius = 10;

            boton.HoverState.FillColor = Color.FromArgb(215, 195, 173);
            boton.HoverState.ForeColor = Color.FromArgb(90, 55, 32);
            boton.HoverState.BorderColor = Color.FromArgb(121, 75, 45);

            boton.PressedColor = Color.FromArgb(200, 175, 150);

            boton.Cursor = Cursors.Hand;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------


        // VARIABLES PARA LA PAGINACIÓN
        private DataTable dtProveedores;
        private int paginaActual = 1;
        private int registrosPorPagina = 10;
        private int totalPaginas = 0;

        //------------------------------------------------------------------------------------------------------
        //// CONFIGURAR TOOLTIPS
        private void ConfigurarTooltips()
        {
            // Crear ToolTip
            ToolTip toolTip1 = new ToolTip();

            // Propiedades del ToolTip
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;

            // Búsqueda
            toolTip1.SetToolTip(txtBuscar, "Buscar un proveedor por nombre, teléfono o correo.");

            // Datos del proveedor
            toolTip1.SetToolTip(txtNombreProveedor, "Ingrese el nombre del proveedor.");

            toolTip1.SetToolTip(txtCorreo, "Ingrese el correo electrónico del proveedor.");

            toolTip1.SetToolTip(txtTelefono, "Ingrese el número de teléfono del proveedor.");

            toolTip1.SetToolTip(txtUbicacion, "Ingrese la ubicación o dirección del proveedor.");

            // Estado
            toolTip1.SetToolTip(chkEstado, "Indica si el proveedor se encuentra activo.");

            // Botones
            toolTip1.SetToolTip(btnGuardar, "Guarda el nuevo proveedor.");

            toolTip1.SetToolTip(btnEditar, "Permite editar los datos del proveedor seleccionado.");

            toolTip1.SetToolTip(btnGuardarCambios, "Guarda los cambios realizados al proveedor.");

            toolTip1.SetToolTip(btnDesactivarProveedor, "Desactiva o vuelve a activar el proveedor el proveedor seleccionado.");

            // Tabla
            toolTip1.SetToolTip(dgvProveedores, "Muestra los proveedores registrados. Haz doble clic en un proveedor para seleccionarlo.");
        }

        //------------------------------------------------------------------------------------------------------
        //---------------------- CONFIGURAR TABLA DE PROVEEDORES -----------------------------------------------//
        private void ConfigurarTablaProveedores()
        {
            // Encabezado
            dgvProveedores.EnableHeadersVisualStyles = false;

            dgvProveedores.AllowUserToResizeRows = false;

            dgvProveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 75, 45);

            dgvProveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            dgvProveedores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProveedores.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(121, 75, 45);

            dgvProveedores.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // Filas
            dgvProveedores.DefaultCellStyle.BackColor = Color.White;

            dgvProveedores.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);

            dgvProveedores.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            dgvProveedores.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas
            dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 241, 232);

            // Selección
            dgvProveedores.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 193, 157);

            dgvProveedores.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvProveedores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvProveedores.GridColor = Color.FromArgb(220, 220, 220);

            // Alto de las filas
            dgvProveedores.RowTemplate.Height = 40;

            // Alto del encabezado
            dgvProveedores.ColumnHeadersHeight = 30;

            // No permitir modificar
            dgvProveedores.ReadOnly = true;

            dgvProveedores.AllowUserToAddRows = false;

            dgvProveedores.AllowUserToDeleteRows = false;

            // Seleccionar fila completa
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvProveedores.MultiSelect = false;

            // Quitar borde exterior
            dgvProveedores.BorderStyle = BorderStyle.None;

            // Quitar columna de selección de filas
            dgvProveedores.RowHeadersVisible = false;
        }
        //----------------------------------------------------------------------------------------------
        //----------------------EVENTO LOAD DEL FORMULARIO-------------------------------------------------//
        private void frmProveedores_Load(object sender, EventArgs e)
        {
            MostrarProveedor();

            //CONFIGURACION DE TOOLTIPS
            ConfigurarTooltips();

            //CONFIGURACION DE TOOLTIPS
            ConfigurarTooltips();
            //Maximo de caracteres admitidos
            txtNombreProveedor.MaxLength = 50;
            txtCorreo.MaxLength = 100;
            txtTelefono.MaxLength = 9;
            txtUbicacion.MaxLength = 200;
            //Navegar con la tecla Tab
            txtNombreProveedor.TabIndex = 1;
            txtCorreo.TabIndex = 2;
            txtTelefono.TabIndex = 3;
            txtUbicacion.TabIndex = 4;
            btnGuardar.TabIndex = 5;
            btnEditar.TabIndex = 6;
            btnDesactivarProveedor.TabIndex = 7;

            btnEditar.Visible = false;

            dgvProveedores.Columns["IdProveedor"].Visible = false;

            //Declaramos que el estado del provedor al momento de registrar siempre sea activo, hasta que el usuario lo desactive
            chkEstado.Checked = true;
            chkEstado.Enabled = false;
            chkEstado.Visible = false;

            errorProvider1.SetIconAlignment(txtTelefono, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(txtTelefono, 2);
        }
        private void MostrarProveedor()
        {
            try
            {
                // Cargar todos los proveedores
                dtProveedores = DbProveedor.CargarProveedor();

                // Iniciar desde la primera página
                paginaActual = 1;

                // Calcular cantidad de páginas
                CalcularPaginasProveedores();

                // Mostrar la primera página
                MostrarPaginaProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularPaginasProveedores()
        {
            if (dtProveedores == null || dtProveedores.Rows.Count == 0)
            {
                totalPaginas = 1;
                paginaActual = 1;
                return;
            }

            totalPaginas = (int)Math.Ceiling((double)dtProveedores.Rows.Count / registrosPorPagina
            );

            if (totalPaginas == 0)
                totalPaginas = 1;

            if (paginaActual > totalPaginas)
                paginaActual = totalPaginas;
        }

        private void MostrarPaginaProveedores()
        {
            if (dtProveedores == null)
                return;

            DataTable dtPagina = dtProveedores.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(inicio + registrosPorPagina, dtProveedores.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtProveedores.Rows[i]);
            }
            // Mostrar únicamente los registros de la página actual
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = dtPagina;

            // Ocultar el ID
            if (dgvProveedores.Columns.Contains("IdProveedor"))
            {
                dgvProveedores.Columns["IdProveedor"].Visible = false;
            }

            // CONFIGURAR DISEÑO DE LA TABLA
            ConfigurarTablaProveedores();

            // Mostrar página actual
            lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";

            // Activar o desactivar botones
            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPaginaProveedores();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPaginaProveedores();
            }
        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Validar que el nombre del proveedor no quede vacío
            if (string.IsNullOrWhiteSpace(txtNombreProveedor.Text))
            {
                errorProvider1.SetError(txtNombreProveedor, "Ingrese el nombre del proveedor.");
                MessageBox.Show("Ingrese el nombre del proveedor.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProveedor.Focus();
                return;
            }

            // Validar que teléfono no esté vacío
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                errorProvider1.SetError(txtTelefono, "Ingrese el teléfono del proveedor.");
                MessageBox.Show("Ingrese el teléfono del proveedor.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            // Validar que ubicación no esté vacía
            if (string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                errorProvider1.SetError(txtUbicacion, "Ingrese la ubicación del proveedor.");
                MessageBox.Show("Ingrese la ubicación del proveedor.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUbicacion.Focus();
                return;
            }

            // Validar correo
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "El correo es obligatorio.");
                MessageBox.Show("El correo es obligatorio.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }
            try
            {
                MailAddress correo = new MailAddress(txtCorreo.Text);
            }
            catch
            {
                MessageBox.Show("Ingrese un correo válido.");
                txtCorreo.Focus();
                return;
            }

            DbProveedor proveedor = new DbProveedor();

            // TRIM elimina los espacios de los extremos
            proveedor.Nombre_Proveedor1 = txtNombreProveedor.Text.Trim();
            proveedor.Telefono1 = txtTelefono.Text.Trim();
            proveedor.Correo1 = txtCorreo.Text.Trim();
            proveedor.Ubicacion1 = txtUbicacion.Text.Trim();
            // Todo proveedor su estado inicial siempre sera activo, hasta que el usuario decida desactivarlo
            proveedor.Estado1 = true;

            if (proveedor.InsertarProveedor())
            {
                MessageBox.Show("Proveedor registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpiar();
                // Actualiza la tabla de proveedores

                MostrarProveedor();
            }
        }
        private int idProveedorSeleccionado = 0;
        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BloquearCampos();
            dgvProveedores.Columns["IdProveedor"].Visible = false;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProveedores.Rows[e.RowIndex];
                idProveedorSeleccionado = Convert.ToInt32(fila.Cells["IdProveedor"].Value);
                txtNombreProveedor.Text = fila.Cells["Proveedor"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtUbicacion.Text = fila.Cells["Ubicacion"].Value.ToString();
                chkEstado.Checked = fila.Cells["Estado"].Value.ToString() == "Activo";

                // Guardar valores originales
                nombreProveedorOriginal = txtNombreProveedor.Text.Trim();
                telefonoProveedorOriginal = txtTelefono.Text.Trim();
                correoProveedorOriginal = txtCorreo.Text.Trim();
                ubicacionProveedorOriginal = txtUbicacion.Text.Trim();

                btnEditar.Visible = true;
                btnGuardar.Visible = true;

            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;
            HabilitarCampos();
        }

        private void HabilitarCampos()
        {
            chkEstado.Enabled = true;

            txtNombreProveedor.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtUbicacion.ReadOnly = false;
        }

        private void BloquearCampos()
        {
            chkEstado.Enabled = false;
            txtNombreProveedor.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtUbicacion.ReadOnly = true;
        }

        private void Limpiar()
        {
            txtNombreProveedor.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtUbicacion.Clear();

            idProveedorSeleccionado = 0;

            txtNombreProveedor.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtUbicacion.ReadOnly = false;

            chkEstado.Checked = true;
            chkEstado.Enabled = false;

            btnEditar.Visible = false;
            btnGuardarCambios.Visible = false;
            btnGuardar.Visible = true;
            btnDesactivarProveedor.Visible = true;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            string texto = txtTelefono.Text.Replace("-", "");

            if (texto.Length > 4)
            {
                txtTelefono.Text = texto.Insert(4, "-");
                txtTelefono.SelectionStart = txtTelefono.Text.Length;
            }
        }
        private void DesactivarCopiarPegar(Control control)
        {
            foreach (Control elemento in control.Controls)
            {
                if (elemento is TextBox)
                {
                    ((TextBox)elemento).ShortcutsEnabled = false;
                }

                if (elemento.HasChildren)
                {
                    DesactivarCopiarPegar(elemento);
                }
            }
        }

        private void txtNombreProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtUbicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '#' && e.KeyChar != '-' && e.KeyChar != '/' &&
           e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '(' && e.KeyChar != ')')
            {
                e.Handled = true;
            }
        }



        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarBotonEstado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el botón de estado.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text == TextoBusqueda)
                    return;

                string buscar = txtBuscar.Text.Trim();

                if (string.IsNullOrWhiteSpace(buscar))
                {
                    paginaActual = 1;
                    dtProveedores = null;
                    MostrarProveedor();
                    return;
                }

                dtProveedores = DbProveedor.BuscarProveedor(buscar);

                int totalResultados = dtProveedores.Rows.Count;

                totalPaginas = (int)Math.Ceiling((double)totalResultados / registrosPorPagina);

                if (totalPaginas == 0)
                    totalPaginas = 1;

                paginaActual = 1;

                MostrarPaginaProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar proveedores.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesactivarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProveedores.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione un proveedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idProveedor = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["IdProveedor"].Value);
                string estadoActual = dgvProveedores.CurrentRow.Cells["Estado"].Value?.ToString();

                bool activar = estadoActual == "Inactivo";

                string mensaje = activar ? "¿Desea volver a activar este proveedor?" : "¿Desea desactivar este proveedor?";

                if (MessageBox.Show(mensaje, activar ? "Activar proveedor" : "Desactivar proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                if (DbProveedor.CambiarEstadoProveedor(idProveedor, activar))
                {
                    MessageBox.Show(activar ? "El proveedor ha sido activado correctamente." : "El proveedor ha sido desactivado correctamente.", "Operación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarProveedor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar el estado del proveedor.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            Limpiar();
            dgvProveedores.ClearSelection();
            dgvProveedores.CurrentCell = null;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtNombreProveedor_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }

        private void txtUbicacion_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }

        private void btnGuardarCambios_Click_1(object sender, EventArgs e)
        {
            if (idProveedorSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un proveedor para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool cambioNombre = txtNombreProveedor.Text.Trim() != nombreProveedorOriginal;
            bool cambioTelefono = txtTelefono.Text.Trim() != telefonoProveedorOriginal;
            bool cambioCorreo = txtCorreo.Text.Trim() != correoProveedorOriginal;
            bool cambioUbicacion = txtUbicacion.Text.Trim() != ubicacionProveedorOriginal;

            if (!cambioNombre && !cambioTelefono && !cambioCorreo && !cambioUbicacion)
            {
                MessageBox.Show("No se detectaron cambios en el proveedor.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "El correo es obligatorio.");
                txtCorreo.Focus();
                return;
            }

            try
            {
                MailAddress correo = new MailAddress(txtCorreo.Text.Trim());
                errorProvider1.SetError(txtCorreo, "");
            }
            catch
            {
                errorProvider1.SetError(txtCorreo, "Ingrese un correo válido.");
                txtCorreo.Focus();
                return;
            }

            DbProveedor proveedor = new DbProveedor();

            proveedor.IdProveedor1 = idProveedorSeleccionado;
            proveedor.Nombre_Proveedor1 = txtNombreProveedor.Text.Trim();
            proveedor.Telefono1 = txtTelefono.Text.Trim();
            proveedor.Correo1 = txtCorreo.Text.Trim();
            proveedor.Ubicacion1 = txtUbicacion.Text.Trim();

            if (proveedor.ActualizarProveedor())
            {
                string cambios = "Se realizaron los siguientes cambios:\n\n";

                if (cambioNombre)
                    cambios += "• Nombre: " + nombreProveedorOriginal + " → " + txtNombreProveedor.Text.Trim() + "\n";

                if (cambioTelefono)
                    cambios += "• Teléfono: " + telefonoProveedorOriginal + " → " + txtTelefono.Text.Trim() + "\n";

                if (cambioCorreo)
                    cambios += "• Correo: " + correoProveedorOriginal + " → " + txtCorreo.Text.Trim() + "\n";

                if (cambioUbicacion)
                    cambios += "• Ubicación: " + ubicacionProveedorOriginal + " → " + txtUbicacion.Text.Trim() + "\n";

                MessageBox.Show(cambios, "Proveedor actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarProveedor();
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvProveedores.Columns["IdProveedor"].Visible = false;
        }
    }
}
