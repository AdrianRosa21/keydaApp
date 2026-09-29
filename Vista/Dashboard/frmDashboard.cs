using System;
using System.Windows.Forms;
using Vista.Ayuda;
using Vista.Categorías;
using Vista.Clientes;
using Vista.Compras;
using Vista.configuracion;
using Vista.Cotizaciones;
using Vista.Facturación;
using Vista.Inventario;
using Vista.Login;
using Vista.Pedidos;
using Vista.Producción;
using Vista.Proveedores;
using Vista.Reportes;
using Vista.Responsive;
using Vista.Usuarios;
using Vista.Ventas;

namespace Vista.Dashboard
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);


        }
        private void AbrirFormulario(Form formulario)
        {
            pnlContenedor.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenedor.Controls.Add(formulario);
            pnlContenedor.Tag = formulario;

            formulario.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmInicio());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmClientes());
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmPedidos());
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmProduccion());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmInventario());
            AlternalPanel(pnlSubInventario);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmCompras());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmCategorias());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmVentas());
            AlternalPanel(pnlSubVentas);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmProveedores());
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmFacturacion());
        }

        private void btnCotizaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmCotizaciones());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAgrupar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void subPanel(bool estado)
        {
            pnlSubInventario.Visible = estado;
            pnlSubVentas.Visible = estado;
        }

        private void AlternalPanel(Panel panelObjetivo)
        {
            bool actualmenteVisible = panelObjetivo.Visible;
            this.subPanel(false);
            panelObjetivo.Visible = !actualmenteVisible;
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            subPanel(false);
            AbrirFormulario(new frmInicio());
            toolTip1.SetToolTip(btnClientes, "Ver clientes registrados");
            toolTip1.SetToolTip(btnVentas, "Consultar ventas");
            toolTip1.SetToolTip(btnPedidos, "Ver pedidos registrados");
            toolTip1.SetToolTip(btnCotizaciones, "Gestionar cotizaciones");
            toolTip1.SetToolTip(btnProduccion, "Ver Produccion de los pedidos");
            toolTip1.SetToolTip(btnInventario, "Ver Materiales del inventario");
            toolTip1.SetToolTip(btnReportes, "Consulta informacion y genera PDF");
            toolTip1.SetToolTip(btnProveedores, "Ver Proveedores registrados");
            toolTip1.SetToolTip(btnFacturacion, "Registra y genera una facturas");
            toolTip1.SetToolTip(btnCompras, "Registra y administra las compras");
            toolTip1.SetToolTip(btnCategorias, "Categorias del inventario");
            toolTip1.SetToolTip(btnCerrarSesion, "Cierra sesión");
            toolTip1.SetToolTip(btnAyuda, "Ayuda del sistema");
            toolTip1.SetToolTip(btnUsuarios, "Gestión de usuarios");
            toolTip1.SetToolTip(btnConfiguracion, "Configuración de la empresa");
            toolTip1.SetToolTip(btnMinimizar, "Minimizar");
            toolTip1.SetToolTip(btnSalir, "Salir");
            toolTip1.SetToolTip(btnMaximizar, "Maximizar");

        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frmLogin form_principal = new frmLogin();
            this.Hide();
            form_principal.Show();

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmUsuarios());
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAyuda());
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmConfiguracion());

        }
    }
}
