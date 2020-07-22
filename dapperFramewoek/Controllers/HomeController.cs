using DapperEx;
using dapperFramewoek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dapperFramewoek.Controllers
{
    public class HomeController : Controller
    {
        public string connectionName = "DB";
        public DbBase CreateDbBase()
        {
            return new DbBase(connectionName);
        }
        public ActionResult Index(int pageIndex = 1, string name = "")
        {
            List<Account> list = new List<Account>();
            using (var db = CreateDbBase())
            {
                var sql = SqlQuery<Account>.Builder(db).AndWhere(m => m.Age, OperationMethod.Less, 20)
                     .LeftInclude()
                     .AndWhere(m => m.Name, OperationMethod.Contains, name)
                     .RightInclude();
                long pageCount = 0;
                //sql语句：
                //SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY Id) rid, * FROM Account WHERE Age < @Age1 AND ( Name LIKE @Name1 ) ) p_paged WHERE rid>0 AND rid<=0
                list = db.Page<Account>(pageIndex, 10, out pageCount, sql).ToList();
                ViewBag.PageList = ComHelper.PageList(pageCount, 10, pageIndex, "/Home?pageIndex={P}&name=" + name);
                return View(list);
            } 

        }

        public ActionResult List()
        {

            using (var db = CreateDbBase())
            {
                int pageCount = 0;
                string sql = @"select a.*,b.ProductName from OrderInfo as a inner join Product as b on a.ProductID=b.ID ";
                var list = db.getList<OrderInfo>(sql, out pageCount);
                return View(list);

                
            }
        }

        #region 新增
        public ActionResult Create(int id = 0)
        {
            Account model = new Account();
            model.CreateTime = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Account model)
        {

            using (var db = CreateDbBase())
            {
                int  result = db.Insert<Account>(model);
                if (result>0)
                    return Content("添加成功");
                else
                    return Content("添加失败");
            }
        }
        #endregion


        #region 编辑
        public ActionResult Edit(int id = 0)
        {
            using (var db = CreateDbBase())
            {
                var sql = SqlQuery<Account>.Builder(db).AndWhere(m => m.Id, OperationMethod.Equal, id);
                var model = db.SingleOrDefault<Account>(sql);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Edit(Account model)
        {
            using (var db = CreateDbBase())
            {
                var result = db.Update<Account>(model);
                if (result)
                    return Content("编辑成功");
                else
                    return Content("编辑失败");
            }
        }
        #endregion


        #region 获取Details
        public ActionResult Details(int id = 0)
        {
            using (var db = CreateDbBase())
            {
                var model = db.SingleOrDefault<Account>(SqlQuery<Account>.Builder(db)
                 .AndWhere(m => m.Id, OperationMethod.Equal, id));
                //取到用户的订单信息集合
                var sql = SqlQuery<OrderInfo>.Builder(db).AndWhere(m => m.AccountID, OperationMethod.Equal, id);
                model.listorderinfo = db.Query<OrderInfo>(sql).ToList();
                return View(model);
            }
        }



        public ActionResult Get(int id = 0)
        {
            using (var db = CreateDbBase())
            {
                var model = db.Get<Account>(id);
                return View(model);
            }
        }
        #endregion


        #region 删除Delete
        public ActionResult Delete(int id = 0)
        {
            using (var db = CreateDbBase())
            {

                var result = db.Delete<Account>(id);
            }
            return Content("删除成功");
        }
        #endregion


        #region 批量删除DeleteList
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="listId">需要删除的数据ID</param>
        /// <returns></returns>
        public ActionResult DeleteList(string listId = "")
        {
            using (var db = CreateDbBase())
            {
                var d = SqlQuery<Account>.Builder(db)
                 .AndWhere(m => m.Id, OperationMethod.In, listId);
                var result = db.Delete<Account>(d);
            }
            return View();
        }
        #endregion


    

    }
}
