using Student_API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student_API.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(string id);

        Task<IEnumerable<Student>> GetStudentByName(string name);
        Task<IEnumerable<Student>> GetStudentByYear(int year);

        Task CreateStudent(Student student);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(string id);
    }
}