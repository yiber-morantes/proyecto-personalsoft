﻿using Proyecto_de_Prueba.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_de_Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        public readonly string con;
        public CarrosController(IConfiguration configuration)
        {
            con = configuration.GetConnectionString("conexion");
        }
        [HttpGet]
        public IEnumerable<Carros> Get(int ciudadRecorrida, int ciudadDevolucion,string placaCarro = "",string modeloCarro ="")
        {
            List<Carros> carros = new();
            using (SqlConnection connection = new(con))
            {
                connection.Open();
                using (SqlCommand cmd = new("Listarcarros", connection))
                {
                    cmd.Parameters.AddWithValue("@placaCarro", placaCarro);
                    cmd.Parameters.AddWithValue("@modeloCarro", modeloCarro);
                    cmd.Parameters.AddWithValue("@ciudadRecogidaId", ciudadRecorrida);
                    cmd.Parameters.AddWithValue("@ciudadDevoluciónId", ciudadDevolucion);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Carros p = new Carros
                            {
                                IdCarro = Convert.ToInt32(reader["id"]),
                                PlacaCarro = reader["PlacaCarro"].ToString(),
                                ModeloCarro = reader["ModeloCarro"].ToString(),
                                CiudadRecogida = new Ciudad { IdCiudad = Convert.ToInt32(reader["CiudadRecogidaId"]) },
                                CiudadDevolucion = new Ciudad
                                {
                                    IdCiudad = Convert.ToInt32(reader["CiudadDevoluciónId"])
                                }

                            };
                            carros.Add(p);
                        }
                    }
                }
            }
            return carros;

        }


    }
}
