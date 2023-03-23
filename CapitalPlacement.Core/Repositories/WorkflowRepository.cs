using CapitalPlacement.Core.Context;
using CapitalPlacement.Core.Models.Stages;
using CapitalPlacement.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Core.Repositories
{
    public class WorkflowRepository : GenericRepository<Stage>, IWorkflowRepository
    {
        private readonly ApplicationContext _dbContext;
        public WorkflowRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
