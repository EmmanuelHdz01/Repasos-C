using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    internal class modeloLibro
    {
        public int idLibro { get; set; }
        public string titulo { get; set; }
        public string escritor { get; set; }
        public int numeroPaginas { get; set; }
        public string idioma { get; set; }
        public DateTime fechaPublicacion { get; set; }
        public int idGenero { get; set; }
        public string descripcionGenero
        {
            get
            {
                if (tipoGeneroL != null)
                {
                    return tipoGeneroL.tipoGenero;
                }
                else
                {
                    return "No hay";
                }

            }
        }
        public modeloGenero tipoGeneroL { get; set; }
        public int cantidadCopias { get; set; }
    }
}
