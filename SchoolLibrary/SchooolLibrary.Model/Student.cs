namespace SchooolLibrary.Model
{
    using SchoolLibrary.DTO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Threading.Tasks;

    [Table("tbStudent")]
    public partial class Student : IStudent
    {
        public Student()
        {

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string Identification { get; set; }

        [StringLength(100)]
        public string Program { get; set; }

        public async Task<IEnumerable<SchoolLibrary.DTO.StudentDto>> GetStudents()
        {
            var response = new List<SchoolLibrary.DTO.StudentDto>();

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    response = await ctx.Student.Select(x =>
                   new SchoolLibrary.DTO.StudentDto()
                   {
                       Id = x.Id,
                       Name = x.Name,
                       LastName = x.LastName,
                       Identification = x.Identification,
                       Program = x.Program
                   }).ToListAsync();

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return response;
        }

        public async Task<SchoolLibrary.DTO.StudentDto> GetStudent(int studentId)
        {
            var response = new SchoolLibrary.DTO.StudentDto();

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    response = await ctx.Student.Where(x => x.Id == studentId).Select(x =>
                      new SchoolLibrary.DTO.StudentDto()
                      {
                          Id = x.Id,
                          Name = x.Name,
                          LastName = x.LastName,
                          Identification = x.Identification,
                          Program = x.Program
                      }).SingleOrDefaultAsync();

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return response;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            var response = false;

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    var studentDb = ctx.Student.Where(x => x.Id == studentId).FirstOrDefault();
                    ctx.Student.Remove(studentDb);
                    await ctx.SaveChangesAsync();
                    response = true;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return response;
        }



        public async Task<bool> saveStudent(SchoolLibrary.DTO.StudentDto student)
        {


            var response = false;

            try
            {
                using (var ctx = new SchoolLibraryDBContext())
                {
                    var studentDb =  ctx.Student.Where(x => x.Id == student.Id).FirstOrDefault();

                    if (studentDb != null)
                    {                        
                        studentDb.Name = student.Name;
                        studentDb.LastName = student.LastName;
                        studentDb.Identification = student.Identification;
                        studentDb.Program = student.Program;
                    }
                    else
                    {
                        ctx.Student.Add(new Student()
                        {
                            Identification = student.Identification,
                            LastName = student.LastName,
                            Name = student.Name,
                            Program = student.Program
                        });

                    }
                    
                    await ctx.SaveChangesAsync();
                }

                response = true;

            }
            catch (Exception)
            {

                throw;
            }
            return response;

        }


    }
}
