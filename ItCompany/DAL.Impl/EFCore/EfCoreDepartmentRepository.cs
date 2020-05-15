using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public class EfCoreDepartmentRepository : EfCoreRepository<Department, ItCompanyContext>
    {
        public EfCoreDepartmentRepository(ItCompanyContext context) : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }

}
