using StudentInformationSystem.Data;
using StudentInformationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace StudentInformationSystem.Interfaces
{
    public class StudentRepository : EfRepository<StudentMaster,DatabaseContext>
    {
        DatabaseContext dbcontext;
        public StudentRepository(DatabaseContext context) : base(context) {
            dbcontext = context;
        }

        public async Task<IEnumerable<StudentMaster>> SearchByName(string name)
        {
            return await dbcontext.StudentMaster.Include(a=>a.Files).Where(a => a.StudentName.Contains(name)).OrderBy(a => a.StudentName).ToListAsync();

        }
        public  async Task<IEnumerable<StudentMaster>> GetAll()
        {
            return await dbcontext.StudentMaster.Include(a => a.Files).OrderBy(a => a.StudentName).ToListAsync();

        }
    }
}
