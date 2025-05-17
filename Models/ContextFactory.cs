using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
        public class ContextFactory : IDesignTimeDbContextFactory<Context>
        {
            public Context CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<Context>();

                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("Server=REEM-ASHRAF;Database=TestShop;Integrated Security=True;TrustServerCertificate=True;");

                return new Context(optionsBuilder.Options);
            }
        }
    }

