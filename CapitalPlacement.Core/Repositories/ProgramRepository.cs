using CapitalPlacement.Core.Context;
using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Repositories
{
    public class ProgramRepository : GenericRepository<Program>, IProgramRepository
    {
        private readonly ApplicationContext _dbContext;
        public ProgramRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
