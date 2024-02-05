using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProyectoCoder.Properties;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoCoder
{
    public partial class Form1 : Form
    {
        private string stringConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e, object IdProducto)
        {
            List<Producto> listaProductos = new List<Producto>();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=coderhouse;Trusted_Connection=True;";

            var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock from Producto;";


            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
                    var parametro = new SqlParameter();
                    parametro.ParameterName = "IdProducto";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = IdProducto;

                    command.Parameters.Add(parametro);

                    using (SqlDataReader dataReader = command.ExecuteReader()) 
                    {
                        
                        if (dataReader.HasRows) 
                        {
                            while (dataReader.Read()) 
                            {
                                var Producto = new Producto();
                                Producto.Id = Convert.ToInt32(dataReader["Id"]);
                                Producto.Descripcion = dataReader["Descripciones"].ToString();
                                Producto.Costo = Convert.ToDouble(dataReader["Costo"]);
                                Producto.PrecioVenta = Convert.ToDouble(dataReader["PrecioVenta"]);
                                Producto.Stock = Convert.ToInt32(dataReader["Stock"]);

                                listaProductos.Add(Producto);
                            }
                        }
                    }
                }
            } 
            dataGridView1.DataSource = listaProductos;
            dataGridView1.AutoGenerateColumns = true;
        }
        public Usuario ObtenerUsuarioPorId(int id) 
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection)) 
            {
                string query = "SELECT * FROM Usuario where id = 1";
                

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader= command.ExecuteReader();

                if (reader.Read()) 
                { 
                    int idObtenido = Convert.ToInt32(reader[name: "id"]);
                    string nombre = reader.GetString(i: 1);
                    string apellido = reader.GetString(i: 2);
                    string nombreUsuario = reader.GetString(i: 3);
                    string password = reader.GetString(i: 4);
                    string email = reader.GetString(i: 5);

                    Usuario usuario = new Usuario(id, nombre, apellido, nombreUsuario, password, email: email);
                    return usuario;
                }
                throw new Exception(message: "Id no encontrado");
            }
        }


        
    }
}
