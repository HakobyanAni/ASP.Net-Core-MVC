using System;
using System.Collections.Generic;
using System.Text;
using Project.BLL.Interfaces;
using Project.DAL;

namespace Project.BLL.Implementation
{
    public class BaseService : IBaseService
    {
        protected ProjectDbContext _projectDbContext;
        public BaseService(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

    }
}
