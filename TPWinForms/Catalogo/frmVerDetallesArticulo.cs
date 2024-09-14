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
    public partial class frmVerDetallesArticulo : Form
    {
        private articulo articulo = null;
        public frmVerDetallesArticulo()
        {
            InitializeComponent();
        }
        public frmVerDetallesArticulo(articulo articulo)
        { 
            InitializeComponent();
            this.articulo = articulo;
        }

        private void frmVerDetallesArticulo_Load(object sender, EventArgs e)
        {
            marcaNegocio marca = new marcaNegocio();
            categoriaNegocio categoria = new categoriaNegocio();
            try
            {
                txtIdArticulo.Text = articulo.idArticulo.ToString();
                txtCodigo.Text = articulo.codigo;
                txtNombre.Text = articulo.nombre;
                txtDescripcion.Text = articulo.descripcion;
                txtIdMarca.Text = articulo.marca.idMarca.ToString();
                txtMarca.Text = articulo.marca.nombre;
                txtIdCategoria.Text = articulo.categoria.idCategoria.ToString();
                txtCategoria.Text = articulo.categoria.nombre;
                txtPrecio.Text = articulo.precio.ToString();
                txtUrlImagen.Text = articulo.imagen.urlImagen;

                cargarImagen(articulo.imagen.urlImagen);
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
                pbxImagen.Load(imagen);
            }
            catch (Exception)
            {
                pbxImagen.Load("https://img.freepik.com/premium-vector/default-image-icon-vector-missing-picture-page-website-design-mobile-app-no-photo-available_87543-11093.jpg");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
