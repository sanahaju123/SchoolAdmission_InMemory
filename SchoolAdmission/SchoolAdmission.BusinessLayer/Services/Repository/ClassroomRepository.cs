using SchoolAdmission.DataLayer;
using SchoolAdmission.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.BusinessLayer.Services.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly SchoolDbContext _schoolDbContext;
        public ClassroomRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public async Task<Classroom> AddClassroom(Classroom classroom)
        {
            try
            {
                var result = await _schoolDbContext.Classrooms.AddAsync(classroom);
                await _schoolDbContext.SaveChangesAsync();
                return classroom;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Classroom> FindClassroomById(int classroomId)
        {
            try
            {
                return await _schoolDbContext.Classrooms.FindAsync(classroomId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Classroom>> GetClassroom()
        {
            try
            {
                var result = _schoolDbContext.Classrooms.Where
                (x => x.Availability=="yes").Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
