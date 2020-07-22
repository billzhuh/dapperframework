using IYRSystemDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRSystemDAL
{
    /// <summary>
    /// 数据层实例工厂
    /// </summary>
    public   partial  class DbSession : IDbSession
    {
        public    IAccountDAL getAccountDAL
        {
            get { return new AccountDAL() as IAccountDAL; }
        }

        public  IProductDAL getProductDAL
        {
            get { return new ProductDAL() as IProductDAL; }
        }


        public  IOrderInfoDAL getOrderInfoDAL
        {
            get { return new OrderInfoDAL() as IOrderInfoDAL; }
        }
    }
}
