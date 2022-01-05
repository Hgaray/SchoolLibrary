using SchoolLibrary.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchooolLibrary.Model
{
    public interface IStudent
    {
        Task<IEnumerable<SchoolLibrary.DTO.StudentDto>> GetStudents();

        Task<bool> saveStudent(SchoolLibrary.DTO.StudentDto student);

        Task<SchoolLibrary.DTO.StudentDto> GetStudent(int studentId);

        Task<bool> DeleteStudent(int studentId);
    }
}
