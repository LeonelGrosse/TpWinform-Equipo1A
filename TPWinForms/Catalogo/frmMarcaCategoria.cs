using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        List<marca> marcaLista = new List<marca>();
        public frmMarcaCategoria()
        {
            InitializeComponent();
        }

        private void frmMarcaCategoria_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar() 
        {
            marcaNegocio marcaNegocio = new marcaNegocio();

            try
            {
                marcaLista = marcaNegocio.listar();
                dgwMarCat.DataSource = marcaLista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
