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
            cargar();
            cbxTipo.Items.Add("Código");
            cbxTipo.Items.Add("Nombre");
            cbxTipo.Items.Add("Descripción");
            cbxTipo.Items.Add("Precio");
            cbxTipo.Items.Add("Marca");
            cbxTipo.Items.Add("Categoria");
        }

        private void cargar()
        {
            articuloNegocio artNegocio = new articuloNegocio();
            try
            {
                listaArticulo = artNegocio.listar();
                dgvArticulos.DataSource = listaArticulo;
                ocultarColumnas();
                cargarImagen(listaArticulo[0].imagen.urlImagen);           //Carga la imagen del primer articulo de la lista
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["idArticulo"].Visible = false;
            dgvArticulos.Columns["imagen"].Visible = false;
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)                 //Cambia la imagen del articulo al moverse por la tabla
        {
            if(dgvArticulos.CurrentRow != null)
            {
                articulo seleccionado = (articulo)dgvArticulos.CurrentRow.DataBoundItem;        
                cargarImagen(seleccionado.imagen.urlImagen);
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxImagen.Load("https://img.freepik.com/premium-vector/default-image-icon-vector-missing-picture-page-website-design-mobile-app-no-photo-available_87543-11093.jpg");  //Al no tener imagen el articulo, se carga esta imagen por defecto
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

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            frmAgregarArticulo alta = new frmAgregarArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            articulo seleccionado;
            seleccionado = (articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAgregarArticulo modificar = new frmAgregarArticulo(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnBorrarArticulo_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("Estas seguro que queres eliminar este articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.idArticulo);
                    cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            List<articulo> listaFiltrada;
            string filtro = txtBusqueda.Text;

            if(filtro != "")
            {               
                listaFiltrada = listaArticulo.FindAll(x => x.nombre.ToUpper().Contains(filtro.ToUpper()) || x.marca.nombre.ToUpper().Contains(filtro.ToUpper()) || x.categoria.nombre.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {               
                listaFiltrada = listaArticulo;
            }
       
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void CargarOrden()
        {
            cbxOrden.Items.Clear();
            cbxOrden.Items.Add("Mayor a");
            cbxOrden.Items.Add("Menor a");
            cbxOrden.Items.Add("Igual a");
            cbxOrden.Items.Add("Comienza con");
            cbxOrden.Items.Add("Termina con");
            cbxOrden.Items.Add("Contiene");
        }
        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbxTipo.SelectedItem.ToString();
            switch (opcion)
            {
                case "Código":
                case "Nombre":
                case "Descripción":
                case "Precio":
                case "Marca":
                case "Categoria":
                    CargarOrden();
                    break;
            }
        }
    }
}
