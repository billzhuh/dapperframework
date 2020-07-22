using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ColumnAttribute : BaseAttribute
    {
        /// <summary>
        /// 自增长
        /// </summary>
        public bool AutoIncrement { get; set; }
        public ColumnAttribute()
        {
            AutoIncrement = false;
        }
        /// <summary>
        /// 是否是自增长
        /// </summary>
        /// <param name="autoIncrement"></param>
        public ColumnAttribute(bool autoIncrement)
        {
            AutoIncrement = autoIncrement;
        }
    }
}
