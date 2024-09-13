using dominio;
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

namespace Catalogo
{
    public partial class frmAgregarImagen : Form
    {
        private articulo articulo = null;
        public frmAgregarImagen()
        {
            InitializeComponent();
        }
        public frmAgregarImagen(articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Agregar imagen";
        }
        private void frmAgregarImagen_Load(object sender, EventArgs e)
        {
            marcaNegocio marca = new marcaNegocio();
            categoriaNegocio categoria = new categoriaNegocio();
            try
            {
                txtCodigo.Text = articulo.codigo;
                txtNombre.Text = articulo.nombre;
                txtDescripcion.Text = articulo.descripcion;
                txtPrecio.Text = articulo.precio.ToString();
                txtMarca.Text = articulo.marca.nombre;
                txtCategoria.Text = articulo.categoria.nombre;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxAgregarImagen.Load(imagen);
            }
            catch (Exception)                                     
            {
                pbxAgregarImagen.Load("https://img.freepik.com/premium-vector/default-image-icon-vector-missing-picture-page-website-design-mobile-app-no-photo-available_87543-11093.jpg");  
            }
        }

        private void btnCancelarImagen_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();

            if (!string.IsNullOrWhiteSpace(txtUrlImagen.Text))
            {
                try
                {
                    negocio.modificarImagen(articulo);
                    MessageBox.Show("Agregado exitosamente");

                    Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }    
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una Url");
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
    }
}
