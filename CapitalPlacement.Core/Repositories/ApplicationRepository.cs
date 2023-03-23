using CapitalPlacement.Core.Context;
using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapitalPlacement.Core.Repositories.ApplicationRepository;

namespace CapitalPlacement.Core.Repositories
{
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
        {
            private readonly ApplicationContext _dbContext;

            public ApplicationRepository(ApplicationContext dbContext) : base(dbContext)
            {
                _dbContext = dbContext;
            }
        }

}
