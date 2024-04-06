using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SEMANA04
{
    public partial class Conexion 
    {
        private string connectionString = "Data Source=LAB1504-11\\SQLEXPRESS;Initial Catalog=yerly;User Id=tecsup;Password=123456";

        public Conexion()
        {
            InitializeComponent();
        }


       private void DataReader_Click(object sender, RoutedEventArgs e)
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                // Cadena de conexión
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                // Comandos de TRANSACT SQL
                SqlCommand command = new SqlCommand("USP_ListarProductos", connection);

                // CONECTADA
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nombreProducto = reader.GetString(reader.GetOrdinal("NombreProducto"));
                    string cantidadPorUnidad = reader.GetString(reader.GetOrdinal("CantidadPorUnidad"));
                    double precioUnidad = reader.GetDouble(reader.GetOrdinal("PrecioUnidad"));
                    string categoriaProducto = reader.GetString(reader.GetOrdinal("CategoriaProducto"));

                    productos.Add(new Producto { nombreProducto = nombreProducto, cantidadPorUnidad = cantidadPorUnidad, precioUnidad = precioUnidad, categoriaProducto = categoriaProducto });
                }

                connection.Close();

                studentData.ItemsSource = productos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DataTable_Click(object sender, RoutedEventArgs e)
        {
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                // Cadena de conexión
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                // Comandos de TRANSACT SQL
                SqlCommand command = new SqlCommand("USP_ListarCategoria", connection);

                // CONECTADA
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idcategoria = reader.GetInt32(reader.GetOrdinal("Idcategoria"));
                    string nombrecategoria = reader.GetString(reader.GetOrdinal("Nombrecategoria"));
                    string descripcion = reader.GetString(reader.GetOrdinal("Descripcion"));
                    string Activo = reader.GetString(reader.GetOrdinal("Activo"));
                    string CodCategoria = reader.GetString(reader.GetOrdinal("CodCategoria"));


                    categorias.Add(new Categoria { idcategoria = idcategoria, nombrecategoria = nombrecategoria, descripcion = descripcion,Activo = Activo, CodCategoria = CodCategoria });
                }

                connection.Close();

                studentData.ItemsSource = categorias;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
