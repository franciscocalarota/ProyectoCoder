using ProyectoCoder.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder.DataBase
{
    public static class VentaData
    {
        public static List<Venta> ObtenerUsuarioPorId(int Id, List<Venta> ventas)
        {
            List<Venta> lista = new List<Venta>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT * FROM Venta Where Id = @Id";

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
                            string IdUsuario = dr.GetString(i: 1);
                            string Comentarios = dr.GetString(i: 2);


                            Venta ventas1 = new Venta(Id, IdUsuario, Comentarios);
                            



                        }
                        throw new Exception(message: "Id no encontrado");
                    }
                }

            }
        }

        public static List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT IdUsuario, Id, Comentarios FROM Venta;";

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
                                var ventas = new Venta();
                                ventas.Id = Convert.ToInt32(dr["Id"]);
                                ventas.Comentarios = Convert.ToString(dr["Comentarios"]);                            
                                ventas.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                lista.Add(ventas);
                            }
                        }
                    }
                }
                return lista;

            }
        }

        public static void CrearVenta(Venta ventas)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "INSERT INTO Venta (Id, IdUsuario, Comentarios) values (@Id ,@IdUsuario, @Comentarios); select @@IDENTITY as ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Money) { Value = ventas.Id });
                    command.Parameters.Add(new SqlParameter("Comentarios", System.Data.SqlDbType.VarChar) { Value = ventas.Comentarios });
                    command.Parameters.Add(new SqlParameter("IdUsuario", System.Data.SqlDbType.Int) { Value = ventas.IdUsuario });
                    
                    


                }
                connection.Close();

            }


        }
        public static void ModificarUsuario(Venta ventas)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "UPDATE Venta" +
                        "SET IdUsuario = @IdUsuario" +
                        ", Comentarios = @Comentarios" +               
                        "WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Money) { Value = ventas.Id });
                    command.Parameters.Add(new SqlParameter("Comentarios", System.Data.SqlDbType.VarChar) { Value = ventas.Comentarios });
                    command.Parameters.Add(new SqlParameter("IdUsuario", System.Data.SqlDbType.Int) { Value = ventas.IdUsuario });

                }
                connection.Close();
            }
        }

        public static void EliminarUsuario(Venta ventas)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "DELETE FROM Venta WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Money) { Value = ventas.Id });
                }
                connection.Close();
            }


        }
    }
}
