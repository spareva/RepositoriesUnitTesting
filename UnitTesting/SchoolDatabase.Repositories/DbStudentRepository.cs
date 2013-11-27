using StudentsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StudentsDatabase.Repositories
{
    public class DbStudentRepository : AbstractRepository<Student>
    {
        public DbStudentRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public virtual IEnumerable<Student> GetStudentsWithMarkGreaterThan(string subject, double value)
        {
            var found = (from st in base.entitySet
                         from m in st.Marks
                         where m.Value >= value
                         where m.Subject == subject
                         select st).ToList();

            return found;
        }

        public override Student Update(int id, Student entity)
        {
            var found = base.entitySet.Find(id);
            if (found != null)
            {
                found.FirstName = entity.FirstName;
                found.LastName = entity.LastName;
                found.Age = entity.Age;
                found.Grade = entity.Grade;
                found.Marks = entity.Marks;
                found.SchoolId = entity.SchoolId;

                base.dbContext.SaveChanges();
            }

            return found;
        }
    }
}