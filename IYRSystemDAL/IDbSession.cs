using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IYRSystemDAL
{
    public partial interface IDbSession
    {

        IAccountDAL getAccountDAL { get; }

        IProductDAL getProductDAL { get; }

        IOrderInfoDAL getOrderInfoDAL { get; }
    }
}
