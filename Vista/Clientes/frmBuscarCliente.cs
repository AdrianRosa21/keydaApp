using Modelo.Entidades;
using System;
using System.Drawing;
using System.Windows.Forms;
using Vista.Responsive;

namespace Vista.Clientes
{
    public partial class frmBuscarCliente : Form
    {
        public frmBuscarCliente()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);

            // CONFIGURACIÓN DEL DATA GRID
            DiseñoConfigurarDataGrid();

            // TOOLTIPS
            ConfigurarTooltips();
        }
        public int IdClienteSeleccionado { get; private set; }
        public string NombreClienteSeleccionado { get; private set; }
        public string TelefonoClienteSeleccionado { get; private set; }

        public string CorreoClienteSeleccionado { get; private set; }

        public string DireccionClienteSeleccionado { get; private set; }

        //----------------------------------------------------------------------
        // CONFIGURACIÓN DEL DATA GRID
        private void DiseñoConfigurarDataGrid()
        {
            // CONFIGURACIÓN GENERAL
            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.AllowUserToResizeColumns = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.MultiSelect = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClientes.GridColor = Color.FromArgb(220, 220, 220);
            dgvClientes.EnableHeadersVisualStyles = false;

            // ENCABEZADO
            dgvClientes.ColumnHeadersHeight = 40;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvClientes.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(121, 75, 45),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(121, 75, 45),
                SelectionForeColor = Color.White,
                Padding = new Padding(5)
            };

            // FILAS
            dgvClientes.RowTemplate.Height = 36;

            dgvClientes.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(45, 45, 45),
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(224, 193, 157),
                SelectionForeColor = Color.Black,
                Padding = new Padding(5)
            };

            // FILAS ALTERNADAS
            dgvClientes.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 241, 232),
                ForeColor = Color.FromArgb(45, 45, 45),
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(224, 193, 157),
                SelectionForeColor = Color.Black
            };

            // AJUSTAR COLUMNAS
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // NO PERMITIR ORDENAMIENTO
            foreach (DataGridViewColumn columna in dgvClientes.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // ----------------------------------------------------------------------
        // FORMATEAR DATA GRID

        private void FormatearDataGrid()
        {
            if (dgvClientes.Columns.Count == 0)
                return;
            // Ocultar ID

            if (dgvClientes.Columns.Contains("#"))
            {
                dgvClientes.Columns["#"].Visible = false;
            }
            // ------------------------------------------------------------------
            // CLIENTE
            if (dgvClientes.Columns.Contains("Cliente"))
            {
                dgvClientes.Columns["Cliente"].HeaderText = "Cliente";

                dgvClientes.Columns["Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            // ------------------------------------------------------------------
            // TELÉFONO

            if (dgvClientes.Columns.Contains("Telefono"))
            {
                dgvClientes.Columns["Telefono"].HeaderText =
                    "Teléfono";
            }
            // ------------------------------------------------------------------
            // CORREO

            if (dgvClientes.Columns.Contains("Correo"))
            {
                dgvClientes.Columns["Correo"].HeaderText = "Correo";
            }
            // ------------------------------------------------------------------
            // DIRECCIÓN

            if (dgvClientes.Columns.Contains("Direccion"))
            {
                dgvClientes.Columns["Direccion"].HeaderText = "Dirección";
            }
            // ------------------------------------------------------------------
            // ESTADO

            if (dgvClientes.Columns.Contains("Estado"))
            {
                dgvClientes.Columns["Estado"].HeaderText = "Estado";
            }


            // ------------------------------------------------------------------
            // EVITAR ORDENAMIENTO

            foreach (DataGridViewColumn columna in dgvClientes.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        // ----------------------------------------------------------------------
        // MOSTRAR CLIENTES

        private void MostrarClientes()
        {
            try
            {
                dgvClientes.DataSource = null;

                dgvClientes.DataSource =
                    DbCliente.CargarClientesParaSeleccionar();

                FormatearDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar los clientes: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ----------------------------------------------------------------------
        // TOOLTIP
        private void ConfigurarTooltips()
        {
            ToolTip tooltip = new ToolTip();
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 500;
            tooltip.ReshowDelay = 200;
            tooltip.ShowAlways = true;

            tooltip.SetToolTip(txtBuscarCliente, "Buscar un cliente por nombre, teléfono, correo o dirección.");
            tooltip.SetToolTip(dgvClientes, "Seleccione el cliente que desea utilizar.");
            tooltip.SetToolTip(btnSeleccionarCliente, "Seleccionar el cliente marcado.");
            tooltip.SetToolTip(btnSlir, "Cerrar esta ventana.");
        }
        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            MostrarClientes();

        }
        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona un cliente.");
                    return;
                }

                DataGridViewRow fila = dgvClientes.CurrentRow;

                IdClienteSeleccionado = Convert.ToInt32(fila.Cells["#"].Value);

                NombreClienteSeleccionado = Convert.ToString(fila.Cells["Cliente"].Value);

                TelefonoClienteSeleccionado = Convert.ToString(fila.Cells["Telefono"].Value);

                CorreoClienteSeleccionado = Convert.ToString(fila.Cells["Correo"].Value);

                DireccionClienteSeleccionado = Convert.ToString(fila.Cells["Direccion"].Value);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al seleccionar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ----------------------------------------------------------------------
        // BOTON DE SALIR
        private void btnSlir_Click(object sender, EventArgs e)
        {
            Close();

        }
        // ----------------------------------------------------------------------
        // AL SELECCIONAR UN CLIENTE
        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscarCliente.Text == "Buscar Cliente...")
                    return;

                dgvClientes.DataSource = DbCliente.BuscarClientesSeleecion(txtBuscarCliente.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // ----------------------------------------------------------------------
        // BUSQUEDA
        private void txtBuscarCliente_Leave(object sender, EventArgs e)
        {

            txtBuscarCliente.Text = "Buscar Cliente...";
            txtBuscarCliente.ForeColor = Color.Gray;
        }
        private void txtBuscarCliente_Enter(object sender, EventArgs e)
        {
            //Cuando el usuario de enter para escribir, se va a borrar el texto de indicacion
            // Y el texto ya no sera opaco, sera color negro
            if (txtBuscarCliente.Text == "Buscar Cliente...")
            {
                txtBuscarCliente.Text = "";
                txtBuscarCliente.ForeColor = Color.Black;
            }
        }



    }
}

