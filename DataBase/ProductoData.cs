using ProyectoCoder.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder.DataBase
{
    public static class ProductoData
    {


        public static List<Producto> ObtenerProducto(int IdProducto)
        {
            List<Producto> lista = new List<Producto>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Descripcion, Costo, PrecioVenta, Stock, IdUsuario FROM Producto WHERE Id=@IdProducto;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdProducto";
                    parametro.SqlDbType = System.Data.SqlDbType.Int;
                    parametro.Value = IdProducto;

                    command.Parameters.Add(parametro);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(dr["Id"]);
                                producto.Descripcion = dr["Descripcion"].ToString();
                                producto.Costo = Convert.ToDouble(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                lista.Add(producto);
                            }
                        }
                    }
                }
                return lista;
            }
        }

        public static List<Producto> ListarProductos() 
        {
            List<Producto> lista = new List<Producto>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Descripcion, Costo, PrecioVenta, Stock, IdUsuario FROM Producto;";

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
                                var producto = new Producto();
                                producto.Id = Convert.ToInt32(dr["Id"]);
                                producto.Descripcion = dr["Descripcion"].ToString();
                                producto.Costo = Convert.ToDouble(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                lista.Add(producto);
                            }
                        }
                    }
                }
                return lista;

            } 
        }

        public static void CrearProducto(Producto producto)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "INSERT INTO Usuarios (Nombre, Apellido, NombreUsuario, Contraseña, Mail) values (@nombre,@apellido,@nombreUsuario,@contrasena,@mail); select @@IDENTITY as ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar) { Value = producto.Descripcion });
                    command.Parameters.Add(new SqlParameter("Costo", System.Data.SqlDbType.Money) { Value = producto.Costo });
                    command.Parameters.Add(new SqlParameter("PrecioVenta", System.Data.SqlDbType.Money) { Value = producto.PrecioVenta });
                    command.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.Int) { Value = producto.Stock });
                    command.Parameters.Add(new SqlParameter("IdUsuario", System.Data.SqlDbType.VarChar) { Value = producto.IdUsuario });

                }
                connection.Close();

            }
              
        
        }
        public static void ModificarProducto(Producto producto)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "UPDATE Producto" +
                        "SET Descripcion = @Descripcion" +
                        ", Costo = @Costo" +
                        ", PrecioVenta = @PrecioVenta" +
                        ", Stock = @Stock" +
                        ", IdUsuario = @IdUsuario" +
                        "WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.Add(new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar) { Value = producto.Descripcion });
                    command.Parameters.Add(new SqlParameter("Costo", System.Data.SqlDbType.Money) { Value = producto.Costo });
                    command.Parameters.Add(new SqlParameter("PrecioVenta", System.Data.SqlDbType.Money) { Value = producto.PrecioVenta });
                    command.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.Int) { Value = producto.Stock });
                    command.Parameters.Add(new SqlParameter("IdUsuario", System.Data.SqlDbType.VarChar) { Value = producto.IdUsuario });

                }
                connection.Close();
            }
        }
        
        public static void EliminarProducto(Producto producto)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "DELETE FROM Producto WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = producto.Id });
                }
                connection.Close();
            }

        }
    }
}
