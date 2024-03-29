﻿using Microsoft.AspNetCore.Mvc;
using Proyecto_de_Prueba.Models;
using Microsoft.Data.SqlClient;

namespace Proyecto_de_Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        public readonly string con;
        public CiudadController(IConfiguration configuration)
        {
            con = configuration.GetConnectionString("conexion");
        }
        [HttpGet]
        public IEnumerable<Ciudad> Get(string nombreCiudad)
        {
            List<Ciudad> ciudad = new();

            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("ListarCiudades", connection))
                {
                    cmd.Parameters.AddWithValue("@nombreCiudad", nombreCiudad);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Ciudad p = new Ciudad
                            {
                                NombreCiudad = reader["nombreCiudad"].ToString(),
                            };
                            ciudad.Add(p);
                        }
                    }
                }
                return ciudad;
            }
        }
    }
}
