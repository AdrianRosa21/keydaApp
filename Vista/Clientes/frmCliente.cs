using Guna.UI2.WinForms;
using Modelo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Clientes
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            ConfigurarTablasClientes();


            ConfigurarTarjetas();
            ConfigurarSeparadores();
            ConfigurarBarraBusqueda();
            ConfigurarBotonesCliente();


            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        }

        //VARIABLES
        private int idClienteSeleccionado = 0;
        private int tipoClienteSeleccionado = 0;

        // Cantidad de clientes que se mostrarán por página.
        private int registrosPorPagina = 10;

        // Página en la que estamos actualmente.
        private int paginaActual = 1;

        // Cantidad total de clientes.
        private int totalRegistros = 0;

        // Cantidad total de páginas.
        private int totalPaginas = 0;

        // PAGINACIÓN DE CLIENTES INDIVIDUALES
        private int paginaActualIndividual = 1;
        private int totalRegistrosIndividual = 0;
        private int totalPaginasIndividual = 0;

        // DATOS PARA LAS BÚSQUEDAS PAGINADAS
        private DataTable dtCorporativosBusqueda;
        private DataTable dtIndividualesBusqueda;

        //DATOS ORIGINALES DEL CLIENTE SELECCIONADO
        private string identificador1Original;
        private string identificador2Original;
        private string documentoOriginal;
        private string telefonoOriginal;
        private string correoOriginal;
        private string direccionOriginal;

        private string estadoOriginal;

        private bool modoEdicion = false;

        // Manejo visual de errores de validación
        private ErrorProvider errorProvider = new ErrorProvider();

        private Guna2Elipse elipseActivos;
        private Guna2Elipse elipseInactivos;
        private Guna2Elipse elipseTotales;

        private Guna2Elipse elipseNuevoCliente;
        private Guna2Elipse elipseEditar;
        private Guna2Elipse elipseGuardarIndividual;
        private Guna2Elipse elipseGuardarCorporativo;
        private Guna2Elipse elipseGuardarCambios;
        private Guna2Elipse elipseDatosCliente;
        private Guna2Elipse elipseRegistroIndividual;
        private Guna2Elipse elipseRegistroCorporativo;
        private const string TextoBusqueda = "Buscar...";
        private readonly Color ColorPlaceholder = Color.LightGray;
        private readonly Color ColorCafe = Color.FromArgb(121, 75, 45);

        private void ConfigurarTarjetas()
        {
            // INDICADORES

            elipseActivos = new Guna2Elipse
            {
                TargetControl = pnlIndicador3,
                BorderRadius = 12
            };

            elipseInactivos = new Guna2Elipse
            {
                TargetControl = pnlIndicador1,
                BorderRadius = 12
            };

            elipseTotales = new Guna2Elipse
            {
                TargetControl = pnlIndicador4,
                BorderRadius = 12
            };

            // PANELES

            elipseRegistroIndividual = new Guna2Elipse
            {
                TargetControl = pnlRegistroClienteIndividual,
                BorderRadius = 10
            };

            elipseRegistroCorporativo = new Guna2Elipse
            {
                TargetControl = pnlRegistroClienteCorporativo,
                BorderRadius = 10
            };

            // HOVER

            ConfigurarHoverTarjeta(pnlIndicador3);
            ConfigurarHoverTarjeta(pnlIndicador1);
            ConfigurarHoverTarjeta(pnlIndicador4);

        }

        private void ConfigurarHoverTarjeta(Control tarjeta)
        {
            tarjeta.MouseEnter += Tarjeta_MouseEnter;
            tarjeta.MouseLeave += Tarjeta_MouseLeave;

            foreach (Control control in tarjeta.Controls)
                ConfigurarHoverTarjeta(control);
        }

        private void Tarjeta_MouseEnter(object sender, EventArgs e)
        {
            Control control = sender as Control;

            while (control != null && control != pnlIndicador1 &&
                   control != pnlIndicador3 && control != pnlIndicador4)
            {
                control = control.Parent;
            }

            if (control == pnlIndicador3)
                control.BackColor = Color.FromArgb(151, 225, 130);
            else if (control == pnlIndicador1)
                control.BackColor = Color.FromArgb(235, 143, 132);
            else if (control == pnlIndicador4)
                control.BackColor = Color.FromArgb(245, 238, 225);
        }

        private void Tarjeta_MouseLeave(object sender, EventArgs e)
        {
            Control control = sender as Control;

            while (control != null && control != pnlIndicador1 &&
                   control != pnlIndicador3 && control != pnlIndicador4)
            {
                control = control.Parent;
            }

            if (control == pnlIndicador3)
                control.BackColor = Color.FromArgb(157, 230, 132);
            else if (control == pnlIndicador1)
                control.BackColor = Color.FromArgb(235, 157, 145);
            else if (control == pnlIndicador4)
                control.BackColor = Color.White;
        }



        private void ActivarPestana(bool individual)
        {
            if (individual)
            {
                pnlBarraClienteCorporativo.BackColor = Color.FromArgb(220, 200, 180);
                pnlBarraClienteIndividual.BackColor = Color.FromArgb(121, 75, 45);

                btnClienteIndividual.ForeColor = Color.White;
                btnClienteIndividual.Font = new Font(btnClienteIndividual.Font, FontStyle.Bold);

                btnClienteCorporativo.ForeColor = Color.Black;
                btnClienteCorporativo.Font = new Font(btnClienteCorporativo.Font, FontStyle.Regular);
            }
            else
            {
                pnlBarraClienteIndividual.BackColor = Color.FromArgb(220, 200, 180);
                pnlBarraClienteCorporativo.BackColor = Color.FromArgb(121, 75, 45);

                btnClienteIndividual.ForeColor = Color.Black;
                btnClienteIndividual.Font = new Font(btnClienteIndividual.Font, FontStyle.Regular);

                btnClienteCorporativo.ForeColor = Color.White;
                btnClienteCorporativo.Font = new Font(btnClienteCorporativo.Font, FontStyle.Bold);
            }
        }

        private void ConfigurarSeparadores()
        {
            separadorDatosCliente.FillColor = Color.FromArgb(190, 160, 130);
            separadorDatosCliente.FillThickness = 1;
        }
        private void ConfigurarBarraBusqueda()
        {
            ConfigurarBusqueda(txtBuscarIndividual);
            ConfigurarBusqueda(txtBuscarCorporativo);
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

        private void ConfigurarBotonCliente(Guna.UI2.WinForms.Guna2Button boton)
        {
            boton.FillColor = Color.FromArgb(235, 218, 198);
            boton.ForeColor = Color.FromArgb(121, 75, 45);

            boton.BorderColor = Color.FromArgb(121, 75, 45);
            boton.BorderThickness = 1;
            boton.BorderRadius = 10;

            boton.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            boton.HoverState.FillColor = Color.FromArgb(220, 190, 160);
            boton.HoverState.ForeColor = Color.FromArgb(121, 75, 45);
            boton.HoverState.BorderColor = Color.FromArgb(121, 75, 45);

            boton.PressedColor = Color.FromArgb(205, 175, 145);

            boton.Cursor = Cursors.Hand;
        }
        private void ConfigurarBotonesCliente()
        {
            ConfigurarBotonCliente(btnNuevoCliente);
            ConfigurarBotonCliente(btnEditar);
            ConfigurarBotonCliente(btnGuardarIndividual);
            ConfigurarBotonCliente(btnGuardarCambios);
            ConfigurarBotonCliente(btnGuardarCorporativo);
        }




        //-----------------------------------------------------------------------------------------------------------------------------------------//



        //MOSTRAR CLIENTES
        private void MostrarClientes()
        {
            int registrosSaltar = (paginaActual - 1) * registrosPorPagina;

            dgvClientesCorporativos.DataSource = DbCliente.CargarCorporativos(registrosSaltar, registrosPorPagina);
            FormatearTablaCorporativos();

            totalRegistros = DbCliente.ObtenerTotalCorporativos();

            totalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);

            if (totalPaginas == 0)
            {
                totalPaginas = 1;
            }

            // Evitar que la página actual quede fuera de rango.
            if (paginaActual > totalPaginas)
            {
                paginaActual = totalPaginas;
            }

            lblPaginaC.Text = $"Página {paginaActual} de {totalPaginas}";

            btnAtrasC.Enabled = paginaActual > 1;

            btnSiguienteC.Enabled = paginaActual < totalPaginas;
            ActualizarEstadisticas();
            FormatearTablaCorporativos();
        }
        private void MostrarClientes2()
        {
            int registrosSaltar = (paginaActualIndividual - 1) * registrosPorPagina;

            dgvClientesIndividuales.DataSource = DbCliente.CargarIndividuales(registrosSaltar, registrosPorPagina);

            totalRegistrosIndividual = DbCliente.ObtenerTotalIndividuales();

            totalPaginasIndividual = (int)Math.Ceiling((double)totalRegistrosIndividual / registrosPorPagina);

            if (totalPaginasIndividual == 0)
            {
                totalPaginasIndividual = 1;
            }

            // Evitar que la página actual quede fuera de rango.
            if (paginaActualIndividual > totalPaginasIndividual)
            {
                paginaActualIndividual = totalPaginasIndividual;
            }

            lblPagina.Text = $"Página {paginaActualIndividual} de {totalPaginasIndividual}";

            btnAnterior.Enabled = paginaActualIndividual > 1;

            btnSiguiente.Enabled = paginaActualIndividual < totalPaginasIndividual;

            ActualizarEstadisticas();
            FormatearTablaIndividuales();

        }
        //----------------------------------------------------------------------
        // CONFIGURAR TABLAS DE CLIENTES

        private void ConfigurarTablasClientes()
        {
            // TABLA DE CLIENTES CORPORATIVOS
            ConfigurarEstiloTabla(dgvClientesCorporativos);

            // TABLA DE CLIENTES INDIVIDUALES
            ConfigurarEstiloTabla(dgvClientesIndividuales);
        }
        //----------------------------------------------------------------------
        // CONFIGURAR ESTILO GENERAL DE LAS TABLAS
        private void ConfigurarEstiloTabla(DataGridView tabla)
        {
            // Configuración general
            tabla.AutoGenerateColumns = true;

            tabla.AllowUserToAddRows = false;
            tabla.AllowUserToDeleteRows = false;
            tabla.AllowUserToResizeRows = false;
            tabla.AllowUserToResizeColumns = false;
            dgvClientesIndividuales.RowTemplate.Height = 36;
            dgvClientesCorporativos.RowTemplate.Height = 36;

            tabla.ReadOnly = true;

            tabla.MultiSelect = false;

            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tabla.RowHeadersVisible = false;

            tabla.BorderStyle = BorderStyle.None;

            tabla.BackgroundColor = Color.White;

            tabla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            tabla.GridColor = Color.FromArgb(225, 225, 225);

            tabla.EnableHeadersVisualStyles = false;

            // Altura del encabezado
            tabla.ColumnHeadersHeight = 40;

            // Altura de las filas
            tabla.RowTemplate.Height = 34;

            // Ajustar columnas al espacio disponible
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //---------------------------------------------------------------------- 
            // ENCABEZADO
            tabla.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(121, 78, 48),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(121, 78, 48),
                SelectionForeColor = Color.White,
                Padding = new Padding(5)
            };

            // FILAS
            tabla.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(55, 55, 55),
                Font = new Font("Segoe UI", 10),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(238, 215, 185),
                SelectionForeColor = Color.FromArgb(60, 45, 35),
                Padding = new Padding(5)

            };

            // FILAS ALTERNADAS
            tabla.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(250, 246, 240),
                ForeColor = Color.FromArgb(55, 55, 55),
                Font = new Font("Segoe UI", 10),
                SelectionBackColor = Color.FromArgb(238, 215, 185),
                SelectionForeColor = Color.FromArgb(60, 45, 35)
            };

            // FILA SELECCIONADA
            tabla.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 215, 185);
            tabla.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 45, 35);

        }
        //----------------------------------------------------------------------
        // FORMATEAR TABLA DE CLIENTES INDIVIDUALES
        private void FormatearTablaIndividuales()
        {
            if (dgvClientesIndividuales.Columns.Count == 0)
                return;
            // ID

            if (dgvClientesIndividuales.Columns.Contains("IdCliente"))
            {
                dgvClientesIndividuales.Columns["IdCliente"].Visible = false;
            }
            // NOMBRE

            if (dgvClientesIndividuales.Columns.Contains("Nombre"))
            {
                dgvClientesIndividuales.Columns["Nombre"].HeaderText = "Nombre";
            }
            // APELLIDOS
            if (dgvClientesIndividuales.Columns.Contains("Apellidos"))
            {
                dgvClientesIndividuales.Columns["Apellidos"].HeaderText = "Apellidos";
            }
            // DUI
            if (dgvClientesIndividuales.Columns.Contains("DUI"))
            {
                dgvClientesIndividuales.Columns["DUI"].HeaderText = "DUI";
            }
            // TELÉFONO
            if (dgvClientesIndividuales.Columns.Contains("Telefono"))
            {
                dgvClientesIndividuales.Columns["Telefono"].HeaderText = "Teléfono";
            }
            // CORREO
            if (dgvClientesIndividuales.Columns.Contains("Correo"))
            {
                dgvClientesIndividuales.Columns["Correo"].HeaderText = "Correo";
            }
            // DIRECCIÓN

            if (dgvClientesIndividuales.Columns.Contains("Direccion"))
            {
                dgvClientesIndividuales.Columns["Direccion"].HeaderText = "Dirección";
            }
            // ESTADO

            if (dgvClientesIndividuales.Columns.Contains("Estado"))
            {
                dgvClientesIndividuales.Columns["Estado"].HeaderText = "Estado";
            }
            //---------------------------------------------------------------------- 
            // ALINEACIÓN
            if (dgvClientesIndividuales.Columns.Contains("Nombre"))
                dgvClientesIndividuales.Columns["Nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvClientesIndividuales.Columns.Contains("Apellidos"))
                dgvClientesIndividuales.Columns["Apellidos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvClientesIndividuales.Columns.Contains("Correo"))
                dgvClientesIndividuales.Columns["Correo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvClientesIndividuales.Columns.Contains("Direccion"))
                dgvClientesIndividuales.Columns["Direccion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //---------------------------------------------------------------------- 
            // ESTADO
            if (dgvClientesIndividuales.Columns.Contains("Estado"))
                dgvClientesIndividuales.Columns["Estado"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);

            // No permitir ordenar las columnas
            foreach (DataGridViewColumn columna in dgvClientesIndividuales.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Ajustar nuevamente las columnas
            dgvClientesIndividuales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //----------------------------------------------------------------------
        // FORMATEAR TABLA DE CLIENTES CORPORATIVOS

        private void FormatearTablaCorporativos()
        {
            if (dgvClientesCorporativos.Columns.Count == 0)
                return;
            // ID
            if (dgvClientesCorporativos.Columns.Contains("IdCliente"))
                dgvClientesCorporativos.Columns["IdCliente"].Visible = false;

            // EMPRESA
            if (dgvClientesCorporativos.Columns.Contains("Nombre_De_Empresa"))
                dgvClientesCorporativos.Columns["Nombre_De_Empresa"].HeaderText = "Empresa";

            // ENCARGADO
            if (dgvClientesCorporativos.Columns.Contains("Nombre_Del_Encargado"))
                dgvClientesCorporativos.Columns["Nombre_Del_Encargado"].HeaderText = "Encargado";

            // NIT
            if (dgvClientesCorporativos.Columns.Contains("NIT"))
                dgvClientesCorporativos.Columns["NIT"].HeaderText = "NIT";

            // TELÉFONO
            if (dgvClientesCorporativos.Columns.Contains("Telefono"))
                dgvClientesCorporativos.Columns["Telefono"].HeaderText = "Teléfono";

            // CORREO
            if (dgvClientesCorporativos.Columns.Contains("Correo"))
                dgvClientesCorporativos.Columns["Correo"].HeaderText = "Correo";

            // DIRECCIÓN
            if (dgvClientesCorporativos.Columns.Contains("Direccion"))
                dgvClientesCorporativos.Columns["Direccion"].HeaderText = "Dirección";

            // ESTADO
            if (dgvClientesCorporativos.Columns.Contains("Estado"))
                dgvClientesCorporativos.Columns["Estado"].HeaderText = "Estado";

            //---------------------------------------------------------------------- 
            // ALINEACIÓN
            if (dgvClientesCorporativos.Columns.Contains("Nombre_De_Empresa"))
                dgvClientesCorporativos.Columns["Nombre_De_Empresa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvClientesCorporativos.Columns.Contains("Nombre_Del_Encargado"))
                dgvClientesCorporativos.Columns["Nombre_Del_Encargado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvClientesCorporativos.Columns.Contains("Correo"))
                dgvClientesCorporativos.Columns["Correo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            if (dgvClientesCorporativos.Columns.Contains("Direccion"))
                dgvClientesCorporativos.Columns["Direccion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //---------------------------------------------------------------------- 
            // ESTADO

            if (dgvClientesCorporativos.Columns.Contains("Estado"))
            {
                dgvClientesCorporativos.Columns["Estado"].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            }
            // No permitir ordenar las columnas

            foreach (DataGridViewColumn columna in dgvClientesCorporativos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            // Ajustar nuevamente las columnas
            dgvClientesCorporativos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        //------------------------------------------------------------------------------------
        //CONFIGURACION DE PAGINACION DE LOS DATAGRID

        private void btnSiguienteC_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;

                if (dtCorporativosBusqueda != null)
                {
                    MostrarPaginaCorporativosBusqueda();
                }
                else
                {
                    MostrarClientes();
                }
            }
        }

        private void btnAtrasC_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;

                if (dtCorporativosBusqueda != null)
                {
                    MostrarPaginaCorporativosBusqueda();
                }
                else
                {
                    MostrarClientes();
                }
            }
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActualIndividual > 1)
            {
                paginaActualIndividual--;

                if (dtIndividualesBusqueda != null)
                {
                    MostrarPaginaIndividualesBusqueda();
                }
                else
                {
                    MostrarClientes2();
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActualIndividual < totalPaginasIndividual)
            {
                paginaActualIndividual++;

                if (dtIndividualesBusqueda != null)
                {
                    MostrarPaginaIndividualesBusqueda();
                }
                else
                {
                    MostrarClientes2();
                }
            }
        }

        //----------------------------------------------------------------------
        // ACTUALIZAR LAS ESTADISTICAS DE LOS CLIENTES
        private void ActualizarEstadisticas()
        {
            try
            {
                lblTotalClientes.Text = DbCliente.ContarClientesTotales().ToString();
                lblClientesActivos.Text = DbCliente.ContarClientesActivos().ToString();
                lblClientesInactivos.Text = DbCliente.ContarClientesInactivos().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar las estadísticas.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----------------------------------------------------------------------------
        //METODOS DE BLOQUEAR Y HABILITAR CAMPOS
        private void BloquearCampos()
        {
            // CLIENTE CORPORATIVO
            txtNombreEmpresa.Enabled = false;
            txtNombreEncargado.Enabled = false;
            txtNIT.Enabled = false;

            // CLIENTE INDIVIDUAL
            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;
            txtDUI.Enabled = false;

            // CAMPOS COMPARTIDOS
            txtTelefono.Enabled = false;
            txtCorreo.Enabled = false;
            txtDireccion.Enabled = false;

            // ESTADO
            cbEstadoCliente.Enabled = false;

            // TIPO DE CLIENTE
            cbTipoCliente.Enabled = false;
        }
        private void HabilitarCampos()
        {
            // CLIENTE CORPORATIVO
            txtNombreEmpresa.Enabled = true;
            txtNombreEncargado.Enabled = true;
            txtNIT.Enabled = true;

            // CLIENTE INDIVIDUAL
            txtNombres.Enabled = true;
            txtApellidos.Enabled = true;
            txtDUI.Enabled = true;

            // CAMPOS COMPARTIDOS
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;
            txtDireccion.Enabled = true;

            // ESTADO
            cbEstadoCliente.Enabled = true;

            // El tipo de cliente NO se modifica
            cbTipoCliente.Enabled = false;

        }
        //-------------------------------------------------VALIDACIONES-----------------------------------------------------------------------//

        private bool ValidarCampos()
        {
            // Validar que haya seleccionado un tipo de cliente
            if (!modoEdicion && cbTipoCliente.SelectedIndex == -1)
            {
                errorProvider.SetError(cbTipoCliente, "Seleccione un tipo de cliente.");
                MessageBox.Show("Seleccione un tipo de cliente.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTipoCliente.Focus();
                return false;
            }

            // PERSONA NATURAL
            if (cbTipoCliente.Text == "Persona Natural")
            {
                if (string.IsNullOrWhiteSpace(txtNombres.Text))
                {
                    errorProvider.SetError(txtNombres, "Debe ingresar el nombre del cliente.");
                    MessageBox.Show("Debe ingresar el nombre del cliente.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombres.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtApellidos.Text))
                {
                    errorProvider.SetError(txtApellidos, "Debe ingresar los apellidos del cliente.");
                    MessageBox.Show("Debe ingresar los apellidos del cliente.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellidos.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtDUI.Text))
                {
                    errorProvider.SetError(txtDUI, "Debe ingresar el DUI del cliente.");
                    MessageBox.Show("Debe ingresar el DUI del cliente.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDUI.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    errorProvider.SetError(txtTelefono, "Debe ingresar el teléfono del cliente.");
                    MessageBox.Show("Debe ingresar el teléfono del cliente.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    errorProvider.SetError(txtCorreo, "Debe ingresar el correo del cliente.");
                    MessageBox.Show("Debe ingresar el correo del cliente.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    errorProvider.SetError(txtDireccion, "Debe ingresar la dirección del cliente.");
                    MessageBox.Show("Debe ingresar la dirección del cliente.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccion.Focus();
                    return false;
                }
            }

            // EMPRESA
            if (cbTipoCliente.Text == "Empresa")
            {
                if (string.IsNullOrWhiteSpace(txtNombreEmpresa.Text))
                {
                    errorProvider.SetError(txtNombreEmpresa, "Debe ingresar el nombre de la empresa.");
                    MessageBox.Show("Debe ingresar el nombre de la empresa.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreEmpresa.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtNombreEncargado.Text))
                {
                    errorProvider.SetError(txtNombreEncargado, "Debe ingresar el nombre del encargado.");
                    MessageBox.Show("Debe ingresar el nombre del encargado.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreEncargado.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtNIT.Text))
                {
                    errorProvider.SetError(txtNIT, "Debe ingresar el NIT de la empresa.");
                    MessageBox.Show("Debe ingresar el NIT de la empresa.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNIT.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    errorProvider.SetError(txtTelefono, "Debe ingresar el teléfono.");
                    MessageBox.Show("Debe ingresar el teléfono.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    errorProvider.SetError(txtCorreo, "Debe ingresar el correo.");
                    MessageBox.Show("Debe ingresar el correo.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    errorProvider.SetError(txtDireccion, "Debe ingresar la dirección de la empresa.");
                    MessageBox.Show("Debe ingresar la dirección de la empresa.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccion.Focus();
                    return false;
                }
            }

            return true;
        }
        //VALIDAR CORREO
        private bool ValidarCorreo()
        {
            try
            {
                MailAddress correo = new MailAddress(txtCorreo.Text);

                if (correo.Address != txtCorreo.Text)
                {
                    errorProvider1.SetError(txtCorreo, "Ingrese un correo válido.");

                    MessageBox.Show("Ingrese un correo electrónico válido.", "Correo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtCorreo.Focus();
                    return false;
                }

                return true;
            }
            catch
            {
                errorProvider1.SetError(txtCorreo, "Ingrese un correo electrónico válido.");

                MessageBox.Show("Ingrese un correo electrónico válido.", "Correo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }
        }

        //DESACTIVAR COPIAR Y PEGAR
        private void DesactivarCopiarPegar(Control control)
        {
            foreach (Control elemento in control.Controls)
            {
                if (elemento is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)elemento).ShortcutsEnabled = false;
                }

                if (elemento.HasChildren)
                {
                    DesactivarCopiarPegar(elemento);
                }
            }
        }
        //VALIDACIONES DE LOS TEXTBOX
        private void txtDUI_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar) && txtDUI.Text.Length >= 10)
            {
                e.Handled = true;
            }
        }

        private void txtNIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar) && txtNIT.Text.Length >= 17)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && txtTelefono.Text.Length >= 9)
            {
                e.Handled = true;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_TextChanged_1(object sender, EventArgs e)
        {
            string texto = txtTelefono.Text.Replace("-", "");

            if (texto.Length > 4)
            {
                txtTelefono.Text = texto.Insert(4, "-");
                txtTelefono.SelectionStart = txtTelefono.Text.Length;
            }
        }

        private void txtDUI_TextChanged_1(object sender, EventArgs e)
        {
            string texto = txtDUI.Text.Replace("-", "");

            if (texto.Length > 8)
            {
                txtDUI.Text = texto.Insert(8, "-");
                txtDUI.SelectionStart = txtDUI.Text.Length;
            }
        }

        private void txtNombres_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtApellidos_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != '#' &&
                e.KeyChar != '-' &&
                e.KeyChar != '/' &&
                e.KeyChar != '.' &&
                e.KeyChar != ',' &&
                e.KeyChar != '(' &&
                e.KeyChar != ')')
            {
                e.Handled = true;
            }
        }

        //--------------------------  FIN VALIDACIONES -------------------------------------//
        // CAMBIAR ENTRE PERSONA NATURAL Y EMPRESA
        private void btnClienteIndividual_Click_1(object sender, EventArgs e)
        {
            // Barras
            pnlBarraClienteIndividual.Visible = true;
            pnlBarraClienteCorporativo.Visible = false;

            // Paneles
            pnlRegistroClienteIndividual.Visible = true;
            pnlRegistroClienteCorporativo.Visible = false;

            //Barra de busqueda
            txtBuscarCorporativo.Visible = false;
            txtBuscarIndividual.Visible = true;

            ActivarPestana(true);
        }

        private void btnClienteCorporativo_Click_1(object sender, EventArgs e)
        {
            // Barras
            pnlBarraClienteIndividual.Visible = false;
            pnlBarraClienteCorporativo.Visible = true;

            // Paneles
            pnlRegistroClienteIndividual.Visible = false;
            pnlRegistroClienteCorporativo.Visible = true;

            //Barra de busqueda
            txtBuscarCorporativo.Visible = true;
            txtBuscarIndividual.Visible = false;

            ActivarPestana(false);
        }
        //---------------------------------------------------------------------------------------------
        // CONFIGURAR TOOLTIPS
        private void ConfigurarTooltips()
        {
            // Crea el ToolTip
            toolTip1 = new ToolTip();

            // Propiedades del ToolTip
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(txtBuscarCorporativo, "Buscar un cliente por nombre, documento o teléfono.");
            toolTip1.SetToolTip(txtBuscarIndividual, "Buscar un cliente por nombre, documento o teléfono.");
            toolTip1.SetToolTip(cbTipoCliente, "Seleccione el tipo de cliente que desea registrar.");
            toolTip1.SetToolTip(txtNombres, "Ingrese el nombre del cliente.");
            toolTip1.SetToolTip(txtApellidos, "Ingrese los apellidos del cliente.");
            toolTip1.SetToolTip(txtDUI, "Ingrese el DUI del cliente en formato 00000000-0.");
            toolTip1.SetToolTip(txtTelefono, "Ingrese el número de teléfono del cliente.");
            toolTip1.SetToolTip(txtCorreo, "Ingrese el correo electrónico del cliente.");
            toolTip1.SetToolTip(txtDireccion, "Ingrese la dirección del cliente.");
            toolTip1.SetToolTip(cbEstadoCliente, "Seleccione el estado actual del cliente.");
            toolTip1.SetToolTip(btnNuevoCliente, "Limpia los campos para registrar un nuevo cliente.");
            toolTip1.SetToolTip(btnEditar, "Edita los datos del cliente seleccionado.");
            toolTip1.SetToolTip(btnGuardarCambios, "Guarda los datos del cliente corporativo.");
            toolTip1.SetToolTip(btnGuardarIndividual, "Guarda los datos del cliente individual.");
            toolTip1.SetToolTip(btnGuardarCambios, "Guarda los cambios realizados al cliente seleccionado.");
        }

        //------------------------------------------------------------------------
        // CARGA DEL FORMULARIO
        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar los clientes
                MostrarClientes();
                MostrarClientes2();
                ActualizarEstadisticas();

                //Configura los tooltips
                ConfigurarTooltips();

                // Desactivar copiar y pegar
                DesactivarCopiarPegar(this);

                // Mostrar persona natural al iniciar
                pnlRegistroClienteIndividual.Visible = true;
                pnlRegistroClienteCorporativo.Visible = false;

                pnlBarraClienteIndividual.Visible = true;
                pnlBarraClienteCorporativo.Visible = false;

                // Ocultar botones de edición
                btnEditar.Visible = false;
                btnGuardarCambios.Visible = false;

                // Límites de los campos
                txtDireccion.MaxLength = 200;
                txtApellidos.MaxLength = 40;
                txtNombres.MaxLength = 40;
                txtNombreEmpresa.MaxLength = 40;
                txtNombreEncargado.MaxLength = 40;
                txtDUI.MaxLength = 10;
                txtNIT.MaxLength = 17;
                txtTelefono.MaxLength = 9;
                txtCorreo.MaxLength = 50;

                // Estado desactivado al comenzar
                cbEstadoCliente.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar el formulario.\n" + ex.Message);
            }
        }

        //----------------------------------------------------------------------------------------------
        // CAMBIO DE TIPO DE CLIENTE
        private void cbTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoCliente.Text == "Persona Natural")
            {
                txtNombres.TabIndex = 1;
                txtApellidos.TabIndex = 2;
                txtDUI.TabIndex = 3;
                txtTelefono.TabIndex = 4;
                txtCorreo.TabIndex = 5;
                txtDireccion.TabIndex = 6;
                btnEditar.TabIndex = 7;
                btnGuardarIndividual.TabIndex = 8;
            }
            else if (cbTipoCliente.Text == "Empresa")
            {
                txtNombreEmpresa.TabIndex = 1;
                txtNombreEncargado.TabIndex = 2;
                txtNIT.TabIndex = 3;
                txtTelefono.TabIndex = 4;
                txtCorreo.TabIndex = 5;
                txtDireccion.TabIndex = 6;
                btnEditar.TabIndex = 7;
                btnGuardarCorporativo.TabIndex = 8;
            }

            if (cbTipoCliente.SelectedIndex == 0)
            {
                // Paneles
                pnlRegistroClienteIndividual.Visible = true;
                pnlRegistroClienteCorporativo.Visible = false;

                // Barras
                pnlBarraClienteIndividual.Visible = true;
                pnlBarraClienteCorporativo.Visible = false;

                // Botones
                btnGuardarIndividual.Visible = true;
                btnGuardarCambios.Visible = false;

                //Group Box

                gbPersonaNatural.Visible = true;
                gbDatosEmpresa.Visible = false;

                //El estado inicial será activo
                cbEstadoCliente.Text = "Activo";

            }
            else if (cbTipoCliente.SelectedIndex == 1)
            {
                // Paneles
                pnlRegistroClienteIndividual.Visible = false;
                pnlRegistroClienteCorporativo.Visible = true;

                // Barras
                pnlBarraClienteIndividual.Visible = false;
                pnlBarraClienteCorporativo.Visible = true;

                // Botones
                btnGuardarIndividual.Visible = false;
                btnGuardarCambios.Visible = true;

                //Group Box
                gbPersonaNatural.Visible = false;
                gbDatosEmpresa.Visible = true;

                //El estado inicial será activo
                cbEstadoCliente.Text = "Activo";

            }
        }
        //--------------------------------------------------------------
        // REGISTRAR CLIENTE INDIVIDUAL

        private void btnGuardarIndividuales_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            if (txtDUI.Text.Length != 10 || txtDUI.Text[8] != '-')
            {
                errorProvider1.SetError(txtDUI, "El DUI debe tener el formato 12345678-9.");
                MessageBox.Show("El DUI debe tener el formato 12345678-9.", "DUI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDUI.Focus();
                return;
            }

            if (txtTelefono.Text.Length != 9 || txtTelefono.Text[4] != '-')
            {
                errorProvider1.SetError(txtTelefono, "El teléfono debe tener el formato 1234-5678.");
                MessageBox.Show("El teléfono debe tener el formato 1234-5678.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            // Validar Correo
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
                errorProvider1.SetError(txtCorreo, "Ingrese un correo válido.");
                MessageBox.Show("Ingrese un correo válido.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            DbCliente cliente = new DbCliente();

            cliente.TipoCliente1 = 2;
            cliente.Identificador11 = txtNombres.Text;
            cliente.Identificador21 = txtApellidos.Text;
            cliente.Documento1 = txtDUI.Text;
            cliente.Telefono1 = txtTelefono.Text;
            cliente.Correo1 = txtCorreo.Text;
            cliente.Direccion1 = txtDireccion.Text;
            cliente.Estado1 = "Activo";


            if (cliente.InsertarClienteIndividual())
            {
                MessageBox.Show("Cliente actualizado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                paginaActualIndividual = 1;
                dtIndividualesBusqueda = null;

                MostrarClientes2();

                LimpiarFormularioCliente();
            }
        }

        // REGISTRAR CLIENTE CORPORATIVO
        private void btnGuardarCorporativo_Click(object sender, EventArgs e)
        {

            // Validar campos obligatorios
            if (!ValidarCampos())
                return;

            // Validar NIT
            if (txtNIT.Text.Length != 18)
            {
                errorProvider1.SetError(txtNIT, "El NIT debe tener el formato 7172-910203-020-1.");
                MessageBox.Show("El NIT debe tener el formato 7172-910203-020-1.", "NIT inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIT.Focus();
                return;
            }

            // Validar teléfono
            if (txtTelefono.Text.Length != 9 || txtTelefono.Text[4] != '-')
            {
                errorProvider1.SetError(txtTelefono, "El teléfono debe tener el formato 1234-5678.");
                MessageBox.Show("El teléfono debe tener el formato 1234-5678.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            // Validar correo
            if (!ValidarCorreo())
                return;

            try
            {
                // Crear un objeto con los datos del cliente
                DbCliente cliente = new DbCliente();

                // Asignar los datos del formulario al objeto
                cliente.TipoCliente1 = 1;
                cliente.Identificador11 = txtNombreEmpresa.Text;
                cliente.Identificador21 = txtNombreEncargado.Text;
                cliente.Documento1 = txtNIT.Text;
                cliente.Telefono1 = txtTelefono.Text;
                cliente.Correo1 = txtCorreo.Text;
                cliente.Direccion1 = txtDireccion.Text;
                cliente.Estado1 = "Activo";

                if (cliente.InsertarClienteCorporativo())
                {
                    MessageBox.Show("Cliente registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    paginaActual = 1;
                    dtCorporativosBusqueda = null;

                    MostrarClientes();
                    LimpiarFormularioCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al registrar el cliente.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----------------------------------------------------------------------
        // SELECCIONAR CLIENTE CORPORATIVO

        private void dgvClientesCorporativos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Revisar que se haya seleccionado una fila válida
                if (e.RowIndex < 0 || dgvClientesCorporativos.Rows[e.RowIndex].IsNewRow)
                    return;

                DataGridViewRow fila = dgvClientesCorporativos.Rows[e.RowIndex];

                // Obtener el ID del cliente
                idClienteSeleccionado = Convert.ToInt32(fila.Cells["IdCliente"].Value);

                tipoClienteSeleccionado = 1;

                // Guardar los datos originales
                identificador1Original = fila.Cells["Nombre_De_Empresa"].Value?.ToString() ?? "";

                identificador2Original = fila.Cells["Nombre_Del_Encargado"].Value?.ToString() ?? "";

                documentoOriginal = fila.Cells["NIT"].Value?.ToString() ?? "";

                telefonoOriginal = fila.Cells["Telefono"].Value?.ToString() ?? "";

                correoOriginal = fila.Cells["Correo"].Value?.ToString() ?? "";

                direccionOriginal = fila.Cells["Direccion"].Value?.ToString() ?? "";

                estadoOriginal = fila.Cells["Estado"].Value?.ToString() ?? "";

                // Mostrar los datos en el formulario
                txtNombreEmpresa.Text = identificador1Original;
                txtNombreEncargado.Text = identificador2Original;
                txtNIT.Text = documentoOriginal;
                txtTelefono.Text = telefonoOriginal;
                txtCorreo.Text = correoOriginal;
                txtDireccion.Text = direccionOriginal;
                cbEstadoCliente.Text = estadoOriginal;

                // Bloquear campos hasta presionar Editar
                BloquearCampos();

                modoEdicion = false;

                // Mostrar botones
                btnEditar.Visible = true;
                btnGuardarCambios.Visible = false;

                btnGuardarCambios.Visible = false;
                btnGuardarIndividual.Visible = false;

                // Mostrar datos de empresa
                gbDatosEmpresa.Visible = true;
                gbPersonaNatural.Visible = false;

                // Mostrar tabla corporativa
                pnlRegistroClienteIndividual.Visible = false;
                pnlRegistroClienteCorporativo.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al seleccionar el cliente.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SELECCIONAR CLIENTE INDIVIDUAL
        private void dgvClientesIndividuales_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Revisar que se haya seleccionado una fila válida
                if (e.RowIndex < 0 || dgvClientesIndividuales.Rows[e.RowIndex].IsNewRow)
                    return;

                DataGridViewRow fila = dgvClientesIndividuales.Rows[e.RowIndex];

                // Obtener el ID del cliente
                idClienteSeleccionado = Convert.ToInt32(fila.Cells["IdCliente"].Value);

                tipoClienteSeleccionado = 2;

                // Guardar los datos originales
                identificador1Original = fila.Cells[1].Value?.ToString() ?? "";

                identificador2Original = fila.Cells[2].Value?.ToString() ?? "";

                documentoOriginal = fila.Cells[3].Value?.ToString() ?? "";

                telefonoOriginal = fila.Cells[4].Value?.ToString() ?? "";

                correoOriginal = fila.Cells[5].Value?.ToString() ?? "";

                direccionOriginal = fila.Cells[6].Value?.ToString() ?? "";

                estadoOriginal = fila.Cells[7].Value?.ToString() ?? "";

                // Mostrar los datos en el formulario
                txtNombres.Text = identificador1Original;
                txtApellidos.Text = identificador2Original;
                txtDUI.Text = documentoOriginal;
                txtTelefono.Text = telefonoOriginal;
                txtCorreo.Text = correoOriginal;
                txtDireccion.Text = direccionOriginal;
                cbEstadoCliente.Text = estadoOriginal;

                // Bloquear campos hasta presionar Editar
                BloquearCampos();

                modoEdicion = false;

                // Mostrar botones
                btnEditar.Visible = true;
                btnGuardarIndividual.Visible = false;
                btnGuardarCambios.Visible = false;
                btnGuardarCambios.Visible = false;

                // Mostrar datos de persona natural
                gbDatosEmpresa.Visible = false;
                gbPersonaNatural.Visible = true;

                // Mostrar tabla individual
                pnlRegistroClienteIndividual.Visible = true;
                pnlRegistroClienteCorporativo.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al seleccionar el cliente.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-------------------------------------------------------------------------------
        // BOTÓN EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            modoEdicion = true;
            cbEstadoCliente.Enabled = true;

            HabilitarCampos();
            // Ya estamos editando, por eso Editar desaparece
            btnEditar.Visible = false;
            // Ahora sí aparece Guardar cambios
            btnGuardarCambios.Visible = true;

            btnGuardarIndividual.Visible = false;
        }

        //----------------------------------------------------------------------------------
        //BOTON GUARDAR CAMBIOS
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!modoEdicion)
            {
                MessageBox.Show("Debe presionar Editar antes de guardar cambios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!HayCambios())
            {
                MessageBox.Show("No se han realizado cambios en los datos del cliente.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validar campos
            if (!ValidarCampos())
                return;

            // Validar correo
            if (!ValidarCorreo())
                return;

            // VALIDAR SEGÚN EL TIPO DE CLIENTE

            // Persona natural
            if (tipoClienteSeleccionado == 2)
            {
                if (txtDUI.Text.Length != 10 || txtDUI.Text[8] != '-')
                {
                    errorProvider1.SetError(txtDUI, "El DUI debe tener el formato 12345678-9.");
                    MessageBox.Show("El DUI debe tener el formato 12345678-9.", "DUI inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDUI.Focus();
                    return;
                }
            }

            // Empresa
            else if (tipoClienteSeleccionado == 1)
            {
                if (txtNIT.Text.Length != 17)
                {
                    errorProvider1.SetError(txtNIT, "El NIT debe tener el formato 8181-929200-182-9.");
                    MessageBox.Show("El NIT debe tener el formato 8181-929200-182-9.", "NIT inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNIT.Focus();
                    return;
                }
            }

            // Validar teléfono
            if (txtTelefono.Text.Length != 9 || txtTelefono.Text[4] != '-')
            {
                errorProvider1.SetError(txtTelefono, "El teléfono debe tener el formato 1234-5678.");
                MessageBox.Show("El teléfono debe tener el formato 1234-5678.", "Teléfono inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }
            try
            {
                DbCliente cliente = new DbCliente();

                cliente.IdCliente1 = idClienteSeleccionado;
                cliente.TipoCliente1 = tipoClienteSeleccionado;

                // PERSONA NATURAL
                if (tipoClienteSeleccionado == 2)
                {
                    cliente.Identificador11 = txtNombres.Text.Trim();
                    cliente.Identificador21 = txtApellidos.Text.Trim();
                    cliente.Documento1 = txtDUI.Text.Trim();
                }

                // EMPRESA
                else if (tipoClienteSeleccionado == 1)
                {
                    cliente.Identificador11 = txtNombreEmpresa.Text.Trim();
                    cliente.Identificador21 = txtNombreEncargado.Text.Trim();
                    cliente.Documento1 = txtNIT.Text.Trim();
                }

                // DATOS COMPARTIDOS
                cliente.Telefono1 = txtTelefono.Text.Trim();
                cliente.Correo1 = txtCorreo.Text.Trim();
                cliente.Direccion1 = txtDireccion.Text.Trim();
                cliente.Estado1 = cbEstadoCliente.Text.Trim();

                // ACTUALIZAR CLIENTE
                if (cliente.ActualizarCliente())
                {
                    MessageBox.Show("Cliente actualizado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Actualizar la tabla correspondiente
                    if (tipoClienteSeleccionado == 1)
                    {
                        MostrarClientes();
                    }
                    else if (tipoClienteSeleccionado == 2)
                    {
                        MostrarClientes2();
                    }

                    // Dejar el formulario listo para otro cliente
                    LimpiarFormularioCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar el cliente.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //------------------------------------------------------------------------

        // COMPROBAR SI HUBO CAMBIOS

        private bool HayCambios()
        {
            string identificador1Actual;
            string identificador2Actual;
            string documentoActual;

            if (tipoClienteSeleccionado == 2) // Persona Natural
            {
                identificador1Actual = txtNombres.Text.Trim();
                identificador2Actual = txtApellidos.Text.Trim();
                documentoActual = txtDUI.Text.Trim();
            }
            else // Empresa
            {
                identificador1Actual = txtNombreEmpresa.Text.Trim();
                identificador2Actual = txtNombreEncargado.Text.Trim();
                documentoActual = txtNIT.Text.Trim();
            }

            string telefonoActual = txtTelefono.Text.Trim();
            string correoActual = txtCorreo.Text.Trim();
            string direccionActual = txtDireccion.Text.Trim();
            string estadoActual = cbEstadoCliente.Text.Trim();

            return
                identificador1Actual != identificador1Original || identificador2Actual != identificador2Original || documentoActual != documentoOriginal || telefonoActual != telefonoOriginal ||
                correoActual != correoOriginal || direccionActual != direccionOriginal || estadoActual != estadoOriginal;
        }
        //----------------------------------------------------------------
        //LIMPIAR FORMULARIO

        private void LimpiarFormularioCliente()
        {
            // Habilitar los campos para registrar un nuevo cliente
            HabilitarCampos();

            // Permitir seleccionar nuevamente el tipo de cliente
            cbTipoCliente.Enabled = true;
            cbTipoCliente.SelectedIndex = -1;

            // Limpiar persona natural
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDUI.Clear();

            // Limpiar empresa
            txtNombreEmpresa.Clear();
            txtNombreEncargado.Clear();
            txtNIT.Clear();

            // Limpiar campos compartidos
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();

            // Reiniciar estado
            cbEstadoCliente.Text = "Activo";
            cbEstadoCliente.Enabled = false;

            // Reiniciar datos seleccionados
            idClienteSeleccionado = 0;
            tipoClienteSeleccionado = 0;
            modoEdicion = false;

            // Ocultar botones de edición
            btnEditar.Visible = false;
            btnGuardarCambios.Visible = false;
            if (cbTipoCliente.Text == "Empresa")
            {
                btnGuardarCambios.Visible = true;
            }
            else
            {
                btnGuardarIndividual.Visible = true;
            }
        }

        //---------------------------------------------------------------------------------
        //Metodos de busqueda

        private void MostrarPaginaCorporativosBusqueda()
        {
            if (dtCorporativosBusqueda == null)
                return;

            DataTable dtPagina = dtCorporativosBusqueda.Clone();

            int inicio = (paginaActual - 1) * registrosPorPagina;

            int fin = Math.Min(inicio + registrosPorPagina, dtCorporativosBusqueda.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtCorporativosBusqueda.Rows[i]);
            }

            dgvClientesCorporativos.DataSource = null;
            dgvClientesCorporativos.DataSource = dtPagina;
            FormatearTablaCorporativos();

            lblPagina.Text = $"Página {paginaActual} de {totalPaginas}";

            btnAtrasC.Enabled = paginaActual > 1;

            btnSiguienteC.Enabled = paginaActual < totalPaginas;
        }

        private void MostrarPaginaIndividualesBusqueda()
        {
            if (dtIndividualesBusqueda == null)
                return;

            DataTable dtPagina = dtIndividualesBusqueda.Clone();

            int inicio = (paginaActualIndividual - 1) * registrosPorPagina;

            int fin = Math.Min(inicio + registrosPorPagina, dtIndividualesBusqueda.Rows.Count);

            for (int i = inicio; i < fin; i++)
            {
                dtPagina.ImportRow(dtIndividualesBusqueda.Rows[i]);
            }

            dgvClientesIndividuales.DataSource = null;
            dgvClientesIndividuales.DataSource = dtPagina;
            FormatearTablaCorporativos();


            lblPagina.Text = $"Página {paginaActualIndividual} de {totalPaginasIndividual}";

            btnAnterior.Enabled = paginaActualIndividual > 1;

            btnSiguiente.Enabled = paginaActualIndividual < totalPaginasIndividual;


        }
        private void txtBuscarCorporativo_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarCorporativo.Text == TextoBusqueda)
                    return;

                string buscar = txtBuscarCorporativo.Text.Trim();

                if (string.IsNullOrWhiteSpace(buscar))
                {
                    paginaActual = 1;
                    dtCorporativosBusqueda = null;
                    MostrarClientes();
                    return;
                }

                dtCorporativosBusqueda = DbCliente.BuscarClienteCorporativo(buscar);

                int totalResultados = dtCorporativosBusqueda.Rows.Count;

                totalPaginas = (int)Math.Ceiling((double)totalResultados / registrosPorPagina);

                if (totalPaginas == 0)
                    totalPaginas = 1;

                paginaActual = 1;

                MostrarPaginaCorporativosBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar clientes.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarIndividual_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarIndividual.Text == TextoBusqueda)
                    return;

                string buscar = txtBuscarIndividual.Text.Trim();

                if (string.IsNullOrWhiteSpace(buscar))
                {
                    paginaActualIndividual = 1;
                    dtIndividualesBusqueda = null;
                    MostrarClientes2();
                    return;
                }

                dtIndividualesBusqueda = DbCliente.BuscarClienteIndividual(buscar);

                int totalResultados = dtIndividualesBusqueda.Rows.Count;

                totalPaginasIndividual = (int)Math.Ceiling((double)totalResultados / registrosPorPagina);

                if (totalPaginasIndividual == 0)
                    totalPaginasIndividual = 1;

                paginaActualIndividual = 1;

                MostrarPaginaIndividualesBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar clientes.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-----------------------------------------------------------------------------------

        //BOTON DE NUEVO CLIENTE

        private void btnNuevoCliente_Click_1(object sender, EventArgs e)
        {
            LimpiarFormularioCliente();
            dgvClientesIndividuales.ClearSelection();
            dgvClientesIndividuales.CurrentCell = null;
            dgvClientesCorporativos.ClearSelection();
            dgvClientesCorporativos.CurrentCell = null;
        }

        private void txtNIT_TextChanged(object sender, EventArgs e)
        {
            string nit = txtNIT.Text.Replace("-", "");

            if (nit.Length > 14)
                nit = nit.Substring(0, 14);

            string resultado = "";

            if (nit.Length > 0)
                resultado += nit.Substring(0, Math.Min(4, nit.Length));

            if (nit.Length > 4)
                resultado += "-" + nit.Substring(4, Math.Min(6, nit.Length - 4));

            if (nit.Length > 10)
                resultado += "-" + nit.Substring(10, Math.Min(3, nit.Length - 10));

            if (nit.Length > 13)
                resultado += "-" + nit.Substring(13, 1);

            txtNIT.Text = resultado;
            txtNIT.SelectionStart = txtNIT.Text.Length;
        }

    }
}

