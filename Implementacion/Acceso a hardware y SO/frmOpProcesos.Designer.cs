namespace Acceso_a_hardware_y_SO
{
    partial class frmOpProcesos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpProcesos));
            this.btnProcesAct = new System.Windows.Forms.Button();
            this.btnKillProcs = new System.Windows.Forms.Button();
            this.rtbVisDatos = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnProcesAct
            // 
            this.btnProcesAct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProcesAct.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesAct.Location = new System.Drawing.Point(81, 184);
            this.btnProcesAct.Name = "btnProcesAct";
            this.btnProcesAct.Size = new System.Drawing.Size(75, 23);
            this.btnProcesAct.TabIndex = 9;
            this.btnProcesAct.Text = "&MOSTRAR";
            this.btnProcesAct.UseVisualStyleBackColor = true;
            this.btnProcesAct.Click += new System.EventHandler(this.btnProcesAct_Click);
            // 
            // btnKillProcs
            // 
            this.btnKillProcs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKillProcs.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKillProcs.Location = new System.Drawing.Point(248, 184);
            this.btnKillProcs.Name = "btnKillProcs";
            this.btnKillProcs.Size = new System.Drawing.Size(75, 23);
            this.btnKillProcs.TabIndex = 10;
            this.btnKillProcs.Text = "&EJECUTAR";
            this.btnKillProcs.UseVisualStyleBackColor = true;
            this.btnKillProcs.Click += new System.EventHandler(this.btnKillProcs_Click);
            // 
            // rtbVisDatos
            // 
            this.rtbVisDatos.Location = new System.Drawing.Point(28, 13);
            this.rtbVisDatos.Name = "rtbVisDatos";
            this.rtbVisDatos.Size = new System.Drawing.Size(349, 149);
            this.rtbVisDatos.TabIndex = 11;
            this.rtbVisDatos.Text = "";
            // 
            // frmOpProcesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 238);
            this.Controls.Add(this.rtbVisDatos);
            this.Controls.Add(this.btnKillProcs);
            this.Controls.Add(this.btnProcesAct);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOpProcesos";
            this.Text = "Procesos ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProcesAct;
        private System.Windows.Forms.Button btnKillProcs;
        private System.Windows.Forms.RichTextBox rtbVisDatos;
    }
}