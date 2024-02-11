using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProyectoCoder.Properties;
using ProyectoCoder.DataBase;
using ProyectoCoder.models;

namespace ProyectoCoder
{
    internal static class Program
    { 
        static void Main(string[] args)
        {    
            GestorDb db = new GestorDb();
            try
            {
                Usuario usuarioObtenido = db.ObtenerUsuarioPorId(Id: 2);
                Console.WriteLine(usuarioObtenido.ToString());

                Usuario usuarioNuevo = new Usuario(id: 6, nombre: "pedro", apellido: "perez", nombreUsuario: "pperez",
                    password: "12345", email: "pp@mail.com");
                if (db.AgregarUsuario(usuarioNuevo))
                {
                    Console.WriteLine(value: "Usuario Agregado");
                }
                
                if (db.BorrarUnUsuarioPorId(id:6))
                {
                    Console.WriteLine(value: "Usuario Eliminado");
                }
                
                Usuario usuarioAActualizar = new Usuario(id: 7, nombre: "juan", apellido: "sanchez", nombreUsuario: "jsanchez",
                    password: "123456", email: "js@mail.com");
                if (db.ActualizarUsuarioPorId(id:7, usuarioAActualizar)) 
                {
                    Console.WriteLine(value: "Actualice un Usuario");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
