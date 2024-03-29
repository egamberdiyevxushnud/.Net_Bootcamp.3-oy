﻿using _45_Wep_api_Dapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace _45_Wep_api_Dapper.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExperimentsController : ControllerBase
    {
        const string connectionstring = "Server=127.0.0.1;Port=5432;Database=MongoDb;username=postgres;Password=xushnud;";

        [HttpGet]

        public List<Experemts> Get()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionstring))
            {
                string query = $"Select * from darslar;";
                connection.Open();

                var experemeties = connection.Query<Experemts>(query);

                return experemeties.ToList();


            }
        }

        [HttpPost]
        public string CreateData(ExperementDto model)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionstring))
            {
                string query = "Insert Into darslar(mavzu, student_count) values(@mavzu, @student_count)";
                connection.Execute(query, new ExperementDto
                {
                    mavzu = model.mavzu,
                    student_count = model.student_count
                });

                return "Malumot qoshild";





            }

        }

        [HttpPatch]
        public int UpdatePatch(int id, string mavzu)
        {
            string query = $"update darslar set mavzu = @mavzu where id = @id";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionstring))
            {
                var x = connection.Execute(query, new { mavzu = mavzu, id = id });

                return x;
            }
        }
        [HttpDelete]
        public int DeleteData(int id)
        {
            string query = $"Delete From darslar where id = @id";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionstring))
            {
                var x = connection.Execute(query, new { id = id });

                return x;
            }

        }
    }
}
