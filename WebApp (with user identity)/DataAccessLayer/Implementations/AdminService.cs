using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Implementations
{
    public class AdminService : BaseService, IAdminService
    {
        public AdminService(DBContext context):base(context)
        {
        }
    }
}
