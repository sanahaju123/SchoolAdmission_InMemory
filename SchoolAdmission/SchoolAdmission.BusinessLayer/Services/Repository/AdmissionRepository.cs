using SchoolAdmission.DataLayer;
using SchoolAdmission.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.BusinessLayer.Services.Repository
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly SchoolDbContext _schoolDbContext;
        public AdmissionRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public async Task<Admission> AddAdmission(Admission admission)
        {
            try
            {
                var result = await _schoolDbContext.Admissions.AddAsync(admission);
                await _schoolDbContext.SaveChangesAsync();
                return admission;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Admission> FindAdmissionById(int AdmissionId)
        {
            try
            {
                return await _schoolDbContext.Admissions.FindAsync(AdmissionId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Admission>> GetAdmission()
        {
            try
            {
                var result = _schoolDbContext.Admissions.OrderByDescending(x => x.AdmissionId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
