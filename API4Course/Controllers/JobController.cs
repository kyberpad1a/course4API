using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using API4Course.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace API4Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public JobController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Job;";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Weaponry");
            NpgsqlDataReader myreader ;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myreader = myCommand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Job job)
        {
            string query = @"insert into Job(Job_Name, Job_Payment) values (@Job_Name, @Job_Payment);";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Weaponry");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    
                    myCommand.Parameters.AddWithValue("@Job_Name", job.Job_Name);
                    myCommand.Parameters.AddWithValue("@Job_Payment", job.Job_Payment);
                    
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");

        }


        [HttpPut]
        public JsonResult Put(Job job)
        {
            string query = @"update Job set Job_Name=@Job_Name where ID_Job=@ID_Job
";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Weaponry");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_Job", job.ID_Job);
                    myCommand.Parameters.AddWithValue("@Job_Name", job.Job_Name);
                    myCommand.Parameters.AddWithValue("@Job_Payment", job.Job_Payment);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");

        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from Job where ID_Job=@ID_Job";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Weaponry");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID_Post", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Delete Successfully");

        }

    }
}
