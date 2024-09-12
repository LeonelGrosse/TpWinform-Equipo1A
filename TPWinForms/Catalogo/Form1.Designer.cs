namespace Catalogo
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
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.btnBorrarArticulo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.lbTipo = new System.Windows.Forms.Label();
            this.lbOrden = new System.Windows.Forms.Label();
            this.cbxOrden = new System.Windows.Forms.ComboBox();
            this.btnSiguienteImagen = new System.Windows.Forms.Button();
            this.btnAnteriorImagen = new System.Windows.Forms.Button();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulos.Location = new System.Drawing.Point(12, 49);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(805, 297);
            this.dgvArticulos.TabIndex = 0;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // btnMarcas
            // 
            this.btnMarcas.Location = new System.Drawing.Point(527, 366);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Size = new System.Drawing.Size(140, 51);
            this.btnMarcas.TabIndex = 1;
            this.btnMarcas.Text = "MARCAS";
            this.btnMarcas.UseVisualStyleBackColor = true;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Location = new System.Drawing.Point(673, 366);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(144, 51);
            this.btnCategorias.TabIndex = 2;
            this.btnCategorias.Text = "CATEGORIAS";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // pbxImagen
            // 
            this.pbxImagen.Location = new System.Drawing.Point(839, 49);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(363, 297);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagen.TabIndex = 3;
            this.pbxImagen.TabStop = false;
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Location = new System.Drawing.Point(11, 366);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(141, 51);
            this.btnAgregarArticulo.TabIndex = 4;
            this.btnAgregarArticulo.Text = "Agregar Articulo";
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // btnBorrarArticulo
            // 
            this.btnBorrarArticulo.Location = new System.Drawing.Point(305, 366);
            this.btnBorrarArticulo.Name = "btnBorrarArticulo";
            this.btnBorrarArticulo.Size = new System.Drawing.Size(153, 51);
            this.btnBorrarArticulo.TabIndex = 5;
            this.btnBorrarArticulo.Text = "Borrar Articulo";
            this.btnBorrarArticulo.UseVisualStyleBackColor = true;
            this.btnBorrarArticulo.Click += new System.EventHandler(this.btnBorrarArticulo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(158, 366);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(141, 51);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar Articulo";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.Location = new System.Drawing.Point(8, 18);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(76, 19);
            this.lblBusqueda.TabIndex = 8;
            this.lblBusqueda.Text = "Busqueda: ";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(77, 19);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(164, 20);
            this.txtBusqueda.TabIndex = 9;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // cbxTipo
            // 
            this.cbxTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Location = new System.Drawing.Point(512, 16);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(121, 21);
            this.cbxTipo.TabIndex = 10;
            this.cbxTipo.SelectedIndexChanged += new System.EventHandler(this.cbxCampo_SelectedIndexChanged);
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipo.Location = new System.Drawing.Point(467, 17);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(39, 19);
            this.lbTipo.TabIndex = 11;
            this.lbTipo.Text = "Tipo:";
            // 
            // lbOrden
            // 
            this.lbOrden.AutoSize = true;
            this.lbOrden.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrden.Location = new System.Drawing.Point(639, 16);
            this.lbOrden.Name = "lbOrden";
            this.lbOrden.Size = new System.Drawing.Size(51, 19);
            this.lbOrden.TabIndex = 12;
            this.lbOrden.Text = "Orden:";
            // 
            // cbxOrden
            // 
            this.cbxOrden.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxOrden.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOrden.FormattingEnabled = true;
            this.cbxOrden.Location = new System.Drawing.Point(696, 16);
            this.cbxOrden.Name = "cbxOrden";
            this.cbxOrden.Size = new System.Drawing.Size(121, 21);
            this.cbxOrden.TabIndex = 13;
            // 
            // btnSiguienteImagen
            // 
            this.btnSiguienteImagen.Location = new System.Drawing.Point(1111, 366);
            this.btnSiguienteImagen.Name = "btnSiguienteImagen";
            this.btnSiguienteImagen.Size = new System.Drawing.Size(91, 33);
            this.btnSiguienteImagen.TabIndex = 14;
            this.btnSiguienteImagen.Text = "-->";
            this.btnSiguienteImagen.UseVisualStyleBackColor = true;
            // 
            // btnAnteriorImagen
            // 
            this.btnAnteriorImagen.Location = new System.Drawing.Point(1019, 366);
            this.btnAnteriorImagen.Name = "btnAnteriorImagen";
            this.btnAnteriorImagen.Size = new System.Drawing.Size(86, 33);
            this.btnAnteriorImagen.TabIndex = 15;
            this.btnAnteriorImagen.Text = "<--";
            this.btnAnteriorImagen.UseVisualStyleBackColor = true;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(839, 366);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(128, 33);
            this.btnAgregarImagen.TabIndex = 16;
            this.btnAgregarImagen.Text = "Agregar Imagen";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1232, 430);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.btnAnteriorImagen);
            this.Controls.Add(this.btnSiguienteImagen);
            this.Controls.Add(this.cbxOrden);
            this.Controls.Add(this.lbOrden);
            this.Controls.Add(this.lbTipo);
            this.Controls.Add(this.cbxTipo);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBorrarArticulo);
            this.Controls.Add(this.btnAgregarArticulo);
            this.Controls.Add(this.pbxImagen);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.btnMarcas);
            this.Controls.Add(this.dgvArticulos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalogo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Button btnMarcas;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.Button btnBorrarArticulo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.Label lbOrden;
        private System.Windows.Forms.ComboBox cbxOrden;
        private System.Windows.Forms.Button btnSiguienteImagen;
        private System.Windows.Forms.Button btnAnteriorImagen;
        private System.Windows.Forms.Button btnAgregarImagen;
    }
}

