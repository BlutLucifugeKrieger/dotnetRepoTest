using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using azure_test.Models;

namespace azure_test.Data
{
    public class azure_testContext : DbContext
    {
        public azure_testContext (DbContextOptions<azure_testContext> options)
            : base(options)
        {
        }

        public DbSet<azure_test.Models.operationsModel> operationsModel { get; set; } = default!;
    }
}
