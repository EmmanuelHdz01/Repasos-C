using Biblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class controlCRUDLibros
    {
        public static bool RegistrarLibro(modeloLibro libro)
        {
            try
            {
                using (SqlConnection connection = conn())
                {
                    connection.Open();
                    SqlCommand comando = new SqlCommand("INSERT INTO tblLibro " +
                        "(Titulo, Escritor, NumeroPaginas, Idioma, FechaPublicacion, idGenero, CantidadCopias) " +
                        "VALUES (@Titulo, @Escritor, @NumeroPaginas, @Idioma, @FechaPublicacion, @idGenero, @CantidadCopias)", connection);
                    comando.Parameters.AddWithValue("@Titulo", libro.titulo);
                    comando.Parameters.AddWithValue("@Escritor", libro.escritor);
                    comando.Parameters.AddWithValue("@NumeroPaginas", libro.numeroPaginas);
                    comando.Parameters.AddWithValue("@Idioma", libro.idioma);
                    comando.Parameters.AddWithValue("@FechaPublicacion", libro.fechaPublicacion);
                    comando.Parameters.AddWithValue("@idGenero", libro.idGenero);
                    comando.Parameters.AddWithValue("@CantidadCopias", libro.cantidadCopias);

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar el libro: " + ex.Message);
                return false;
            }
            return true;
        }

        public List<modeloGenero> MostrarGeneros ()
        {
            try
            {
                using (SqlConnection connection = conn())
                {
                    connection.Open();
                    SqlCommand comando = new SqlCommand ("SELECT * FROM tblGenero", connection);
                    List<modeloGenero> modeloGeneros = new List<modeloGenero>();

                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        modeloGenero genero = new modeloGenero();
                        genero.idGenero = (int)reader["idGenero"];
                        genero.tipoGenero = reader["TipoGenero"].ToString();
                        modeloGeneros.Add(genero);
                    }
                    return modeloGeneros;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al mostrar los géneros: " + ex.Message);
                return null;
            }
        }

        public static List<modeloLibro> MostrarLibros()
        {
            try
            {
                using (SqlConnection connection = conn())
                {
                    connection.Open();
                    SqlCommand consulta = new SqlCommand("SELECT * FROM tblLibro", connection);

                    List<modeloLibro> libros = new List<modeloLibro>();

                    SqlDataReader reader = consulta.ExecuteReader();
                    while (reader.Read())
                    {
                        modeloLibro datos = new modeloLibro();
                        datos.idLibro = (int)reader["idLibro"];
                        datos.titulo = reader["Titulo"].ToString();
                        datos.escritor = reader["Escritor"].ToString();
                        datos.numeroPaginas = (int)reader["NumeroPaginas"];
                        datos.idioma = reader["Idioma"].ToString();
                        datos.fechaPublicacion = (DateTime)reader["FechaPublicacion"];
                        datos.idGenero = (int)reader["idGenero"];
                        datos.cantidadCopias = (int)reader["CantidadCopias"];

                        libros.Add(datos);
                    }
                    return libros;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al mostrar los libros: " + ex.Message);
                return null;
            }

        }

        public static SqlConnection conn()
        {
            SqlConnection conn = new SqlConnection("DATA SOURCE = WORK-TEAM\\SQLEXPRESS; DATABASE = Biblioteca; INTEGRATED SECURITY = True");
            //SqlConnection conn = new SqlConnection("Data Source=.; DATABASE = Biblioteca; Integrated Security=True");
            return conn;
        }
    }
}
