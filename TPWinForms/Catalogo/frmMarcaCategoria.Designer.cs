namespace Catalogo
{
    partial class frmMarcaCategoria
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
            this.dgwMarCat = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMarCat)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwMarCat
            // 
            this.dgwMarCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMarCat.Location = new System.Drawing.Point(21, 11);
            this.dgwMarCat.Name = "dgwMarCat";
            this.dgwMarCat.Size = new System.Drawing.Size(386, 276);
            this.dgwMarCat.TabIndex = 0;
            // 
            // frmMarcaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 356);
            this.Controls.Add(this.dgwMarCat);
            this.Name = "frmMarcaCategoria";
            this.Text = "frmMarcaCategoria";
            this.Load += new System.EventHandler(this.frmMarcaCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwMarCat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwMarCat;
    }
}