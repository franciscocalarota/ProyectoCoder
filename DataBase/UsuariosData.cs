using ProyectoCoder.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder.DataBase
{
    public static class UsuariosData
    {
        public static List<Usuario> ObtenerUsuarioPorId(int Id, List<Usuario> usuario)
        {
            List<Usuario> lista = new List<Usuario>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT * FROM Usuario where id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "Id";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = Id;

                    command.Parameters.Add(parametro);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int idObtenido = Convert.ToInt32(dr[name: "id"]);
                            string nombre = dr.GetString(i: 1);
                            string apellido = dr.GetString(i: 2);
                            string nombreUsuario = dr.GetString(i: 3);
                            string contrasena = dr.GetString(i: 4);
                            string mail = dr.GetString(i: 5);

                            Usuario usuarios = new Usuario(Id, nombre, apellido, nombreUsuario, contrasena, mail);

                            
                            
                        }
                        throw new Exception(message: "Id no encontrado");
                    }
                }
                
            }
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Nombre, Apellido, Id, NombreUsuario, Contraseña, Mail FROM Usuario;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var usuarios = new Usuario();
                                usuarios.Id = Convert.ToInt32(dr["Id"]);
                                usuarios.Nombre = Convert.ToString(dr["Nombre"]);
                                usuarios.Apellido = Convert.ToString(dr["Apellido"]);
                                usuarios.NombreUsuario = Convert.ToString(dr["NombreUsuario"]);
                                usuarios.Contrasena = Convert.ToInt32(dr["Contraseña"]);
                                usuarios.Mail = Convert.ToString(dr["Mail"]);

                                lista.Add(usuarios);
                            }
                        }
                    }
                }
                return lista;

            }
        }

        public static void CrearUsuario(Usuario usuarios)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "INSERT INTO Usuarios (Nombre, Apellido, NombreUsuario, Contraseña, Mail) values (@nombre,@apellido,@nombreUsuario,@contrasena,@mail); select @@IDENTITY as ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Nombre", System.Data.SqlDbType.VarChar) { Value = usuarios.Nombre });
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Money) { Value = usuarios.Id });
                    command.Parameters.Add(new SqlParameter("Apellido", System.Data.SqlDbType.Money) { Value = usuarios.Apellido });
                    command.Parameters.Add(new SqlParameter("NombreUsuario", System.Data.SqlDbType.Int) { Value = usuarios.NombreUsuario });
                    command.Parameters.Add(new SqlParameter("Contraseña", System.Data.SqlDbType.Money) { Value = usuarios.Contrasena });
                    command.Parameters.Add(new SqlParameter("Mail", System.Data.SqlDbType.Money) { Value = usuarios.Mail });


                }
                connection.Close();

            }


        }
        public static void ModificarUsuario(Usuario usuarios)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "UPDATE Usuario" +
                        "SET Nombre = @Nombre" +
                        ", Apellido = @Apellido" +
                        ", NombreUsuario = @NombreUsuario" +
                        ",Contraseña = @Contraseña"+
                        ", Mail = @Mail"+
                        "WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Nombre", System.Data.SqlDbType.VarChar) { Value = usuarios.Nombre });
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Money) { Value = usuarios.Id });
                    command.Parameters.Add(new SqlParameter("Apellido", System.Data.SqlDbType.Money) { Value = usuarios.Apellido });
                    command.Parameters.Add(new SqlParameter("NombreUsuario", System.Data.SqlDbType.Int) { Value = usuarios.NombreUsuario });
                    command.Parameters.Add(new SqlParameter("Contraseña", System.Data.SqlDbType.Money) { Value = usuarios.Contrasena });
                    command.Parameters.Add(new SqlParameter("Mail", System.Data.SqlDbType.Money) { Value = usuarios.Mail });

                }
                connection.Close();
            }
        }

        public static void EliminarUsuario(Usuario usuarios)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "DELETE FROM Usuario WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Money) { Value = usuarios.Id });
                }
                connection.Close();
            }

        }



    }
}
