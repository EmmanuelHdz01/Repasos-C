using Biblioteca.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Controladores
{
    internal class controlLogin
    {
        public static bool ValidarUsuarios(modelUsuarios usuariosBD)
        {
            try
            {
                using (SqlConnection coneccion = conn())
                {
                    coneccion.Open();

                    SqlCommand comando = new SqlCommand("SELECT COUNT(*) FROM tblUsuarios WHERE Usuario = @usuario AND Contrasena = @contrasena", coneccion);
                    comando.Parameters.AddWithValue("@usuario", usuariosBD.usuario);
                    comando.Parameters.AddWithValue("@contrasena", usuariosBD.contrasena);

                    int cont = (int)comando.ExecuteScalar();
                    return cont > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al validar usuarios: " + ex.Message);
                return false;
            }
        }

        public static SqlConnection conn()
        {
            SqlConnection cmd = new SqlConnection("Data Source=WORK-TEAM\\SQLEXPRESS; DATABASE = Biblioteca; Integrated Security=True");
            //SqlConnection cmd = new SqlConnection("Data Source=.; DATABASE = Biblioteca; Integrated Security=True");
            return cmd;
        }
    }
}
