using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementations
{
   public class BaseService
    {
        private DBContext _dBContext;

        public BaseService(DBContext dBContext)
        {
            _dBContext = dBContext;
        }
    }
}
