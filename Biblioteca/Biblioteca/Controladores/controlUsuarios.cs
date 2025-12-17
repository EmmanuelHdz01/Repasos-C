using Biblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Controladores
{
    internal class controlUsuarios
    {
        public static bool RegistarUsuario(modelUsuarios add)
        {
            try
            {
                using (SqlConnection connection = Conn())
                {
                    connection.Open();
                    SqlCommand comando = new SqlCommand("INSERT INTO tblUsuarios(Usuario, Contrasena, TipoUsuario, LibrosPrestados, LibrosPendientes " +
                        "VALUES (@Usuario, @Contrasena, @TipoUsuario, @LibrosPrestados, @LibrosPendientes)", connection);

                    comando.Parameters.AddWithValue("@Usuario", add.usuario);
                    comando.Parameters.AddWithValue("@Contrasena", add.contrasena);
                    comando.Parameters.AddWithValue("@TipoUsuario", add.tipoUsuario);
                    comando.Parameters.AddWithValue("@LibrosPrestados", add.librosPrestados);
                    comando.Parameters.AddWithValue("@LibrosPendientes", add.librosPendientes);

                    comando.ExecuteNonQuery();
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Error al registrar el usuario: " + ex.Message);
                return false;
            }
            return true;
        }
        public static bool EliminarUsuario(modelUsuarios delete)
        {
            try
            {
                using (SqlConnection connection = Conn())
                {
                    connection.Open();
                    SqlCommand comando = new SqlCommand("DELETE FROM tblUsuarios WHERE idUsuario = @idUsuario", connection);

                    comando.Parameters.AddWithValue("@idUsuario", delete.idUsuario);

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el usuario: " + ex.Message);
                return false;
            }
            return true;
        }

        public static List<modelUsuarios> MostrarUsuarios()
        {
            try
            {
                using (SqlConnection connection = Conn())
                {
                    connection.Open();
                    SqlCommand comando = new SqlCommand("SELECT * FROM tblUsuarios", connection);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al mostrar los usuarios: " + ex.Message);
                return null;
            }
        }
        public static SqlConnection Conn ()
        {
            //SqlConnection conn = new SqlConnection("DATA SOURCE = WORK-TEAM\\SQLEXPRESS; DATABASE = Biblioteca; INTEGRATED SECURITY = True");
            SqlConnection conn = new SqlConnection("Data Source=.; DATABASE = Biblioteca; Integrated Security=True");
            return conn;
        }
    }
}
