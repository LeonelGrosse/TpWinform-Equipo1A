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
using negocio;

namespace Catalogo
{
    public partial class Form1 : Form
    {
        private List<articulo> listaArticulo; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            articuloNegocio artNegocio = new articuloNegocio();
            try
            {
                listaArticulo = artNegocio.listar();
                dgvArticulos.DataSource = listaArticulo;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            frmMarcaCategoria marca = new frmMarcaCategoria(true); // al manar el TRUE, se inica que se quiere ver MARCAS
            marca.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmMarcaCategoria categorias = new frmMarcaCategoria(false); // al manar el FALSE, se inica que se quiere ver CATEGORIAS
            categorias.ShowDialog();
        }
    }
}
