using Student_API.Data;
using Student_API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Student_API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IStudentContext _context;

        public StudentRepository(IStudentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context
                .Students
                .Find(p => true)
                .ToListAsync();
        }
        public async Task<Student> GetStudent(string id)
        {
            return await _context
                .Students
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<Student>> GetStudentByName(string name)
        {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(p => p.Name, name);

            return await _context
                            .Students
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentByYear(int year)
        {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(p =>p.Year, year);

            return await _context
                            .Students
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateStudent(Student student)
        {
            await _context.Students.InsertOneAsync(student);
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            var updateResult = await _context
                                        .Students
                                        .ReplaceOneAsync(filter: g => g.Id == student.Id, replacement: student);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteStudent(string id)
        {
            FilterDefinition<Student> filter = Builders<Student>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Students
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}