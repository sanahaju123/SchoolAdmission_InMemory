using SchoolAdmission.BusinessLayer.Interfaces;
using SchoolAdmission.BusinessLayer.Services.Repository;
using SchoolAdmission.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.BusinessLayer.Services
{
    public class ClassroomServices : IClassroomServices
    {
        private readonly IClassroomRepository _classroomRepository;

        public ClassroomServices(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task<Classroom> AddClassroom(Classroom classroom)
        {
            return await _classroomRepository.AddClassroom(classroom);
        }

        public async Task<Classroom> FindClassroomById(int classroomId)
        {
            return await _classroomRepository.FindClassroomById(classroomId);
        }

        public async Task<IEnumerable<Classroom>> GetClassroom()
        {
            return await _classroomRepository.GetClassroom();
        }
    }
}
