using DapperEx;
using IYRSystemDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YRSystemDAL;


namespace YRSystemService
{
    /// <summary>
    /// 逻辑层抽象基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> where T : class,new()
    {
        /// <summary>
        /// 基类构造函数
        /// </summary>
        public BaseService()
        {
            SetCurrentDAL();
        }

        /// <summary>
        /// 当前数据层实例
        /// </summary>
        public IBaseDAL<T> CurrentDAL { get; set; }

        /// <summary>
        /// 抽象方法：要求子类必须实现
        /// </summary>
        public abstract void SetCurrentDAL();

        /// <summary>
        /// 通过实例访问工厂属性
        /// </summary>
        public IDbSession DbSession = new DbSession();

        /// <summary>
        /// 列表
        /// </summary>
        public List<T> getPage(int pageIndex, int pageSize, out long pageCount, 
            Expression<Func<T, object>> whereLambda, OperationMethod operation, object value)
        {
            return CurrentDAL.getPage(pageIndex, pageSize, out pageCount,whereLambda,operation,value);
        }
               
        /// <summary>
        /// 新增：返回新增实体的ID
        /// </summary>
        public int Add(T entity)
        {
            return CurrentDAL.Add(entity);
        }
                
        /// <summary>
        /// 更新实体：返回bool
        /// </summary>
        public bool Update(T entity)
        {
            return CurrentDAL.Update(entity);
        }

        /// <summary>
        /// 删除指定实体
        /// </summary>
        public T GetModel(int id)
        {
            return CurrentDAL.GetModel(id);
        }

        /// <summary>
        ///  获取指定实体
        /// </summary>
        public bool Delete(int id)
        {
            return CurrentDAL.Delete(id);
        }
    }
}
