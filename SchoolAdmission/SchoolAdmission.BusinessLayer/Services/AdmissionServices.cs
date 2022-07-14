using SchoolAdmission.BusinessLayer.Interfaces;
using SchoolAdmission.BusinessLayer.Services.Repository;
using SchoolAdmission.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.BusinessLayer.Services
{
    public class AdmissionServices : IAdmissionServices
    {
        private readonly IAdmissionRepository _admissionRepository;

        public AdmissionServices(IAdmissionRepository admissionRepository)
        {
            _admissionRepository = admissionRepository;
        }

        public async Task<Admission> AddAdmission(Admission admission)
        {
            return await _admissionRepository.AddAdmission(admission);
        }

        public async Task<Admission> FindAdmissionById(int AdmissionId)
        {
            return await _admissionRepository.FindAdmissionById(AdmissionId);
        }

        public async Task<IEnumerable<Admission>> GetAdmission()
        {
            return await _admissionRepository.GetAdmission();
        }
    }
}
