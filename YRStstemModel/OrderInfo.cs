using Dapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dapperFramewoek.Models
{
    public class OrderInfo
    {
        [Id(true)]
        public virtual int Id { get; set; }

        public virtual string OrderNum { get; set; }

        public virtual string OrderDes { get; set; }

        public virtual int AccountID { get; set; }

        public virtual int ProductID { get; set; }
       // [Ignore]
       // public virtual Account account { get; set; }


       
        /// <summary>
        /// 产品名称--虚属性
        /// </summary>
       [Ignore]
        public virtual string  productname { get; set; }
    }
}