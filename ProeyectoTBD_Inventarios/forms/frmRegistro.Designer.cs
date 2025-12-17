namespace ProeyectoTBD_Inventarios.forms
{
    partial class frmRegistro
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
            this.txtbUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btRegistrarse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbContraseña = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbConfirmarCont = new System.Windows.Forms.TextBox();
            this.btVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2 - TÍTULO
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.label2.Location = new System.Drawing.Point(150, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.Text = "Crear cuenta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.label1.Location = new System.Drawing.Point(60, 85);
            this.label1.Name = "label1";
            this.label1.Text = "Usuario";
            // 
            // txtbUsuario
            // 
            this.txtbUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtbUsuario.Location = new System.Drawing.Point(60, 105);
            this.txtbUsuario.Name = "txtbUsuario";
            this.txtbUsuario.Size = new System.Drawing.Size(320, 25);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.label4.Location = new System.Drawing.Point(60, 145);
            this.label4.Name = "label4";
            this.label4.Text = "Contraseña";
            // 
            // txtbContraseña
            // 
            this.txtbContraseña.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtbContraseña.Location = new System.Drawing.Point(60, 165);
            this.txtbContraseña.Name = "txtbContraseña";
            this.txtbContraseña.Size = new System.Drawing.Size(320, 25);
            this.txtbContraseña.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.label5.Location = new System.Drawing.Point(60, 205);
            this.label5.Name = "label5";
            this.label5.Text = "Confirmar contraseña";
            // 
            // txtbConfirmarCont
            // 
            this.txtbConfirmarCont.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtbConfirmarCont.Location = new System.Drawing.Point(60, 225);
            this.txtbConfirmarCont.Name = "txtbConfirmarCont";
            this.txtbConfirmarCont.Size = new System.Drawing.Size(320, 25);
            this.txtbConfirmarCont.UseSystemPasswordChar = true;
            // 
            // btRegistrarse
            // 
            this.btRegistrarse.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btRegistrarse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRegistrarse.FlatAppearance.BorderSize = 0;
            this.btRegistrarse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btRegistrarse.ForeColor = System.Drawing.Color.White;
            this.btRegistrarse.Location = new System.Drawing.Point(60, 280);
            this.btRegistrarse.Name = "btRegistrarse";
            this.btRegistrarse.Size = new System.Drawing.Size(320, 35);
            this.btRegistrarse.Text = "Registrarse";
            this.btRegistrarse.UseVisualStyleBackColor = false;
            // 
            // btVolver
            // 
            this.btVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVolver.FlatAppearance.BorderSize = 0;
            this.btVolver.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btVolver.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btVolver.Location = new System.Drawing.Point(12, 330);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(70, 28);
            this.btVolver.Text = "Volver";
            this.btVolver.UseVisualStyleBackColor = true;
            // 
            // frmRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 382);
            this.Controls.Add(this.btVolver);
            this.Controls.Add(this.btRegistrarse);
            this.Controls.Add(this.txtbConfirmarCont);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbContraseña);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "frmRegistro";
            this.Text = "Registro";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btRegistrarse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbContraseña;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbConfirmarCont;
        private System.Windows.Forms.Button btVolver;
    }
}