using System;
using System.Collections.Generic;
using System.Text;
using Project.DAL;

namespace Project.BLL.Implementation
{
    public class BaseService : IBaseService, IDisposable
    {
        private ProjectDbContext _projectDbContext;

        public BaseService(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }


    }
}
