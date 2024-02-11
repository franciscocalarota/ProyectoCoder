using ProyectoCoder.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCoder.DataBase
{
    public class GestorDb
    {
        private string stringConnection;

        public GestorDb()
        {
            this.stringConnection = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        }

        public Usuario ObtenerUsuarioPorId(int Id) 
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Usuario where id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue(parameterName:"id", Id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader[name:"id"]);
                    string nombre = reader.GetString(i: 1);
                    string apellido = reader.GetString(i: 2);
                    string nombreUsuario = reader.GetString(i: 3);
                    string contrasena = reader.GetString(i: 4);
                    string mail = reader.GetString(i: 5);

                    Usuario usuario = new Usuario(Id, nombre, apellido, nombreUsuario, contrasena, mail);

                    return usuario; 
                }
                throw new Exception(message: "Id no encontrado");
            }

            
        }

        public bool AgregarUsuario(Usuario usuario) 
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection)) 
            {
                string query = "INSERT INTO Usuarios (Nombre, Apellido, NombreUsuario, Contraseña, Mail) values (@nombre,@apellido,@nombreUsuario,@contrasena,@mail); select @@IDENTITY as ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue(parameterName: "nombre", usuario.Nombre);
                command.Parameters.AddWithValue(parameterName: "apellido", usuario.Apellido);
                command.Parameters.AddWithValue(parameterName: "nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue(parameterName: "contraseña", usuario.Contrasena);
                command.Parameters.AddWithValue(parameterName: "mail", usuario.Mail);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool BorrarUnUsuarioPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE FROM Usuario WHERE id= @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue(parameterName: "id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarUsuarioPorId(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contraseña = @contrasena, Mail = @mail WHERE id = @id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue(parameterName: "id", id);
                command.Parameters.AddWithValue(parameterName: "nombre", usuario.Nombre);
                command.Parameters.AddWithValue(parameterName: "apellido", usuario.Apellido);
                command.Parameters.AddWithValue(parameterName: "nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue(parameterName: "contraseña", usuario.Contrasena);
                command.Parameters.AddWithValue(parameterName: "mail", usuario.Mail);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}

