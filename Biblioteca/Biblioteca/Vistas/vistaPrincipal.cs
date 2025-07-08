using Biblioteca.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class vistaPrincipal : Form
    {
        public vistaPrincipal()
        {
            InitializeComponent();
        }

        private void mdiUsuarios_Click(object sender, EventArgs e)
        {
            vistaUsuarios vista = new vistaUsuarios();
            vista.MdiParent = this;
            vista.Show();
        }

        private void mdiLibros_Click(object sender, EventArgs e)
        {
            vistaLibros vista = new vistaLibros();
            vista.MdiParent = this;
            vista.Show();
        }
    }
}
