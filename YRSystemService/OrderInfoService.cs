using dapperFramewoek.Models;
using IYRSystemDAL;
using IYRSystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRSystemDAL;


namespace YRSystemService
{
    public partial class OrderInfoService : BaseService<OrderInfo>, IOrderInfoService
    {
       
        
        public override void SetCurrentDAL()
        {
            this.CurrentDAL = DbSession.getOrderInfoDAL;
        }
    }
}
