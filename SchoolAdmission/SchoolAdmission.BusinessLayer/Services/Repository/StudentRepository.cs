using SchoolAdmission.DataLayer;
using SchoolAdmission.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmission.BusinessLayer.Services.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _schoolDbContext;
        public StudentRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public async Task<Person> FindPersonById(int personId)
        {
            try
            {
                return await _schoolDbContext.People.FindAsync(personId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> Login(string emailId, string password)
        {
            try
            {
               
                var result = await _schoolDbContext.People.FindAsync(emailId);
                if (result.Password == password)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Person> Register(Person person)
        {
            try
            {
                var result = await _schoolDbContext.People.AddAsync(person);
                await _schoolDbContext.SaveChangesAsync();
                return person;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
