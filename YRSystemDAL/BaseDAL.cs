using DapperEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YRSystemDAL
{
    /// <summary>
    /// 数据层基类：封装基本的crud操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDAL<T> where T : class ,new()
    {
        public string connectionName = "DB";


        /// <summary>
        /// 上下文基类构造函数
        /// </summary>
        /// <returns></returns>
        public DbBase CreateDbBase()
        {
            return new DbBase(connectionName);
        }

        /// <summary>
        /// 列表
        /// </summary>
        public virtual List<T> getPage(int pageIndex, int PageSize, out long pageCount,
            Expression<Func<T, object>> whereLambda, OperationMethod operation,
            object value = null)
        {
            using (var db = CreateDbBase())
            {
                SqlQuery sql;
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    sql = SqlQuery<T>.Builder(db);
                }
                else
                {
                    sql = SqlQuery<T>.Builder(db).AndWhere(whereLambda, operation, value);
                }
                List<T> list = db.Page<T>(pageIndex, 10, out pageCount, sql).ToList();
                return list;
            }
        }


        /// <summary>
        /// 新增：返回新增实体的ID
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(T entity)
        {
            using (var db = CreateDbBase())
            {
                int isAdd = db.Insert<T>(entity);
                return isAdd;
            }
        }


        /// <summary>
        ///  更新实体：返回bool
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            using (var db = CreateDbBase())
            {
                bool isUpdate = db.Update<T>(entity);
                return isUpdate;
            }
        }


        /// <summary>
        /// 获取指定实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetModel(int id)
        {
            using (var db = CreateDbBase())
            {
                return db.Get<T>(id);
            }
        }



        /// <summary>
        ///  删除指定实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using (var db = CreateDbBase())
            {
                return db.Delete<T>(id);
            }
        }

    }
}
