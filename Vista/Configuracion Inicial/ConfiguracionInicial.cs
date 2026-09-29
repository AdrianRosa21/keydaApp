using System;
using System.Windows.Forms;

namespace Vista.Configuracion_Inicial
{
    public partial class ConfiguracionInicial : Form
    {
        public ConfiguracionInicial()
        {
            InitializeComponent();
        }

        private void ConfiguracionParte1_Load(object sender, EventArgs e)
        {

        }

        private void btnSeguir_Click(object sender, EventArgs e)
        {
            frmConfiguracionparte2 frm = new frmConfiguracionparte2();
            frm.Show();

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
