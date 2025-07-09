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
            //dtFechaPublicacion.Format = DateTimePickerFormat.Short;
            MostrarLibros();
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            modeloLibro inflibro = new modeloLibro()
            {
                titulo = txtTitulo.Text,
                escritor = txtEscritor.Text,
                numeroPaginas = int.Parse(txtNumeroPaginas.Text),
                idioma = txtIdioma.Text,
                fechaPublicacion = dtFechaPublicacion.Value,
                idGenero = int.Parse(cbGenero.SelectedValue.ToString()),
                cantidadCopias = int.Parse(txtCopias.Text)
            };
            if (controlCRUDLibros.RegistrarLibro(inflibro))
            {
                MessageBox.Show("Libro registrado correctamente");
                MostrarLibros();
                btnLimpiar.PerformClick();
            }
            else
            {
                MessageBox.Show("Error al registrar el libro");
            }
        }

        public void MostrarLibros()
        {
            dtgvLibros.AutoGenerateColumns = false;
            controlCRUDLibros.MostrarLibros();
            List<modeloLibro> vistaLibros = controlCRUDLibros.MostrarLibros();
            dtgvLibros.DataSource = vistaLibros;

        }

        private void dtgvJalarDatos(object sender, DataGridViewCellEventArgs e)
        {
            modeloLibro libro = dtgvLibros.CurrentRow.DataBoundItem as modeloLibro;
            txtIdLibro.Text = libro.idLibro.ToString();
            txtTitulo.Text = libro.titulo;
            txtEscritor.Text = libro.escritor;
            txtNumeroPaginas.Text = libro.numeroPaginas.ToString();
            txtIdioma.Text = libro.idioma;
            dtFechaPublicacion.Value = libro.fechaPublicacion;
            cbGenero.Text = libro.idGenero.ToString();
            txtCopias.Text = libro.cantidadCopias.ToString();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdLibro.Text = "";
            txtTitulo.Text = "";
            txtEscritor.Text = "";
            txtNumeroPaginas.Text = "";
            txtIdioma.Text = "";
            dtFechaPublicacion.Value = DateTime.Now;
            cbGenero.SelectedIndex = -1;
            txtCopias.Text = "";
        }
    }
}
