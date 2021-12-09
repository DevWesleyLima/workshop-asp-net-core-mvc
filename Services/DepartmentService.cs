using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models;
using SalesWebMvc.Data;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext Context;

        public DepartmentService(SalesWebMvcContext context)
        {
            Context = context;
        }

        public List<Department> FindAll()
        {
            return Context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
