using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_API.Data;
using Student_API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Student_API.Data
{
    public class StudentContext : IStudentContext
    {
        public StudentContext()
        {

        }

        public StudentContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Students = database.GetCollection<Student>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            StudentContextSeed.SeedData(Students);

        }

        public IMongoCollection<Student> Students { get; }
    }
}