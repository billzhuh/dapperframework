using DapperEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IYRSystemService
{
    public interface IBaseService<T> where T : class,new()
    {


        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="pageCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="operation"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        List<T> getPage(int pageIndex, int PageSize, out long pageCount, Expression<Func<T, object>> whereLambda, OperationMethod operation, object value);



        /// <summary>
        /// 新增：返回新增实体的ID
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(T entity);
    
        /// <summary>
        /// 更新实体：返回bool
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);


        /// <summary>
        /// 删除指定实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);



        /// <summary>
        /// 获取指定实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetModel(int id);


    }
}
