using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder.models
{
    public class Usuario
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private long _contrasena;
        private string _mail;
        private string password;
        private string email;

        public Usuario(int id, string nombre, string apellido, string nombreUsuario) { }
        public Usuario(int id, string nombre, string apellido, string nombreUsuario, long contrasena, string mail)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._nombreUsuario = nombreUsuario;
            this._contrasena = contrasena;
            this._mail = mail;
        }

        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string password, string email) : this(id, nombre, apellido, nombreUsuario)
        {
            this.password = password;
            this.email = email;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string NombreUsuario { get { return _nombreUsuario; } set { _nombreUsuario = value; } }
        public long Contrasena { get { return _contrasena; } set { _contrasena = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }

        public override string ToString()
        {
            return $"nombre:{this._nombre}, apellido: {this._apellido}";
        }

    }

}
