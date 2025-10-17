namespace presentacion
{
    partial class Form1
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
            this.lblFiltroRapido = new System.Windows.Forms.Label();
            this.lblCampo = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtCriterio = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.dgvArticulo = new System.Windows.Forms.DataGridView();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFiltroRapido
            // 
            this.lblFiltroRapido.AutoSize = true;
            this.lblFiltroRapido.Location = new System.Drawing.Point(12, 54);
            this.lblFiltroRapido.Name = "lblFiltroRapido";
            this.lblFiltroRapido.Size = new System.Drawing.Size(87, 16);
            this.lblFiltroRapido.TabIndex = 0;
            this.lblFiltroRapido.Text = "Filtro Rapido:";
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(45, 111);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(54, 16);
            this.lblCampo.TabIndex = 1;
            this.lblCampo.Text = "Campo:";
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(60, 166);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(39, 16);
            this.lblFiltro.TabIndex = 2;
            this.lblFiltro.Text = "Filtro:";
            // 
            // txtCriterio
            // 
            this.txtCriterio.AutoSize = true;
            this.txtCriterio.Location = new System.Drawing.Point(253, 114);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(52, 16);
            this.txtCriterio.TabIndex = 3;
            this.txtCriterio.Text = "Criterio:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(105, 51);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(327, 22);
            this.txtFiltro.TabIndex = 4;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(105, 166);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(100, 22);
            this.txtFiltroAvanzado.TabIndex = 5;
            this.txtFiltroAvanzado.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // cboCampo
            // 
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(105, 111);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(121, 24);
            this.cboCampo.TabIndex = 6;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // cboCriterio
            // 
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(311, 111);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(121, 24);
            this.cboCriterio.TabIndex = 7;
            // 
            // dgvArticulo
            // 
            this.dgvArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulo.Location = new System.Drawing.Point(15, 246);
            this.dgvArticulo.Name = "dgvArticulo";
            this.dgvArticulo.RowHeadersWidth = 51;
            this.dgvArticulo.RowTemplate.Height = 24;
            this.dgvArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulo.Size = new System.Drawing.Size(494, 150);
            this.dgvArticulo.TabIndex = 8;
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.Location = new System.Drawing.Point(24, 417);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(91, 28);
            this.btnVerDetalles.TabIndex = 9;
            this.btnVerDetalles.Text = "Ver Detalles";
            this.btnVerDetalles.UseVisualStyleBackColor = true;
            this.btnVerDetalles.Click += new System.EventHandler(this.btnVerDetalles_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(289, 483);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(151, 483);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(24, 483);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(230, 166);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 562);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnVerDetalles);
            this.Controls.Add(this.dgvArticulo);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.txtCriterio);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.lblFiltroRapido);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiltroRapido;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label txtCriterio;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.DataGridView dgvArticulo;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnBuscar;
    }
}

