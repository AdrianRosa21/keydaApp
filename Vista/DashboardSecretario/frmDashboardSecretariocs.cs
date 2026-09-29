using System;
using System.Windows.Forms;
using Vista.Ayuda;
using Vista.Categorias_Inventario_Empleado;
using Vista.Clientes_Secretario;
using Vista.Dashboard;
using Vista.InicioSecretario;
using Vista.Iventario_Secretario;
using Vista.Login;
using Vista.Pedidos_Secretario;
using Vista.Produccion_Secretario;
using Vista.Responsive;

namespace Vista.DashboardSecretario
{
    public partial class frmDashboardSecretariocs : Form
    {
        public frmDashboardSecretariocs()
        {
            InitializeComponent();
            ResponsiveHelper.Apply(this);
            this.btnAgrupar.Click += new System.EventHandler(this.btnAgrupar_Click);
            AbrirFormulario(new frmInicio());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            AbrirFormulario(new frmInicioSecretario());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmClientesSecretario());
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmPedidosSecretario());
        }

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmProduccionSecretario());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmInventarioSecretario());
            AlternalPanel(pnlSubInventario);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmCategoriasInventarioSecretario());
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

        private void frmDashboardSecretariocs_Load(object sender, EventArgs e)
        {
            subPanel(false);

            AbrirFormulario(new frmInicioSecretario());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frmLogin form_principal = new frmLogin();
            this.Hide();
            form_principal.Show();
        }

        private void btnAgrupar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAyuda());
        }
    }
}
