using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoHWySO;

namespace Acceso_a_hardware_y_SO
{
    public partial class frmMenu : Form
    {
        clsSystemAcesso loAcesso = new clsSystemAcesso();
        int lnCont = 1;
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnUndsDisco_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"N° Unidades de Disco: {loAcesso.ObtenerCantidadUnidadesDisco()}.");
        }

        private void btnDisk_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Numero serial :{loAcesso.ObtenerNumeroSerial()}.");            
        }

        private void btnInvSys_Click(object sender, EventArgs e)
        {
            MessageBox.Show(loAcesso.ObtenerInventarioGeneralSistema());            
        }

        private void btnMAC_Addr_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"MAC Address: {loAcesso.ObtenerMACAddress()}.");
        }

        private void btnCrearKey_Click(object sender, EventArgs e)
        {
            loAcesso.CrearClaveRegistro("HKEY_CURRENT_USER\\Software\\MyAPP", "Version", $"{lnCont++}.0");
        }

        private void btnLeerKey_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Version: {loAcesso.LeerClaveRegistro("HKEY_CURRENT_USER\\Software\\MyAPP", "Version")}");
        }

        private void btnModKey_Click(object sender, EventArgs e)
        {
            loAcesso.ModificarClaveResgitro("HKEY_CURRENT_USER\\Software\\MyAPP", "Version", $"{lnCont++}.0");
        }

        private void btnBorrarKey_Click(object sender, EventArgs e)
        {
            loAcesso.BorrarClaveRegisto("HKEY_CURRENT_USER\\Software\\MyAPP", "Version");
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }
        private void btnProcesos_Click(object sender, EventArgs e)
        {
            frmOpProcesos opProcesos = new frmOpProcesos();
            opProcesos.ShowDialog();
            this.SuspendLayout();
        }
    }
}
