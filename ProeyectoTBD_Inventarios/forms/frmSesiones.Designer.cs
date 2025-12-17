namespace ProeyectoTBD_Inventarios.forms
{
    partial class frmSesiones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvSesiones = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSesiones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVolver.ForeColor = System.Drawing.Color.Gray;
            this.btnVolver.Location = new System.Drawing.Point(35, 400);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 35);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvSesiones
            // 
            this.dgvSesiones.AllowUserToAddRows = false;
            this.dgvSesiones.AllowUserToDeleteRows = false;
            this.dgvSesiones.BackgroundColor = System.Drawing.Color.White;
            this.dgvSesiones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSesiones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSesiones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSesiones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSesiones.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSesiones.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSesiones.EnableHeadersVisualStyles = false;
            this.dgvSesiones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvSesiones.Location = new System.Drawing.Point(35, 70);
            this.dgvSesiones.Name = "dgvSesiones";
            this.dgvSesiones.ReadOnly = true;
            this.dgvSesiones.RowHeadersVisible = false;
            this.dgvSesiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSesiones.Size = new System.Drawing.Size(560, 310);
            this.dgvSesiones.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Historial de Sesiones";
            // 
            // frmSesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 460);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvSesiones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSesiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sesiones";
            this.Load += new System.EventHandler(this.frmSesiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSesiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvSesiones;
        private System.Windows.Forms.Label label1;
    }
}