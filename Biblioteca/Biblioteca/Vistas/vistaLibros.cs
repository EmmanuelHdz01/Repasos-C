using Biblioteca.Controladores;
using Biblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Controladores
{
    public partial class vistaLibros : Form
    {
        public vistaLibros()
        {
            InitializeComponent();
            MostrarLibros();
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {

        }

        public void MostrarLibros()
        {
            dtgvLibros.AutoGenerateColumns = false;
            controlCRUDLibros.MostrarLibros();
            List<modeloLibro> vistaLibros = controlCRUDLibros.MostrarLibros();
            dtgvLibros.DataSource = vistaLibros;

        }
    }
}
