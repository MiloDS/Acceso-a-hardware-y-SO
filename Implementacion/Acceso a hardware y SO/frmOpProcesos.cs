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
    public partial class frmOpProcesos : Form
    {
        clsSystemAcesso loClsSystemAcesso = new clsSystemAcesso();
        public frmOpProcesos()
        {
            InitializeComponent();
        }

        private void btnProcesAct_Click(object sender, EventArgs e)
        {
            rtbVisDatos.Text = loClsSystemAcesso.ObtenerProcesosActivos();
        }

        private void btnKillProcs_Click(object sender, EventArgs e)
        {
            //Se crean los objetos que van en el formulario, de forma dinamica
            Label lblIdProc = new Label() { Left = 10, Top = 10, Text = "ID del Proceso:", Width = 260 };
            TextBox txtIdProc = new TextBox() { Left = 10, Top = 30, Width = 260 };
            Button btnOK = new Button() { Text = "OK", Left = 100, Width = 80, Top = 60 };
            Button btnCancel = new Button() { Text = "Cancelar", Left = 200, Width = 80, Top = 60 };
            
            //Se crea el formulario de forma dinamica
            Form frmDinamo = new Form()
            {
                Text = "Eliminando Proceso...",
                Width = 300,
                Height = 150,
                StartPosition = FormStartPosition.CenterParent
            };

            frmDinamo.Icon = new Icon(Application.StartupPath + "\\pikachu_icon-icons.com_67535.ico");

            //Se añaden controles al formulario
            frmDinamo.Controls.Add(lblIdProc);
            frmDinamo.Controls.Add(txtIdProc);
            frmDinamo.Controls.Add(btnOK);
            frmDinamo.Controls.Add(btnCancel);

            btnOK.Click += (senderOK, eOK) =>
            {
                //Obtiene el ID del proceso desde el TextBox
                if (int.TryParse(txtIdProc.Text, out int processId))
                {
                    //Confirmacion antes de matar el proceso
                    DialogResult result = MessageBox.Show(
                        $"¿Estás seguro de que deseas finalizar el proceso con ID {processId}?",
                        "Confirmación",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.OK)
                    {
                        try
                        {
                            loClsSystemAcesso.KillProcesos(processId); 
                            MessageBox.Show("Proceso finalizado con éxito.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al finalizar el proceso: {ex.Message}");
                        }
                    }
                }
                else
                {
                    
                    MessageBox.Show("Por favor, introduce un ID de proceso válido.");
                }                
                frmDinamo.Close();
            };
           
            btnCancel.Click += (senderCancel, eCancel) =>
            {
                
                frmDinamo.Close();
            };

            frmDinamo.Show();
        }
    }
}
