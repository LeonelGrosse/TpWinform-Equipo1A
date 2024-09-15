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
            CargarOrdenDentroForm1_Load();
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
            if (dgvArticulos.CurrentRow != null)
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

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            frmAgregarArticulo alta = new frmAgregarArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            articulo seleccionado;
            try
            {
                if (dgvArticulos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay articulos para modificar");
                    return;
                }
                cargar();
                seleccionado = (articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAgregarArticulo modificar = new frmAgregarArticulo(seleccionado);
                modificar.ShowDialog();

                cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBorrarArticulo_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            articulo seleccionado;
            try
            {
                if (dgvArticulos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay articulos para eliminar");
                    return;
                }
                DialogResult respuesta = MessageBox.Show("Estas seguro que queres eliminar este articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    cargar();
                    seleccionado = (articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.idArticulo);
                }
                cargar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void CargarOrdenDentroForm1_Load()
        {
            cbxTipo.Items.Add("Código");
            cbxTipo.Items.Add("Nombre");
            cbxTipo.Items.Add("Precio");
        }
        
        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTipo.SelectedItem == null) return;
            string opcion = cbxTipo.SelectedItem.ToString();
            cbxOrden.Items.Clear();
            switch (opcion)
            {
                case "Código":
                    cbxOrden.Items.Add("Comienza con");
                    cbxOrden.Items.Add("Termina con");
                    cbxOrden.Items.Add("Contiene");
                    break;
                case "Nombre":
                    cbxOrden.Items.Add("Comienza con");
                    cbxOrden.Items.Add("Termina con");
                    cbxOrden.Items.Add("Contiene");
                    break;
                case "Precio":
                    cbxOrden.Items.Add("Mayor a");
                    cbxOrden.Items.Add("Menor a");
                    cbxOrden.Items.Add("Igual a");
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
            if(dgvArticulos.CurrentRow != null)
            {
                articulo seleccionado;
                seleccionado = (articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAgregarImagen modificar = new frmAgregarImagen(seleccionado);
                modificar.ShowDialog();
                cargar();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo en la lista.");
            }
        }

        public List<articulo> filtrarLista(string tipo, string orden, string filtro)
        {
            List<articulo> lista = new List<articulo>();
            accesoDatos datos = new accesoDatos();
            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS marcDesc, C.Id AS catID, C.Descripcion AS catDesc, A.Precio, I.Id AS imgID, I.ImagenUrl AS imgUrl FROM Articulos A " +
                                  "JOIN Marcas M ON A.IdMarca = M.Id " +
                                  "JOIN Categorias C ON A.IdCategoria = C.Id " +
                                  "LEFT JOIN Imagenes I ON A.Id = I.IdArticulo";

                if (!string.IsNullOrEmpty(tipo) && !string.IsNullOrEmpty(orden) && !string.IsNullOrEmpty(filtro))
                {
                    consulta += " WHERE ";
                    switch (tipo)
                    {
                        case "Código":
                            switch (orden)
                            {
                                case "Comienza con":
                                    consulta += "A.Codigo LIKE @filtro + '%' ";
                                    break;
                                case "Termina con":
                                    consulta += "A.Codigo LIKE '%' + @filtro";
                                    break;
                                case "Contiene":
                                    consulta += "A.Codigo LIKE '%' + @filtro + '%'";
                                    break;
                            }
                            break;
                        case "Nombre":
                            switch (orden)
                            {
                                case "Comienza con":
                                    consulta += "A.Nombre LIKE @filtro + '%' ";
                                    break;
                                case "Termina con":
                                    consulta += "A.Nombre LIKE '%' + @filtro";
                                    break;
                                case "Contiene":
                                    consulta += "A.Nombre LIKE '%' + @filtro + '%'";
                                    break;
                            }
                            break;
                        case "Precio":
                            switch (orden)
                            {
                                case "Mayor a":
                                    consulta += "A.Precio >= @filtro";
                                    break;
                                case "Menor a":
                                    consulta += "A.Precio <= @filtro";
                                    break;
                                case "Igual a":
                                    consulta += "A.Precio = @filtro";
                                    break;
                            }
                            break;
                    }
                }

                datos.setConsulta(consulta);
                datos.setParametro("@filtro", filtro);
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
                    aux.marca.idMarca = (int)datos.Lector["IdMarca"];
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
                string tipo = cbxTipo.SelectedItem != null ? cbxTipo.SelectedItem.ToString() : string.Empty;
                string orden = cbxOrden.SelectedItem != null ? cbxOrden.SelectedItem.ToString() : string.Empty;
                string filtro = txtBusqueda.Text.Trim();

                if (string.IsNullOrEmpty(tipo))
                {
                    MessageBox.Show("Por favor, seleccione un tipo.");
                    return;
                }

                if (string.IsNullOrEmpty(orden))
                {
                    MessageBox.Show("Por favor, seleccione un orden.");
                    return;
                }

                if (string.IsNullOrEmpty(filtro))
                {
                    MessageBox.Show("Por favor, ingrese un filtro de búsqueda.");
                    return;
                }

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
            seleccionado = (articulo)dgvArticulos.CurrentRow.DataBoundItem;

            int contador = 0;

            foreach (articulo art in listaArticulo)
            {
                if (art.idArticulo == seleccionado.idArticulo)
                {
                    if (art.imagen.urlImagen != seleccionado.imagen.urlImagen && pbxImagen.Visible == true)
                    {
                        cargarImagen2(art.imagen.urlImagen);
                        pbxImagen2.Visible = true;
                        pbxImagen.Visible = false;
                        contador++;
                    }
                    else if (art.imagen.urlImagen != seleccionado.imagen.urlImagen && pbxImagen.Visible == false)
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

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcaCategoria categorias = new frmMarcaCategoria(false); // al manar el FALSE, se inica que se quiere ver CATEGORIAS
            categorias.ShowDialog();
            cargar();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcaCategoria marca = new frmMarcaCategoria(true); // al manar el TRUE, se inica que se quiere ver MARCAS
            marca.ShowDialog();
            cargar();
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            cargar();
            articulo seleccionado;
            seleccionado = (articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmVerDetallesArticulo detalles = new frmVerDetallesArticulo(seleccionado);
            detalles.ShowDialog();
        }
    }
}
