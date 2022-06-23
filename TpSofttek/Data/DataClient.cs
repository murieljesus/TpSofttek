using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TpSofttek.Models;

namespace TpSofttek.Data
{
    public class DataClient
    {
        public List<ModelClient> modelClients()
        {
            var listClient = new List<ModelClient>();
            var connect = new Connection();
            var connection = new SqlConnection(@"Data Source=LAPTOP-JTBI104U;Initial Catalog=BD1;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("List", connection);
            command.CommandType = CommandType.StoredProcedure;
            using (var _command = command.ExecuteReader())
            {
                while (_command.Read()) listClient.Add(new ModelClient()
                {
                    Id = Convert.ToInt32(_command["id"]),
                    nombre = _command["nombre"].ToString(),
                    direccion = _command["direccion"].ToString(),
                    poblacion = _command["poblacion"].ToString(),
                    telefono = _command["telefono"].ToString()
                });
                {

                }

            }
            return listClient;
        }
        public ModelClient GetClient(int id)
        {
            var listClient = new ModelClient();
            var connect = new Connection();
            var connection = new SqlConnection(@"Data Source=LAPTOP-JTBI104U;Initial Catalog=BD1;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Get1", connection);
            command.Parameters.AddWithValue("IdCliente", id);
            command.CommandType = CommandType.StoredProcedure;
            var _command = command.ExecuteReader();
            
                while (_command.Read())
                {
                    listClient.Id = Convert.ToInt32(_command["id"]);
                    listClient.nombre = _command["nombre"].ToString();
                    listClient.direccion = _command["direccion"].ToString();
                    listClient.poblacion = _command["poblacion"].ToString();
                    listClient.telefono = _command["telefono"].ToString();
                }
            

            return listClient;
        }
        public bool SaveClient(ModelClient modelClient)
        {
            var connect = new Connection();
            var connection = new SqlConnection(@"Data Source=LAPTOP-JTBI104U;Initial Catalog=BD1;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Save1", connection);
            command.Parameters.AddWithValue("nombre", modelClient.nombre);
            command.Parameters.AddWithValue("direccion", modelClient.direccion);

            command.Parameters.AddWithValue("poblacion", modelClient.poblacion);
            command.Parameters.AddWithValue("telefono", modelClient.telefono);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return true;
        }
        public bool EditClient(ModelClient modelClient)
        {
            var connect = new Connection();
            var connection = new SqlConnection(@"Data Source=LAPTOP-JTBI104U;Initial Catalog=BD1;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Edit", connection);
            command.Parameters.AddWithValue("Id", modelClient.Id);
            command.Parameters.AddWithValue("nombre", modelClient.nombre);
            command.Parameters.AddWithValue("direccion", modelClient.direccion);
            command.Parameters.AddWithValue("poblacion", modelClient.poblacion);
            command.Parameters.AddWithValue("telefono", modelClient.telefono);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return true;

        }
        public bool DeleteClient(int id)
        {
            var connect = new Connection();
            var connection = new SqlConnection(@"Data Source=LAPTOP-JTBI104U;Initial Catalog=BD1;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Delete1", connection);
            command.Parameters.AddWithValue("Id",id);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return true;

        }
    }
}
