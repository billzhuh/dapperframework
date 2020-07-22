using Dapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dapperFramewoek.Models
{
    public class Account
    {
        [Id(true)]
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual int Age { get; set; }
        public virtual int Flag { get; set; }
        [Ignore]
        public virtual string AgeStr
        {
            get
            {
                return "年龄：" + Age;
            }
        }

        [Ignore]
        public virtual List<OrderInfo> listorderinfo { get; set; }

        //若是1:N的关系则定义成泛型
    }
}