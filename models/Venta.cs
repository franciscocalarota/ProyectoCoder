using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder.models
{
    public class Venta
    {
        private int _id;
        private string _comentarios;
        private int _idUsuario;
        private int idObtenido;
        private object value;

        public Venta()
        { }

        public Venta(int idObtenido)
        {
            this.idObtenido = idObtenido;
        }

        public Venta(int idObtenido, object value) : this(idObtenido)
        {
            this.value = value;
        }

        public Venta(int idObtenido, object value, string comentarios) : this(idObtenido, value)
        {
        }

        public Venta(int id, string comentarios, int idUsuario, object comentarios1)
        {
            this._id = id;
            this._comentarios = comentarios;
            this._idUsuario = idUsuario;
        }

        public int Id { get { return _id; } set { _id = value; } }

        public string Comentarios { get { return _comentarios; } set { _comentarios = value; } }

        public int IdUsuario { get { return _idUsuario; } set { _idUsuario = value; } }
    }
}
