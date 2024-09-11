using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using dominio;
using negocio;

namespace Catalogo
{
    public partial class frmMarcaCategoria : Form
    {
        private bool marca = true;
        List<marca> marcaLista = new List<marca>();
        List<categoria> categoriaLista = new List<categoria>();
        public frmMarcaCategoria(bool marca)
        {
            InitializeComponent();
            this.marca = marca;
        }

        private void frmMarcaCategoria_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            if (marca == true)
            {
                marcaNegocio marcaNegocio = new marcaNegocio();

                try
                {
                    marcaLista = marcaNegocio.listar();
                    dgwMarCat.DataSource = marcaLista;

                    this.Text = " MARCA ";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                categoriaNegocio categoriaNegocio = new categoriaNegocio();

                try
                {
                    categoriaLista = categoriaNegocio.listar();
                    dgwMarCat.DataSource = categoriaLista;

                    this.Text = " CATEGORIA ";
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                try
                {
                    if (marca == true)
                    {
                        marcaNegocio marcaNegocio = new marcaNegocio();
                        marca aux = new marca();
                        aux.nombre = txtNombre.Text;
                        marcaNegocio.agregar(aux);

                        MessageBox.Show(" MARCA AGREGADA ");

                    }
                    else
                    {
                        categoriaNegocio categoriaNegocio = new categoriaNegocio();
                        categoria aux = new categoria();
                        aux.nombre = txtNombre.Text;
                        categoriaNegocio.agregar(aux);

                        MessageBox.Show(" CATEGORIA AGREGAA ");
                    }
                    cargar();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                MessageBox.Show(" AGREGAR NOMBRE ");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (marca == true)
                {
                    DialogResult respuesta = MessageBox.Show("Estas seguro que queres eliminar esta marca?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(respuesta == DialogResult.Yes)
                    {
                        marcaNegocio marcNegocio = new marcaNegocio();
                        marca select = (marca)dgwMarCat.CurrentRow.DataBoundItem;
                        marcNegocio.eliminar(select.idMarca);
                        MessageBox.Show(" MARCA ELIMINADA ");
                    }                   
                }
                else
                {
                    DialogResult respuesta = MessageBox.Show("Estas seguro que queres eliminar esta categoria?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(respuesta == DialogResult.Yes)
                    {
                        categoriaNegocio catNegocio = new categoriaNegocio();
                        categoria select = (categoria)dgwMarCat.CurrentRow.DataBoundItem;
                        catNegocio.eliminar(select.idCategoria);
                        MessageBox.Show(" CATEGORIA ELIMINADA ");
                    }              
                }
                cargar() ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
