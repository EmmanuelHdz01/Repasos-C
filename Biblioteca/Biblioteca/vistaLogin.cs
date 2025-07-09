using Biblioteca.Controladores;//Pendiente para revisar 
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

namespace Biblioteca
{
    public partial class vistaLogin : Form
    {
        public vistaLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            modelUsuarios data = new modelUsuarios
            {
                usuario = txtUsuario.Text,
                contrasena = txtContrasena.Text
            };

            if (controlLogin.ValidarUsuarios (data))
            {
                Hide();
                MessageBox.Show("Bienvenido " + data.usuario, "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vistaPrincipal principal = new vistaPrincipal();
                principal.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Clear();
                txtContrasena.Clear();
                txtUsuario.Focus();
            }
        }
    }
}
