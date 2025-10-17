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
        public static bool RegistarUsuario()
        {
            SqlConnection connection = Conn();
            connection.Open();
            SqlCommand comando = new SqlCommand("INSERT INTO tblUsuarios (Usuario,Contrasena,TipoUsuario,LibrosPrestados,LibrosPendientes)" +
                "VALUES(<Usuario, varchar(50),>,<Contrasena, varchar(50),>,<TipoUsuario, int,>,<LibrosPrestados, int,>,<LibrosPendientes, int,>)");
            return true;
        }
        public static SqlConnection Conn ()
        {
            //SqlConnection conn = new SqlConnection("DATA SOURCE = WORK-TEAM\\SQLEXPRESS; DATABASE = Biblioteca; INTEGRATED SECURITY = True");
            SqlConnection conn = new SqlConnection("Data Source=.; DATABASE = Biblioteca; Integrated Security=True");
            return conn;
        }
    }
}
