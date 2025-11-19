using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace ClientesApp
{
    /// <summary>
    /// La base de datos esta agregada en app.config en connectionString
    /// </summary>
    public class Cliente
    {
        public int ID { get; set; } // Primary key
        public string Nombre { get; set; } // Not null
        public string Apellido { get; set; } // Not null
        public string Email { get; set; } // Null
    }
    public class RepositorioCliente
    {
        private readonly string _connectionString;
        public RepositorioCliente()
        {
            _connectionString = ConfigurationManager
                                                    .ConnectionStrings["ConexionClientes"]
                                                    .ConnectionString;
            // Aca se declara que conexion va a tener el ConfigurationManager, en este caso va a ser "ConexionClientes"
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString); // GetConnection SIEMPRE va a dar como resultado la base de datos
                                                         // Esto es util para no tener que reescribir siempre lo mismo y solo
                                                         // LLamar a esta funcion
        }
        public List<Cliente> ObtenerClientes()
        {
            var lista = new List<Cliente>();
            using (var conn = GetConnection()) // Aca se puede observar como conn toma la connectionstring de la funcion
                                               // Simplificando el codigo para que sea mas legible
            {
                conn.Open();
                string query = "SELECT Id, Nombre, Apellido, Email FROM Clientes";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var c = new Cliente
                        {
                            ID = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Email = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };
                        lista.Add(c);
                        // No se usa conn.Close()  (O sea cerrar la base de datos) porque USING ya lo cierra de por si
                    }
                }
            }
            return lista;
        }
        public void InsertarCliente (Cliente c)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Clientes (Nombre, Apellido, Email) VALUES (@Nombre, @Apellido, @Email)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@Email", (object)c.Email ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Modificar(Cliente c)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Clientes
                                                SET Nombre = @Nombre,
                                                    Apellido = @Apellido,
                                                    Email = @Email
                                            WHERE Id = @Id;";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@Email", (object)c.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id", c.ID);

                    cmd.ExecuteNonQuery();
                }
                
            }
        }
        public void Eliminar(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Clientes WHERE Id = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
