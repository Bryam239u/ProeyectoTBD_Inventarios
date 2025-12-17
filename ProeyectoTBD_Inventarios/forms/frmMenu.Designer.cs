namespace ProeyectoTBD_Inventarios.forms
{
    partial class frmMenu
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.lblCat = new System.Windows.Forms.Label();
            this.lblOps = new System.Windows.Forms.Label();
            this.lblAdmin = new System.Windows.Forms.Label();

            // Botones (Manteniendo nombres originales para evitar errores en el backend)
            this.button1 = new System.Windows.Forms.Button(); // Almacenes
            this.button2 = new System.Windows.Forms.Button(); // Productos
            this.button3 = new System.Windows.Forms.Button(); // Categorías
            this.button8 = new System.Windows.Forms.Button(); // Movimientos
            this.button4 = new System.Windows.Forms.Button(); // Detalles
            this.button7 = new System.Windows.Forms.Button(); // Inventarios
            this.button5 = new System.Windows.Forms.Button(); // Usuarios
            this.button6 = new System.Windows.Forms.Button(); // Sesiones
            this.btnOut = new System.Windows.Forms.Button();  // Log out

            this.panelMenu.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.lblAdmin);
            this.panelMenu.Controls.Add(this.lblOps);
            this.panelMenu.Controls.Add(this.lblCat);
            this.panelMenu.Controls.Add(this.btnOut);
            this.panelMenu.Controls.Add(this.labelTitle);

            // Agregando botones en orden lógico
            this.panelMenu.Controls.Add(this.button1); // Almacenes
            this.panelMenu.Controls.Add(this.button3); // Categorías
            this.panelMenu.Controls.Add(this.button2); // Productos

            this.panelMenu.Controls.Add(this.button8); // Movimientos
            this.panelMenu.Controls.Add(this.button4); // Detalles

            this.panelMenu.Controls.Add(this.button7); // Inventarios
            this.panelMenu.Controls.Add(this.button5); // Usuarios
            this.panelMenu.Controls.Add(this.button6); // Sesiones

            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(280, 520);
            this.panelMenu.TabIndex = 0;

            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(117, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Menú Principal";

            // 
            // SECCIÓN: CATÁLOGOS
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCat.ForeColor = System.Drawing.Color.Silver;
            this.lblCat.Location = new System.Drawing.Point(25, 65);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(75, 15);
            this.lblCat.Text = "CATÁLOGOS";

            // button1 (Almacenes)
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(0, 85);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(280, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "🏭  Almacenes";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // button3 (Categorías)
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.Location = new System.Drawing.Point(0, 120);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(280, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "🏷️  Categorías";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);

            // button2 (Productos)
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.Location = new System.Drawing.Point(0, 155);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(280, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "📦  Productos";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);

            // 
            // SECCIÓN: OPERACIONES
            // 
            this.lblOps.AutoSize = true;
            this.lblOps.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOps.ForeColor = System.Drawing.Color.Silver;
            this.lblOps.Location = new System.Drawing.Point(25, 205);
            this.lblOps.Name = "lblOps";
            this.lblOps.Size = new System.Drawing.Size(86, 15);
            this.lblOps.Text = "OPERACIONES";

            // button8 (Movimientos)
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button8.Location = new System.Drawing.Point(0, 225);
            this.button8.Name = "button8";
            this.button8.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button8.Size = new System.Drawing.Size(280, 35);
            this.button8.TabIndex = 4;
            this.button8.Text = "🚚  Movimientos";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);

            // button4 (Detalle Movimientos)
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.Location = new System.Drawing.Point(0, 260);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(280, 35);
            this.button4.TabIndex = 5;
            this.button4.Text = "📄  Detalles de Mov.";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);

            // 
            // SECCIÓN: ADMINISTRACIÓN
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAdmin.ForeColor = System.Drawing.Color.Silver;
            this.lblAdmin.Location = new System.Drawing.Point(25, 310);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(108, 15);
            this.lblAdmin.Text = "ADMINISTRACIÓN";

            // button7 (Inventarios)
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button7.Location = new System.Drawing.Point(0, 330);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(280, 35);
            this.button7.TabIndex = 6;
            this.button7.Text = "📊  Reporte Inventario";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);

            // button5 (Usuarios)
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button5.Location = new System.Drawing.Point(0, 365);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(280, 35);
            this.button5.TabIndex = 7;
            this.button5.Text = "👥  Usuarios";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);

            // button6 (Sesiones)
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button6.Location = new System.Drawing.Point(0, 400);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(280, 35);
            this.button6.TabIndex = 8;
            this.button6.Text = "🕒  Historial Sesiones";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);

            // 
            // btnOut (Log Out)
            // 
            this.btnOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnOut.FlatAppearance.BorderSize = 0;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOut.ForeColor = System.Drawing.Color.IndianRed;
            this.btnOut.Location = new System.Drawing.Point(0, 480);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(280, 40);
            this.btnOut.TabIndex = 9;
            this.btnOut.Text = "Cerrar Sesión";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            this.btnOut.Cursor = System.Windows.Forms.Cursors.Hand;

            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(280, 520);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Inventarios";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1; // Almacenes
        private System.Windows.Forms.Button button2; // Productos
        private System.Windows.Forms.Button button3; // Categorías
        private System.Windows.Forms.Button button4; // Detalles
        private System.Windows.Forms.Button button6; // Sesiones
        private System.Windows.Forms.Button button7; // Inventarios
        private System.Windows.Forms.Button button8; // Movimientos
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button button5; // Usuarios
        private System.Windows.Forms.Button btnOut;
        // Etiquetas para agrupar visualmente
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label lblOps;
        private System.Windows.Forms.Label lblAdmin;
    }
}