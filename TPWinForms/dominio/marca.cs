using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class marca
    {
        public int idMarca { get; set; }
        [DisplayName("NOMBRE")]
        public string nombre { get; set; }
        public override string ToString()
        {
            return nombre;
        }
    }
}
