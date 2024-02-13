using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoCoder.models;


namespace ProyectoCoder.DataBase
{
    public static class ProductoVendidoData
    {
        public static List<ProductoVendido> ObtenerProductoVendido(int IdProducto)
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido WHERE Id=@IdProducto;";

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
                                var productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(dr["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);



                                lista.Add(productoVendido);
                            }
                        }
                    }
                }
                return lista;
            }
        }

        public static List<ProductoVendido> ListarProductosVendidos()
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            var query = "SELECT Id, Stock, IdProducto, IdVenta FROM ProductoVendido;";

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
                                var productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(dr["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dr["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dr["IdVenta"]);

                                lista.Add(productoVendido);
                            }
                        }
                    }
                }
                return lista;

            }
        }

        public static void CrearProductoVendido(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "INSERT INTO ProductoVendido (Id, IdProducto, Stock, IdVenta) values (@Id,@IdProducto,@Stock,@IdVenta); select @@IDENTITY as Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.VarChar) { Value = productoVendido.Stock });
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Money) { Value = productoVendido.Id });
                    command.Parameters.Add(new SqlParameter("IdVenta", System.Data.SqlDbType.Money) { Value = productoVendido.IdVenta });
                    command.Parameters.Add(new SqlParameter("IdProducto", System.Data.SqlDbType.Int) { Value = productoVendido.IdProducto });
                    

                }
                connection.Close();

            }


        }
        public static void ModificarProducto(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "UPDATE ProductoVendido" +
                        "SET IdVenta = @IdVenta" +
                        ", IdProducto = @IdProducto" +
                        ", Stock = @Stock" +                      
                        "WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.VarChar) { Value = productoVendido.Stock });
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Money) { Value = productoVendido.Id });
                    command.Parameters.Add(new SqlParameter("IdVenta", System.Data.SqlDbType.Money) { Value = productoVendido.IdVenta });
                    command.Parameters.Add(new SqlParameter("IdProducto", System.Data.SqlDbType.Int) { Value = productoVendido.IdProducto });

                }
                connection.Close();
            }
        }

        public static void EliminarProducto(ProductoVendido productoVendido)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            var query = "DELETE FROM ProductoVendido WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.Money) { Value = productoVendido.Id });
                }
                connection.Close();
            }

        }






    }
}
