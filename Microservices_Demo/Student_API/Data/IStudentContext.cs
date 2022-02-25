using Student_API.Entities;
using MongoDB.Driver;

namespace Student_API.Data
{
    public interface IStudentContext
    {
        IMongoCollection<Student> Students { get; }
    }
}
