using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationApi.Models
{
    public class BrandContext :DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> options):
            base(options){ 
        

        }
        public DbSet<Employee> Brands { set; get; }
    }
}
