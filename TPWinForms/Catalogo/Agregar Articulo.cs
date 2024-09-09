using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;

namespace Catalogo
{
    public partial class frmAgregarArticulo : Form
    {
        public frmAgregarArticulo()
        {
            InitializeComponent();
        }

        private void frmAgregarArticulo_Load(object sender, EventArgs e)
        {
            marcaNegocio marca = new marcaNegocio();    
            categoriaNegocio categoria = new categoriaNegocio();
            try
            {
                cbxMarca.DataSource = marca.listar();
                cbxCategoria.DataSource = categoria.listar();   
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            articulo art = new articulo(); 
            articuloNegocio negocio = new articuloNegocio();

            try
            {
                art.codigo = txtCodigo.Text;
                art.nombre = txtNombre.Text;    
                art.descripcion = txtDescripcion.Text;
                art.marca = (marca)cbxMarca.SelectedItem;
                art.categoria =(categoria)cbxCategoria.SelectedItem;
                art.precio = int.Parse(txtPrecio.Text);

                negocio.agregar(art);
                MessageBox.Show("Agregado exitosamente");
                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
