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
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public List<Cliente> ObtenerClientes()
        {
            var lista = new List<Cliente>();
            using (var conn = GetConnection())
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
