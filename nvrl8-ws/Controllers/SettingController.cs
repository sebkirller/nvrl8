﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nvrl8_ws.Model;

namespace nvrl8_ws.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private static string ConnectionString =
            "Server=tcp:nvrl8.database.windows.net,1433;Initial CataLog=nvrl8;Persist Security Info=False;User ID=nvrl8admin;Password=p@$$W0RD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        // GET: api/Setting
        [HttpGet]
        public Settings GetAllSettings()
        {
            using (SqlConnection dbConnection = new SqlConnection(ConnectionString))
            {
                dbConnection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Settings", dbConnection))
                {
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Settings(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                        }
                    }
                }

                dbConnection.Close();

                return null;
            }
        }

        // GET: api/Setting/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Setting
        [HttpPost]
        public int AddSettings([FromBody] Settings set)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string SqlQuery = "INSERT INTO Settings(Origin, Destination, GoTime) VALUES (@Origin, @Destination, @GoTime)";
                using (SqlCommand cmd = new SqlCommand(SqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Origin", set.Origin);
                    cmd.Parameters.AddWithValue("@Destination", set.Destination);
                    cmd.Parameters.AddWithValue("@GoTime", set.GoTime);

                    int RowsAffected = cmd.ExecuteNonQuery();



                    return RowsAffected;

                }
            }
        }

        // PUT: api/Setting/5
        [HttpPut("{id}")]
        public int UpdateSettings(int id, [FromBody]Settings set)
        {

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string SqlQuery = "UPDATE Settings SET Origin=@Origin, Destination=@Destination, GoTime=@GoTime WHERE ID=@Id;";
                using (SqlCommand cmd = new SqlCommand(SqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Origin", set.Origin);
                    cmd.Parameters.AddWithValue("@Destination", set.Destination);
                    cmd.Parameters.AddWithValue("@GoTime", set.GoTime);

                    int RowsAffected = cmd.ExecuteNonQuery();



                    return RowsAffected;


                }
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
