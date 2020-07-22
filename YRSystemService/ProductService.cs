using dapperFramewoek.Models;
using IYRSystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRSystemService
{
    public partial class ProductService : BaseService<Product>, IProductService
    {
        /// <summary>
        /// 重写基类的SetCurrentDAL()方法，为基类的CurrentDAL指定当前访问的数据层实体
        /// </summary>
        public override void SetCurrentDAL()
        {
            //throw new NotImplementedException();
            
            this.CurrentDAL = DbSession.getProductDAL;
        }
    }
}
