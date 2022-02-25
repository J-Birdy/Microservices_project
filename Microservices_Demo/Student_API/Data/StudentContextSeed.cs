using Student_API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_API.Data
{
    public class StudentContextSeed
    {
        public static void SeedData(IMongoCollection<Student> StudentCollection)
        {
            bool existStudent = StudentCollection.Find(p => true).Any();
            if (!existStudent)
            {
                StudentCollection.InsertManyAsync(GetPreconfiguredStudents());
            }
        }

        private static IEnumerable<Student> GetPreconfiguredStudents()
        {
            return new List<Student>()
            {
                new Student()
                {
                    Id = "3",
                    Name = "Student3",
                    Year = 2,
                    Grade = "C"
                },
                new Student()
                {
                    Id = "sldkfjsal",
                    Name = "Student4",
                    Year = 1,
                    Grade = "C"
                },
                new Student()
                {
                    Id = "asdfasdfe",
                    Name = "Student5",
                    Year = 2,
                    Grade = "B"
                },
                new Student()
                {
                    Id = "daefasdf33",
                    Name = "Student6",
                    Year = 1,
                    Grade = "F"
                },
                new Student()
                {
                    Id = "314dfasdfs",
                    Name = "Student7",
                    Year = 2,
                    Grade = "A"
                },
                new Student()
                {
                    Id = "33fsdgadgadva",
                    Name = "Student8",
                    Year = 1,
                    Grade = "A"
                }
            };
        }
    }
}
