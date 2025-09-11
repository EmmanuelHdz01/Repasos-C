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
            MostrarLibro();
            MostrarGeneros();
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            modeloLibro inflibro = new modeloLibro()
            {
                titulo = txtTitulo.Text,
                escritor = txtEscritor.Text,
                numeroPaginas = int.Parse(txtNumeroPaginas.Text),
                idioma = txtIdioma.Text,
                fechaPublicacion = dtFechaPublicacion.Value.Date,
                idGenero = int.Parse(cbGenero.SelectedValue.ToString()),
                cantidadCopias = int.Parse(txtCopias.Text)
            };
            if (controlCRUDLibros.RegistrarLibro(inflibro))
            {
                MessageBox.Show("Libro registrado correctamente");
                MostrarLibro();
            }
            else
            {
                MessageBox.Show("Error al registrar el libro");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            modeloLibro infLibro = new modeloLibro()
            {
                idLibro = int.Parse(txtIdLibro.Text),
                titulo = txtTitulo.Text,
                escritor = txtEscritor.Text,
                numeroPaginas = int.Parse(txtNumeroPaginas.Text),
                idioma = txtIdioma.Text,
                fechaPublicacion = dtFechaPublicacion.Value.Date,
                idGenero = int.Parse(cbGenero.SelectedValue.ToString()),
                cantidadCopias = int.Parse(txtCopias.Text)
            };
            if (controlCRUDLibros.ActualizarLibro(infLibro))
            {
                MessageBox.Show("Libro actualizado correctamente");
                MostrarLibro();
            }
            else
            {
                MessageBox.Show("Error al actualizar el libro");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            modeloLibro libro = dtgvLibros.CurrentRow.DataBoundItem as modeloLibro; 
            if (MessageBox.Show("¿Está seguro de eliminar el libro seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                controlCRUDLibros.EliminarLibro(libro.idLibro);
                MessageBox.Show("Libro eliminado correctamente");
                MostrarLibro();
            }
            else
            {
                MessageBox.Show("Operación cancelada");
            }
        }

        public void MostrarLibro()
        {
            dtgvLibros.AutoGenerateColumns = false;
            controlCRUDLibros.MostrarLibros();
            List<modeloLibro> vistaLibros = controlCRUDLibros.MostrarLibros();
            dtgvLibros.DataSource = vistaLibros;

        }

        public void MostrarGeneros()
        {
            controlCRUDLibros control = new controlCRUDLibros();
            cbGenero.DataSource = control.MostrarGeneros();
            cbGenero.DisplayMember = "tipoGenero";
            cbGenero.ValueMember = "idGenero";
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
            cbGenero.Text = libro.descripcionGenero.ToString();
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
            MostrarLibro();
        }


    }
}
