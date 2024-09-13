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

        private void CargarOrdenForm()
        {
            cbxTipo.Items.Add("Código");
            cbxTipo.Items.Add("Nombre");
            cbxTipo.Items.Add("Precio");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            CargarOrdenForm();
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
            catch (Exception)                                      //Le saque la variable ex ya que no se usa y generaba un warning
            {
                pbxImagen.Load("https://img.freepik.com/premium-vector/default-image-icon-vector-missing-picture-page-website-design-mobile-app-no-photo-available_87543-11093.jpg");  //Al no tener imagen el articulo, se carga esta imagen por defecto
            }
        }

        private void cargarImagen2(string imagen)
        {
            try
            {
                pbxImagen2.Load(imagen);
            }
            catch (Exception)                                    
            {
                pbxImagen2.Load("https://img.freepik.com/premium-vector/default-image-icon-vector-missing-picture-page-website-design-mobile-app-no-photo-available_87543-11093.jpg");  
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
                case "Precio":
                    CargarOrden();
                    break;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<articulo> listaFiltrada;
            string filtro = txtBusqueda.Text;

            if (filtro.Length >= 3)
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
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            articulo seleccionado;
            seleccionado = (articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAgregarImagen modificar = new frmAgregarImagen(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        public List<articulo> filtrarLista(string tipo, string orden, string filtro)
        {
            List<articulo> lista = new List<articulo>();
            accesoDatos datos = new accesoDatos();
            try
            {
                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Id marcID, M.Descripcion marcDesc, C.Id catID, C.Descripcion catDesc, Precio, I.Id imgID, I.ImagenUrl imgUrl FROM Articulos A " +
                          "JOIN Marcas M ON A.MarcaId = M.Id " +
                          "JOIN Categorias C ON A.CategoriaId = C.Id " +
                          "LEFT JOIN Imagenes I ON A.Id = I.ArticuloId WHERE P.Activo = 1 AND ";
                switch (tipo)
                {
                    case "Comienza con":
                        consulta += "Código like '" + filtro + "%' ";
                        break;
                    case "Termina con":
                        consulta += "Código like '%" + filtro + "'";
                        break;
                    default:
                        consulta += "Código like '%" + filtro + "%'";
                        break;   
                }
                switch (tipo)
                {
                    case "Comienza con":
                        consulta += "Nombre like '" + filtro + "%' ";
                        break;
                    case "Termina con":
                        consulta += "Nombre like '%" + filtro + "'";
                        break;
                    default:
                        consulta += "Nombre like '%" + filtro + "%'";
                        break;
                }
                switch (tipo)
                {
                    case "Mayor a":
                        consulta += "Precio > " + filtro;
                        break;
                    case "Menor a":
                        consulta += "Precio < " + filtro;
                        break;
                    case "Igual a":
                        consulta += "Precio = " + filtro;
                        break;
                }
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                
                while (datos.Lector.Read())
                {
                    articulo aux = new articulo();
                    aux.idArticulo = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    aux.marca = new marca();
                    aux.marca.idMarca = (int)datos.Lector["marcID"];
                    aux.marca.nombre = (string)datos.Lector["marcDesc"];

                    aux.categoria = new categoria();
                    aux.categoria.idCategoria = (int)datos.Lector["catID"];
                    aux.categoria.nombre = (string)datos.Lector["catDesc"];

                    aux.imagen = new imagen();
                    if (!(datos.Lector["imgID"] is DBNull))
                    {
                        aux.imagen.idImagen = (int)datos.Lector["imgID"];
                        aux.imagen.urlImagen = (string)datos.Lector["imgUrl"];
                    }

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnFiltro_Click(object sender, EventArgs e)
        {
            articulo art = new articulo();

            try
            {            
                string tipo = cbxTipo.SelectedItem.ToString();
                string orden = cbxOrden.SelectedItem.ToString();
                string filtro = txtBusqueda.Text;
                dgvArticulos.DataSource = filtrarLista(tipo, orden, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnSiguienteImagen_Click(object sender, EventArgs e)
        {
            articulo seleccionado;
            seleccionado=(articulo)dgvArticulos.CurrentRow.DataBoundItem;

            int contador = 0;
            
            foreach (articulo art in listaArticulo)
            { 
                if(art.idArticulo == seleccionado.idArticulo)
                {
                    if (art.imagen.urlImagen != seleccionado.imagen.urlImagen && pbxImagen.Visible == true)
                    {
                        cargarImagen2(art.imagen.urlImagen);
                        pbxImagen2.Visible = true;
                        pbxImagen.Visible = false;
                        contador++;
                    }
                    else if(art.imagen.urlImagen != seleccionado.imagen.urlImagen && pbxImagen.Visible == false)
                    {
                        cargarImagen(art.imagen.urlImagen);
                        pbxImagen2.Visible = false;
                        pbxImagen.Visible = true;
                        contador++;
                    }
                }
            }
            if (contador == 0)
                MessageBox.Show("No hay mas imagenes");
        }
    }
}
