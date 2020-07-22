using dapperFramewoek.Models;
using IYRSystemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRSystemService
{
    public class AccountService:BaseService<Account>,IAccountService
    {
        public override void SetCurrentDAL()
        {
            this.CurrentDAL = DbSession.getAccountDAL;
        }


      
    }
}
