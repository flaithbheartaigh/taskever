using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Taskever.Infrastructure.EntityFramework.Data.Repositories.NHibernate;

namespace Taskever.Infrastructure.EntityFramework.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly TaskeverDbContext _context;

        public InitialDataBuilder(TaskeverDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            new DefaultUserBuilder(_context).Build();
        }
    }
}
