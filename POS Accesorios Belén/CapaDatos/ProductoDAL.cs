using POS_Accesorios_Belén.CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Accesorios_Belén.CapaDatos
{
    public class ProductoDAL
    {
     
        
            public static void Insertar(Producto p)
            {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Productos (Nombre, Categoria, Marca, Modelo, Stock, Precio, IdProveedor) " +
                        "VALUES (@n, @c, @m, @mo, @s, @p, @pro)", cn);

                    cmd.Parameters.AddWithValue("@n", p.Nombre);
                    cmd.Parameters.AddWithValue("@c", p.Categoria);
                    cmd.Parameters.AddWithValue("@m", p.Marca);
                    cmd.Parameters.AddWithValue("@mo", p.Modelo);
                    cmd.Parameters.AddWithValue("@s", p.Stock);
                    cmd.Parameters.AddWithValue("@p", p.Precio);
                    cmd.Parameters.AddWithValue("@pro", p.IdProveedor);

                    cmd.ExecuteNonQuery();
                }
            }

            public static List<Producto> Listar()
            {
                List<Producto> lista = new List<Producto>();

            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Productos", cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new Producto()
                        {
                            IdProducto = dr.GetInt32(0),
                            Nombre = dr.GetString(1),
                            Categoria = dr.GetString(2),
                            Marca = dr.GetString(3),
                            Modelo = dr.GetString(4),
                            Stock = dr.GetInt32(5),
                            Precio = dr.GetDecimal(6),
                            IdProveedor = dr.GetInt32(7)
                        });
                    }
                }
                return lista;
            }

            public static void Actualizar(Producto p)
            {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Productos SET Nombre=@n, Categoria=@c, Marca=@m, Modelo=@mo, Stock=@s, Precio=@p, IdProveedor=@pro " +
                        "WHERE IdProducto=@id", cn);

                    cmd.Parameters.AddWithValue("@id", p.IdProducto);
                    cmd.Parameters.AddWithValue("@n", p.Nombre);
                    cmd.Parameters.AddWithValue("@c", p.Categoria);
                    cmd.Parameters.AddWithValue("@m", p.Marca);
                    cmd.Parameters.AddWithValue("@mo", p.Modelo);
                    cmd.Parameters.AddWithValue("@s", p.Stock);
                    cmd.Parameters.AddWithValue("@p", p.Precio);
                    cmd.Parameters.AddWithValue("@pro", p.IdProveedor);

                    cmd.ExecuteNonQuery();
                }
            }

            public static void Eliminar(int id)
            {
            using (SqlConnection cn = new SqlConnection(Conexion.Cadena))
            {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Productos WHERE IdProducto=@id", cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        
    }
}
